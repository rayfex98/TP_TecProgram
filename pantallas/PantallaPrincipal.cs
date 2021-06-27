using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL;
using Entidades;

namespace pantallas
{
    public partial class PantallaPrincipal : Form
    {
        readonly NProducto bllProducto = new NProducto();
        readonly NProveedor bllProveedor = new NProveedor();
        readonly NDireccion bllDireccion = new NDireccion();
        readonly NCategoria bllCategoria = new NCategoria();
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bllProducto.CargarLista();
            bllCategoria.CargarLista();

            cmbProveedor.DataSource = bllProveedor.RecuperarProveedoresHabilitados();
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "RazonSocial";

            cmboxProvincias.DataSource = bllDireccion.CargarProvincias();
            cmboxProvincias.DisplayMember = "provincia";
            cmboxProvincias.ValueMember = "provincia";


            cmbProducto.DataSource = bllProducto.RecuperarProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Nombre";

            cmbCategoria.DataSource = bllCategoria.RecuperarCategoria();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Nombre";

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvBuscarProducto.DataSource = null;
            List<Producto> productos = new List<Producto>
            {
                (Producto)cmbProducto.SelectedItem
            };//lista con producto especifico
            dtgvBuscarProducto.DataSource = productos;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lleno el datagridview con los datos que traigo de este metodo 
            dtgvBuscarProducto.DataSource = null;
            dtgvBuscarProducto.DataSource = bllProducto.RecuperarProductoCategoria(cmbCategoria.SelectedValue.ToString());
            //ver que rows trae en este orden datos 'nombre','categoria', 'Stock','Precio de compra','Precio de venta'
        }
        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvProveedores.DataSource = null;
            List<Proveedor> _unProveedor = new List<Proveedor>
            {
                (Proveedor)cmbProveedor.SelectedItem
            }; //lista con proveedor especifico
            dtgvProveedores.DataSource = _unProveedor;
        }
        private void cmboxProvincias_SelectedIndexChanged(object sender, EventArgs e) //A VECES SE BORRA EL SP
        {
            dtgvProveedores.DataSource = null;
            dtgvProveedores.DataSource = bllProveedor.RecuperarProveedoresPorProvincia(cmboxProvincias.Text);
        }

        private void btnHacerOrden_Click(object sender, EventArgs e)
        {
           Form producto = new ordenes_compra_ENC();
            producto.Show();
        }

        private void BtnListarOrdenesCompra_Click(object sender, EventArgs e)
        {
            Form producto = new ordenes_compra_GER();
            producto.Show();
        }

        private void BtnVerDeposito_Click(object sender, EventArgs e)
        {
            Form producto = new Deposito();
            producto.Show();
        }

        private void BtnVerAlertas_Click(object sender, EventArgs e)
        {
            Form producto = new ALertas();
            producto.Show();
        }

        private void BtnAlertasCriticas_Click(object sender, EventArgs e)
        {
            Form producto = new AlertasCriticas();
            producto.Show();
        }

        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarProveedor();
            producto.Show();
        }

        private void BtnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarCategoria();
            producto.Show();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarProducto();
            producto.Show();
        }

    }
}
