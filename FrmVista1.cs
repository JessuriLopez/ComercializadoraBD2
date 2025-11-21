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
    public partial class FrmVista1 : Form
    {
        public FrmVista1()
        {
            InitializeComponent();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmVista1_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }


        private void CargarProductos()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_ProductosConCategoria", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVista1.DataSource = dt;
            }
        }
    }
}
