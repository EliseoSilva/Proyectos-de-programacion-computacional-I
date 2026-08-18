using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.Pkcs;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {

        string[][] etiquetas = {
            new string[]{"Metros", "Centímetros", "Pulgadas", "Pies", "Varas", "Yardas", "Kilómetros", "Millas", "Milímetros", "Milla Nautica"}, //Longitud
            new string[]{"Dolar", "quetzal", "Lempira", "Cordobas", "Colon CR", "Euro", "Peso MxM", "libra Esterlina", "Peso Argentino", "Bitcoin"}, //Moneda
            new string[]{"Nanogramo", "Microgramo", "Miligramo", "Gramo", "Onza", "Libra", "Kilogramo", "Piedra", "Quintal", "Tonelada"}, //Masa
            new string[]{"Microlitro", "Mililitro", "Centilitro", "Decilitro", "Litro", "Decalitro", "Hectolitro", "Kilolitro", "Megalitro", "Gigalitro"}, //Volumen
            new string[]{"Bit", "Byte", "Kilobyte", "Megabyte", "Gigabyte", "Terabyte", "Petabyte", "Exabyte", "Zettabyte", "Yottabyte"}, //Almacenamiento
            new string[]{"Nanosegundo", "Microsegundo", "Milisegundo", "Segundo", "Minuto", "Hora", "Día", "Semana", "Mes", "Año"} //Tiempo
        };


        Double[][] valores = {
            new double []{1, 100, 39.37, 3.28084, 1.19631, 1.09361, 0.001, 0.000621371, 1000, 0.000539957}, //Longitud
            new double []{1, 7.63, 26.82, 36.81, 449.27, 0.86, 17.06, 0.74, 1495.36, 0.000015}, //Moneda
            new double []{1000000000.0, 1000000.0, 1000.0, 1.0, 0.03527396, 0.00220462, 0.001, 0.000157473, 0.00001, 0.000001}, //Masa
            new double []{1000000.0, 1000.0, 100.0, 10.0, 1.0, 0.1, 0.01, 0.001, 0.000001, 0.000000001}, //Volumen
            new double []{8.0, 1.0, 0.0009765625, 0.0000009536743164, 0.0000000009313225746, 0.0000000000009094947018, 0.0000000000000008881784197, 0.0000000000000000008673617, 0.0000000000000000000008470329, 0.0000000000000000000000008271806}, //Almacenamiento
            new double []{1000000000.0, 1000000.0, 1000.0, 1.0, 0.0166666667, 0.000277777778, 0.0000115740741, 0.00000165343915, 0.000000380517504, 0.000000031688087} //Tiempo
        };
        public Form1()
        {
            InitializeComponent();

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                int de = cboDe.SelectedIndex, a = cboA.SelectedIndex, opcion = cboOpciones.SelectedIndex;
                double cantidad = Double.Parse(txtCantidad.Text);

                double respuesta = valores[opcion][a] / valores[opcion][de] * cantidad;
                lblRespuesta.Text = "Respuesta: " + Math.Round(respuesta, 5).ToString();
            }
            catch
            {
                lblRespuesta.Text = "Error en la entrada de datos";
            }
        }

        private void cboOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboA.Items.Clear();
            cboDe.Items.Clear();

            int opcion = cboOpciones.SelectedIndex;
            cboDe.Items.AddRange(etiquetas[opcion]);
            cboA.Items.AddRange(etiquetas[opcion]);
        }
    }
}