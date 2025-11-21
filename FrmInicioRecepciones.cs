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
    public partial class FrmInicioRecepciones : Form
    {
        public FrmInicioRecepciones()
        {
            InitializeComponent();
        }

        private void btnAgregarRecepcion_Click(object sender, EventArgs e)
        {
            FrmRecepciones f = new FrmRecepciones();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnVerRecepciones_Click(object sender, EventArgs e)
        {
            FrmVerRecepciones f = new FrmVerRecepciones();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
