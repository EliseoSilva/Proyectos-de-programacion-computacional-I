using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Security.Cryptography.Pkcs;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        string[,] prioridades =
        {
            {"Signos de emergencia", "ROJO"},
            {"Paciente inconsciente", "ROJO"},
            {"Dificultad respiratoria", "ROJO"},
            {"Embarazada con emergencia", "ROJO"},
            {"Menor de 5 años grave", "ROJO"},
            {"Embarazada", "AMARILLO"},
            {"Adulto mayor", "AMARILLO"},
            {"Persona con discapacidad", "AMARILLO"},
            {"Enfermedad descompensada", "AMARILLO"}
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClasificar_Click(object sender, EventArgs e)
        {
            try
            {
                int edad = int.Parse(txtEdad.Text);

                double temperatura = double.Parse(
                    txtTemperatura.Text.Replace(",", "."),
                    CultureInfo.InvariantCulture);

                string presion = txtPresion.Text;

                double saturacion = double.Parse(
                    txtSaturacion.Text.Replace(",", "."),
                    CultureInfo.InvariantCulture);

                if (chkEmergencia.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (chkInconsciente.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (chkRespiracion.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (chkEmbarazadaEmergencia.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (edad < 5 && chkDeshidratacion.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (saturacion < 90)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (temperatura >= 40)
                {
                    lblPrioridad.Text = "PRIORIDAD I - ROJO";
                    lblTiempo.Text = "Atención inmediata";
                    lblArea.Text = "Emergencia";
                }
                else if (chkEmbarazada.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD II - AMARILLO";
                    lblTiempo.Text = "Menos de 2 horas";
                    lblArea.Text = "Consulta prioritaria";
                }
                else if (chkAdultoMayor.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD II - AMARILLO";
                    lblTiempo.Text = "Menos de 2 horas";
                    lblArea.Text = "Consulta prioritaria";
                }
                else if (chkDiscapacidad.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD II - AMARILLO";
                    lblTiempo.Text = "Menos de 2 horas";
                    lblArea.Text = "Consulta prioritaria";
                }
                else if (chkDescompensado.Checked == true)
                {
                    lblPrioridad.Text = "PRIORIDAD II - AMARILLO";
                    lblTiempo.Text = "Menos de 2 horas";
                    lblArea.Text = "Consulta prioritaria";
                }
                else if (temperatura >= 38 && temperatura < 40)
                {
                    lblPrioridad.Text = "PRIORIDAD II - AMARILLO";
                    lblTiempo.Text = "Menos de 2 horas";
                    lblArea.Text = "Consulta prioritaria";
                }
                else
                {
                    lblPrioridad.Text = "PRIORIDAD III - VERDE";
                    lblTiempo.Text = "2 horas, máximo 4 horas";
                    lblArea.Text = "Consulta general";
                }
            }
            catch
            {
                MessageBox.Show("Debe ingresar correctamente los datos.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtEdad.Text = "";
            txtMotivo.Text = "";

            txtTemperatura.Text = "";
            txtPresion.Text = "";
            txtSaturacion.Text = "";

            chkEmergencia.Checked = false;
            chkInconsciente.Checked = false;
            chkRespiracion.Checked = false;
            chkDeshidratacion.Checked = false;
            chkEmbarazadaEmergencia.Checked = false;
            chkEmbarazada.Checked = false;
            chkAdultoMayor.Checked = false;
            chkDiscapacidad.Checked = false;
            chkDescompensado.Checked = false;

            lblPrioridad.Text = "Sin clasificar";
            lblTiempo.Text = "Sin clasificar";
            lblArea.Text = "Sin clasificar";
        }
    }
}