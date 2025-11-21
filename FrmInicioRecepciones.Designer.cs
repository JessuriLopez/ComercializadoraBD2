namespace ComercializadoraBD2
{
    partial class FrmInicioRecepciones
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
            this.btnAgregarRecepcion = new System.Windows.Forms.Button();
            this.btnVerRecepciones = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregarRecepcion
            // 
            this.btnAgregarRecepcion.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAgregarRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRecepcion.Location = new System.Drawing.Point(444, 97);
            this.btnAgregarRecepcion.Name = "btnAgregarRecepcion";
            this.btnAgregarRecepcion.Size = new System.Drawing.Size(179, 215);
            this.btnAgregarRecepcion.TabIndex = 30;
            this.btnAgregarRecepcion.Text = "Agregar Nueva Recepcion";
            this.btnAgregarRecepcion.UseVisualStyleBackColor = false;
            this.btnAgregarRecepcion.Click += new System.EventHandler(this.btnAgregarRecepcion_Click);
            // 
            // btnVerRecepciones
            // 
            this.btnVerRecepciones.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnVerRecepciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRecepciones.Location = new System.Drawing.Point(119, 88);
            this.btnVerRecepciones.Name = "btnVerRecepciones";
            this.btnVerRecepciones.Size = new System.Drawing.Size(177, 215);
            this.btnVerRecepciones.TabIndex = 29;
            this.btnVerRecepciones.Text = "Ver Recepciones Recibidas";
            this.btnVerRecepciones.UseVisualStyleBackColor = false;
            this.btnVerRecepciones.Click += new System.EventHandler(this.btnVerRecepciones_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(777, 63);
            this.panel2.TabIndex = 31;
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
            // FrmInicioRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 397);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAgregarRecepcion);
            this.Controls.Add(this.btnVerRecepciones);
            this.Name = "FrmInicioRecepciones";
            this.Text = "FrmInicioRecepciones";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarRecepcion;
        private System.Windows.Forms.Button btnVerRecepciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
    }
}