using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bll_modulo;
using Entidades;
using ddl_modulo;
namespace ui_vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DCategoria cat = new DCategoria();
            dtgvcategoria.DataSource = cat.ListadeCategoria();
        }
    }
}
