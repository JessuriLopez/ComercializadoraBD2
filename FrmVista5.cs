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
    public partial class FrmVista5 : Form
    {
        public FrmVista5()
        {
            InitializeComponent();
        }

        private void FrmVista5_Load(object sender, EventArgs e)
        {
            CargarVista5();
        }

        private void CargarVista5()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_ProductosConCategoria", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVista5.DataSource = dt;
            }
        }
    }
}
