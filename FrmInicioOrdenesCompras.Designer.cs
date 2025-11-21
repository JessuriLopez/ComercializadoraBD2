namespace ComercializadoraBD2
{
    partial class FrmInicioOrdenesCompras
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
            this.btnVerOrdenes = new System.Windows.Forms.Button();
            this.btnGuardarOrden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerOrdenes
            // 
            this.btnVerOrdenes.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnVerOrdenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerOrdenes.Location = new System.Drawing.Point(167, 116);
            this.btnVerOrdenes.Name = "btnVerOrdenes";
            this.btnVerOrdenes.Size = new System.Drawing.Size(177, 215);
            this.btnVerOrdenes.TabIndex = 26;
            this.btnVerOrdenes.Text = "Ver Ordenes";
            this.btnVerOrdenes.UseVisualStyleBackColor = false;
            this.btnVerOrdenes.Click += new System.EventHandler(this.btnVerOrdenes_Click);
            // 
            // btnGuardarOrden
            // 
            this.btnGuardarOrden.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGuardarOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarOrden.Location = new System.Drawing.Point(449, 116);
            this.btnGuardarOrden.Name = "btnGuardarOrden";
            this.btnGuardarOrden.Size = new System.Drawing.Size(179, 215);
            this.btnGuardarOrden.TabIndex = 28;
            this.btnGuardarOrden.Text = "Agregar Orden";
            this.btnGuardarOrden.UseVisualStyleBackColor = false;
            this.btnGuardarOrden.Click += new System.EventHandler(this.btnGuardarOrden_Click);
            // 
            // FrmInicioOrdenesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 428);
            this.Controls.Add(this.btnGuardarOrden);
            this.Controls.Add(this.btnVerOrdenes);
            this.Name = "FrmInicioOrdenesCompras";
            this.Text = "FrmInicioOrdenesCompras";
            this.Load += new System.EventHandler(this.FrmInicioOrdenesCompras_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVerOrdenes;
        private System.Windows.Forms.Button btnGuardarOrden;
    }
}