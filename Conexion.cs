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
<<<<<<< HEAD
        
        private static string cadena = "Server=figueroa\\SQLEXPRESS01;Database=ComercializadoraPM;Trusted_Connection=True;";
=======
        private static string cadena = "Server=localhost;Database=ComercializadoraPM;Trusted_Connection=True;\r\nServer=localhost;Database=ComercializadoraPM;Trusted_Connection=True;";
>>>>>>> fb77e96df6c8f08e345c3e9b2f83d5041fb7fabd

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}