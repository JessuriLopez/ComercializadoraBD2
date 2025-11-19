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
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnProveedores.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnCategorias.PerformClick();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias f = new FrmCategorias();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnProductos.PerformClick();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos f = new FrmProductos();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnLotes.PerformClick();
        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            FrmLotes f = new FrmLotes();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {

        }
    }
}
