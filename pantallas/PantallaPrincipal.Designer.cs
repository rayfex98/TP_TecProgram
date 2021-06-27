
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
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.dtgvProveedores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvBuscarProducto = new System.Windows.Forms.DataGridView();
            this.btnHacerOrden = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.BtnAgregarCategoria = new System.Windows.Forms.Button();
            this.BtnAgregarProveedor = new System.Windows.Forms.Button();
            this.BtnListarOrdenesCompra = new System.Windows.Forms.Button();
            this.BtnVerDeposito = new System.Windows.Forms.Button();
            this.BtnVerAlertas = new System.Windows.Forms.Button();
            this.BtnAlertasCriticas = new System.Windows.Forms.Button();
            this.cmboxProvincias = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBuscarProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Categorias";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(479, 213);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 23);
            this.cmbProducto.TabIndex = 7;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(654, 213);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(136, 23);
            this.cmbCategoria.TabIndex = 8;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Proveedores";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(12, 213);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(168, 23);
            this.cmbProveedor.TabIndex = 10;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            // 
            // dtgvProveedores
            // 
            this.dtgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProveedores.Location = new System.Drawing.Point(12, 242);
            this.dtgvProveedores.Name = "dtgvProveedores";
            this.dtgvProveedores.RowTemplate.Height = 25;
            this.dtgvProveedores.Size = new System.Drawing.Size(346, 150);
            this.dtgvProveedores.TabIndex = 11;
            this.dtgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvProveedores_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Buscar proveedor por provincia";
            // 
            // dtgvBuscarProducto
            // 
            this.dtgvBuscarProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBuscarProducto.Location = new System.Drawing.Point(384, 242);
            this.dtgvBuscarProducto.Name = "dtgvBuscarProducto";
            this.dtgvBuscarProducto.RowTemplate.Height = 25;
            this.dtgvBuscarProducto.Size = new System.Drawing.Size(416, 150);
            this.dtgvBuscarProducto.TabIndex = 14;
            // 
            // btnHacerOrden
            // 
            this.btnHacerOrden.Location = new System.Drawing.Point(39, 26);
            this.btnHacerOrden.Name = "btnHacerOrden";
            this.btnHacerOrden.Size = new System.Drawing.Size(145, 25);
            this.btnHacerOrden.TabIndex = 18;
            this.btnHacerOrden.Text = "Hacer orden compra";
            this.btnHacerOrden.UseVisualStyleBackColor = true;
            this.btnHacerOrden.Click += new System.EventHandler(this.btnHacerOrden_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(221, 26);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(152, 25);
            this.btnAgregarProducto.TabIndex = 20;
            this.btnAgregarProducto.Text = "Agregar  producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // BtnAgregarCategoria
            // 
            this.BtnAgregarCategoria.Location = new System.Drawing.Point(221, 80);
            this.BtnAgregarCategoria.Name = "BtnAgregarCategoria";
            this.BtnAgregarCategoria.Size = new System.Drawing.Size(152, 25);
            this.BtnAgregarCategoria.TabIndex = 21;
            this.BtnAgregarCategoria.Text = "Agregar categoria";
            this.BtnAgregarCategoria.UseVisualStyleBackColor = true;
            this.BtnAgregarCategoria.Click += new System.EventHandler(this.BtnAgregarCategoria_Click);
            // 
            // BtnAgregarProveedor
            // 
            this.BtnAgregarProveedor.AccessibleName = "BtnAgregarProveedor";
            this.BtnAgregarProveedor.Location = new System.Drawing.Point(437, 80);
            this.BtnAgregarProveedor.Name = "BtnAgregarProveedor";
            this.BtnAgregarProveedor.Size = new System.Drawing.Size(145, 25);
            this.BtnAgregarProveedor.TabIndex = 22;
            this.BtnAgregarProveedor.Text = "Agregar proveedor";
            this.BtnAgregarProveedor.UseVisualStyleBackColor = true;
            this.BtnAgregarProveedor.Click += new System.EventHandler(this.BtnAgregarProveedor_Click);
            // 
            // BtnListarOrdenesCompra
            // 
            this.BtnListarOrdenesCompra.Location = new System.Drawing.Point(39, 80);
            this.BtnListarOrdenesCompra.Name = "BtnListarOrdenesCompra";
            this.BtnListarOrdenesCompra.Size = new System.Drawing.Size(152, 25);
            this.BtnListarOrdenesCompra.TabIndex = 23;
            this.BtnListarOrdenesCompra.Text = "listar ordenes compra ";
            this.BtnListarOrdenesCompra.UseVisualStyleBackColor = true;
            this.BtnListarOrdenesCompra.Click += new System.EventHandler(this.BtnListarOrdenesCompra_Click);
            // 
            // BtnVerDeposito
            // 
            this.BtnVerDeposito.Location = new System.Drawing.Point(437, 26);
            this.BtnVerDeposito.Name = "BtnVerDeposito";
            this.BtnVerDeposito.Size = new System.Drawing.Size(152, 25);
            this.BtnVerDeposito.TabIndex = 24;
            this.BtnVerDeposito.Text = "ver deposito";
            this.BtnVerDeposito.UseVisualStyleBackColor = true;
            this.BtnVerDeposito.Click += new System.EventHandler(this.BtnVerDeposito_Click);
            // 
            // BtnVerAlertas
            // 
            this.BtnVerAlertas.Location = new System.Drawing.Point(638, 26);
            this.BtnVerAlertas.Name = "BtnVerAlertas";
            this.BtnVerAlertas.Size = new System.Drawing.Size(152, 25);
            this.BtnVerAlertas.TabIndex = 25;
            this.BtnVerAlertas.Text = "ver alertas";
            this.BtnVerAlertas.UseVisualStyleBackColor = true;
            this.BtnVerAlertas.Click += new System.EventHandler(this.BtnVerAlertas_Click);
            // 
            // BtnAlertasCriticas
            // 
            this.BtnAlertasCriticas.Location = new System.Drawing.Point(638, 80);
            this.BtnAlertasCriticas.Name = "BtnAlertasCriticas";
            this.BtnAlertasCriticas.Size = new System.Drawing.Size(152, 25);
            this.BtnAlertasCriticas.TabIndex = 26;
            this.BtnAlertasCriticas.Text = "alertas criticas";
            this.BtnAlertasCriticas.UseVisualStyleBackColor = true;
            this.BtnAlertasCriticas.Click += new System.EventHandler(this.BtnAlertasCriticas_Click);
            // 
            // cmboxProvincias
            // 
            this.cmboxProvincias.FormattingEnabled = true;
            this.cmboxProvincias.Location = new System.Drawing.Point(186, 213);
            this.cmboxProvincias.Name = "cmboxProvincias";
            this.cmboxProvincias.Size = new System.Drawing.Size(172, 23);
            this.cmboxProvincias.TabIndex = 27;
            this.cmboxProvincias.SelectedIndexChanged += new System.EventHandler(this.cmboxProvincias_SelectedIndexChanged);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.cmboxProvincias);
            this.Controls.Add(this.BtnAlertasCriticas);
            this.Controls.Add(this.BtnVerAlertas);
            this.Controls.Add(this.BtnVerDeposito);
            this.Controls.Add(this.BtnListarOrdenesCompra);
            this.Controls.Add(this.BtnAgregarProveedor);
            this.Controls.Add(this.BtnAgregarCategoria);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnHacerOrden);
            this.Controls.Add(this.dtgvBuscarProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgvProveedores);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "PantallaPrincipal";
            this.Text = "pantalla principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBuscarProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.DataGridView dtgvProveedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvBuscarProducto;
        private System.Windows.Forms.Button btnHacerOrden;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button BtnAgregarCategoria;
        private System.Windows.Forms.Button BtnAgregarProveedor;
        private System.Windows.Forms.Button BtnListarOrdenesCompra;
        private System.Windows.Forms.Button BtnVerDeposito;
        private System.Windows.Forms.Button BtnVerAlertas;
        private System.Windows.Forms.Button BtnAlertasCriticas;
        private System.Windows.Forms.ComboBox cmboxProvincias;
    }
}

