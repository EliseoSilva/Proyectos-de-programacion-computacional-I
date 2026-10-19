
using System;
using Microsoft.Data.SqlClient;

namespace PrimeraAplicacion
{
    internal class conexion
    {
        private static readonly string cadenaConexion =
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\ELISE\Downloads\BD_COMUNIDADCONECTA.MDF;
              Integrated Security=True;
              Connect Timeout=30;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
