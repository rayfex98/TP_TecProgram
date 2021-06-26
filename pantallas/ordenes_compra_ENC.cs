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
        List<DetalleOrden> detalles = new List<DetalleOrden>();
        public ordenes_compra_ENC()
        {
            InitializeComponent();
        }

        private void ordenes_compra_ENC_Load(object sender, EventArgs e)
        {

            NProducto bllProducto = new NProducto();
            bllProducto.CargarLista();
            cmbProducto.DataSource = bllProducto.RecuperarProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ID";

            NProveedor bllProveedor = new NProveedor();
            cmbProveedor.DataSource = bllProveedor.RecuperarProveedoresHabilitados();
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ID";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //agregar a detalle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //generar orden
        }
    }
}
