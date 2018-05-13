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

namespace TrabalhoIHC.CadastrosBase.Forms.CategoriaDespesas
{
    public partial class ListCategoriaDespesa : Form
    {
        public ListCategoriaDespesa()
        {
            InitializeComponent();
        }

        private void ListCategoriaDespesa_Load(object sender, EventArgs e)
        {
            List<CategoriaDespesa> categorias = CategoriaDespesaService.List();

            foreach (var categoria in categorias)
            {
                ListViewItem item = new ListViewItem(categoria.Id.ToString());
                item.SubItems.Add(categoria.Descricao);
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListCategoriaDespesa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
