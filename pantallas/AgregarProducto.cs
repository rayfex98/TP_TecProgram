using BLL;
using Entidades;
using System;
using Excepciones;
using System.Windows.Forms;

namespace pantallas
{
    public partial class AgregarProducto : Form
    {
        NCategoria bllCategoria = new NCategoria();
        public AgregarProducto()
        {
            InitializeComponent();
            bllCategoria.CargarLista();
            cmboxCategoria.DataSource = bllCategoria.RecuperarCategoria();
            cmboxCategoria.DisplayMember = "Nombre";
            cmboxCategoria.ValueMember = "ID";
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            NProducto bllProducto = new NProducto();
            try
            {
                Producto nuevo = new Producto();
                Categoria nuevaCat = new Categoria();
                nuevaCat.ID = int.Parse(cmboxCategoria.SelectedValue.ToString());
                nuevo.Nombre = tboxNombre.Text;
                nuevo.PrecioCompra = float.Parse(tboxPrecioCompra.Text);
                nuevo.PrecioVenta = float.Parse(tboxPrecioVenta.Text);
                nuevo.Categoria = nuevaCat;
                bllProducto.NuevoProducto(nuevo);  
            }
            catch (FallaEnInsercion ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
            catch(ExcepcionDeDatos ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
        }
    }
}
