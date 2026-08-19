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

        

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                String[] serie = txtSerie.Text.Split(',');
            double[] miSerie = serie.Select(n=>double.Parse(n)).ToArray();
            double suma = 0;
            for (int i = 0; i < serie.Length; i++) {
                suma += miSerie[i];
                }
            double media = suma / miSerie.Length;
            ltsValores.Items.Add("La media es: " + media);

            } catch { }
        }
    }
}