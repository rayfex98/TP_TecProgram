
namespace pantallas
{
    partial class AgregarCategoria
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
            this.txboxAgregaCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregaCategoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txboxAgregaCategoria
            // 
            this.txboxAgregaCategoria.Location = new System.Drawing.Point(44, 86);
            this.txboxAgregaCategoria.Name = "txboxAgregaCategoria";
            this.txboxAgregaCategoria.Size = new System.Drawing.Size(160, 23);
            this.txboxAgregaCategoria.TabIndex = 0;
            this.txboxAgregaCategoria.Text = "Inserte Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // btnAgregaCategoria
            // 
            this.btnAgregaCategoria.Location = new System.Drawing.Point(129, 57);
            this.btnAgregaCategoria.Name = "btnAgregaCategoria";
            this.btnAgregaCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregaCategoria.TabIndex = 2;
            this.btnAgregaCategoria.Text = "Agregar";
            this.btnAgregaCategoria.UseVisualStyleBackColor = true;
            this.btnAgregaCategoria.Click += new System.EventHandler(this.btnAgregaCategoria_Click);
            // 
            // AgregarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 168);
            this.Controls.Add(this.btnAgregaCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txboxAgregaCategoria);
            this.Name = "AgregarCategoria";
            this.Text = "Agregar categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txboxAgregaCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregaCategoria;
    }
}