using System.Data.SqlClient;

namespace ComercializadoraPM_App
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection("Server=localhost;Database=ComercializadoraPM;Trusted_Connection=True;");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}

