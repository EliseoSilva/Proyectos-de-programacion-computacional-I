using System;
using System.Globalization;                                                 
using System.Windows.Forms; 

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
                
        public Form1()
        {
            InitializeComponent();
            
            btnCalculo.Click += BtnCalculo_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
        }
        
        public record DeduccionesResult(double SalarioBruto, double ISSS, double AFP, double ISR, double SalarioNeto);

        
        public static DeduccionesResult CalcularDeducciones(double salarioBruto)
        {
            if (salarioBruto <= 0)
                return new DeduccionesResult(salarioBruto, 0, 0, 0, salarioBruto);

            // Porcentajes fijos
            double porcentajeISSS = 0.03;   // 3%
            double porcentajeAFP = 0.0725;  // 7.25%

            double isss = Math.Round(salarioBruto * porcentajeISSS, 2);
            double afp = Math.Round(salarioBruto * porcentajeAFP, 2);

            double baseImponible = salarioBruto - isss - afp;

            
            var tramos = new (double limite, double cuotaFija, double tasa)[]
            {
                (472.00, 0.00, 0.00),         // hasta 472.00 => exento
                (895.24, 0.00, 0.10),         // 10% sobre el excedente de 472.00
                (2038.10, 42.20, 0.20),       // 20% sobre el excedente de 895.24 + cuota fija
                (double.MaxValue, 162.46, 0.30) // 30% sobre el excedente de 2038.10 + cuota fija
            };

            double isr = 0.0;
            double limiteAnterior = 0.0;

            foreach (var tramo in tramos)
            {
                if (baseImponible <= tramo.limite)
                {
                    if (tramo.tasa == 0.0)
                    {
                        isr = 0.0;
                    }
                    else
                    {
                        isr = tramo.cuotaFija + tramo.tasa * Math.Round(baseImponible - limiteAnterior, 2);
                    }
                    break;
                }

                limiteAnterior = tramo.limite;
            }

            isr = Math.Round(Math.Max(0, isr), 2);

            double salarioNeto = Math.Round(salarioBruto - isss - afp - isr, 2);

            return new DeduccionesResult(salarioBruto, isss, afp, isr, salarioNeto);
        }

        private void BtnCalculo_Click(object? sender, EventArgs e)
        {
            ltsIssIsrAfp.Items.Clear();

            
            string text = txtMonto.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Ingrese un monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out double salario) &&
                !double.TryParse(text, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out salario))
            {
                MessageBox.Show("Monto inválido. Use números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = CalcularDeducciones(salario);

            
            var ci = CultureInfo.CurrentCulture;
            ltsIssIsrAfp.Items.Add($"Salario bruto: {res.SalarioBruto.ToString("C2", ci)}");
            ltsIssIsrAfp.Items.Add($"ISSS (3%): {res.ISSS.ToString("C2", ci)}");
            ltsIssIsrAfp.Items.Add($"AFP (7.25%): {res.AFP.ToString("C2", ci)}");
            double baseImponible = Math.Round(res.SalarioBruto - res.ISSS - res.AFP, 2);
            ltsIssIsrAfp.Items.Add($"Base imponible: {baseImponible.ToString("C2", ci)}");
            ltsIssIsrAfp.Items.Add($"ISR: {res.ISR.ToString("C2", ci)}");
            ltsIssIsrAfp.Items.Add($"Salario neto: {res.SalarioNeto.ToString("C2", ci)}");
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            txtMonto.Clear();
            ltsIssIsrAfp.Items.Clear();
        }
    }
}