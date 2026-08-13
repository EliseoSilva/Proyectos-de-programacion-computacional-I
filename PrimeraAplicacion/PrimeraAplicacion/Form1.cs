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
            try
            {
                int edad = int.Parse(txtEdad.Text);
                string msg = "Ingrese su edad";
                msg = edad < 0 ? "edad no puede ser negativa":
                    edad <= 2 ? "Eres un bebé" :
                    edad <= 12 ? "Eres un niño" :
                    edad <= 17 ? "Eres un adolescente" :
                    edad <= 65 ? "Eres un adulto" :
                    edad <= 80 ? "Eres un adulto mayor" :
                    edad <= 130 ? "Tienes una larga vida" :
                    "Edad no válida";
                lblRespuesta.Text = msg;
            }
            catch (Exception)
            {
                lblRespuesta.Text = "Ingrese su edad en numeros enteros";
            }
        }
    }
}