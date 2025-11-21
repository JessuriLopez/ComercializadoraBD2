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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void AbrirFormulario(Form formHijo)
        {
            panelContenedor.Controls.Clear();
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formHijo);
            formHijo.Show();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void btnSlice_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 270)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 270;
            }
        }



        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVentas());

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInventario());
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCompras());
        }


        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmCompras());
        }


        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmInicioReportes());
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {

        }
    }
}
