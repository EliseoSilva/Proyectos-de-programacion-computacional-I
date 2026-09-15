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
        
        // --- Cálculo de factura de agua ---
        // Devuelve (tarifaAcueducto por m3, tarifaAlcantarillado fija)
        private static (double tarifaAcueducto, double tarifaAlcantarillado) GetTarifa(bool residencial, int metros)
        {
            if (residencial)
            {
                // Rangos residenciales
                if (metros <= 10) return (2.29, 0.10);
                if (metros <= 20) return (0.21, 0.10);
                if (metros == 21) return (0.25, 1.80);
                if (metros == 22) return (0.28, 1.80);
                if (metros == 23) return (0.31, 1.80);
                if (metros == 24) return (0.34, 1.80);
                if (metros <= 30) return (0.37, 0.37);
                if (metros == 31) return (0.42, 3.00);
                if (metros == 32) return (0.48, 3.00);
                if (metros == 33) return (0.54, 3.00);
                if (metros == 34) return (0.64, 3.00);
                if (metros <= 40) return (0.76, 3.00);
                if (metros == 41) return (0.90, 4.00);
                if (metros == 42) return (1.05, 4.00);
                if (metros == 43) return (1.20, 4.00);
                if (metros == 44) return (1.40, 4.00);
                if (metros <= 50) return (1.65, 4.00);
                if (metros <= 60) return (1.90, 7.50);
                if (metros <= 70) return (2.20, 7.50);
                if (metros <= 90) return (2.50, 7.50);
                if (metros <= 100) return (2.90, 7.50);
                if (metros <= 500) return (3.40, 10.00);
                return (3.90, 20.00);
            }

            // No residencial
            if (metros <= 5) return (3.760, 0.10);
            if (metros <= 20) return (0.900, 5.00);
            if (metros <= 30) return (1.200, 5.00);
            if (metros <= 50) return (1.500, 7.50);
            if (metros <= 60) return (1.875, 7.50);
            if (metros <= 90) return (2.344, 7.50);
            if (metros <= 100) return (2.930, 7.50);
            if (metros <= 500) return (3.662, 10.00);
            return (4.578, 20.00);
        }

        private void BtnCalculo_Click(object? sender, EventArgs e)
        {
            string text = txtMonto.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Ingrese el consumo en metros cúbicos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out int metros) &&
                !int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out metros))
            {
                MessageBox.Show("Consumo inválido. Ingrese un número entero de metros cúbicos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool residencial = true;
            if (cboTarifa.SelectedItem != null)
            {
                residencial = cboTarifa.SelectedItem.ToString() == "Residencial";
            }

            var (tarifaAcueducto, tarifaAlcantarillado) = GetTarifa(residencial, metros);
            double total = Math.Round(metros * tarifaAcueducto + tarifaAlcantarillado, 2);

            lblTotal.Text = $"Total a pagar: {total.ToString("C2", CultureInfo.CurrentCulture)}";
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            txtMonto.Clear();
            cboTarifa.SelectedIndex = -1;
            lblTotal.Text = "Total a pagar: $0.00";
        }
    }
}