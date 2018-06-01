using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIHC.Model
{
    public class Financa
    {
        public int Id { get; set; }

        //ForeignKeys
        public int CategoriaId { get; set; }
        public int ContaId { get; set; }

        //Descricao
        public string Descricao { get; set; }

        //AnoMesReferencia e Vencimento
        public string AnoMesReferencia { get; set; }
        public DateTime Vencimento { get; set; }

        //Valor Despesa/Receita
        public double Valor { get; set; }

        //Bools
        public bool Receita { get; set; }
        public bool Pago { get; set; }

    }
}
