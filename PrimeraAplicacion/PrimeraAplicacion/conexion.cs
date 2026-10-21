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
            string cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\elise\source\repos\Proyectos-de-programacion-computacional-I\PrimeraAplicacion\PrimeraAplicacion\db academica.mdf"";Integrated Security=True";
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

        public DataSet obtenerDatosMaterias()
        {
            objDs.Clear();
            objComando.CommandText = "SELECT * FROM materias";
            objComando.CommandType = CommandType.Text;

            objDataAdapter.SelectCommand = objComando;
            objDataAdapter.Fill(objDs, "materias");

            return objDs;
        }

        public void insertarMateria(string codigo, string nombre, string uv)
        {
            try
            {
                int nextId = 0;
                using (SqlCommand cmdMax = new SqlCommand("SELECT ISNULL(MAX(idMateria),0)+1 FROM Materias", objConexion))
                {
                    object? result = cmdMax.ExecuteScalar();
                    nextId = (result == null || result == DBNull.Value) ? 1 : Convert.ToInt32(result);
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Materias(idMateria, [código], nombre, [UV]) VALUES(@id, @código, @nombre, @uv)";

                    cmd.Parameters.AddWithValue("@id", nextId);
                    cmd.Parameters.AddWithValue("@código", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@uv", uv);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void actualizarMateria(int idMateria, string codigo, string nombre, string uv)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE materias SET [código] = @codigo, nombre = @nombre, [UV] = @uv WHERE idMateria = @id";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@uv", uv);
                    cmd.Parameters.AddWithValue("@id", idMateria);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void eliminarMateria(int idMateria)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = objConexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM materias WHERE idMateria = @id";
                    cmd.Parameters.AddWithValue("@id", idMateria);
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

        // Ejecuta instrucciones SQL de INSERT, UPDATE y DELETE.
        public int procesar(string sentencia, params SqlParameter[] parametros)
        {
            using (SqlCommand cmd = new SqlCommand(sentencia, objConexion))
            {
                cmd.CommandType = CommandType.Text;

                if (parametros != null)
                {
                    cmd.Parameters.AddRange(parametros);
                }

                if (objConexion.State != ConnectionState.Open)
                {
                    objConexion.Open();
                }

                return cmd.ExecuteNonQuery();
            }
        }

        // Crea el DataSet para la tabla de usuarios.
        public DataSet crearDs()
        {
            DataSet ds = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT * FROM usuarios_usss057823", objConexion))
            {
                adapter.Fill(ds, "usuarios_usss057823");
            }

            return ds;
        }

        // Mantenimiento: AGREGAR, MODIFICAR y ELIMINAR usuarios.
        public int mantenimiento_usuarios_usss057823(
            string accion,
            int idUsuario,
            string usuario,
            string clave,
            string nombre,
            string direccion,
            string telefono)
        {
            string sql;

            switch (accion.Trim().ToUpper())
            {
                case "AGREGAR":
                    sql = @"INSERT INTO usuarios_usss057823
                            (usuario, clave, nombre, [direccion], telefono)
                            VALUES
                            (@usuario, @clave, @nombre, @direccion, @telefono)";
                    break;

                case "MODIFICAR":
                    sql = @"UPDATE usuarios_usss057823
                            SET usuario = @usuario,
                                clave = @clave,
                                nombre = @nombre,
                                [direccion] = @direccion,
                                telefono = @telefono
                            WHERE idUsuario = @idUsuario";
                    break;

                case "ELIMINAR":
                    sql = @"DELETE FROM usuarios_usss057823
                            WHERE idUsuario = @idUsuario";
                    break;

                default:
                    throw new ArgumentException(
                        "Acción no válida. Use AGREGAR, MODIFICAR o ELIMINAR.");
            }

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (accion.Trim().ToUpper() != "ELIMINAR")
            {
                parametros.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 35)
                { Value = usuario });

                parametros.Add(new SqlParameter("@clave", SqlDbType.VarChar, 35)
                { Value = clave });

                parametros.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 65)
                { Value = nombre });

                parametros.Add(new SqlParameter("@direccion", SqlDbType.VarChar, 85)
                { Value = direccion });

                parametros.Add(new SqlParameter("@telefono", SqlDbType.VarChar, 9)
                { Value = telefono });
            }

            if (accion.Trim().ToUpper() != "AGREGAR")
            {
                parametros.Add(new SqlParameter("@idUsuario", SqlDbType.Int)
                { Value = idUsuario });
            }

            return procesar(sql, parametros.ToArray());
        }

        // Comprueba las credenciales para el formulario Login.
        public bool validarLogin(string usuario, string clave)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM usuarios_usss057823
                WHERE usuario = @usuario AND clave = @clave";

            using (SqlCommand cmd = new SqlCommand(sql, objConexion))
            {
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 35)
                    .Value = usuario;

                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 35)
                    .Value = clave;

                if (objConexion.State != ConnectionState.Open)
                {
                    objConexion.Open();
                }

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

    }

}
