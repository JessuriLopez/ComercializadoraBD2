namespace ComercializadoraBD2
{
    partial class FrmRecepciones
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDetallesRecepcion = new System.Windows.Forms.Button();
            this.txtNumRemision = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbNumOrden = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.dtpFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.btnDetallesRecepcion);
            this.panel3.Controls.Add(this.txtNumRemision);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1102, 79);
            this.panel3.TabIndex = 40;
            // 
            // btnDetallesRecepcion
            // 
            this.btnDetallesRecepcion.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnDetallesRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallesRecepcion.Location = new System.Drawing.Point(777, 12);
            this.btnDetallesRecepcion.Name = "btnDetallesRecepcion";
            this.btnDetallesRecepcion.Size = new System.Drawing.Size(270, 51);
            this.btnDetallesRecepcion.TabIndex = 26;
            this.btnDetallesRecepcion.Text = "Agregar detalles a la recepcion";
            this.btnDetallesRecepcion.UseVisualStyleBackColor = false;
            this.btnDetallesRecepcion.Click += new System.EventHandler(this.btnDetallesRecepcion_Click);
            // 
            // txtNumRemision
            // 
            this.txtNumRemision.Enabled = false;
            this.txtNumRemision.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumRemision.Location = new System.Drawing.Point(219, 27);
            this.txtNumRemision.Name = "txtNumRemision";
            this.txtNumRemision.Size = new System.Drawing.Size(104, 27);
            this.txtNumRemision.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Num. Remision";
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cmbNumOrden);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.btnRecibir);
            this.panel1.Controls.Add(this.dtpFechaRecepcion);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbUsuario);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtObservaciones);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(25, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 394);
            this.panel1.TabIndex = 39;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbNumOrden
            // 
            this.cmbNumOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNumOrden.FormattingEnabled = true;
            this.cmbNumOrden.Location = new System.Drawing.Point(183, 107);
            this.cmbNumOrden.Name = "cmbNumOrden";
            this.cmbNumOrden.Size = new System.Drawing.Size(151, 28);
            this.cmbNumOrden.TabIndex = 41;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(800, 107);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(147, 28);
            this.cmbEstado.TabIndex = 38;
            // 
            // btnRecibir
            // 
            this.btnRecibir.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibir.Location = new System.Drawing.Point(340, 308);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(277, 51);
            this.btnRecibir.TabIndex = 23;
            this.btnRecibir.Text = "Recibir Orden";
            this.btnRecibir.UseVisualStyleBackColor = false;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // dtpFechaRecepcion
            // 
            this.dtpFechaRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaRecepcion.Location = new System.Drawing.Point(349, 190);
            this.dtpFechaRecepcion.Name = "dtpFechaRecepcion";
            this.dtpFechaRecepcion.Size = new System.Drawing.Size(170, 27);
            this.dtpFechaRecepcion.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(727, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Estado";
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Enabled = false;
            this.cmbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(465, 107);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(208, 28);
            this.cmbUsuario.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(440, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Recepcion ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(160, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Fecha de recepcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Num. Orden";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(539, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(679, 192);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(182, 61);
            this.txtObservaciones.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(376, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Usuario";
            // 
            // FrmRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 493);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRecepciones";
            this.Text = "FrmRecepciones";
            this.Load += new System.EventHandler(this.FrmRecepciones_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDetallesRecepcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.DateTimePicker dtpFechaRecepcion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumRemision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNumOrden;
    }
}