
namespace pantallas
{
    partial class ordenes_compra_GER
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
            this.btnTodas = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.btpPendientes = new System.Windows.Forms.Button();
            this.cmboxPendientes = new System.Windows.Forms.ComboBox();
            this.btnHabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTodas
            // 
            this.btnTodas.Location = new System.Drawing.Point(16, 26);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(112, 23);
            this.btnTodas.TabIndex = 2;
            this.btnTodas.Text = "Mostrar Todas ";
            this.btnTodas.UseVisualStyleBackColor = true;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(12, 82);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowTemplate.Height = 25;
            this.dgvOrdenes.Size = new System.Drawing.Size(535, 239);
            this.dgvOrdenes.TabIndex = 5;
            // 
            // btpPendientes
            // 
            this.btpPendientes.Location = new System.Drawing.Point(134, 26);
            this.btpPendientes.Name = "btpPendientes";
            this.btpPendientes.Size = new System.Drawing.Size(114, 23);
            this.btpPendientes.TabIndex = 10;
            this.btpPendientes.Text = "Pendientes";
            this.btpPendientes.UseVisualStyleBackColor = true;
            this.btpPendientes.Click += new System.EventHandler(this.btpPendientes_Click);
            // 
            // cmboxPendientes
            // 
            this.cmboxPendientes.FormattingEnabled = true;
            this.cmboxPendientes.Location = new System.Drawing.Point(302, 26);
            this.cmboxPendientes.Name = "cmboxPendientes";
            this.cmboxPendientes.Size = new System.Drawing.Size(133, 23);
            this.cmboxPendientes.TabIndex = 11;
            this.cmboxPendientes.Text = "Pendientes";
            this.cmboxPendientes.SelectedIndexChanged += new System.EventHandler(this.cmboxPendientes_SelectedIndexChanged);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(460, 25);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(75, 23);
            this.btnHabilitar.TabIndex = 12;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // ordenes_compra_GER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 356);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.cmboxPendientes);
            this.Controls.Add(this.btpPendientes);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnTodas);
            this.Name = "ordenes_compra_GER";
            this.Text = "Ordenes de compra ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btpPendientes;
        private System.Windows.Forms.ComboBox cmboxPendientes;
        private System.Windows.Forms.Button btnHabilitar;
    }
}