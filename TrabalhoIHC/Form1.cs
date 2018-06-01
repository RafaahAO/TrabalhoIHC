using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoIHC.CadastrosBase.Forms;
using TrabalhoIHC.CadastrosBase.Forms.CategoriaDespesas;
using TrabalhoIHC.CadastrosBase.Forms.CategoriaReceitas;
using TrabalhoIHC.CadastrosBase.Forms.Financa;
using TrabalhoIHC.CadastrosBase.Forms.Indicadores;
using TrabalhoIHC.CadastrosBase.Model;
using TrabalhoIHC.CadastrosBase.Service;

namespace TrabalhoIHC
{
    public partial class Form1 : Form
    {
        static int IdSelected = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FiltroFinanca form = new FiltroFinanca(this);
            form.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btn_F1.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_F2.PerformClick();

            }
            else if (e.KeyCode == Keys.F3)
            {
                btn_F3.PerformClick();

            }
            else if (e.KeyCode == Keys.F4)
            {
                btn_F4.PerformClick();

            }
            else if (e.KeyCode == Keys.F5)
            {
                btn_F5.PerformClick();

            }
            else if (e.KeyCode == Keys.F6)
            {
                btn_F6.PerformClick();

            }
            else if (e.KeyCode == Keys.F7)
            {
                btn_F7.PerformClick();

            }
            else if (e.KeyCode == Keys.F8)
            {
                btn_F8.PerformClick();

            }
            else if (e.KeyCode == Keys.F9)
            {
                btn_F9.PerformClick();

            }
            else if (e.KeyCode == Keys.F10)
            {
                btn_F10.PerformClick();

            }
        }

        public void filterGrid(List<Financa> financas)
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = financas;
            dataGridView1.DataSource = binding;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            CreateConta Create = new CreateConta();
            Create.Show();
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            EditConta form = new EditConta();
            form.Show();
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            DeleteConta form = new DeleteConta();
            form.Show();
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            ListConta form = new ListConta();
            form.Show();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            CreateCategoriaDespesa form = new CreateCategoriaDespesa();
            form.Show();
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            EditCategoriaDespesa form = new EditCategoriaDespesa();
            form.Show();
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            DeleteCategoriaDespesa form = new DeleteCategoriaDespesa();
            form.Show();
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            ListCategoriaDespesa form = new ListCategoriaDespesa();
            form.Show();
        }

        private void btn_F1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Filtro filtro = FiltroService.findfiltro("F1");
                if (filtro != null)
                {
                    FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                }
            }
        }

        internal void Form1_Load(object sender, EventArgs e)
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = FinancaService.List();
            dataGridView1.DataSource = binding;

        }

        private void Add_Click(object sender, EventArgs e)
        {
            CreateFinanca form = new CreateFinanca(this);
            form.Show();
        }

        private void menuItem18_Click(object sender, EventArgs e)
        {
            CreateCategoriaReceita form = new CreateCategoriaReceita();
            form.Show();
        }

        private void menuItem19_Click(object sender, EventArgs e)
        {
            EditCategoriaReceita form = new EditCategoriaReceita();
            form.Show();
        }

        private void menuItem20_Click(object sender, EventArgs e)
        {
            ListCategoriaReceitas form = new ListCategoriaReceitas();
            form.Show();
        }

        private void menuItem21_Click(object sender, EventArgs e)
        {
            DeleteCategoriaReceita form = new DeleteCategoriaReceita();
            form.Show();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = (bool)dataGridView1.Rows[e.RowIndex].Cells[6].Value ? Color.Green : Color.Red;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                var Id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var Financa = FinancaService.findFinanca(Id);
                Financa.Pago = !Financa.Pago;
                FinancaService.Edit(Financa.Id, Financa.Descricao, Financa.Valor.ToString("0.00"), Financa.ContaId, Financa.Pago, Financa.AnoMesReferencia, Financa.Vencimento, Financa.Receita, Financa.CategoriaId);

                if (Financa.Pago)
                {
                    FinancaService.setValorConta(Financa, FinancaService.Method.Edit);//Mudou de não pago para pago 
                }
                else
                {
                    FinancaService.setValorConta(Financa, FinancaService.Method.Edit);//Mudou de pago para não pago
                }
                this.Form1_Load(null, EventArgs.Empty);
            }

            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            foreach (DataGridViewCell item in dataGridView1.Rows[e.RowIndex].Cells)
            {
                if (item == dataGridView1.Rows[e.RowIndex].Cells["Id"])
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }


            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var idFinanca = (int)this.dataGridView1.SelectedCells[0].Value;
            Financa financa = FinancaService.findFinanca(idFinanca);
            AdviceConta confirm = new AdviceConta();
            DialogResult result = confirm.ShowDialog();
            List<string> Erros = new List<string>();

            if (result == DialogResult.OK)
            {
                Erros = FinancaService.Delete(financa);

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
                    MessageBox.Show("Registro deletado com sucesso.");
                    this.Form1_Load(null, EventArgs.Empty);
                }
            }

        }

        private void Up_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.SelectedCells[0].RowIndex;
            if (index >= 1)
            {
                this.dataGridView1.Rows[index].Cells[0].Selected = false;
                this.dataGridView1.Rows[index - 1].Cells[0].Selected = true;
            }
        }

        private void Down_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.SelectedCells[0].RowIndex;
            if (index != 1)
            {
                this.dataGridView1.Rows[index].Cells[0].Selected = false;
                this.dataGridView1.Rows[index + 1].Cells[0].Selected = true;
            }
        }

        private void AUp_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.SelectedCells[0].RowIndex;
            if (index >= 0)
            {
                this.dataGridView1.Rows[index].Cells[0].Selected = false;
                this.dataGridView1.Rows[0].Cells[0].Selected = true;
            }
        }

        private void ADown_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.SelectedCells[0].RowIndex;
            if (index != 1)
            {
                this.dataGridView1.Rows[index].Cells[0].Selected = false;
                this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Selected = true;
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BindingSource binding = new BindingSource();
            binding.DataSource = FinancaService.List();
            dataGridView1.DataSource = binding;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_F1_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F1");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);
            }

        }

        private void btn_F2_Click(object sender, EventArgs e)
        {

            Filtro filtro = FiltroService.findfiltro("F2");
            if (filtro != null)
            {
                var financas =  FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }

        }

        private void btn_F2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F4_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btn_F4_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F7_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F8_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F9_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F10_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btn_F3_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F3");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }

        }

        private void btn_F4_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F4");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F5_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F5");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F6_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F6");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F7_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F7");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F8_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F8");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F9_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F9");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void btn_F10_Click(object sender, EventArgs e)
        {
            Filtro filtro = FiltroService.findfiltro("F10");
            if (filtro != null)
            {
                var financas = FiltroService.Filtrar(filtro.Id, filtro.ftrCatDespesa, filtro.ftrCatReceita, filtro.ftrConta, filtro.ftrDescricao, filtro.ftrPago, filtro.ftrReferencias, filtro.ftrReferencias, filtro.ftrVencimento);
                this.filterGrid(financas);

            }
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            InstrucoesCF instrucoes = new InstrucoesCF();
            instrucoes.Show();
        }

        private void menuItem2_Click_1(object sender, EventArgs e)
        {
            CotroleGastos cg = new CotroleGastos();
            cg.Show();
        }
    }
}
