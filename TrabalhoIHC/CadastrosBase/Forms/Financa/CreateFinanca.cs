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

namespace TrabalhoIHC.CadastrosBase.Forms.Financa
{
    public partial class CreateFinanca : Form
    {
        Form1 form = new Form1();
        public CreateFinanca(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboTipoValue = (string)comboBox1.SelectedItem;


            if (comboTipoValue.Equals("Despesa"))
            {
                panel2.Visible = true;
                panelDespesa.Visible = true;
                panelReceita.Visible = false;

            }
            else if (comboTipoValue.Equals("Receita"))
            {
                panel2.Visible = true;
                panelReceita.Visible = true;
                panelDespesa.Visible = false;

            }
            else
            {
                panel2.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Erros = new List<string>();
            string descricao = textBox1.Text;
            string Valor = textBox2.Text;
            bool pago = chkPago.Checked;
            DateTime vencimento = dateTimePicker1.Value;
            string referencia = textBox3.Text;

            string tipoFinanca = comboBox1.Text;
            if (tipoFinanca != "Receita" && tipoFinanca != "Despesa")
            {
                MessageBox.Show("Selecione um tipo válido");
            }
            else if (comboCatReceita.SelectedItem == null && comboCatDespesa.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma categoria válida");
            }
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma Conta válida");
            }
            else
            {
                if (comboBox1.Text == "Receita")
                {
                    Erros = FinancaService.Create(descricao, Valor, (Conta)comboBox2.SelectedItem, pago, referencia, vencimento, true, null, (CategoriaReceita)comboCatReceita.SelectedItem);
                }
                else
                {
                    Erros = FinancaService.Create(descricao, Valor, (Conta)comboBox2.SelectedItem, pago, referencia, vencimento, false, (CategoriaDespesa)comboCatDespesa.SelectedItem);
                }


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
                    MessageBox.Show("Finança gravada com sucesso.");
                    form.Form1_Load(null, EventArgs.Empty);
                }
            }
            //FinancaService.Create()
        }

        private void CreateFinanca_Load(object sender, EventArgs e)
        {
            var tipos = new List<dynamic>() { "Despesa", "Receita" };
            if (tipos.Count > 0)
            {
                comboCatReceita.DataSource = tipos;
                comboCatReceita.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var categoriaReceitas = CategoriaReceitaService.List();
            if (categoriaReceitas.Count > 0)
            {
                comboCatReceita.DataSource = categoriaReceitas;
                comboCatReceita.DisplayMember = "Descricao";
                comboCatReceita.ValueMember = "Id";
                comboCatReceita.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var categoriaDespesas = CategoriaDespesaService.List();
            if (categoriaDespesas.Count > 0)
            {
                comboCatDespesa.DataSource = categoriaDespesas;
                comboCatDespesa.DisplayMember = "Descricao";
                comboCatDespesa.ValueMember = "Id";
                comboCatDespesa.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var Contas = ContaService.List();
            if (Contas.Count > 0)
            {
                comboBox2.DataSource = Contas;
                comboBox2.DisplayMember = "Descricao";
                comboBox2.ValueMember = "Id";
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            dateTimePicker1.Value = DateTime.Now;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateFinanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
