using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace pantallas
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NProducto productos = new NProducto();

            cmbProducto.DataSource = productos.RecuperarProductos();
            cmbProducto.DisplayMember = "nombre";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Form producto = new ordenes_compra_ENC();
            producto.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form producto = new ordenes_compra_GER();
            producto.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form producto = new Deposito();
            producto.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form producto = new ALertas();
            producto.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form producto = new AlertasCriticas();
            producto.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarProveedor();
            producto.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarCategoria();
            producto.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form producto = new AgregarProducto();
            producto.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lleno el datagridview con los datos que traigo de este metodo 
            NProveedor proveedor = new NProveedor();
            string provincia = BtnBuscarPorProvincia.Text;
            dtbvProveedoresProvincia.DataSource = proveedor.RecuperarProveedoresPorProvincia(provincia);
            //ver que rows trae en este orden datos'Razon social','Direccion','Provincia','Cuil','Calle','Localidad','Codigo postal','Habilitado'

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //lleno el datagridview con los datos que traigo de este metodo 
            NProducto producto = new NProducto();
            string categoria = txbBuscarProductoPorcategoria.Text;
            dtgvBuscarProductoPorCategoria.DataSource = producto.RecuperarProductoCategoria(categoria);
            //ver que rows trae en este orden datos 'nombre','categoria', 'Stock','Precio de compra','Precio de venta'
        }
    }
}
