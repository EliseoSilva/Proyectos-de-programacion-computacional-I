using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PrimeraAplicacion
{
    internal class Conexion
    {
        // Conexión a la base de datos
        public SqlConnection objConexion = new SqlConnection();
        public SqlCommand objComando = new SqlCommand();
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        private DataSet objDs = new DataSet();

        public Conexion()
        {
            // Ajusta la ruta del archivo .mdf si es necesario en tu proyecto
            string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\elise\Documents\Programacion I 2026\Formulario academica funcionando\PrimeraAplicacion\PrimeraAplicacion\db academica.mdf"";Integrated Security=True";
            objConexion.ConnectionString = cadenaConexion;
            // Abrir la conexión sólo si no está abierta
            if (objConexion.State != ConnectionState.Open)
            {
                objConexion.Open();
            }
            // Asociar el comando a la conexión
            objComando.Connection = objConexion;
        }

        public DataSet obtenerDatos()
        {
            objDs.Clear();

            objComando.CommandText = "SELECT * FROM alumnos";
            objComando.CommandType = CommandType.Text;

            objDataAdapter.SelectCommand = objComando;
            objDataAdapter.Fill(objDs, "alumnos");

            return objDs;
        }
    }
}
