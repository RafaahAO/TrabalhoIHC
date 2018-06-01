using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHC.Model;

namespace TrabalhoIHC.Service
{
    public class CategoriaDespesaService
    {
        private enum Method { Create, Edit, Delete };

        public static List<CategoriaDespesa> List()
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "CategoriaDespesas.txt";
            string path = basePath + FileName;
            string[] obj;

            List<CategoriaDespesa> categorias = new List<CategoriaDespesa>();

            try
            {

                using (StreamReader sr = new StreamReader(path))
                {
                    linha = sr.ReadLine();

                    while (linha != null)
                    {
                        obj = linha.Split('|').ToArray();
                        CategoriaDespesa conta = new CategoriaDespesa();
                        conta.Id = int.Parse(obj[0]);
                        conta.Descricao = obj[1];

                        categorias.Add(conta);
                        linha = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return categorias;
        }

        public static List<string> Create(string Descricao)
        {
            List<string> Erros = new List<string>();

            CategoriaDespesa categoria = new CategoriaDespesa();
            categoria.Descricao = Descricao;

            GravarDados(Method.Create, ref Erros, categoria);

            return Erros;
        }

        public static List<string> Edit(int Id, string Descricao)
        {
            List<string> Erros = new List<string>();

            CategoriaDespesa categoria = new CategoriaDespesa();
            categoria.Descricao = Descricao;
            categoria.Id = Id;

            GravarDados(Method.Edit, ref Erros, categoria);

            return Erros;
        }

        public static List<string> Delete(CategoriaDespesa categoria)
        {
            List<string> Erros = new List<string>();

            GravarDados(Method.Delete, ref Erros, categoria);

            return Erros;
        }

        public static CategoriaDespesa findCategoria(int idCategoria)
        {
            List<CategoriaDespesa> categorias = List();
            CategoriaDespesa categoria = categorias.Where(m => m.Id == idCategoria).FirstOrDefault();

            return categoria;
        }

        private static void GravarDados(Method Method, ref List<string> Erros, CategoriaDespesa categoria)
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "CategoriaDespesas.txt";
            string path = basePath + FileName;
            string tempBasePath = basePath + "TempContext";
            string tempPath = basePath + "TempContext\\" + FileName;
            Dictionary<int, string[]> matSave = new Dictionary<int, string[]>();

            switch (Method)
            {
                case Method.Create:

                    if (File.Exists(path))
                    {

                        using (StreamReader sr = new StreamReader(path))
                        {
                            linha = sr.ReadLine();//Ler a primeira linha.

                            while (linha != null)
                            {
                                lastId = int.Parse(linha.Split('|')[0]);
                                linha = sr.ReadLine();//Ler a proxima linha.
                            }
                        }
                        lastId = lastId == 0 ? 1 : lastId + 1;//Pega o ultimo Id da conta do arquivo gravado
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(lastId.ToString() + "|" + categoria.Descricao);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("1|" + categoria.Descricao);
                        }
                    }


                    break;
                case Method.Edit:

                    if (File.Exists(path))
                    {
                        try
                        {

                            if (!Directory.Exists(tempBasePath))
                            {
                                Directory.CreateDirectory(tempBasePath);
                            }
                            File.Move(path, tempPath);
                        }
                        catch (Exception ex)
                        {
                            Erros.Add("Falha ao criar o diretório, entre em contato com o desenvolvedor para mais detalhes.");
                        }

                        using (StreamReader sr = new StreamReader(tempPath))
                        {
                            linha = sr.ReadLine();
                            while (linha != null)
                            {
                                string[] vetObj = linha.Split('|').ToArray();
                                if (vetObj[0].Trim() == categoria.Id.ToString())
                                {
                                    vetObj[1] = categoria.Descricao;
                                }

                                matSave.Add(int.Parse(vetObj[0]), vetObj);
                                linha = sr.ReadLine();

                            }

                        }

                        matSave = matSave.OrderBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);

                        using (StreamWriter sw = File.CreateText(path))
                        {
                            foreach (var item in matSave.Values)
                            {
                                sw.WriteLine(item[0] + "|" + item[1]);
                            }

                        }

                        try
                        {
                            File.Delete(tempPath);
                        }
                        catch (Exception ex)
                        {
                            Erros.Add("Falha ao deletar o arquivo temporário.");
                        }

                    }
                    else
                    {
                        Erros.Add("O arquivo de contexto não existe no diretório. Entre em contato com o suporte para solucionar o problema.");
                    }

                    break;
                case Method.Delete:
                    if (File.Exists(path))
                    {
                        try
                        {

                            if (!Directory.Exists(tempBasePath))
                            {
                                Directory.CreateDirectory(tempBasePath);
                            }
                            File.Move(path, tempPath);
                        }
                        catch (Exception ex)
                        {
                            Erros.Add("Falha ao criar o diretório, entre em contato com o desenvolvedor para mais detalhes.");
                        }

                        using (StreamReader sr = new StreamReader(tempPath))
                        {
                            linha = sr.ReadLine();
                            while (linha != null)
                            {
                                string[] vetObj = linha.Split('|').ToArray();
                                if (vetObj[0].Trim() == categoria.Id.ToString())
                                {
                                    linha = sr.ReadLine();
                                    continue;
                                }
                                else
                                {
                                    matSave.Add(int.Parse(vetObj[0]), vetObj);
                                }

                                linha = sr.ReadLine();

                            }

                        }

                        matSave = matSave.OrderBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);

                        using (StreamWriter sw = File.CreateText(path))
                        {
                            foreach (var item in matSave.Values)
                            {
                                sw.WriteLine(item[0] + "|" + item[1]);
                            }

                        }

                        try
                        {
                            File.Delete(tempPath);
                        }
                        catch (Exception ex)
                        {
                            Erros.Add("Falha ao deletar o arquivo temporário.");
                        }

                    }
                    else
                    {
                        Erros.Add("O arquivo de contexto não existe no diretório. Entre em contato com o suporte para solucionar o problema.");
                    }

                    break;
            }
        }
    }
}
