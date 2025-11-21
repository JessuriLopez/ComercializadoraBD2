namespace ComercializadoraBD2
{
    partial class FrmInicioDevolucionesProveedor
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
            this.btnAgregarDevolucion = new System.Windows.Forms.Button();
            this.btnVerDevouciones = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarDevolucion
            // 
            this.btnAgregarDevolucion.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAgregarDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDevolucion.Location = new System.Drawing.Point(446, 91);
            this.btnAgregarDevolucion.Name = "btnAgregarDevolucion";
            this.btnAgregarDevolucion.Size = new System.Drawing.Size(179, 215);
            this.btnAgregarDevolucion.TabIndex = 32;
            this.btnAgregarDevolucion.Text = "Agregar devolucion";
            this.btnAgregarDevolucion.UseVisualStyleBackColor = false;
            this.btnAgregarDevolucion.Click += new System.EventHandler(this.btnAgregarDevolucion_Click);
            // 
            // btnVerDevouciones
            // 
            this.btnVerDevouciones.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnVerDevouciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDevouciones.Location = new System.Drawing.Point(106, 91);
            this.btnVerDevouciones.Name = "btnVerDevouciones";
            this.btnVerDevouciones.Size = new System.Drawing.Size(177, 215);
            this.btnVerDevouciones.TabIndex = 31;
            this.btnVerDevouciones.Text = "Ver Registro de Devoluciones";
            this.btnVerDevouciones.UseVisualStyleBackColor = false;
            this.btnVerDevouciones.Click += new System.EventHandler(this.btnVerDevouciones_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 63);
            this.panel2.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bernard MT Condensed", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(306, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 33);
            this.label8.TabIndex = 21;
            this.label8.Text = "Modulo de Compras";
            // 
            // FrmInicioDevolucionesProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAgregarDevolucion);
            this.Controls.Add(this.btnVerDevouciones);
            this.Name = "FrmInicioDevolucionesProveedor";
            this.Text = "FrmInicioDevolucionesProveedor";
            this.Load += new System.EventHandler(this.FrmInicioDevolucionesProveedor_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarDevolucion;
        private System.Windows.Forms.Button btnVerDevouciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
    }
}