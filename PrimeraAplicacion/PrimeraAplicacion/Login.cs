
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeraAplicacion
{
    public partial class Login : Form
    {
        private Conexion conexion = new Conexion();

        public Login()
        {
            InitializeComponent();

            txtContraseña.UseSystemPasswordChar = true;

            // Configurar el botón de inicio de sesión
            Button btnIniciarSesion = new Button();

            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.Size = new Size(200, 40);
            btnIniciarSesion.Location = new Point(315, 350);

            btnIniciarSesion.Click += btnIniciarSesion_Click;

            Controls.Add(btnIniciarSesion);

            AcceptButton = btnIniciarSesion;

            Shown += (sender, e) => txtUsuario.Focus();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show(
                    "Ingrese su usuario y contraseña.",
                    "Campos obligatorios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                if (conexion.validarLogin(usuario, clave))
                {
                    MessageBox.Show("Inicio de sesión exitoso.");

                    Hide();

                    using (frmPrincipal principal = new frmPrincipal())
                    {
                        principal.ShowDialog();
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar sesión:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (frm_usuario registro = new frm_usuario())
            {
                registro.ShowDialog(this);
            }
            this.Show();
        }
    }
}
