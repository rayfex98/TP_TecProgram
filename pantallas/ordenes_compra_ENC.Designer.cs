
using System;

namespace pantallas
{
    partial class ordenes_compra_ENC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tboxCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvProductos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cboxProveedor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerarOrden = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(403, 97);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(96, 25);
            this.btnAgregar.TabIndex = 23;
            this.btnAgregar.Text = "agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // tboxCantidad
            // 
            this.tboxCantidad.Location = new System.Drawing.Point(67, 99);
            this.tboxCantidad.Name = "tboxCantidad";
            this.tboxCantidad.Size = new System.Drawing.Size(102, 23);
            this.tboxCantidad.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "cantidad ";
            // 
            // dtgvProductos
            // 
            this.dtgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Categoria,
            this.Cantidad,
            this.Precio_unitario,
            this.Precio_total});
            this.dtgvProductos.Location = new System.Drawing.Point(70, 146);
            this.dtgvProductos.Name = "dtgvProductos";
            this.dtgvProductos.RowTemplate.Height = 25;
            this.dtgvProductos.Size = new System.Drawing.Size(544, 150);
            this.dtgvProductos.TabIndex = 20;
            this.dtgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "producto ";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(229, 99);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(121, 23);
            this.cmbProducto.TabIndex = 25;
            this.cmbProducto.Text = "productos ";
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // cboxProveedor
            // 
            this.cboxProveedor.FormattingEnabled = true;
            this.cboxProveedor.Location = new System.Drawing.Point(70, 369);
            this.cboxProveedor.Name = "cboxProveedor";
            this.cboxProveedor.Size = new System.Drawing.Size(121, 23);
            this.cboxProveedor.TabIndex = 26;
            this.cboxProveedor.Text = "proveedor ";
            this.cboxProveedor.SelectedIndexChanged += new System.EventHandler(this.cboxProveedor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "proveedor ";
            // 
            // btnGenerarOrden
            // 
            this.btnGenerarOrden.Location = new System.Drawing.Point(355, 369);
            this.btnGenerarOrden.Name = "btnGenerarOrden";
            this.btnGenerarOrden.Size = new System.Drawing.Size(96, 25);
            this.btnGenerarOrden.TabIndex = 28;
            this.btnGenerarOrden.Text = "generar orden ";
            this.btnGenerarOrden.UseVisualStyleBackColor = true;
            this.btnGenerarOrden.Click += new System.EventHandler(this.btnGenerarOrden_Click);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Precio_unitario
            // 
            this.Precio_unitario.HeaderText = "Precio unitario";
            this.Precio_unitario.Name = "Precio_unitario";
            // 
            // Precio_total
            // 
            this.Precio_total.HeaderText = "Precio total";
            this.Precio_total.Name = "Precio_total";
            // 
            // ordenes_compra_ENC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerarOrden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboxProveedor);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.tboxCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgvProductos);
            this.Name = "ordenes_compra_ENC";
            this.Text = "Orden de compra";
            this.Load += new System.EventHandler(this.ordenes_compra_ENC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox tboxCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cboxProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerarOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_total;
    }
}