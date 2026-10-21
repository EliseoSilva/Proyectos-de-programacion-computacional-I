
using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PrimeraAplicacion
{
    public partial class frm_usuario : Form
    {
        private Conexion conexion = new Conexion();
        private DataTable tablaUsuarios = new DataTable();
        private int indiceActual = -1;
        private string modo = "CONSULTA";

        public frm_usuario()
        {
            InitializeComponent();

            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.TabStop = false;
            textBox1.UseSystemPasswordChar = true;

            btnAgregar.Click += btnAgregar_Click;
            btnModificar.Click += btnModificar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnPrimero.Click += btnPrimero_Click;
            btnAnterior.Click += btnAnterior_Click;
            btnSiguiente.Click += btnSiguiente_Click;
            btnUltimo.Click += btnUltimo_Click;

            EstablecerModoConsulta();
            CargarUsuarios();
        }

        private void EstablecerModoConsulta()
        {
            modo = "CONSULTA";

            txtIdUsuario.ReadOnly = true;
            txtUsuario.ReadOnly = true;
            textBox1.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;

            btnAgregar.Text = "Agregar";
            btnModificar.Text = "Modificar";

            btnAgregar.Enabled = true;
            btnModificar.Enabled = tablaUsuarios.Rows.Count > 0;
            btnEliminar.Enabled = tablaUsuarios.Rows.Count > 0;

            btnPrimero.Enabled = true;
            btnAnterior.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;
        }

        private void EstablecerModoEdicion()
        {
            txtIdUsuario.ReadOnly = true;
            txtUsuario.ReadOnly = false;
            textBox1.ReadOnly = false;
            txtNombre.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtTelefono.ReadOnly = false;

            btnPrimero.Enabled = false;
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            btnEliminar.Enabled = false;

            txtUsuario.Focus();
        }

        private void CargarUsuarios()
        {
            try
            {
                DataSet ds = conexion.crearDs();
                tablaUsuarios = ds.Tables["usuarios_usss057823"];

                if (tablaUsuarios == null)
                    throw new Exception("No se encontró la tabla de usuarios.");

                if (tablaUsuarios.Rows.Count > 0)
                    indiceActual = Math.Max(0, Math.Min(
                        indiceActual, tablaUsuarios.Rows.Count - 1));
                else
                    indiceActual = -1;

                MostrarRegistro();
                EstablecerModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar usuarios:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarRegistro()
        {
            if (indiceActual < 0 ||
                indiceActual >= tablaUsuarios.Rows.Count)
            {
                LimpiarCampos();
                lblNavegacion.Text = "0 de 0";
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                return;
            }

            DataRow fila = tablaUsuarios.Rows[indiceActual];

            txtIdUsuario.Text = fila["idUsuario"].ToString();
            txtUsuario.Text = fila["usuario"].ToString();

            // La contraseña no se muestra al navegar.
            textBox1.Clear();

            txtNombre.Text = fila["nombre"].ToString();
            txtDireccion.Text = fila["direccion"].ToString();
            txtTelefono.Text = fila["telefono"].ToString();

            lblNavegacion.Text =
                $"{indiceActual + 1} de {tablaUsuarios.Rows.Count}";

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void LimpiarCampos()
        {
            txtIdUsuario.Clear();
            txtUsuario.Clear();
            textBox1.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void IniciarAgregar()
        {
            modo = "AGREGAR";

            LimpiarCampos();
            EstablecerModoEdicion();

            btnAgregar.Text = "Guardar";
            btnModificar.Text = "Cancelar";
            btnAgregar.Enabled = true;
            btnModificar.Enabled = true;

            lblNavegacion.Text = "Nuevo usuario";
        }

        private void IniciarModificar()
        {
            if (string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            modo = "MODIFICAR";
            EstablecerModoEdicion();

            btnAgregar.Text = "Cancelar";
            btnModificar.Text = "Guardar Cambios";

            btnAgregar.Enabled = true;
            btnModificar.Enabled = true;
            textBox1.Clear();
        }

        private bool ValidarDatos()
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = textBox1.Text;

            if (usuario.Length < 6 || usuario.Length > 16)
            {
                MessageBox.Show(
                    "El usuario debe tener entre 6 y 16 caracteres.");
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }

            if (txtNombre.Text.Trim().Length > 65 ||
                txtDireccion.Text.Trim().Length > 85 ||
                txtTelefono.Text.Trim().Length > 9)
            {
                MessageBox.Show(
                    "El nombre, dirección o teléfono excede la longitud permitida.");
                return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{1,9}$"))
            {
                MessageBox.Show(
                    "El teléfono debe contener entre 1 y 9 dígitos.");
                txtTelefono.Focus();
                return false;
            }

            if (modo == "AGREGAR" || !string.IsNullOrEmpty(clave))
            {
                if (string.IsNullOrWhiteSpace(clave) ||
                    clave.Length > 35 ||
                    !Regex.IsMatch(clave, @"[A-Za-z]") ||
                    !Regex.IsMatch(clave, @"\d"))
                {
                    MessageBox.Show(
                        "La contraseña debe contener letras y números " +
                        "y no superar 35 caracteres.");
                    textBox1.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool SolicitarConfirmacionClave(string clave)
        {
            using (Form ventana = new Form())
            using (Label etiqueta = new Label())
            using (TextBox confirmacion = new TextBox())
            using (Button aceptar = new Button())
            using (Button cancelar = new Button())
            {
                ventana.Text = "Confirmar contraseña";
                ventana.StartPosition = FormStartPosition.CenterParent;
                ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
                ventana.ClientSize = new Size(340, 125);
                ventana.MinimizeBox = false;
                ventana.MaximizeBox = false;

                etiqueta.Text = "Vuelve a escribir la contraseña:";
                etiqueta.AutoSize = true;
                etiqueta.Location = new Point(15, 15);

                confirmacion.Location = new Point(15, 42);
                confirmacion.Size = new Size(310, 25);
                confirmacion.UseSystemPasswordChar = true;

                aceptar.Text = "Aceptar";
                aceptar.DialogResult = DialogResult.OK;
                aceptar.Location = new Point(75, 82);

                cancelar.Text = "Cancelar";
                cancelar.DialogResult = DialogResult.Cancel;
                cancelar.Location = new Point(175, 82);

                ventana.Controls.Add(etiqueta);
                ventana.Controls.Add(confirmacion);
                ventana.Controls.Add(aceptar);
                ventana.Controls.Add(cancelar);

                ventana.AcceptButton = aceptar;
                ventana.CancelButton = cancelar;

                if (ventana.ShowDialog(this) != DialogResult.OK)
                    return false;

                if (confirmacion.Text != clave)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return false;
                }

                return true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // En modo consulta, iniciar el registro.
            if (modo == "CONSULTA")
            {
                IniciarAgregar();
                return;
            }

            // En modo modificación, cancelar y descartar los cambios.
            if (modo == "MODIFICAR")
            {
                CargarUsuarios();
                return;
            }

            // En modo agregar, guardar el nuevo usuario.
            if (modo != "AGREGAR")
                return;

            if (!ValidarDatos())
                return;

            string clave = textBox1.Text;

            if (!SolicitarConfirmacionClave(clave))
                return;

            try
            {
                conexion.mantenimiento_usuarios_usss057823(
                    "AGREGAR",
                    0,
                    txtUsuario.Text.Trim(),
                    clave,
                    txtNombre.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim());

                MessageBox.Show("Usuario agregado correctamente.");

                CargarUsuarios();
                indiceActual = tablaUsuarios.Rows.Count - 1;
                MostrarRegistro();
                EstablecerModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al agregar el usuario:\n" + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // En consulta, entrar en modo modificación.
            if (modo == "CONSULTA")
            {
                IniciarModificar();
                return;
            }

            // En modo agregar, cancelar el nuevo registro.
            if (modo == "AGREGAR")
            {
                CargarUsuarios();
                return;
            }

            if (modo != "MODIFICAR")
                return;

            if (!ValidarDatos())
                return;

            string clave = textBox1.Text;

            if (string.IsNullOrEmpty(clave))
            {
                MessageBox.Show(
                    "Introduce una contraseña nueva para guardar los cambios.");
                textBox1.Focus();
                return;
            }

            if (!SolicitarConfirmacionClave(clave))
                return;

            try
            {
                int id = Convert.ToInt32(txtIdUsuario.Text);

                int filas = conexion.mantenimiento_usuarios_usss057823(
                    "MODIFICAR",
                    id,
                    txtUsuario.Text.Trim(),
                    clave,
                    txtNombre.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    txtTelefono.Text.Trim());

                if (filas > 0)
                    MessageBox.Show("Usuario modificado correctamente.");
                else
                    MessageBox.Show("No se encontró el usuario.");

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al modificar el usuario:\n" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modo != "CONSULTA" ||
                string.IsNullOrWhiteSpace(txtIdUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(txtIdUsuario.Text);

                conexion.mantenimiento_usuarios_usss057823(
                    "ELIMINAR", id, "", "", "", "", "");

                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al eliminar el usuario:\n" + ex.Message);
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (modo != "CONSULTA" || tablaUsuarios.Rows.Count == 0)
                return;

            indiceActual = 0;
            MostrarRegistro();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (modo != "CONSULTA" || indiceActual <= 0)
                return;

            indiceActual--;
            MostrarRegistro();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (modo != "CONSULTA" ||
                indiceActual >= tablaUsuarios.Rows.Count - 1)
                return;

            indiceActual++;
            MostrarRegistro();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (modo != "CONSULTA" || tablaUsuarios.Rows.Count == 0)
                return;

            indiceActual = tablaUsuarios.Rows.Count - 1;
            MostrarRegistro();
        }
    }
}
