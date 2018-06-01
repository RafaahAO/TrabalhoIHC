using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoIHC.Model;
using TrabalhoIHC.Service;

namespace TrabalhoIHC.CadastrosBase.Forms.CategoriaDespesas
{
    public partial class DeleteCategoriaDespesa : Form
    {
        public DeleteCategoriaDespesa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdviceCategoriaDespesa confirm = new AdviceCategoriaDespesa();
            DialogResult result = confirm.ShowDialog();
            List<string> Erros = new List<string>();
            List<CategoriaDespesa> lstShow = CategoriaDespesaService.List();

            if (result == DialogResult.OK)
            {
                CategoriaDespesa categoria = CategoriaDespesaService.findCategoria(int.Parse(txtId.Text));
                Erros = CategoriaDespesaService.Delete(categoria);

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
                    MessageBox.Show("Conta deletada com sucesso.");

                    DeleteCategoriaDespesa_Load(null, EventArgs.Empty);
                }
            }
        }

        private void DeleteCategoriaDespesa_Load(object sender, EventArgs e)
        {
            List<CategoriaDespesa> lstShow = CategoriaDespesaService.List();

            if (lstShow.Count > 0)
            {

                comboBox1.DataSource = lstShow;
                comboBox1.DisplayMember = "Descricao";
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                this.Close();
                MessageBox.Show("Deve haver ao menos uma Conta para ser Deletada.");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaDespesa categoria = (CategoriaDespesa)(comboBox1.SelectedItem);
            txtId.Text = categoria.Id.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteCategoriaDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
