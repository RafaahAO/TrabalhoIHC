using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHC.Model;
using TrabalhoIHC.Service;

namespace TrabalhoIHC.CadastrosBase.Service
{
    public class IndicadoresService
    {
        public static Dictionary<string, dynamic> getIndicadores()
        {
            ControleGastos metas = ControleGastosService.List().FirstOrDefault();

            List<Financa> financasDia = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) == DateTime.Parse(m.Vencimento.ToString("dd/MM/yyyy"))).ToList();
            List<Financa> financasSemana = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) <= m.Vencimento).Where(m => DateTime.Parse(DateTime.Now.AddDays(7).ToString("dd/MM/yyyy")) >= m.Vencimento).ToList();
            List<Financa> financasMes = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) <= m.Vencimento).Where(m => DateTime.Parse(DateTime.Now.AddDays(30).ToString("dd/MM/yyyy")) >= m.Vencimento).ToList();
            List<Financa> financasTrimestre = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) <= m.Vencimento).Where(m => DateTime.Parse(DateTime.Now.AddDays(90).ToString("dd/MM/yyyy")) >= m.Vencimento).ToList();
            List<Financa> financasSemestre = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) <= m.Vencimento).Where(m => DateTime.Parse(DateTime.Now.AddDays(180).ToString("dd/MM/yyyy")) >= m.Vencimento).ToList();
            List<Financa> financasAno = FinancaService.List().Where(m => DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")) <= m.Vencimento).Where(m => DateTime.Parse(DateTime.Now.AddDays(360).ToString("dd/MM/yyyy")) >= m.Vencimento).ToList();

            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();

            dynamic obj = new ExpandoObject();
            obj.Meta = metas.ValorDiario;
            obj.Realizado = financasDia.Sum(m => m.Valor);
            obj.Resultado = obj.Meta > obj.Realizado ? "Dentro da Meta" : "Superior à Meta";
            result.Add("Dia", obj);

            obj = new ExpandoObject();
            obj.Meta = metas.ValorMensal;
            obj.Realizado = financasMes.Sum(m => m.Valor);
            obj.Resultado = obj.Meta > obj.Realizado ? "Dentro da Meta" : "Superior à Meta";
            result.Add("Mes", obj);

            obj = new ExpandoObject();
            obj.Meta = metas.ValorTrimestral;
            obj.Realizado = financasTrimestre.Sum(m => m.Valor);
            obj.Resultado = obj.Meta > obj.Realizado ? "Dentro da Meta" : "Superior à Meta";
            result.Add("Trimestre", obj);

            obj = new ExpandoObject();
            obj.Meta = metas.ValorSemestral;
            obj.Realizado = financasSemestre.Sum(m => m.Valor);
            obj.Resultado = obj.Meta > obj.Realizado ? "Dentro da Meta" : "Superior à Meta";
            result.Add("Semestre", obj);

            obj = new ExpandoObject();
            obj.Meta = metas.ValorAnual;
            obj.Realizado = financasAno.Sum(m => m.Valor);
            obj.Resultado = obj.Meta > obj.Realizado ? "Dentro da Meta" : "Superior à Meta";
            result.Add("Ano", obj);

            return result;
        }
    }
}
