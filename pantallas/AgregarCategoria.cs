using System;
using System.Windows.Forms;
using BLL;
using Excepciones;

namespace pantallas
{
    public partial class AgregarCategoria : Form
    {
        public AgregarCategoria()
        {
            InitializeComponent();
        }

        private void btnAgregaCategoria_Click(object sender, EventArgs e)
        {
            NCategoria bllCategoria = new NCategoria();
            try
            {
                if (bllCategoria.AgregarCategoria(txboxAgregaCategoria.Text))
                {
                    MessageBox.Show("Categoria agregada con exito!");
                }
            }
            catch (FallaEnInsercion ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
        }
    }
}
