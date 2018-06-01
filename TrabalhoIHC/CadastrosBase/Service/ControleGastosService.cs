using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHC.CadastrosBase.Forms.Indicadores;
using TrabalhoIHC.CadastrosBase.Model;

namespace TrabalhoIHC.Service
{
    public class ControleGastosService
    {
        private enum Method { Create, Edit, Delete };

        public static List<ControleGastos> List()
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "ControleGastoss.txt";
            string path = basePath + FileName;
            string[] obj;

            List<ControleGastos> ControleGastoss = new List<ControleGastos>();

            try
            {

                using (StreamReader sr = new StreamReader(path))
                {
                    linha = sr.ReadLine();

                    while (linha != null)
                    {
                        obj = linha.Split('|').ToArray();
                        ControleGastos ControleGastos = new ControleGastos();
                        ControleGastos.Id = int.Parse(obj[0]);
                        ControleGastos.ValorDiario = double.Parse(obj[1]);
                        ControleGastos.ValorMensal = double.Parse(obj[2]);
                        ControleGastos.ValorTrimestral = double.Parse(obj[3]);
                        ControleGastos.ValorSemestral = double.Parse(obj[4]);
                        ControleGastos.ValorAnual = double.Parse(obj[5]);

                        ControleGastoss.Add(ControleGastos);
                        linha = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ControleGastoss;
        }

        public static List<string> Create(string ValorDiario, string ValorMensal, string ValorTrimestral, string ValorSemestral, string ValorAnual)
        {
            List<string> Erros = new List<string>();

            ControleGastos ControleGastos = new ControleGastos();
            ControleGastos.ValorDiario = ConvertDouble(ValorDiario);
            ControleGastos.ValorMensal = ConvertDouble(ValorMensal);
            ControleGastos.ValorTrimestral = ConvertDouble(ValorTrimestral);
            ControleGastos.ValorSemestral = ConvertDouble(ValorSemestral);
            ControleGastos.ValorAnual = ConvertDouble(ValorAnual);

            GravarDados(Method.Create, ref Erros, ControleGastos);

            return Erros;
        }
        public static List<string> Edit(string ValorDiario, string ValorMensal, string ValorTrimestral, string ValorSemestral, string ValorAnual)
        {
            List<string> Erros = new List<string>();

            ControleGastos ControleGastos = new ControleGastos();
            ControleGastos.ValorDiario = ConvertDouble(ValorDiario);
            ControleGastos.ValorMensal = ConvertDouble(ValorMensal);
            ControleGastos.ValorTrimestral = ConvertDouble(ValorTrimestral);
            ControleGastos.ValorSemestral = ConvertDouble(ValorSemestral);
            ControleGastos.ValorAnual = ConvertDouble(ValorAnual);

            GravarDados(Method.Edit, ref Erros, ControleGastos);

            return Erros;
        }

        public static List<string> Delete(ControleGastos ControleGastos)
        {
            List<string> Erros = new List<string>();

            GravarDados(Method.Delete, ref Erros, ControleGastos);

            return Erros;
        }

        public static ControleGastos findControleGastos(int idControleGastos)
        {
            List<ControleGastos> ControleGastoss = List();
            ControleGastos ControleGastos = ControleGastoss.Where(m => m.Id == idControleGastos).FirstOrDefault();

            return ControleGastos;
        }



        private static void GravarDados(Method Method, ref List<string> Erros, ControleGastos ControleGastos)
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "ControleGastoss.txt";
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
                        lastId = lastId == 0 ? 1 : lastId + 1;//Pega o ultimo Id da ControleGastos do arquivo gravado
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(lastId.ToString() + "|" + ControleGastos.ValorDiario + "|" + ControleGastos.ValorMensal.ToString("0.00") + "|" + ControleGastos.ValorTrimestral.ToString("0.00") + "|" + ControleGastos.ValorSemestral.ToString("0.00") + "|" + ControleGastos.ValorAnual.ToString("0.00"));
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(lastId.ToString() + "|" + ControleGastos.ValorDiario + "|" + ControleGastos.ValorMensal.ToString("0.00") + "|" + ControleGastos.ValorTrimestral.ToString("0.00") + "|" + ControleGastos.ValorSemestral.ToString("0.00") + "|" + ControleGastos.ValorAnual.ToString("0.00"));
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
                            Erros.Add("Falha ao criar o diretório, entre em ControleGastosto com o desenvolvedor para mais detalhes.");
                        }

                        using (StreamReader sr = new StreamReader(tempPath))
                        {
                            linha = sr.ReadLine();
                            while (linha != null)
                            {
                                string[] vetObj = linha.Split('|').ToArray();
                                if (vetObj[0].Trim() == ControleGastos.Id.ToString())
                                {
                                    vetObj[1] = ControleGastos.ValorDiario.ToString("0.00");
                                    vetObj[2] = ControleGastos.ValorMensal.ToString("0.00");
                                    vetObj[3] = ControleGastos.ValorTrimestral.ToString("0.00");
                                    vetObj[4] = ControleGastos.ValorSemestral.ToString("0.00");
                                    vetObj[5] = ControleGastos.ValorAnual.ToString("0.00");
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
                                sw.WriteLine(lastId.ToString() + "|" + ControleGastos.ValorDiario + "|" + ControleGastos.ValorMensal.ToString("0.00") + "|" + ControleGastos.ValorTrimestral.ToString("0.00") + "|" + ControleGastos.ValorSemestral.ToString("0.00") + "|" + ControleGastos.ValorAnual.ToString("0.00"));
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
                        Erros.Add("O arquivo de contexto não existe no diretório. Entre em ControleGastosto com o suporte para solucionar o problema.");
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
                            Erros.Add("Falha ao criar o diretório, entre em ControleGastosto com o desenvolvedor para mais detalhes.");
                        }

                        using (StreamReader sr = new StreamReader(tempPath))
                        {
                            linha = sr.ReadLine();
                            while (linha != null)
                            {
                                string[] vetObj = linha.Split('|').ToArray();
                                if (vetObj[0].Trim() == ControleGastos.Id.ToString())
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
                                sw.WriteLine(lastId.ToString() + "|" + ControleGastos.ValorDiario + "|" + ControleGastos.ValorMensal.ToString("0.00") + "|" + ControleGastos.ValorTrimestral.ToString("0.00") + "|" + ControleGastos.ValorSemestral.ToString("0.00") + "|" + ControleGastos.ValorAnual.ToString("0.00"));
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
                        Erros.Add("O arquivo de contexto não existe no diretório. Entre em ControleGastosto com o suporte para solucionar o problema.");
                    }

                    break;
            }
        }

        private static double ConvertDouble(string Value) =>
            (object)Value is double ? double.Parse(Value) : 0.0;

    }
}
