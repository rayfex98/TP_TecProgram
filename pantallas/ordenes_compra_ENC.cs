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
        readonly NOrdenCompra OrdenCompra = new NOrdenCompra();
        readonly List<DetalleOrden> newdetalle = new List<DetalleOrden>();
        readonly OrdenDeCompra unaOrdenCompra = new OrdenDeCompra();
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
            cboxProveedor.DataSource = bllProveedor.RecuperarProveedoresHabilitados();
            cboxProveedor.DisplayMember = "RazonSocial";
            cboxProveedor.ValueMember = "ID";

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleOrden undetalle = new DetalleOrden
            {
                Producto = (Producto)cmbProducto.SelectedItem,
                Cantidad = Convert.ToInt32(tboxCantidad.Text)
            };
            //meter en lista dentro de "orden" 
            newdetalle.Add(undetalle);
            int n = dtgvProductos.Rows.Add();
            dtgvProductos.Rows[n].Cells[0].Value = this.newdetalle[n].Producto.Nombre;
            dtgvProductos.Rows[n].Cells[1].Value = this.newdetalle[n].Producto.Categoria.Nombre;
            dtgvProductos.Rows[n].Cells[2].Value = this.newdetalle[n].Cantidad;
            dtgvProductos.Rows[n].Cells[3].Value = this.newdetalle[n].Producto.PrecioVenta;
            dtgvProductos.Rows[n].Cells[4].Value = this.newdetalle[n].Cantidad * this.newdetalle[n].Producto.PrecioVenta;
        }

        private void cboxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {          
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            Usuario newusuario = new Usuario
            {
                ID = 1
            };
            unaOrdenCompra.Proveedor = (Proveedor)cboxProveedor.SelectedItem;               
            unaOrdenCompra.Detalles = newdetalle;
            unaOrdenCompra.UsuarioCreador = newusuario;
            if (OrdenCompra.NuevaOrden(unaOrdenCompra))
            {
                MessageBox.Show("Se creo la orden de compra con exito");
            }
            else
            {
                MessageBox.Show(" no se pudo crear la orden de compra");
            }
            newdetalle.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int n = dtgvProductos.Rows.Add();
            dtgvProductos.Rows[n].Cells[0].Value = this.newdetalle[n].Producto.Nombre;
            dtgvProductos.Rows[n].Cells[1].Value = this.newdetalle[n].Producto.Categoria.Nombre;
            dtgvProductos.Rows[n].Cells[2].Value = this.newdetalle[n].Cantidad;
        }
    }
}
