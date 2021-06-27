using BLL;
using Excepciones;
using System;
using System.Windows.Forms;

namespace pantallas
{
    public partial class ordenes_compra_GER : Form
    {
        /// <summary>
        /// VER QUE HACER CON VARIABLE USUARIO
        /// </summary>
        int usuario = 1; 
        NDetalleOrden blldetalle = new NDetalleOrden();
        NOrdenCompra bllCompra = new NOrdenCompra();
        bool combo = true;
        public ordenes_compra_GER()
        {
            InitializeComponent();
            CargaCmbBoxPendiente();
        }

        private void CargaCmbBoxPendiente()
        {
            cmboxPendientes.DataSource = null;
            cmboxPendientes.DataSource = bllCompra.RecuperarOrdenPendiente();
            cmboxPendientes.DisplayMember = "Orden";
            cmboxPendientes.ValueMember = "Orden";
        }
        private void btnTodas_Click(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = null;
            try
            {
                dgvOrdenes.DataSource = bllCompra.RecuperarOrdenCompra();
            }
            catch (NoEncontrado ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
        }

        private void cmboxPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo)
            {
                combo = false;
                return;
            }
            dgvOrdenes.DataSource = null;
            try
            {
                dgvOrdenes.DataSource = blldetalle.RecuperarDetalleOrden((int)cmboxPendientes.SelectedValue);
            }
            catch(NoEncontrado)
            {
                MessageBox.Show("Orden Sin Detalles");
            }
            catch (NullReferenceException)
            {
            }
        }

        private void btpPendientes_Click(object sender, EventArgs e)
        {
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = bllCompra.RecuperarOrdenPendiente();
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            int id = (int)cmboxPendientes.SelectedValue;
            try
            {
                bllCompra.AprobarOrden(id, usuario);
            }
            catch (ExcepcionDeDatos ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
            catch (FallaEnEdicion ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
            finally
            {
                CargaCmbBoxPendiente();
            }
        }
    }
}
