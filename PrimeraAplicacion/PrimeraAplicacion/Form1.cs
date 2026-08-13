using System.Diagnostics.Eventing.Reader;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        /* Metros, Cm, Pulgadas, Pies, Varas, Yardas, Km, Millas, mm
            */
        double[] valores = { 1, 100, 39.3701, 3.28084, 1.1963, 109361, 0.001, 0.000621371, 1000 };
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try {
                int de = cboDe.SelectedIndex, a = cboA.SelectedIndex;
                double cantidad = Double.Parse(txtCantidad.Text);

                double respuesta = valores[a] / valores[de] * cantidad;
                lblRespuesta.Text = respuesta.ToString();
            } catch {
                lblRespuesta.Text = "Error en la entrada de datos";
            }
        }
    }
}