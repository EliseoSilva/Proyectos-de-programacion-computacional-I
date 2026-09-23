using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String accion = "nuevo";
        int posicion = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerDatos();
        }

        private void obtenerDatos()
        {
            ds.Clear();
            ds = objConexion.obtenerDatos();
            dt = ds.Tables["alumnos"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["idAlumnos"] };
        }
        private void mostrarDatos()
        {
            if (dt.Rows.Count > 0 && posicion >= 0 && posicion < dt.Rows.Count)
            {
                txtCodigo.Text = dt.Rows[posicion]["código"].ToString();
                txtNombre.Text = dt.Rows[posicion]["nombre"].ToString();
                txtDireccion.Text = dt.Rows[posicion]["direccion"].ToString();
                txtTelefono.Text = dt.Rows[posicion]["telefono"].ToString();
                txtEmail.Text = dt.Rows[posicion]["email"].ToString();

                lblNavegacion.Text = (posicion + 1) + " de " + dt.Rows.Count;
            }
        }
        
        private void activarDesactivarCtrls(Boolean estado)
        {
            grbDatos.Enabled = estado;
            grbNavegacion.Enabled = !estado;

        }
        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (btnAgregarAlumno.Text == "Agregar")
            {
                btnAgregarAlumno.Text = "Guardar";
                btnModificarAlumno.Text = "Cancelar";

                activarDesactivarCtrls(true);
            }
            else
            {
                btnAgregarAlumno.Text = "Agregar";
                btnModificarAlumno.Text = "Modificar";
                activarDesactivarCtrls(false);
            }
        }

        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            if (btnModificarAlumno.Text == "Modificar")
            {
                btnAgregarAlumno.Text = "Guardar";
                btnModificarAlumno.Text = "Cancelar";
                activarDesactivarCtrls(true);
            }
            else
            {
                btnAgregarAlumno.Text = "Agregar";
                btnModificarAlumno.Text = "Modificar";
                activarDesactivarCtrls(false);
            }
        }

        private void btnSiguienteAlumno_Click(object sender, EventArgs e)
        {
            posicion++;
            mostrarDatos();
        }

        private void btnAnteriorAlumno_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
        }

        private void btnPrimerAlumno_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }

        private void btnUltimoAlumno_Click(object sender, EventArgs e)
        {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();
        }
    }
}