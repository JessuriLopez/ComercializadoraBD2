using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercializadoraBD2
{
    public partial class FrmMenuFinanzas : Form
    {
        public FrmMenuFinanzas()
        {
            InitializeComponent();
        }

        private void FrmMenuFinanzas_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDepositosBancarios frmCuentas = new FrmDepositosBancarios();


            frmCuentas.Show();

        }

        private void btnCuentasBancarias_Click(object sender, EventArgs e)
        {
            FremCUentasBancariasCliente frmCuentas = new FremCUentasBancariasCliente();


            frmCuentas.Show();
        }

        private void btnPagoProveedores_Click(object sender, EventArgs e)
        {
           
        }
    }
}