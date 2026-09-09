using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Security.Cryptography.Pkcs;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Estadistica objEsta = new Estadistica();
        
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpar();
                String[] serie = txtSerie.Text.Split(',');
                double[] miSerie = serie.Select(n => double.Parse(n)).ToArray();
                double m = objEsta.media(miSerie);

                ltsValores.Items.Add("La media es: " + Math.Round(m, 3).ToString());
                ltsValores.Items.Add("La mediana es: " + Math.Round(objEsta.mediana(miSerie), 3).ToString());
                ltsValores.Items.Add("La desviación típica es: " + Math.Round(objEsta.desviacionTipica(miSerie, m), 3).ToString());
                ltsValores.Items.Add("La media armónica es: " + Math.Round(objEsta.mediaArmonica(miSerie), 3).ToString());
                ltsValores.Items.Add("La varianza es: " + Math.Round(objEsta.varianza(miSerie, m), 3).ToString());
                ltsValores.Items.Add("La moda es: " + Math.Round(objEsta.moda(miSerie), 3).ToString());
                ltsValores.Items.Add("La desviación estándar es: " + Math.Round(objEsta.desviacionEstandar(miSerie, m), 3).ToString());
                ltsValores.Items.Add("El rango es: " + Math.Round(objEsta.rango(miSerie), 3).ToString());
                ltsValores.Items.Add("La frecuencia del primer valor es: " + Math.Round(objEsta.frecuencia(miSerie, miSerie[0]), 3).ToString());
            }
            catch { }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void Limpar()
        {
            ltsValores.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}