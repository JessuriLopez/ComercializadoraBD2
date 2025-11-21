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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClientesCRUD f = new ClientesCRUD();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
