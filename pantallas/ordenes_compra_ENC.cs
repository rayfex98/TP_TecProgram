using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Entidades;


namespace pantallas
{
    public partial class ordenes_compra_ENC : Form
    {
        public ordenes_compra_ENC()
        {
            InitializeComponent();
        }

        private void ordenes_compra_ENC_Load(object sender, EventArgs e)
        {
            NProducto productos = new NProducto();

            cmbProducto.DataSource = productos.RecuperarProductos();
            cmbProducto.DisplayMember ="nombre";
        }
    }
}
