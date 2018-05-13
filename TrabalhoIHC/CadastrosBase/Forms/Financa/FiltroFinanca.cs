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
    public partial class FiltroFinanca : Form
    {
        Form1 form = null;

        public FiltroFinanca(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Erros = new List<string>();
            List<Model.Financa> financas = FiltroService.setFiltro(comboBox1.Text, chkPago.Checked, textBox3.Text, textBox1.Text, textBox2.Text, dateTimePicker1.Value, dateTimePicker2.Value, (string)comboBox5.SelectedItem, ((Conta)comboBox2.SelectedItem).Id, ((CategoriaDespesa)comboBox3.SelectedItem).Id, ((CategoriaReceita)comboBox4.SelectedItem).Id, (string)comboBox5.SelectedItem == "Receita",
                                                                   ftrCatDespesa.Checked,ftrCatReceita.Checked,ftrConta.Checked,ftrDescricao.Checked,ftrPago.Checked,ftrReferências.Checked,ftrTipo.Checked,ftrVencimento.Checked,out Erros);
            form.filterGrid(financas);
            this.Close();

        }

        private void FiltroFinanca_Load(object sender, EventArgs e)
        {
            var tipos = new List<dynamic>() { "Despesa", "Receita" };
            if (tipos.Count > 0)
            {
                comboBox5.DataSource = tipos;
                comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var categoriaReceitas = CategoriaReceitaService.List();
            if (categoriaReceitas.Count > 0)
            {
                comboBox4.DataSource = categoriaReceitas;
                comboBox4.DisplayMember = "Descricao";
                comboBox4.ValueMember = "Id";
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var categoriaDespesas = CategoriaDespesaService.List();
            if (categoriaDespesas.Count > 0)
            {
                comboBox3.DataSource = categoriaDespesas;
                comboBox3.DisplayMember = "Descricao";
                comboBox3.ValueMember = "Id";
                comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            var contas = ContaService.List();
            if (contas.Count > 0)
            {
                comboBox2.DataSource = contas;
                comboBox2.DisplayMember = "Descricao";
                comboBox2.ValueMember = "Id";
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            }


        }

        private void FiltroFinanca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
