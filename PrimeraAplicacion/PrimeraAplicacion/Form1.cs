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

        double media(double[] serie) {  
            double suma = 0;
            for (int i = 0; i < serie.Length; i++) {
                suma += serie[i];
                }
            double media = suma / serie.Length;
            return media;
        }
        double desviacionTipica(double[] serie, double media) { 
            return Math.Sqrt(serie.Average(n => Math.Pow(n - media, 2)));
        }
        //media armonica
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                String[] serie = txtSerie.Text.Split(',');
            double[] miSerie = serie.Select(n=>double.Parse(n)).ToArray();
            double m = media(miSerie);

                ltsValores.Items.Add("La media es: " + Math.Round(m, 3).ToString());
                ltsValores.Items.Add("La desviación típica es: " + Math.Round(desviacionTipica(miSerie, m), 3).ToString());
            } catch { }
        }
    }
}