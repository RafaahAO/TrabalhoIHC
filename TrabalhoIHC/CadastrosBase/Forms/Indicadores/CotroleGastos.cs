﻿using System;
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

namespace TrabalhoIHC.CadastrosBase.Forms.Indicadores
{
    public partial class CotroleGastos : Form
    {
        Form1 form = new Form1();

        public CotroleGastos(Form1 form)
        {
            InitializeComponent();
            this.form = form;

        }

        private void CotroleGastos_Load(object sender, EventArgs e)
        {
            BindingSource bd = new BindingSource();
            bd.DataSource = new List<string>() { "Diario", "Mensal", "Trimestral", "Semestral", "Anual" };
            comboBox1.DataSource = bd;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.SelectedIndex = 0;

            ControleGastos cg = ControleGastosService.List().FirstOrDefault();

            textBox1.Text = cg.ValorDiario.ToString();
            textBox2.Text = cg.ValorMensal.ToString();
            textBox3.Text = cg.ValorTrimestral.ToString();
            textBox4.Text = cg.ValorSemestral.ToString();
            textBox5.Text = cg.ValorAnual.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
    
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

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> Erros = ControleGastosService.Edit(textBox1.Text.Replace('.', ','), textBox2.Text.Replace('.', ','), textBox3.Text.Replace('.', ','), textBox4.Text.Replace('.', ','), textBox5.Text.Replace('.', ','));

            if (Erros.Count > 0)
            {
                string erros = "";
                foreach (var item in Erros)
                {
                    erros += item + "\r\n";
                }
                MessageBox.Show(erros);
            }
            else
            {
                MessageBox.Show("Controle alterado com sucesso.");
                form.Form1_Load(null, EventArgs.Empty);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string typed = textBox1.Text.Replace('.',',');
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox2.Text = (valueTyped * 30).ToString("0.00");
                textBox3.Text = (valueTyped * 90).ToString("0.00");
                textBox4.Text = (valueTyped * 180).ToString("0.00");
                textBox5.Text = (valueTyped * 365).ToString("0.00");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string typed = textBox2.Text.Replace('.', ',');
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 30).ToString("0.00");
                textBox3.Text = (valueTyped * 3).ToString("0.00");
                textBox4.Text = (valueTyped * 6).ToString("0.00");
                textBox5.Text = (valueTyped * 12).ToString("0.00");
            }
            
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            string typed = textBox3.Text.Replace('.', ',');
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 90).ToString("0.00");
                textBox2.Text = (valueTyped / 3).ToString("0.00");
                textBox4.Text = (valueTyped * 2).ToString("0.00");
                textBox5.Text = (valueTyped * 4).ToString("0.00");
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            string typed = textBox4.Text.Replace('.', ',');
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 180).ToString("0.00");
                textBox2.Text = (valueTyped / 6).ToString("0.00");
                textBox3.Text = (valueTyped / 2).ToString("0.00");
                textBox5.Text = (valueTyped * 2).ToString("0.00");
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            string typed = textBox4.Text.Replace('.', ',');
            double valueTyped;

            if (double.TryParse(typed, out valueTyped))
            {
                textBox1.Text = (valueTyped / 180).ToString("0.00");
                textBox2.Text = (valueTyped / 6).ToString("0.00");
                textBox3.Text = (valueTyped / 4).ToString("0.00");
                textBox4.Text = (valueTyped / 2).ToString("0.00");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
