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

namespace TrabalhoIHC.CadastrosBase.Forms
{
    public partial class EditControleGastos : Form
    {
        public EditControleGastos()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void MainLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Desc = txtDesc.Text;
            string Valor = txtValor.Text;
            string Id = txtId.Text;
            List<string> Erros = ControleGastosService.Edit(int.Parse(Id),Desc, Valor);

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
                txtValor.Text = "";
                MessageBox.Show("ControleGastos editada com sucesso.");
                EditControleGastos_Load(null, EventArgs.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditControleGastos_Load(object sender, EventArgs e)
        {
            List<ControleGastos> lstShow = ControleGastosService.List();
            var lstComplete = new List<ControleGastos>();

            if (lstShow.Count > 0)
            {

                comboBox1.DataSource = lstShow;
                comboBox1.DisplayMember = "Descricao";
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                MessageBox.Show("Deve haver ao menos uma ControleGastos para ser editada.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControleGastos ControleGastos = (ControleGastos)(comboBox1.SelectedItem);
            txtId.Text = ControleGastos.Id.ToString();
            txtDesc.Text = ControleGastos.Descricao;
            txtValor.Text = ControleGastos.Valor.ToString("0.00");

        }

        private void EditControleGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
