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


        }
    }
}
