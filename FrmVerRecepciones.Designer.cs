namespace ComercializadoraBD2
{
    partial class FrmVerRecepciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetallesRecepciones = new System.Windows.Forms.DataGridView();
            this.dgvRecepciones = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecepciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetallesRecepciones
            // 
            this.dgvDetallesRecepciones.AllowUserToAddRows = false;
            this.dgvDetallesRecepciones.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesRecepciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetallesRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesRecepciones.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDetallesRecepciones.Location = new System.Drawing.Point(115, 422);
            this.dgvDetallesRecepciones.Name = "dgvDetallesRecepciones";
            this.dgvDetallesRecepciones.RowHeadersWidth = 51;
            this.dgvDetallesRecepciones.RowTemplate.Height = 24;
            this.dgvDetallesRecepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesRecepciones.Size = new System.Drawing.Size(945, 272);
            this.dgvDetallesRecepciones.TabIndex = 38;
            this.dgvDetallesRecepciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetallesRecepciones_CellContentClick);
            // 
            // dgvRecepciones
            // 
            this.dgvRecepciones.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecepciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecepciones.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvRecepciones.Location = new System.Drawing.Point(115, 126);
            this.dgvRecepciones.Name = "dgvRecepciones";
            this.dgvRecepciones.RowHeadersWidth = 51;
            this.dgvRecepciones.RowTemplate.Height = 24;
            this.dgvRecepciones.Size = new System.Drawing.Size(945, 276);
            this.dgvRecepciones.TabIndex = 36;
            this.dgvRecepciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecepciones_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(882, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(165, 51);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmVerRecepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 1055);
            this.Controls.Add(this.dgvDetallesRecepciones);
            this.Controls.Add(this.dgvRecepciones);
            this.Controls.Add(this.btnEliminar);
            this.Name = "FrmVerRecepciones";
            this.Text = "FrmVerRecepciones";
            this.Load += new System.EventHandler(this.FrmVerRecepciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecepciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecepciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetallesRecepciones;
        private System.Windows.Forms.DataGridView dgvRecepciones;
        private System.Windows.Forms.Button btnEliminar;
    }
}