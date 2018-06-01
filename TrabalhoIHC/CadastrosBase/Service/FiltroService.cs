using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHC.Model;

namespace TrabalhoIHC.Service
{
    public class FiltroService
    {
        private enum Method { Create, Edit, Delete };

        public static List<Filtro> List()
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "Filtros.txt";
            string path = basePath + FileName;
            string[] vetObj;
            List<Filtro> ftrs = new List<Filtro>();
            Filtro filtro = null;

            try
            {

                using (StreamReader sr = new StreamReader(path))
                {
                    linha = sr.ReadLine();

                    while (linha != null)
                    {
                        vetObj = linha.Split('|').ToArray();

                        filtro = new Filtro();
                        filtro.Id = vetObj[0];
                        filtro.Pago = bool.Parse(vetObj[1]);
                        filtro.Descricao = vetObj[2];
                        filtro.ReferenciaIni = vetObj[3];
                        filtro.ReferenciaFim = vetObj[4];
                        filtro.Tipo = vetObj[5];
                        filtro.ContaId = int.Parse(vetObj[6]);
                        filtro.CategoriaDespesaId = int.Parse(vetObj[7]);
                        filtro.CategoriaReceitaId = int.Parse(vetObj[8]);
                        filtro.VencimentoIni = DateTime.Parse(vetObj[9]);
                        filtro.VencimentoFim = DateTime.Parse(vetObj[10]);
                        filtro.Receita = bool.Parse(vetObj[11]);

                        filtro.ftrCatDespesa = bool.Parse(vetObj[12]);
                        filtro.ftrCatReceita = bool.Parse(vetObj[13]);
                        filtro.ftrConta = bool.Parse(vetObj[14]);
                        filtro.ftrDescricao = bool.Parse(vetObj[15]);
                        filtro.ftrPago = bool.Parse(vetObj[16]);
                        filtro.ftrReferencias = bool.Parse(vetObj[17]);
                        filtro.ftrTipo = bool.Parse(vetObj[18]);
                        filtro.ftrVencimento = bool.Parse(vetObj[19]);

                        ftrs.Add(filtro);
                        linha = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ftrs;
        }

        public static List<string> Create(string Descricao)
        {
            List<string> Erros = new List<string>();

            Filtro filtro = new Filtro();
            filtro.Descricao = Descricao;

            GravarDados(Method.Create, ref Erros, filtro);

            return Erros;
        }


        public static List<string> Delete(Filtro filtro)
        {
            List<string> Erros = new List<string>();

            GravarDados(Method.Delete, ref Erros, filtro);

            return Erros;
        }

        public static Filtro findfiltro(string idfiltro)
        {
            List<Filtro> filtros = List();
            Filtro filtro = filtros.Where(m => m.Id.ToUpper() == idfiltro.ToUpper()).FirstOrDefault();

            return filtro;
        }

        private static void GravarDados(Method Method, ref List<string> Erros, Filtro filtro)
        {
            string linha = "";
            int lastId = 0;
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = "Filtros.txt";
            string path = basePath + FileName;
            string tempBasePath = basePath + "TempContext";
            string tempPath = basePath + "TempContext\\" + FileName;
            Dictionary<string, string[]> matSave = new Dictionary<string, string[]>();

            switch (Method)
            {
                case Method.Create:

                    if (File.Exists(path))
                    {

                        using (StreamReader sr = new StreamReader(path))
                        {
                            linha = sr.ReadLine();//Ler a primeira linha.

                        }
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine($"{filtro.Id}|{filtro.Pago}|{filtro.Descricao}|{filtro.ReferenciaIni}|{filtro.ReferenciaFim}|{filtro.Tipo}|{filtro.ContaId}|{filtro.CategoriaDespesaId}|{filtro.CategoriaDespesaId}|{filtro.VencimentoIni.ToString("dd/MM/yyyy")}|{filtro.VencimentoIni.ToString("dd/MM/yyyy")}|{filtro.Receita.ToString()}|{filtro.ftrCatDespesa}|{filtro.ftrCatReceita}|{filtro.ftrConta}|{filtro.ftrDescricao}|{filtro.ftrPago}|{filtro.ftrReferencias}|{filtro.ftrTipo}|{filtro.ftrVencimento}");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine($"{filtro.Id}|{filtro.Pago}|{filtro.Descricao}|{filtro.ReferenciaIni}|{filtro.ReferenciaFim}|{filtro.Tipo}|{filtro.ContaId}|{filtro.CategoriaDespesaId}|{filtro.CategoriaDespesaId}|{filtro.VencimentoIni.ToString("dd/MM/yyyy")}|{filtro.VencimentoIni.ToString("dd/MM/yyyy")}|{filtro.Receita.ToString()}|{filtro.ftrCatDespesa}|{filtro.ftrCatReceita}|{filtro.ftrConta}|{filtro.ftrDescricao}|{filtro.ftrPago}|{filtro.ftrReferencias}|{filtro.ftrTipo}|{filtro.ftrVencimento}");
                        }
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
                                if (vetObj[0].Trim() != filtro.Id.ToString())
                                {
                                    //vetObj[0] = filtro.Id;
                                    //vetObj[1] = filtro.Pago.ToString();
                                    //vetObj[2] = filtro.Descricao == null ? "" : filtro.Descricao;
                                    //vetObj[3] = filtro.ReferenciaIni == null ? "" : filtro.ReferenciaIni;
                                    //vetObj[4] = filtro.ReferenciaFim == null ? "" : filtro.ReferenciaFim;
                                    //vetObj[5] = filtro.Tipo == null ? "" : filtro.Tipo;
                                    //vetObj[6] = filtro.ContaId.ToString();
                                    //vetObj[7] = filtro.CategoriaDespesaId.ToString();
                                    //vetObj[8] = filtro.CategoriaReceitaId.ToString();
                                    //vetObj[9] = filtro.VencimentoIni.ToString("dd/MM/yyyy");
                                    //vetObj[10] = filtro.VencimentoFim.ToString("dd/MM/yyyy");
                                    //vetObj[11] = filtro.Receita.ToString();
                                    //vetObj[12] = filtro.ftrCatDespesa.ToString();
                                    //vetObj[13] = filtro.ftrCatReceita.ToString();
                                    //vetObj[14] = filtro.ftrConta.ToString();
                                    //vetObj[15] = filtro.ftrDescricao.ToString();
                                    //vetObj[16] = filtro.ftrPago.ToString();
                                    //vetObj[17] = filtro.ftrReferencias.ToString();
                                    //vetObj[18] = filtro.ftrTipo.ToString();
                                    //vetObj[19] = filtro.ftrVencimento.ToString();
                                    matSave.Add(vetObj[0], vetObj);
                                }
                                linha = sr.ReadLine();

                            }

                        }

                        matSave = matSave.OrderBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);

                        using (StreamWriter sw = File.CreateText(path))
                        {
                            foreach (var item in matSave.Values)
                            {
                                sw.WriteLine($"{item[0]}|{item[1]}|{item[2]}|{item[3]}|{item[4]}|{item[5]}|{item[6]}|{item[7]}|{item[8]}|{item[9]}|{item[10]}|{item[11]}|{item[12]}|{item[13]}|{item[14]}|{item[15]}|{item[16]}|{item[17]}|{item[18]}|{item[19]}");
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
        public static List<Financa> setFiltro(string btn, bool pago, string descricao, string referenciaini, string referenciafim, DateTime vencimentoini, DateTime vencimentofim, string tipo, int contaid, int categoriadespesaid, int categoriareceitaid, bool Receita,
                                              bool ftrCatDespesa, bool ftrCatReceita, bool ftrConta, bool ftrDescricao, bool ftrPago, bool ftrReferências, bool ftrTipo, bool ftrVencimento, out List<string> Erros)
        {
            List<Financa> financas = new List<Financa>();
            Erros = new List<string>();

            Filtro filtro = new Filtro();
            filtro.Id = btn;
            filtro.Pago = pago;
            filtro.Descricao = descricao;
            filtro.ReferenciaIni = referenciaini;
            filtro.ReferenciaFim = referenciafim;
            filtro.Tipo = tipo;
            filtro.ContaId = contaid;
            filtro.CategoriaDespesaId = categoriadespesaid;
            filtro.CategoriaReceitaId = categoriareceitaid;
            filtro.VencimentoIni = vencimentoini;
            filtro.VencimentoFim = vencimentofim;
            filtro.Receita = Receita;

            filtro.ftrCatDespesa = ftrCatDespesa;
            filtro.ftrCatReceita = ftrCatReceita;
            filtro.ftrConta = ftrConta;
            filtro.ftrDescricao = ftrDescricao;
            filtro.ftrPago = ftrPago;
            filtro.ftrReferencias = ftrReferências;
            filtro.ftrTipo = ftrTipo;
            filtro.ftrVencimento = ftrVencimento;

            var filtroOld = findfiltro(filtro.Id);
            if (filtroOld != null)
            {
                Delete(filtroOld);
            }
            GravarDados(Method.Create, ref Erros, filtro);
            financas = Filtrar(filtro.Id, ftrCatDespesa, ftrCatReceita, ftrConta, ftrDescricao, ftrPago, ftrReferências, ftrTipo, ftrVencimento);

            return financas;
        }

        public static List<Financa> Filtrar(string id, bool ftrCatDespesa, bool ftrCatReceita, bool ftrConta, bool ftrDescricao, bool ftrPago, bool ftrReferências, bool ftrTipo, bool ftrVencimento)
        {
            Filtro filtro = findfiltro(id);
            var financas = FinancaService.List();

            if (ftrPago)
            {
                financas = financas.Where(m => m.Pago == filtro.Pago).ToList();
            }
            if (ftrReferências)
            {
                var refIni = filtro.ReferenciaIni.Split('-');
                var refFim = filtro.ReferenciaFim.Split('-');

                var refinicial = int.Parse(refIni[0] + refIni[1]);
                var reffinal = int.Parse(refFim[0] + refFim[1]);

                financas = financas.Where(m => int.Parse(m.AnoMesReferencia.Split('-')[0] + m.AnoMesReferencia.Split('-')[1]) >= refinicial).ToList();
                financas = financas.Where(m => int.Parse(m.AnoMesReferencia.Split('-')[0] + m.AnoMesReferencia.Split('-')[1]) <= reffinal).ToList();
            }
            if (ftrDescricao)
            {
                financas = financas.Where(m => m.Descricao.ToUpper().Contains(filtro.Descricao.ToUpper())).ToList();
            }
            if (ftrVencimento)
            {
                financas = financas.Where(m => m.Vencimento >= filtro.VencimentoIni).Where(m => m.Vencimento <= filtro.VencimentoFim).ToList();
            }
            if (ftrTipo)
            {
                financas = financas.Where(m => m.Receita == filtro.Receita).ToList();
            }
            if (ftrConta)
            {
                financas = financas.Where(m => m.ContaId == filtro.ContaId).ToList();
            }
            if (ftrCatDespesa)
            {
                financas = financas.Where(m => m.CategoriaId == filtro.CategoriaDespesaId).ToList();
            }
            if (ftrCatReceita)
            {
                financas = financas.Where(m => m.CategoriaId == filtro.CategoriaReceitaId).ToList();
            }


            return financas;

        }
    }
}
