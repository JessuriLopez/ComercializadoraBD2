namespace ComercializadoraBD2
{
    partial class FrmDepositosBancarios
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
            this.dgDepositos = new System.Windows.Forms.DataGridView();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Observaciones = new System.Windows.Forms.Label();
            this.txtobservaciones = new System.Windows.Forms.TextBox();
            this.btnDepositar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepositos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDepositos
            // 
            this.dgDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepositos.Location = new System.Drawing.Point(322, 28);
            this.dgDepositos.Name = "dgDepositos";
            this.dgDepositos.RowHeadersWidth = 51;
            this.dgDepositos.RowTemplate.Height = 24;
            this.dgDepositos.Size = new System.Drawing.Size(636, 282);
            this.dgDepositos.TabIndex = 0;
            this.dgDepositos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDepositos_CellContentClick);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(33, 81);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(115, 22);
            this.txtMonto.TabIndex = 1;
            this.txtMonto.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto a depositar";
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(33, 151);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(121, 24);
            this.cmbCuenta.TabIndex = 3;
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cuenta a depositar";
            // 
            // Observaciones
            // 
            this.Observaciones.AutoSize = true;
            this.Observaciones.Location = new System.Drawing.Point(36, 208);
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Size = new System.Drawing.Size(97, 16);
            this.Observaciones.TabIndex = 6;
            this.Observaciones.Text = "observaciones";
            // 
            // txtobservaciones
            // 
            this.txtobservaciones.Location = new System.Drawing.Point(36, 230);
            this.txtobservaciones.Name = "txtobservaciones";
            this.txtobservaciones.Size = new System.Drawing.Size(115, 22);
            this.txtobservaciones.TabIndex = 5;
            this.txtobservaciones.TextChanged += new System.EventHandler(this.txtObservaciones_TextChanged);
            // 
            // btnDepositar
            // 
            this.btnDepositar.Location = new System.Drawing.Point(554, 376);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(142, 52);
            this.btnDepositar.TabIndex = 7;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // FrmDepositosBancarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 523);
            this.Controls.Add(this.btnDepositar);
            this.Controls.Add(this.Observaciones);
            this.Controls.Add(this.txtobservaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCuenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.dgDepositos);
            this.Name = "FrmDepositosBancarios";
            this.Text = "FrmDepositosBancarios";
            this.Load += new System.EventHandler(this.FrmDepositosBancarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDepositos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDepositos;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Observaciones;
        private System.Windows.Forms.TextBox txtobservaciones;
        private System.Windows.Forms.Button btnDepositar;
    }
}