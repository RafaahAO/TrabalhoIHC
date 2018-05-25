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
    public partial class ListControleGastos : Form
    {
        public ListControleGastos()
        {
            InitializeComponent();
        }

        private void ListControleGastos_Load(object sender, EventArgs e)
        {
            List<ControleGastos> ControleGastoss = ControleGastosService.List();

            foreach(var ControleGastos in ControleGastoss)
            {
                ListViewItem item = new ListViewItem(ControleGastos.Id.ToString());
                item.SubItems.Add(ControleGastos.Descricao);
                item.SubItems.Add(ControleGastos.Valor.ToString("0.00"));
                listView1.Items.Add(item);
            }
        }

        private void ListControleGastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
