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
using TrabalhoIHC.CadastrosBase.Service;

namespace TrabalhoIHC.CadastrosBase.Forms.CategoriaReceitas
{
    public partial class EditCategoriaReceita : Form
    {
        public EditCategoriaReceita()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = txtDesc.Text;
            string Id = txtId.Text;
            List<string> Erros = CategoriaReceitaService.Edit(int.Parse(Id), Desc);

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
                EditCategoriaReceita_Load(null, EventArgs.Empty);
            }
        }

        private void EditCategoriaReceita_Load(object sender, EventArgs e)
        {
            List<CategoriaReceita> lstShow = CategoriaReceitaService.List();

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaReceita categoria = (CategoriaReceita)(comboBox1.SelectedItem);
            txtId.Text = categoria.Id.ToString();
            txtDesc.Text = categoria.Descricao;
        }

        private void EditCategoriaReceita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
