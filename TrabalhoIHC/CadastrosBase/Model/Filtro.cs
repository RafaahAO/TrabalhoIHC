using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIHC.Model
{
    public class Filtro
    {
        public string Id { get; set; }
        public bool Pago { get; set; }
        public bool Receita { get; set; }
        public string Descricao { get; set; }
        public string ReferenciaIni { get; set; }
        public string ReferenciaFim { get; set; }
        public DateTime VencimentoIni { get; set; }
        public DateTime VencimentoFim { get; set; }
        public string Tipo { get; set; }
        public int ContaId { get; set; }
        public int CategoriaDespesaId { get; set; }
        public int CategoriaReceitaId { get; set; }

        public bool ftrCatDespesa { get; set; }
        public bool ftrCatReceita { get; set; }
        public bool ftrConta { get; set; }
        public bool ftrDescricao { get; set; }
        public bool ftrPago { get; set; }
        public bool ftrReferencias { get; set; }
        public bool ftrTipo { get; set; }
        public bool ftrVencimento { get; set; }

    }
}
