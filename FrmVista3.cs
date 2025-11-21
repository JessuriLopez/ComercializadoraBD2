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
    public partial class FrmVista3 : Form
    {
        public FrmVista3()
        {
            InitializeComponent();
        }

        private void FrmVista3_Load(object sender, EventArgs e)
        {
            CargarVista3();
        }


        private void CargarVista3()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM v_ProductosConCategoria", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVista3.DataSource = dt;
            }
        }
    }
}
