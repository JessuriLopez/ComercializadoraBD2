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
    public partial class FrmInicioOrdenesCompras : Form
    {
        public FrmInicioOrdenesCompras()
        {
            InitializeComponent();
        }

        private void btnGuardarOrden_Click(object sender, EventArgs e)
        {
            FrmOrdenCompras f = new FrmOrdenCompras();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnVerOrdenes_Click(object sender, EventArgs e)
        {
            FrmVerOrdenesDeCompra f = new FrmVerOrdenesDeCompra();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void FrmInicioOrdenesCompras_Load(object sender, EventArgs e)
        {

        }
    }
}
