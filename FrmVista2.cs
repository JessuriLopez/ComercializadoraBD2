using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercializadoraBD2
{
    public partial class FrmVista2 : Form
    {
        public FrmVista2()
        {
            InitializeComponent();
        }

        private void dgvVista2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarProductos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_FacturasClientes", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVista2.DataSource = dt;
            }
        }

        private void FrmVista2_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
    }
}
