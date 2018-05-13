using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHC.CadastrosBase.Model;

namespace TrabalhoIHC.CadastrosBase.Service
{
    public class FinancaService
    {
        public enum Method { Create, Edit, Delete };

        public static void setValorConta(Financa financa, Method method)
        {
            if (financa.Pago || method == Method.Edit) 
            {

                Conta conta = ContaService.findConta(financa.ContaId);
                if (method == Method.Create || (method == Method.Edit && financa.Pago)) 
                {
                    conta.Valor = financa.Receita ? conta.Valor + financa.Valor : conta.Valor - financa.Valor;
                }
                else
                {
                    conta.Valor = financa.Receita ? conta.Valor - financa.Valor : conta.Valor + financa.Valor;
                }

                ContaService.Edit(conta.Id, conta.Descricao, conta.Valor.ToString("0.00"));
            }
        }

        public static List<Financa> List()
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "Financas.txt";
            string path = basePath + FileName;
            string[] obj;

            List<Financa> Financas = new List<Financa>();

            try
            {

                using (StreamReader sr = new StreamReader(path))
                {
                    linha = sr.ReadLine();

                    while (linha != null)
                    {
                        obj = linha.Split('|').ToArray();
                        Financa Financa = new Financa();
                        Financa.Id = int.Parse(obj[0]);
                        Financa.Descricao = obj[1];
                        Financa.Valor = double.Parse(obj[2]);
                        Financa.AnoMesReferencia = obj[3];
                        Financa.CategoriaId = int.Parse(obj[4]);
                        Financa.ContaId = int.Parse(obj[5]);
                        Financa.Pago = bool.Parse(obj[6]);
                        Financa.Receita = bool.Parse(obj[7]);
                        Financa.Vencimento = DateTime.Parse(obj[8]);


                        Financas.Add(Financa);
                        linha = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return Financas;
        }

        public static List<string> Create(string Descricao, string Valor, Conta Conta, bool Pago, string AnoMesReferencia, DateTime Vencimento, bool Receita, CategoriaDespesa CatDespesa = null, CategoriaReceita CatReceita = null)
        {
            List<string> Erros = new List<string>();
            double ValorValido;
            var vetAnoMes = AnoMesReferencia.Split('-');
            int valido;

            if (!double.TryParse(Valor, out ValorValido))
            {
                Erros.Add("Valor Inválido. Digite um numero decimal para preencher o valor.");
                return Erros;
            }
            else if (vetAnoMes.Length != 2 || vetAnoMes[1].Length != 4 || !int.TryParse(vetAnoMes[1], out valido) || vetAnoMes[0].Length != 2 || !int.TryParse(vetAnoMes[0], out valido))
            {
                Erros.Add("Valor Inválido. Digite a referência no formato MM-AAAA para preencher o valor.");
                return Erros;
            }

            Financa Financa = new Financa();
            Financa.Descricao = Descricao;
            Financa.Valor = ValorValido;
            Financa.ContaId = Conta.Id;
            Financa.Pago = Pago;
            Financa.AnoMesReferencia = AnoMesReferencia;
            Financa.Vencimento = Vencimento;
            Financa.Receita = Receita;
            Financa.CategoriaId = CatDespesa == null ? CatReceita.Id : CatDespesa.Id;

            GravarDados(Method.Create, ref Erros, Financa);

            return Erros;
        }
        public static List<string> Edit(int Id, string Descricao, string Valor,int contaId, bool Pago, string AnoMesReferencia, DateTime Vencimento, bool Receita, int CategoriaId)
        {
            List<string> Erros = new List<string>();
            double ValorValido;

            if (!double.TryParse(Valor, out ValorValido))
            {
                Erros.Add("Valor Inválido. Digite um numero decimal para preencher o valor.");
                return Erros;
            }

            Financa Financa = new Financa();
            Financa.Id = Id;
            Financa.Descricao = Descricao;
            Financa.Valor = ValorValido;
            Financa.ContaId = contaId;
            Financa.Pago = Pago;
            Financa.AnoMesReferencia = AnoMesReferencia;
            Financa.Vencimento = Vencimento;
            Financa.Receita = Receita;
            Financa.CategoriaId = CategoriaId;

            GravarDados(Method.Edit, ref Erros, Financa);

            return Erros;
        }

        public static List<string> Delete(Financa Financa)
        {
            List<string> Erros = new List<string>();

            GravarDados(Method.Delete, ref Erros, Financa);

            return Erros;
        }

        public static Financa findFinanca(int idFinanca)
        {
            List<Financa> Financas = List();
            Financa Financa = Financas.Where(m => m.Id == idFinanca).FirstOrDefault();

            return Financa;
        }



        private static void GravarDados(Method Method, ref List<string> Erros, Financa Financa)
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "Financas.txt";
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
                        lastId = lastId == 0 ? 1 : lastId + 1;//Pega o ultimo Id da Financa do arquivo gravado
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine($"{lastId.ToString()}|{Financa.Descricao}|{Financa.Valor.ToString("0.00")}|{Financa.AnoMesReferencia}|{Financa.CategoriaId}|{Financa.ContaId}|{Financa.Pago.ToString()}|{Financa.Receita}|{Financa.Vencimento.ToString("dd/MM/yyyy")}");
                            setValorConta(Financa, Method.Create);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine($"1|{Financa.Descricao}|{Financa.Valor.ToString("0.00")}|{Financa.AnoMesReferencia}|{Financa.CategoriaId}|{Financa.ContaId}|{Financa.Pago.ToString()}|{Financa.Receita}|{Financa.Vencimento.ToString("dd/MM/yyyy")}");
                            setValorConta(Financa, Method.Create);

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
                                if (vetObj[0].Trim() == Financa.Id.ToString())
                                {
                                    vetObj[6] = Financa.Pago.ToString();
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
                                sw.WriteLine($"{item[0].ToString()}|{item[1]}|{item[2]}|{item[3]}|{item[4]}|{item[5]}|{item[6]}|{item[7]}|{item[8]}");
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
                            Erros.Add("Falha ao criar o diretório, entre em Financato com o desenvolvedor para mais detalhes.");
                        }

                        using (StreamReader sr = new StreamReader(tempPath))
                        {
                            linha = sr.ReadLine();
                            while (linha != null)
                            {
                                string[] vetObj = linha.Split('|').ToArray();
                                if (vetObj[0].Trim() == Financa.Id.ToString())
                                {
                                    setValorConta(Financa, Method.Delete);
                                }
                                else
                                {
                                    matSave.Add(int.Parse(vetObj[0]), vetObj);
                                }

                                linha = sr.ReadLine();

                            }

                        }

                        matSave = matSave.OrderBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);
                        int count = 1;
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            foreach (var item in matSave.Values)
                            {
                                sw.WriteLine($"{count}|{item[1]}|{item[2]}|{item[3]}|{item[4]}|{item[5]}|{item[6]}|{item[7]}|{item[8]}");
                                count++;
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
                        Erros.Add("O arquivo de contexto não existe no diretório. Entre em Financato com o suporte para solucionar o problema.");
                    }

                    break;
            }
        }
    }
}
