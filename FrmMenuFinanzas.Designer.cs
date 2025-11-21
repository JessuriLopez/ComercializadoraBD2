namespace ComercializadoraBD2
{
    partial class FrmMenuFinanzas
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
            this.btnCuentasBancarias = new System.Windows.Forms.Button();
            this.btnDepósitosBancarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCuentasBancarias
            // 
            this.btnCuentasBancarias.Location = new System.Drawing.Point(140, 69);
            this.btnCuentasBancarias.Name = "btnCuentasBancarias";
            this.btnCuentasBancarias.Size = new System.Drawing.Size(227, 258);
            this.btnCuentasBancarias.TabIndex = 0;
            this.btnCuentasBancarias.Text = "Cuentas Bancarias";
            this.btnCuentasBancarias.UseVisualStyleBackColor = true;
            this.btnCuentasBancarias.Click += new System.EventHandler(this.btnCuentasBancarias_Click);
            // 
            // btnDepósitosBancarios
            // 
            this.btnDepósitosBancarios.Location = new System.Drawing.Point(438, 69);
            this.btnDepósitosBancarios.Name = "btnDepósitosBancarios";
            this.btnDepósitosBancarios.Size = new System.Drawing.Size(227, 258);
            this.btnDepósitosBancarios.TabIndex = 1;
            this.btnDepósitosBancarios.Text = "Depósitos Bancarios";
            this.btnDepósitosBancarios.UseVisualStyleBackColor = true;
            this.btnDepósitosBancarios.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmMenuFinanzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 448);
            this.Controls.Add(this.btnDepósitosBancarios);
            this.Controls.Add(this.btnCuentasBancarias);
            this.Name = "FrmMenuFinanzas";
            this.Text = "FrmMenuFinanzas";
            this.Load += new System.EventHandler(this.FrmMenuFinanzas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCuentasBancarias;
        private System.Windows.Forms.Button btnDepósitosBancarios;
    }
}