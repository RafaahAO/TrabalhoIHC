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
    public partial class DeleteCategoriaReceita : Form
    {
        public DeleteCategoriaReceita()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdviceCategoriaReceita confirm = new AdviceCategoriaReceita();
            DialogResult result = confirm.ShowDialog();
            List<string> Erros = new List<string>();
            List<CategoriaReceita> lstShow = CategoriaReceitaService.List();

            if (result == DialogResult.OK)
            {
                CategoriaReceita categoria = CategoriaReceitaService.findCategoria(int.Parse(txtId.Text));
                Erros = CategoriaReceitaService.Delete(categoria);
            }

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
                MessageBox.Show("ControleGastos deletada com sucesso.");

                DeleteCategoriaReceita_Load(null, EventArgs.Empty);
            }
        }

        private void DeleteCategoriaReceita_Load(object sender, EventArgs e)
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
                this.Close();
                MessageBox.Show("Deve haver ao menos uma ControleGastos para ser Deletada.");
            }
        }

        private void DeleteCategoriaReceita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void DeleteCategoriaReceita_Load_1(object sender, EventArgs e)
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
                this.Close();
                MessageBox.Show("Deve haver ao menos uma ControleGastos para ser Deletada.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
