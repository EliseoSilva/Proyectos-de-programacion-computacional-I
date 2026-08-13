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
                int tabla = int.Parse(txtTabla.Text);
                string msg = "";
                for (int i = 1; i <= 10; i++)
                {
                    msg += $"{tabla} x {i} = {tabla * i}\n";
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