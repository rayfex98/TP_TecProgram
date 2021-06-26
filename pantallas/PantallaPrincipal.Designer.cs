
namespace pantallas
{
    partial class PantallaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dtbvProveedoresProvincia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbBuscarPorProvincia = new System.Windows.Forms.TextBox();
            this.dtgvBuscarProductoPorCategoria = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txbBuscarProductoPorcategoria = new System.Windows.Forms.TextBox();
            this.BtnBuscarProductoPorCategoria = new System.Windows.Forms.Button();
            this.btnHacerOrden = new System.Windows.Forms.Button();
            this.BtnBuscarPorProvincia = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.BtnAgregarCategoria = new System.Windows.Forms.Button();
            this.BtnAgregarProveedor = new System.Windows.Forms.Button();
            this.BtnListarOrdenesCompra = new System.Windows.Forms.Button();
            this.BtnVerDeposito = new System.Windows.Forms.Button();
            this.BtnVerAlertas = new System.Windows.Forms.Button();
            this.BtnAlertasCriticas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtbvProveedoresProvincia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBuscarProductoPorCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "categoria";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(48, 56);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 23);
            this.cmbProducto.TabIndex = 7;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(215, 56);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(136, 23);
            this.comboBox2.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "proveedores";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(432, 56);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(178, 23);
            this.comboBox3.TabIndex = 10;
            // 
            // dtbvProveedoresProvincia
            // 
            this.dtbvProveedoresProvincia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbvProveedoresProvincia.Location = new System.Drawing.Point(39, 242);
            this.dtbvProveedoresProvincia.Name = "dtbvProveedoresProvincia";
            this.dtbvProveedoresProvincia.RowTemplate.Height = 25;
            this.dtbvProveedoresProvincia.Size = new System.Drawing.Size(240, 150);
            this.dtbvProveedoresProvincia.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Buscar proveedor por provincia";
            // 
            // TxbBuscarPorProvincia
            // 
            this.TxbBuscarPorProvincia.Location = new System.Drawing.Point(36, 195);
            this.TxbBuscarPorProvincia.Name = "TxbBuscarPorProvincia";
            this.TxbBuscarPorProvincia.Size = new System.Drawing.Size(243, 23);
            this.TxbBuscarPorProvincia.TabIndex = 13;
            // 
            // dtgvBuscarProductoPorCategoria
            // 
            this.dtgvBuscarProductoPorCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBuscarProductoPorCategoria.Location = new System.Drawing.Point(341, 242);
            this.dtgvBuscarProductoPorCategoria.Name = "dtgvBuscarProductoPorCategoria";
            this.dtgvBuscarProductoPorCategoria.RowTemplate.Height = 25;
            this.dtgvBuscarProductoPorCategoria.Size = new System.Drawing.Size(371, 150);
            this.dtgvBuscarProductoPorCategoria.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "buscar producto por categoria";
            // 
            // txbBuscarProductoPorcategoria
            // 
            this.txbBuscarProductoPorcategoria.Location = new System.Drawing.Point(341, 195);
            this.txbBuscarProductoPorcategoria.Name = "txbBuscarProductoPorcategoria";
            this.txbBuscarProductoPorcategoria.Size = new System.Drawing.Size(240, 23);
            this.txbBuscarProductoPorcategoria.TabIndex = 16;
            // 
            // BtnBuscarProductoPorCategoria
            // 
            this.BtnBuscarProductoPorCategoria.Location = new System.Drawing.Point(517, 150);
            this.BtnBuscarProductoPorCategoria.Name = "BtnBuscarProductoPorCategoria";
            this.BtnBuscarProductoPorCategoria.Size = new System.Drawing.Size(64, 25);
            this.BtnBuscarProductoPorCategoria.TabIndex = 17;
            this.BtnBuscarProductoPorCategoria.Text = "buscar";
            this.BtnBuscarProductoPorCategoria.UseVisualStyleBackColor = true;
            this.BtnBuscarProductoPorCategoria.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnHacerOrden
            // 
            this.btnHacerOrden.Location = new System.Drawing.Point(648, 38);
            this.btnHacerOrden.Name = "btnHacerOrden";
            this.btnHacerOrden.Size = new System.Drawing.Size(131, 25);
            this.btnHacerOrden.TabIndex = 18;
            this.btnHacerOrden.Text = "Hacer orden compra";
            this.btnHacerOrden.UseVisualStyleBackColor = true;
            this.btnHacerOrden.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnBuscarPorProvincia
            // 
            this.BtnBuscarPorProvincia.Location = new System.Drawing.Point(223, 153);
            this.BtnBuscarPorProvincia.Name = "BtnBuscarPorProvincia";
            this.BtnBuscarPorProvincia.Size = new System.Drawing.Size(64, 25);
            this.BtnBuscarPorProvincia.TabIndex = 19;
            this.BtnBuscarPorProvincia.Text = "buscar";
            this.BtnBuscarPorProvincia.UseVisualStyleBackColor = true;
            this.BtnBuscarPorProvincia.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(48, 94);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(128, 25);
            this.btnAgregarProducto.TabIndex = 20;
            this.btnAgregarProducto.Text = "Agregar  producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnAgregarCategoria
            // 
            this.BtnAgregarCategoria.Location = new System.Drawing.Point(215, 94);
            this.BtnAgregarCategoria.Name = "BtnAgregarCategoria";
            this.BtnAgregarCategoria.Size = new System.Drawing.Size(136, 25);
            this.BtnAgregarCategoria.TabIndex = 21;
            this.BtnAgregarCategoria.Text = "Agregar categoria";
            this.BtnAgregarCategoria.UseVisualStyleBackColor = true;
            this.BtnAgregarCategoria.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnAgregarProveedor
            // 
            this.BtnAgregarProveedor.Location = new System.Drawing.Point(432, 94);
            this.BtnAgregarProveedor.Name = "BtnAgregarProveedor";
            this.BtnAgregarProveedor.Size = new System.Drawing.Size(178, 25);
            this.BtnAgregarProveedor.TabIndex = 22;
            this.BtnAgregarProveedor.Text = "Agregar proveedor";
            this.BtnAgregarProveedor.UseVisualStyleBackColor = true;
            this.BtnAgregarProveedor.Click += new System.EventHandler(this.button6_Click);
            // 
            // BtnListarOrdenesCompra
            // 
            this.BtnListarOrdenesCompra.Location = new System.Drawing.Point(648, 80);
            this.BtnListarOrdenesCompra.Name = "BtnListarOrdenesCompra";
            this.BtnListarOrdenesCompra.Size = new System.Drawing.Size(152, 25);
            this.BtnListarOrdenesCompra.TabIndex = 23;
            this.BtnListarOrdenesCompra.Text = "listar ordenes compra ";
            this.BtnListarOrdenesCompra.UseVisualStyleBackColor = true;
            this.BtnListarOrdenesCompra.Click += new System.EventHandler(this.button7_Click);
            // 
            // BtnVerDeposito
            // 
            this.BtnVerDeposito.Location = new System.Drawing.Point(648, 122);
            this.BtnVerDeposito.Name = "BtnVerDeposito";
            this.BtnVerDeposito.Size = new System.Drawing.Size(152, 25);
            this.BtnVerDeposito.TabIndex = 24;
            this.BtnVerDeposito.Text = "ver deposito";
            this.BtnVerDeposito.UseVisualStyleBackColor = true;
            this.BtnVerDeposito.Click += new System.EventHandler(this.button8_Click);
            // 
            // BtnVerAlertas
            // 
            this.BtnVerAlertas.Location = new System.Drawing.Point(648, 162);
            this.BtnVerAlertas.Name = "BtnVerAlertas";
            this.BtnVerAlertas.Size = new System.Drawing.Size(152, 25);
            this.BtnVerAlertas.TabIndex = 25;
            this.BtnVerAlertas.Text = "ver alertas";
            this.BtnVerAlertas.UseVisualStyleBackColor = true;
            this.BtnVerAlertas.Click += new System.EventHandler(this.button9_Click);
            // 
            // BtnAlertasCriticas
            // 
            this.BtnAlertasCriticas.Location = new System.Drawing.Point(648, 195);
            this.BtnAlertasCriticas.Name = "BtnAlertasCriticas";
            this.BtnAlertasCriticas.Size = new System.Drawing.Size(152, 25);
            this.BtnAlertasCriticas.TabIndex = 26;
            this.BtnAlertasCriticas.Text = "alertas criticas";
            this.BtnAlertasCriticas.UseVisualStyleBackColor = true;
            this.BtnAlertasCriticas.Click += new System.EventHandler(this.button10_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.BtnAlertasCriticas);
            this.Controls.Add(this.BtnVerAlertas);
            this.Controls.Add(this.BtnVerDeposito);
            this.Controls.Add(this.BtnListarOrdenesCompra);
            this.Controls.Add(this.BtnAgregarProveedor);
            this.Controls.Add(this.BtnAgregarCategoria);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.BtnBuscarPorProvincia);
            this.Controls.Add(this.btnHacerOrden);
            this.Controls.Add(this.BtnBuscarProductoPorCategoria);
            this.Controls.Add(this.txbBuscarProductoPorcategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgvBuscarProductoPorCategoria);
            this.Controls.Add(this.TxbBuscarPorProvincia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtbvProveedoresProvincia);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "PantallaPrincipal";
            this.Text = "pantalla principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbvProveedoresProvincia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBuscarProductoPorCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridView dtbvProveedoresProvincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxbBuscarPorProvincia;
        private System.Windows.Forms.DataGridView dtgvBuscarProductoPorCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbBuscarProductoPorcategoria;
        private System.Windows.Forms.Button BtnBuscarProductoPorCategoria;
        private System.Windows.Forms.Button btnHacerOrden;
        private System.Windows.Forms.Button BtnBuscarPorProvincia;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button BtnAgregarCategoria;
        private System.Windows.Forms.Button BtnAgregarProveedor;
        private System.Windows.Forms.Button BtnListarOrdenesCompra;
        private System.Windows.Forms.Button BtnVerDeposito;
        private System.Windows.Forms.Button BtnVerAlertas;
        private System.Windows.Forms.Button BtnAlertasCriticas;
    }
}

