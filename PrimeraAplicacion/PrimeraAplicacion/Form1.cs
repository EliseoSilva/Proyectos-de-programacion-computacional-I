using System.Diagnostics.Eventing.Reader;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int edad = int.Parse(txtEdad.Text);
            if (edad < 0)
            {
                lblRespuesta.Text = "Edad no válida";
            }
            else if (edad <= 2)
            {
                lblRespuesta.Text = "Bebé";

            }
            else if (edad <= 12)
            {
                lblRespuesta.Text = "Niño";
            }
            else if (edad <= 17)
            {
                lblRespuesta.Text = "Adolescente";
            }
            else if (edad <= 65)
            {
                lblRespuesta.Text = "Adulto";
            }
            else if (edad <= 80)
            {
                lblRespuesta.Text = "Adulto mayor";

            }
            else if (edad <= 130)
            {
                lblRespuesta.Text = "Larga Vida";
            }
            else
            {
                lblRespuesta.Text = "Edad no válida";
            }
        }
    }
}