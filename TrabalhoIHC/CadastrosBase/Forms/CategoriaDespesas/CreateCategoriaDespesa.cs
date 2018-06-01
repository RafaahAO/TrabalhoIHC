using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoIHC.Service;

namespace TrabalhoIHC.CadastrosBase.Forms
{
    public partial class CreateCategoriaDespesa : Form
    {
        public CreateCategoriaDespesa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = txtDesc.Text;
            List<string> Erros = CategoriaDespesaService.Create(Desc);

            if (Erros.Count > 0)
            {
                string textError = "";
                foreach (var erro in Erros)
                {
                    textError += erro + "\r\n";
                }

                MessageBox.Show(textError);
            }
            else
            {
                txtDesc.Text = "";
                MessageBox.Show("Categoria criada com sucesso.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateCategoriaDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
