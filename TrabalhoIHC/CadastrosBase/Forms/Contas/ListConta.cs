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
    public partial class ListConta : Form
    {
        public ListConta()
        {
            InitializeComponent();
        }

        private void ListConta_Load(object sender, EventArgs e)
        {
            List<Conta> contas = ContaService.List();

            foreach(var conta in contas)
            {
                ListViewItem item = new ListViewItem(conta.Id.ToString());
                item.SubItems.Add(conta.Descricao);
                item.SubItems.Add(conta.Valor.ToString("0.00"));
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
