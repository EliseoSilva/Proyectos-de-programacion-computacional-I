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
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            double monto = double.Parse(txtEconomia.Text);
            double impuesto = 0;

            double[,] impuestos =
            {
        { 0.01, 500, 1.5, 0 },
        { 500.01, 1000, 1.5, 3 },
        { 1000.01, 2000, 3, 3 },
        { 2000.01, 3000, 6, 3 },
        { 3000.01, 6000, 9, 2 },
        { 8000.01, 18000, 15, 2 },
        { 18000.01, 30000, 39, 2 },
        { 30000.01, 60000, 63, 1 },
        { 60000.01, 100000, 93, 0.8 },
        { 100000.01, 200000, 125, 0.7 },
        { 200000.01, 300000, 195, 0.6 },
        { 300000.01, 400000, 255, 0.45 },
        { 400000.01, 500000, 300, 0.4 },
        { 500000.01, 1000000, 340, 0.30 },
        { 1000000.01, 99999999, 490, 0.18 }
    };

            for (int i = 0; i < impuestos.GetLength(0); i++)
            {
                if (monto >= impuestos[i, 0] && monto <= impuestos[i, 1])
                {
                    impuesto = ((monto - impuestos[i, 0]) / 1000 * impuestos[i, 3])
                               + impuestos[i, 2];

                    break;
                }
            }

            lblTotal.Text = "Total Impuestos: " + impuesto.ToString("N2");
        }
    }
    
}