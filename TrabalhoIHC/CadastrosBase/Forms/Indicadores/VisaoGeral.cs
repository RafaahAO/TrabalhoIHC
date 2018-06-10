using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoIHC.CadastrosBase.Service;

namespace TrabalhoIHC.CadastrosBase.Forms.Indicadores
{
    public partial class VisaoGeral : Form
    {
        public VisaoGeral()
        {
            InitializeComponent();
        }

        private void VisaoGeral_Load(object sender, EventArgs e)
        {
            var indicadores = IndicadoresService.getIndicadores();

            MetaDia.Text += indicadores["Dia"].Meta;
            RealizadoDia.Text += indicadores["Dia"].Realizado;
            ResultadoDia.Text += indicadores["Dia"].Resultado;

            MetaMes.Text += indicadores["Mes"].Meta;
            RealizadoMes.Text += indicadores["Mes"].Realizado;
            ResultadoMes.Text += indicadores["Mes"].Resultado;

            MetaTrimestre.Text += indicadores["Trimestre"].Meta;
            RealizadoTrimestre.Text += indicadores["Trimestre"].Realizado;
            ResultadoTrimestre.Text += indicadores["Trimestre"].Resultado;

            MetaSemestre.Text += indicadores["Semestre"].Meta;
            RealizadoSemestre.Text += indicadores["Semestre"].Realizado;
            ResultadoSemestre.Text += indicadores["Semestre"].Resultado;

            MetaAno.Text += indicadores["Ano"].Meta;
            RealizadoAno.Text += indicadores["Ano"].Realizado;
            ResultadoAno.Text += indicadores["Ano"].Resultado;

        }
    }
}
