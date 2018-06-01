using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabalhoIHC.CadastrosBase.Forms.Indicadores
{
    public partial class CotroleGastos : Form
    {
        public CotroleGastos()
        {
            InitializeComponent();
        }

        private void CotroleGastos_Load(object sender, EventArgs e)
        {
            BindingSource bd = new BindingSource();
            bd.DataSource = new List<string>() { "Diario", "Mensal", "Trimestral", "Semestral", "Anual" };
            comboBox1.DataSource = bd;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.SelectedIndex = 0;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string typed = textBox1.Text;
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox2.Text = (valueTyped * 30).ToString("0.00");
                textBox3.Text = (valueTyped * 90).ToString("0.00");
                textBox4.Text = (valueTyped * 180).ToString("0.00");
                textBox5.Text = (valueTyped * 365).ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Digite um valor válido.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string typed = textBox2.Text;
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 30).ToString("0.00");
                textBox3.Text = (valueTyped * 3).ToString("0.00");
                textBox4.Text = (valueTyped * 6).ToString("0.00");
                textBox5.Text = (valueTyped * 12).ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Digite um valor válido.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string typed = textBox3.Text;
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 90).ToString("0.00");
                textBox2.Text = (valueTyped / 3).ToString("0.00");
                textBox4.Text = (valueTyped * 2).ToString("0.00");
                textBox5.Text = (valueTyped * 4).ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Digite um valor válido.");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string typed = textBox4.Text;
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 180).ToString("0.00");
                textBox2.Text = (valueTyped / 6).ToString("0.00");
                textBox3.Text = (valueTyped / 2).ToString("0.00");
                textBox5.Text = (valueTyped * 2).ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Digite um valor válido.");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string typed = textBox4.Text;
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 180).ToString("0.00");
                textBox2.Text = (valueTyped / 6).ToString("0.00");
                textBox3.Text = (valueTyped / 4).ToString("0.00");
                textBox4.Text = (valueTyped / 2).ToString("0.00");
            }
            else
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Red;
                MessageBox.Show("Digite um valor válido.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox1.Enabled = true;
                    break;

                case 1:
                    textBox2.Enabled = true;
                    break;

                case 2:
                    textBox3.Enabled = true;
                    break;

                case 3:
                    textBox4.Enabled = true;
                    break;

                case 4:
                    textBox5.Enabled = true;
                    break;
            }
        }
    }
}
