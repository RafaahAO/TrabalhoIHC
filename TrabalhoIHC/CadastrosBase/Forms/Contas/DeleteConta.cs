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
    public partial class DeleteControleGastos : Form
    {
        public DeleteControleGastos()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControleGastos ControleGastos = (ControleGastos)(comboBox1.SelectedItem);
            txtId.Text = ControleGastos.Id.ToString();

        }

        private void DeleteControleGastos_Load(object sender, EventArgs e)
        {

            List<ControleGastos> lstShow = ControleGastosService.List();

            if (lstShow.Count > 0)
            {

                comboBox1.DataSource = lstShow;
                comboBox1.DisplayMember = "Descricao";
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                MessageBox.Show("Deve haver ao menos uma ControleGastos para ser Deletada.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdviceControleGastos confirm = new AdviceControleGastos();
            DialogResult result = confirm.ShowDialog();
            List<string> Erros = new List<string>();
            List<ControleGastos> lstShow = ControleGastosService.List();

            if (result == DialogResult.OK)
            {
                ControleGastos ControleGastos = ControleGastosService.findControleGastos(int.Parse(txtId.Text));
                Erros = ControleGastosService.Delete(ControleGastos);

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

                    DeleteControleGastos_Load(null, EventArgs.Empty);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteControleGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
