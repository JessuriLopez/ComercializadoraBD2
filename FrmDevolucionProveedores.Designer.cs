namespace ComercializadoraBD2
{
    partial class FrmDevolucionProveedores
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
            this.btnDetallesOrdenCompra = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardarDevolucion = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMotivoDevolucion = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNumeroDevolucion = new System.Windows.Forms.TextBox();
            this.btnAgregarDetalles = new System.Windows.Forms.Button();
            this.cmbNumeroOrden = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDetallesOrdenCompra
            // 
            this.btnDetallesOrdenCompra.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnDetallesOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallesOrdenCompra.Location = new System.Drawing.Point(783, 20);
            this.btnDetallesOrdenCompra.Name = "btnDetallesOrdenCompra";
            this.btnDetallesOrdenCompra.Size = new System.Drawing.Size(270, 51);
            this.btnDetallesOrdenCompra.TabIndex = 28;
            this.btnDetallesOrdenCompra.Text = "Agregar detalles a la orden";
            this.btnDetallesOrdenCompra.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cmbNumeroOrden);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.btnGuardarDevolucion);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbMotivoDevolucion);
            this.panel1.Controls.Add(this.cmbProveedor);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(31, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 350);
            this.panel1.TabIndex = 27;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Enabled = false;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(290, 140);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(147, 24);
            this.cmbEstado.TabIndex = 38;
            // 
            // btnGuardarDevolucion
            // 
            this.btnGuardarDevolucion.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGuardarDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarDevolucion.Location = new System.Drawing.Point(370, 266);
            this.btnGuardarDevolucion.Name = "btnGuardarDevolucion";
            this.btnGuardarDevolucion.Size = new System.Drawing.Size(277, 51);
            this.btnGuardarDevolucion.TabIndex = 23;
            this.btnGuardarDevolucion.Text = "Guardar Devolucion";
            this.btnGuardarDevolucion.UseVisualStyleBackColor = false;
            this.btnGuardarDevolucion.Click += new System.EventHandler(this.btnGuardarDevolucion_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "Orden de Compra";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(217, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Estado";
            // 
            // cmbMotivoDevolucion
            // 
            this.cmbMotivoDevolucion.FormattingEnabled = true;
            this.cmbMotivoDevolucion.Location = new System.Drawing.Point(752, 65);
            this.cmbMotivoDevolucion.Name = "cmbMotivoDevolucion";
            this.cmbMotivoDevolucion.Size = new System.Drawing.Size(208, 24);
            this.cmbMotivoDevolucion.TabIndex = 23;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.Enabled = false;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(466, 69);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(181, 24);
            this.cmbProveedor.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(366, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Devolucion a Proveedores";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(513, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(665, 140);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(182, 61);
            this.txtObservaciones.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(670, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Motivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Proveedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Num. Devolucion";
            // 
            // panel3
            // 
            this.panel3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.txtNumeroDevolucion);
            this.panel3.Controls.Add(this.btnAgregarDetalles);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1102, 79);
            this.panel3.TabIndex = 39;
            // 
            // txtNumeroDevolucion
            // 
            this.txtNumeroDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDevolucion.Location = new System.Drawing.Point(229, 27);
            this.txtNumeroDevolucion.Name = "txtNumeroDevolucion";
            this.txtNumeroDevolucion.Size = new System.Drawing.Size(170, 27);
            this.txtNumeroDevolucion.TabIndex = 40;
            // 
            // btnAgregarDetalles
            // 
            this.btnAgregarDetalles.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnAgregarDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDetalles.Location = new System.Drawing.Point(777, 12);
            this.btnAgregarDetalles.Name = "btnAgregarDetalles";
            this.btnAgregarDetalles.Size = new System.Drawing.Size(270, 51);
            this.btnAgregarDetalles.TabIndex = 26;
            this.btnAgregarDetalles.Text = "Agregar detalles de devolucion";
            this.btnAgregarDetalles.UseVisualStyleBackColor = false;
            this.btnAgregarDetalles.Click += new System.EventHandler(this.btnAgregarDetalles_Click);
            // 
            // cmbNumeroOrden
            // 
            this.cmbNumeroOrden.FormattingEnabled = true;
            this.cmbNumeroOrden.Location = new System.Drawing.Point(181, 76);
            this.cmbNumeroOrden.Name = "cmbNumeroOrden";
            this.cmbNumeroOrden.Size = new System.Drawing.Size(147, 24);
            this.cmbNumeroOrden.TabIndex = 39;
            this.cmbNumeroOrden.SelectedIndexChanged += new System.EventHandler(this.cmbNumeroOrden_SelectedIndexChanged);
            // 
            // FrmDevolucionProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnDetallesOrdenCompra);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDevolucionProveedores";
            this.Text = "FrmDevolucionProveedores";
            this.Load += new System.EventHandler(this.FrmDevolucionProveedores_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetallesOrdenCompra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardarDevolucion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMotivoDevolucion;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAgregarDetalles;
        private System.Windows.Forms.TextBox txtNumeroDevolucion;
        private System.Windows.Forms.ComboBox cmbNumeroOrden;
    }
}