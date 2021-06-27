
namespace pantallas
{
    partial class AgregarProducto
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboxCategoria = new System.Windows.Forms.ComboBox();
            this.tboxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tboxPrecioVenta = new System.Windows.Forms.TextBox();
            this.tboxPrecioCompra = new System.Windows.Forms.TextBox();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "agregar categoria";
            // 
            // cmboxCategoria
            // 
            this.cmboxCategoria.FormattingEnabled = true;
            this.cmboxCategoria.Location = new System.Drawing.Point(17, 59);
            this.cmboxCategoria.Name = "cmboxCategoria";
            this.cmboxCategoria.Size = new System.Drawing.Size(121, 23);
            this.cmboxCategoria.TabIndex = 2;
            this.cmboxCategoria.Text = "categorias";
            // 
            // tboxNombre
            // 
            this.tboxNombre.Location = new System.Drawing.Point(17, 133);
            this.tboxNombre.Name = "tboxNombre";
            this.tboxNombre.Size = new System.Drawing.Size(151, 23);
            this.tboxNombre.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "precio de compra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "precio de venta";
            // 
            // tboxPrecioVenta
            // 
            this.tboxPrecioVenta.Location = new System.Drawing.Point(196, 133);
            this.tboxPrecioVenta.Name = "tboxPrecioVenta";
            this.tboxPrecioVenta.Size = new System.Drawing.Size(151, 23);
            this.tboxPrecioVenta.TabIndex = 6;
            // 
            // tboxPrecioCompra
            // 
            this.tboxPrecioCompra.Location = new System.Drawing.Point(196, 59);
            this.tboxPrecioCompra.Name = "tboxPrecioCompra";
            this.tboxPrecioCompra.Size = new System.Drawing.Size(151, 23);
            this.tboxPrecioCompra.TabIndex = 7;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(388, 132);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarProducto.TabIndex = 8;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // AgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 200);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.tboxPrecioCompra);
            this.Controls.Add(this.tboxPrecioVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmboxCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxNombre);
            this.Name = "AgregarProducto";
            this.Text = "Agregar producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboxCategoria;
        private System.Windows.Forms.TextBox tboxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboxPrecioVenta;
        private System.Windows.Forms.TextBox tboxPrecioCompra;
        private System.Windows.Forms.Button btnAgregarProducto;
    }
}