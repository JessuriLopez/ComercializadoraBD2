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
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnInicioOrdenesCompras.PerformClick();
        }



        private void btnInicioOrdenesCompras_Click(object sender, EventArgs e)
        {
            FrmInicioOrdenesCompras f = new FrmInicioOrdenesCompras();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
