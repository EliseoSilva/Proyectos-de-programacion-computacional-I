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

        double media(double[] serie)
        {
            double suma = 0;
            for (int i = 0; i < serie.Length; i++)
            {
                suma += serie[i];
            }
            double media = suma / serie.Length;
            return media;
        }
        double mediana(double[] serie) {
            Array.Sort(serie);
            int n = serie.Length;
            if (n % 2 == 0)
                return (serie[n / 2 - 1] + serie[n / 2]) / 2;
            else
                return serie[n / 2];
        }
        double desviacionTipica(double[] serie, double media)
        {
            return Math.Sqrt(varianza(serie, media));
        }
        double mediaArmonica(double[] serie)
        {
            int n = serie.Length;
            return n / serie.Sum(x => 1 / x);
        }
        double varianza(double[] serie, double media)
        {
            return serie.Average(n => Math.Pow(n - media, 2));
        }
        double moda(double[] serie)
        {
            var grupos = serie.GroupBy(n => n);
            var moda = grupos.OrderByDescending(g => g.Count()).First().Key;
            return moda;
        }
        double desviacionEstantar(double[] serie, double media)
        {
            return Math.Sqrt(varianza(serie, media));
        }
        double rango(double[] serie)
        {
            return serie.Max() - serie.Min();
        }
        double frecuencia(double[] serie, double valor)
        {
            return serie.Count(n => n == valor);
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpar();
                String[] serie = txtSerie.Text.Split(',');
                double[] miSerie = serie.Select(n => double.Parse(n)).ToArray();
                double m = media(miSerie);

                ltsValores.Items.Add("La media es: " + Math.Round(m, 3).ToString());
                ltsValores.Items.Add("La mediana es: " + Math.Round(mediana(miSerie), 3).ToString());
                ltsValores.Items.Add("La desviación típica es: " + Math.Round(desviacionTipica(miSerie, m), 3).ToString());
                ltsValores.Items.Add("La media armónica es: " + Math.Round(mediaArmonica(miSerie), 3).ToString());
                ltsValores.Items.Add("La varianza es: " + Math.Round(varianza(miSerie, m), 3).ToString());
                ltsValores.Items.Add("La moda es: " + Math.Round(moda(miSerie), 3).ToString());
                ltsValores.Items.Add("La desviación estándar es: " + Math.Round(desviacionEstantar(miSerie, m), 3).ToString());
                ltsValores.Items.Add("El rango es: " + Math.Round(rango(miSerie), 3).ToString());
                ltsValores.Items.Add("La frecuencia del primer valor es: " + Math.Round(frecuencia(miSerie, miSerie[0]), 3).ToString());
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