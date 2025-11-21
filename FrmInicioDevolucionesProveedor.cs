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
    public partial class FrmInicioDevolucionesProveedor : Form
    {
        public FrmInicioDevolucionesProveedor()
        {
            InitializeComponent();
        }

        private void btnAgregarDevolucion_Click(object sender, EventArgs e)
        {
            FrmDevolucionProveedores f = new FrmDevolucionProveedores();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void FrmInicioDevolucionesProveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnVerDevouciones_Click(object sender, EventArgs e)
        {
            FrmVerDevoluciones f = new FrmVerDevoluciones();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }
    }
}
