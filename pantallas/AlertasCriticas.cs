using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excepciones;

namespace pantallas
{
    public partial class AlertasCriticas : Form
    {
        public AlertasCriticas()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AlertaCritica_Load(object sender, EventArgs e)
        {
            NAlerta bllAlerta = new NAlerta();
            dtgvAlertaCritica.DataSource = null;
            try
            {
                dtgvAlertaCritica.DataSource = bllAlerta.RecuperarAlertasCriticas();
            }
            catch (NoEncontrado ex)
            {
                MessageBox.Show(ex.Descripcion);
            }
        }
    }
}
