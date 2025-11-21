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
    public partial class FrmSeguridad : Form
    {
        public FrmSeguridad()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text.Trim();
            string contrasena = txtcontraseña.Text.Trim();

            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Advertencia");
                return;
            }

            try
            {
                using (SqlConnection cn = Conexion.ObtenerConexion())
                {
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("sp_LoginUsuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Login exitoso
                        int idUsuario = Convert.ToInt32(dr["UsuarioID"]);
                        string nombreUsuario = dr["NombreUsuario"].ToString();
                        int rol = Convert.ToInt32(dr["RolID"]);

                        MessageBox.Show("Inicio de sesión correcto. Bienvenido " + nombreUsuario);

                        // Abrir el menú principal
                        Home f = new Home();
                        f.Show();

                        this.Hide();  // Ocultar login
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error");
                    }

                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }
    }
}
