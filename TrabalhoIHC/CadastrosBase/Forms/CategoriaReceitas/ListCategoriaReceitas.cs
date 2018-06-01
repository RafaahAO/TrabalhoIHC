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

namespace TrabalhoIHC.CadastrosBase.Forms.CategoriaReceitas
{
    public partial class ListCategoriaReceitas : Form
    {
        public ListCategoriaReceitas()
        {
            InitializeComponent();
        }

        private void ListCategoriaReceitas_Load(object sender, EventArgs e)
        {
            List<CategoriaReceita> categorias = CategoriaReceitaService.List();

            foreach (var categoria in categorias)
            {
                ListViewItem item = new ListViewItem(categoria.Id.ToString());
                item.SubItems.Add(categoria.Descricao);
                listView1.Items.Add(item);
            }
        }

        private void ListCategoriaReceitas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
