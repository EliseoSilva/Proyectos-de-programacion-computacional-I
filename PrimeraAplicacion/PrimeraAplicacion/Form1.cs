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
                int tabla = int.Parse(txtTabla.Text), i = 1;
                string msg = "";
                while (i <= 10) { 
                    msg += $"{tabla} x {i} = {tabla * i}\n";
                    i++;
                }
                lblRespuesta.Text = msg;
            }
            catch (Exception)
            {
                lblRespuesta.Text = "Ingrese un número válido";
            }
        }
    }
}