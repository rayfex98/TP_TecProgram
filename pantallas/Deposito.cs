using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pantallas
{
    public partial class Deposito : Form
    {
        readonly NStock bllStock = new NStock();
        readonly NProducto bllProducto = new NProducto();
        readonly NDeposito blldeposito = new NDeposito();
        public Deposito()
        {
            InitializeComponent();
        }
        private void Deposito_Load(object sender, EventArgs e)
        {
            bllProducto.CargarLista();
            cmboxProductos.DataSource = bllProducto.RecuperarProductos();
            cmboxProductos.DisplayMember = "Nombre";
            cmboxProductos.ValueMember = "ID";

            dtgvStock.DataSource = blldeposito.RecuperarDeposito();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (chkConfirma.Checked || int.Parse(tboxcantidad.Text) <= 0)
            {
                bllStock.AgregarStock((int)cmboxProductos.SelectedValue, int.Parse(tboxcantidad.Text));
                tboxcantidad.Text = "";
                chkConfirma.CheckState = 0;
                dtgvStock.DataSource = null;
                dtgvStock.DataSource = blldeposito.RecuperarDeposito();
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            if (chkConfirma.Checked || int.Parse(tboxcantidad.Text) <= 0)
            {
                bllStock.RestarStock((int)cmboxProductos.SelectedValue, int.Parse(tboxcantidad.Text));
                tboxcantidad.Text = "";
                chkConfirma.CheckState = 0;
                dtgvStock.DataSource = null;
                dtgvStock.DataSource = blldeposito.RecuperarDeposito();
            }

        }
    }
}
