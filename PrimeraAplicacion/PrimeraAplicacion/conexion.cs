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
        public SqlConnection objConexion = new SqlConnection();
        public SqlCommand objComando = new SqlCommand();
        public SqlDataAdapter objDataAdapter = new SqlDataAdapter();
        private DataSet objDs = new DataSet();

        public Conexion()
        {
            // Use |DataDirectory| so the location can be configured at runtime (we set it in Program.Main)
            string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\elise\Documents\Programacion I 2026\clase 10 de octubre\PrimeraAplicacion\PrimeraAplicacion\db academica.mdf"";Integrated Security=True";
            objConexion.ConnectionString = cadenaConexion;
            if (objConexion.State != ConnectionState.Open)
            {
                objConexion.Open();
            }
            objComando.Connection = objConexion;
        }

        public void actualizarAlumno(int idAlumnos, string codigo, string nombre, string direccion, string telefono, string email)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE alumnos SET [código] = @codigo, nombre = @nombre, direccion = @direccion, telefono = @telefono, email = @email WHERE idAlumnos = @id";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", idAlumnos);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        public void eliminarAlumno(int idAlumnos)
        {
            SqlTransaction? tx = null;
            try
            {
                tx = objConexion.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.Transaction = tx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM matricula WHERE idAlumno = @id";
                    cmd.Parameters.AddWithValue("@id", idAlumnos);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.Transaction = tx;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM alumnos WHERE idAlumnos = @id";
                    cmd.Parameters.AddWithValue("@id", idAlumnos);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch (Exception)
            {
                try
                {
                    tx?.Rollback();
                }
                catch { }
                throw;
            }
        }

        public void insertarAlumno(string codigo, string nombre, string direccion, string telefono, string email)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO alumnos([código], nombre, direccion, telefono, email) VALUES(@código, @nombre, @direccion, @telefono, @email)";

                    cmd.Parameters.AddWithValue("@código", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
