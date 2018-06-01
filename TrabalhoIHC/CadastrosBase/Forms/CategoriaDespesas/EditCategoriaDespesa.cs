using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoIHC.CadastrosBase.Model;
using TrabalhoIHC.Service;

namespace TrabalhoIHC.CadastrosBase.Forms.CategoriaDespesas
{
    public partial class EditCategoriaDespesa : Form
    {
        public EditCategoriaDespesa()
        {
            InitializeComponent();
        }

        private void EditCategoriaDespesa_Load(object sender, EventArgs e)
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
                MessageBox.Show("Deve haver ao menos uma categoria para ser editada.");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = txtDesc.Text;
            string Id = txtId.Text;
            List<string> Erros = CategoriaDespesaService.Edit(int.Parse(Id), Desc);

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
                MessageBox.Show("Categoria editada com sucesso.");
                EditCategoriaDespesa_Load(null, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaDespesa categoria = (CategoriaDespesa)(comboBox1.SelectedItem);
            txtId.Text = categoria.Id.ToString();
            txtDesc.Text = categoria.Descricao;
        }

        private void EditCategoriaDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
