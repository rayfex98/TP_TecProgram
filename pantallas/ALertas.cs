using BLL;
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

        private void Form6_Load(object sender, EventArgs e)
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
    }
}
