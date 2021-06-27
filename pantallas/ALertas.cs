using BLL;
using Entidades;
using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pantallas
{
    public partial class ALertas : Form
    {
        public ALertas()
        {
            InitializeComponent();
        }
        private void CargaDGV()
        {
            NAlerta bllAlerta = new NAlerta();
            dtgvAlerta.DataSource = null;
            try
            {
                dtgvAlerta.DataSource = bllAlerta.RecuperarAlerta();
            }
            catch (NoEncontrado ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
        }
        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            NAlerta bllAlerta = new NAlerta();
            Alerta _unAlerta = new Alerta
            {
                Stock = new Stock
                {
                    ID = int.Parse(tboxStock.Text)
                },
                UsuarioCreador = new Usuario
                {
                    ID = 1 //HARDCODE: Usuario
                },
                CantidadMinima = int.Parse(tboxCantidad.Text)
            };
            bllAlerta.CrearAlerta(_unAlerta);
            CargaDGV();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            CargaDGV();
        }
    }
}
