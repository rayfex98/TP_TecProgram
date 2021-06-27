
namespace pantallas
{
    partial class Deposito
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
            this.dtgvStock = new System.Windows.Forms.DataGridView();
            this.tboxcantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboxProductos = new System.Windows.Forms.ComboBox();
            this.btnRestar = new System.Windows.Forms.Button();
            this.chkConfirma = new System.Windows.Forms.CheckBox();
            this.Cantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvStock
            // 
            this.dtgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvStock.Location = new System.Drawing.Point(53, 120);
            this.dtgvStock.Name = "dtgvStock";
            this.dtgvStock.RowTemplate.Height = 25;
            this.dtgvStock.Size = new System.Drawing.Size(801, 372);
            this.dtgvStock.TabIndex = 4;
            // 
            // tboxcantidad
            // 
            this.tboxcantidad.Location = new System.Drawing.Point(125, 30);
            this.tboxcantidad.Name = "tboxcantidad";
            this.tboxcantidad.Size = new System.Drawing.Size(81, 23);
            this.tboxcantidad.TabIndex = 7;
            this.tboxcantidad.Tag = "";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(336, 29);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar Stock";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 9;
            // 
            // cmboxProductos
            // 
            this.cmboxProductos.FormattingEnabled = true;
            this.cmboxProductos.Location = new System.Drawing.Point(53, 66);
            this.cmboxProductos.Name = "cmboxProductos";
            this.cmboxProductos.Size = new System.Drawing.Size(153, 23);
            this.cmboxProductos.TabIndex = 10;
            this.cmboxProductos.Text = "Productos";
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(336, 66);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(104, 23);
            this.btnRestar.TabIndex = 11;
            this.btnRestar.Text = "Restar Stock";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // chkConfirma
            // 
            this.chkConfirma.AutoSize = true;
            this.chkConfirma.Location = new System.Drawing.Point(250, 33);
            this.chkConfirma.Name = "chkConfirma";
            this.chkConfirma.Size = new System.Drawing.Size(80, 19);
            this.chkConfirma.TabIndex = 13;
            this.chkConfirma.Text = "Confirmar";
            this.chkConfirma.UseVisualStyleBackColor = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSize = true;
            this.Cantidad.Location = new System.Drawing.Point(64, 33);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Size = new System.Drawing.Size(58, 15);
            this.Cantidad.TabIndex = 14;
            this.Cantidad.Text = "Cantidad:";
            // 
            // Deposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 540);
            this.Controls.Add(this.Cantidad);
            this.Controls.Add(this.chkConfirma);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.cmboxProductos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tboxcantidad);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtgvStock);
            this.Name = "Deposito";
            this.Text = "Deposito";
            this.Load += new System.EventHandler(this.Deposito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgvStock;
        private System.Windows.Forms.TextBox tboxcantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboxProductos;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.CheckBox chkConfirma;
        private System.Windows.Forms.Label Cantidad;
    }
}