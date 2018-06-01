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
    public partial class ListConta : Form
    {
        public ListConta()
        {
            InitializeComponent();
        }

        private void ListConta_Load(object sender, EventArgs e)
        {
            List<Conta> Contas = ContaService.List();

            foreach(var Conta in Contas)
            {
                ListViewItem item = new ListViewItem(Conta.Id.ToString());
                item.SubItems.Add(Conta.Descricao);
                item.SubItems.Add(Conta.Valor.ToString("0.00"));
                listView1.Items.Add(item);
            }
        }

        private void ListConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
