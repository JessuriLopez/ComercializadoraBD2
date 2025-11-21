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
    public partial class FrmInicioReportes : Form
    {
        public FrmInicioReportes()
        {
            InitializeComponent();
        }

        private void btnVista1_Click(object sender, EventArgs e)
        {
            FrmVista1 f = new FrmVista1();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnVista1.PerformClick();
        }

        private void btnVista2_Click(object sender, EventArgs e)
        {
            FrmVista2 f = new FrmVista2();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnVista2.PerformClick();
        }

        private void btnVista3_Click(object sender, EventArgs e)
        {
            FrmVista3 f = new FrmVista3();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnVista3.PerformClick();
        }

        private void btnVista4_Click(object sender, EventArgs e)
        {
            FrmVista4 f = new FrmVista4();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnVista4.PerformClick();
        }

        private void btnVista5_Click(object sender, EventArgs e)
        {
            FrmVista5 f = new FrmVista5();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            btnVista5.PerformClick();
        }
    }
}
