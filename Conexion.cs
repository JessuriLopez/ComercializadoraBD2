using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercializadoraBD2
{
    internal class Conexion
    {
        private static string cadena = "Server=localhost;Database=ComercializadoraPM;Trusted_Connection=True;\r\nServer=localhost;Database=ComercializadoraPM;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
