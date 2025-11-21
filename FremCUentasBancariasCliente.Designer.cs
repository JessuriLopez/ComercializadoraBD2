namespace ComercializadoraBD2
{
    partial class FremCUentasBancariasCliente
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
            this.txtNombreBanco = new System.Windows.Forms.TextBox();
            this.txtNumeroCuenta = new System.Windows.Forms.TextBox();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.cmbTipoCuenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.datagridCuentaBancaria = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridCuentaBancaria)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.Location = new System.Drawing.Point(43, 54);
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.Size = new System.Drawing.Size(147, 22);
            this.txtNombreBanco.TabIndex = 0;
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(43, 137);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Size = new System.Drawing.Size(147, 22);
            this.txtNumeroCuenta.TabIndex = 1;
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Location = new System.Drawing.Point(43, 287);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Size = new System.Drawing.Size(147, 22);
            this.txtSaldoActual.TabIndex = 2;
            this.txtSaldoActual.TextChanged += new System.EventHandler(this.txtSaldoActual_TextChanged);
            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.FormattingEnabled = true;
            this.cmbTipoCuenta.Items.AddRange(new object[] {
            "Ahorros",
            "Corriente"});
            this.cmbTipoCuenta.Location = new System.Drawing.Point(48, 214);
            this.cmbTipoCuenta.Name = "cmbTipoCuenta";
            this.cmbTipoCuenta.Size = new System.Drawing.Size(142, 24);
            this.cmbTipoCuenta.TabIndex = 3;
            this.cmbTipoCuenta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre del banco";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Numero de cuenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cambiar tipo de cuenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Saldo actual";
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboBoxEstado.Location = new System.Drawing.Point(43, 364);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(147, 24);
            this.comboBoxEstado.TabIndex = 8;
            this.comboBoxEstado.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Estado de Cuenta";
            // 
            // datagridCuentaBancaria
            // 
            this.datagridCuentaBancaria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridCuentaBancaria.Location = new System.Drawing.Point(277, 26);
            this.datagridCuentaBancaria.Name = "datagridCuentaBancaria";
            this.datagridCuentaBancaria.RowHeadersWidth = 51;
            this.datagridCuentaBancaria.RowTemplate.Height = 24;
            this.datagridCuentaBancaria.Size = new System.Drawing.Size(663, 378);
            this.datagridCuentaBancaria.TabIndex = 10;
            this.datagridCuentaBancaria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridCuentaBancaria_CellContentClick);
            this.datagridCuentaBancaria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridCuentaBancaria_CellContentClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(84, 494);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 43);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(438, 494);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 43);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(783, 494);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(114, 43);
            this.btnVer.TabIndex = 14;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.button1_Click);
            // 
            // FremCUentasBancariasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 574);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.datagridCuentaBancaria);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoCuenta);
            this.Controls.Add(this.txtSaldoActual);
            this.Controls.Add(this.txtNumeroCuenta);
            this.Controls.Add(this.txtNombreBanco);
            this.Name = "FremCUentasBancariasCliente";
            this.Text = "FremCUentasBancariasCliente";
            this.Load += new System.EventHandler(this.FremCUentasBancariasCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridCuentaBancaria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreBanco;
        private System.Windows.Forms.TextBox txtNumeroCuenta;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.ComboBox cmbTipoCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView datagridCuentaBancaria;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnVer;
    }
}