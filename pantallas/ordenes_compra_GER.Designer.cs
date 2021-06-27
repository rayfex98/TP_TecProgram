
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
            this.cmboxTodas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTodas
            // 
            this.btnTodas.Location = new System.Drawing.Point(36, 24);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(134, 23);
            this.btnTodas.TabIndex = 2;
            this.btnTodas.Text = "Mostrar Todas ";
            this.btnTodas.UseVisualStyleBackColor = true;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(19, 82);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowTemplate.Height = 25;
            this.dgvOrdenes.Size = new System.Drawing.Size(732, 277);
            this.dgvOrdenes.TabIndex = 5;
            // 
            // btpPendientes
            // 
            this.btpPendientes.Location = new System.Drawing.Point(36, 53);
            this.btpPendientes.Name = "btpPendientes";
            this.btpPendientes.Size = new System.Drawing.Size(134, 23);
            this.btpPendientes.TabIndex = 10;
            this.btpPendientes.Text = "Mostrar Pendientes";
            this.btpPendientes.UseVisualStyleBackColor = true;
            this.btpPendientes.Click += new System.EventHandler(this.btpPendientes_Click);
            // 
            // cmboxPendientes
            // 
            this.cmboxPendientes.FormattingEnabled = true;
            this.cmboxPendientes.Location = new System.Drawing.Point(405, 53);
            this.cmboxPendientes.Name = "cmboxPendientes";
            this.cmboxPendientes.Size = new System.Drawing.Size(117, 23);
            this.cmboxPendientes.TabIndex = 11;
            this.cmboxPendientes.Text = "Pendientes";
            this.cmboxPendientes.SelectedIndexChanged += new System.EventHandler(this.cmboxPendientes_SelectedIndexChanged);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(538, 35);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(75, 40);
            this.btnHabilitar.TabIndex = 12;
            this.btnHabilitar.Text = "Habilitar Pendiente";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // cmboxTodas
            // 
            this.cmboxTodas.FormattingEnabled = true;
            this.cmboxTodas.Location = new System.Drawing.Point(259, 53);
            this.cmboxTodas.Name = "cmboxTodas";
            this.cmboxTodas.Size = new System.Drawing.Size(121, 23);
            this.cmboxTodas.TabIndex = 13;
            this.cmboxTodas.Text = "Ordenes";
            this.cmboxTodas.SelectedIndexChanged += new System.EventHandler(this.cmboxTodas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Detalles de:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Detalles de:";
            // 
            // tboxTotal
            // 
            this.tboxTotal.Location = new System.Drawing.Point(662, 52);
            this.tboxTotal.Name = "tboxTotal";
            this.tboxTotal.ReadOnly = true;
            this.tboxTotal.Size = new System.Drawing.Size(89, 23);
            this.tboxTotal.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Total Orden:";
            // 
            // ordenes_compra_GER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 384);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tboxTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboxTodas);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.cmboxPendientes);
            this.Controls.Add(this.btpPendientes);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.btnTodas);
            this.Name = "ordenes_compra_GER";
            this.Text = "Ordenes de compra ";
            this.Load += new System.EventHandler(this.ordenes_compra_GER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.Button btpPendientes;
        private System.Windows.Forms.ComboBox cmboxPendientes;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.ComboBox cmboxTodas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxTotal;
        private System.Windows.Forms.Label label3;
    }
}