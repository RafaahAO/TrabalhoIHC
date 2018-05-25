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

namespace TrabalhoIHC
{
    public partial class CreateControleGastos : Form
    {
        public CreateControleGastos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = txtDesc.Text;
            string Valor = txtValor.Text;
            List<string>Erros = ControleGastosService.Create(Desc, Valor);

            if (Erros.Count > 0)
            {
                string textError = "";
                foreach(var erro in Erros)
                {
                    textError += erro + "\r\n";
                }

                MessageBox.Show(textError);
            }
            else
            {
                txtDesc.Text = "";
                txtValor.Text = "";
                MessageBox.Show("ControleGastos criada com sucesso.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateControleGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
