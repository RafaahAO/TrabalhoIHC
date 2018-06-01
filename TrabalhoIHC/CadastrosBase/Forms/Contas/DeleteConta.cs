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

namespace TrabalhoIHC.CadastrosBase.Forms
{
    public partial class DeleteConta : Form
    {
        public DeleteConta()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conta Conta = (Conta)(comboBox1.SelectedItem);
            txtId.Text = Conta.Id.ToString();

        }

        private void DeleteConta_Load(object sender, EventArgs e)
        {

            List<Conta> lstShow = ContaService.List();

            if (lstShow.Count > 0)
            {

                comboBox1.DataSource = lstShow;
                comboBox1.DisplayMember = "Descricao";
                comboBox1.ValueMember = "Id";
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                MessageBox.Show("Deve haver ao menos uma Conta para ser Deletada.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdviceConta confirm = new AdviceConta();
            DialogResult result = confirm.ShowDialog();
            List<string> Erros = new List<string>();
            List<Conta> lstShow = ContaService.List();

            if (result == DialogResult.OK)
            {
                Conta Conta = ContaService.findConta(int.Parse(txtId.Text));
                Erros = ContaService.Delete(Conta);

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

                    DeleteConta_Load(null, EventArgs.Empty);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
