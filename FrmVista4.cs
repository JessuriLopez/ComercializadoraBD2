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
    public partial class FrmVista4 : Form
    {
        public FrmVista4()
        {
            InitializeComponent();
        }

        private void dgvVista4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmVista4_Load(object sender, EventArgs e)
        {
            CargarVista4();
        }

        private void CargarVista4()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_ProductosConCategoria", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVista4.DataSource = dt;
            }
        }
    }
}
