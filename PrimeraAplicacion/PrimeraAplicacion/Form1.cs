using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms; 

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        //Se registra el consumo mensual de metros cubicos de agua potable
        //luego se registra la factura y se calcula el valor a pagar segun la tarifa seleccionada
        //Si esta pagada se "Marca como", indica que la factura ya fue pagada
        //Si no esta pagada se puede registrar un pago parcial o total, y se actualiza el saldo pendiente
        public Form1()
        {
            InitializeComponent();
            
            btnCalculo.Click += BtnCalculo_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnRegistrarFactura.Click += BtnRegistrarFactura_Click;
            btnMarcarPagada.Click += BtnMarcarPagada_Click;
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnActualizarSaldo.Click += BtnActualizarSaldo_Click;
        }
        
        
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

        private class FacturaRecord
        {
            public int Id { get; set; }
            public DateTime Mes { get; set; }
            public int Consumo { get; set; }
            public double TarifaAcueducto { get; set; }
            public double TarifaAlcantarillado { get; set; }
            public double MontoFactura { get; set; }
            public string Estado { get; set; } 
            public double MontoPendiente { get; set; }
        }

        private readonly List<FacturaRecord> facturas = new();

        private (double monto, double tarifaA, double tarifaL) CalcularFacturaPorConsumo(int metros, bool residencial)
        {
            var (tarifaA, tarifaL) = GetTarifa(residencial, metros);
            double monto = Math.Round(metros * tarifaA + tarifaL, 2);
            return (monto, tarifaA, tarifaL);
        }

        private void BtnRegistrarFactura_Click(object? sender, EventArgs e)
        {
            
            if (!int.TryParse(txtMonto.Text?.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out int metros) &&
                !int.TryParse(txtMonto.Text?.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out metros))
            {
                MessageBox.Show("Consumo inválido para registrar factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool residencial = cboTarifa.SelectedItem?.ToString() == "Residencial";

            DateTime mes = DateTime.Now;
            
            if (this.Controls.OfType<DateTimePicker>().FirstOrDefault() is DateTimePicker dtp)
            {
                mes = new DateTime(dtp.Value.Year, dtp.Value.Month, 1);
            }

            var (monto, tarifaA, tarifaL) = CalcularFacturaPorConsumo(metros, residencial);

            var nueva = new FacturaRecord
            {
                Id = facturas.Count == 0 ? 1 : facturas.Max(f => f.Id) + 1,
                Mes = mes,
                Consumo = metros,
                TarifaAcueducto = tarifaA,
                TarifaAlcantarillado = tarifaL,
                MontoFactura = monto,
                Estado = "Pendiente",
                MontoPendiente = monto
            };

            facturas.Add(nueva);
            UpdateGridFacturas();
            UpdateAcumuladoLabel();
            MessageBox.Show($"Factura registrada: {monto.ToString("C2", CultureInfo.CurrentCulture)}", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMarcarPagada_Click(object? sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una factura en la tabla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value);
            var fac = facturas.FirstOrDefault(f => f.Id == id);
            if (fac == null) return;

            if (fac.Estado == "Pagado")
            {
                MessageBox.Show("La factura ya está marcada como pagada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            fac.Estado = "Pagado";
            fac.MontoPendiente = 0.0;
            facturas.Remove(fac);
            UpdateGridFacturas();
            UpdateAcumuladoLabel();
        }

        private void BtnRegistrarPago_Click(object? sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la factura a la que aplica el pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!double.TryParse(txtPago?.Text?.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out double pago) &&
                !double.TryParse(txtPago?.Text?.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out pago))
            {
                MessageBox.Show("Monto de pago inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value);
            var fac = facturas.FirstOrDefault(f => f.Id == id);
            if (fac == null) return;

            if (fac.Estado == "Pagado")
            {
                MessageBox.Show("La factura ya está pagada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (pago <= 0)
            {
                MessageBox.Show("El monto de pago debe ser mayor que 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pago >= fac.MontoPendiente)
            {
                
                pago = fac.MontoPendiente;
                fac.MontoPendiente = 0.0;
                fac.Estado = "Pagado";
                facturas.Remove(fac);
            }
            else
            {
               
                fac.MontoPendiente = Math.Round(fac.MontoPendiente - pago, 2);
                
            }

            UpdateGridFacturas();
            UpdateAcumuladoLabel();
            MessageBox.Show($"Pago registrado: {pago.ToString("C2", CultureInfo.CurrentCulture)}", "Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnActualizarSaldo_Click(object? sender, EventArgs e)
        {
            UpdateAcumuladoLabel();
            UpdateGridFacturas();
        }

        private void UpdateGridFacturas()
        {
            dgvFacturas.SuspendLayout();
            dgvFacturas.Rows.Clear();

            
            if (dgvFacturas.Columns.Count == 0)
            {
                dgvFacturas.Columns.Add("Id", "Id");
                dgvFacturas.Columns.Add("Mes", "Mes");
                dgvFacturas.Columns.Add("Consumo", "Consumo (m³)");
                dgvFacturas.Columns.Add("Factura", "Valor factura");
                dgvFacturas.Columns.Add("Estado", "Estado");
                dgvFacturas.Columns.Add("Pendiente", "Monto pendiente");
                dgvFacturas.Columns.Add("Acumulado", "Acumulado");
            }

            
            var ordenadas = facturas.OrderBy(f => f.Mes).ToList();
            double acumulado = 0.0;
            foreach (var f in ordenadas)
            {
                if (f.Estado == "Pendiente") acumulado += f.MontoPendiente;
                var row = new string[]
                {
                    f.Id.ToString(),
                    f.Mes.ToString("MMMM yyyy", new CultureInfo("es-US")),
                    f.Consumo.ToString(),
                    f.MontoFactura.ToString("C2", CultureInfo.CurrentCulture),
                    f.Estado,
                    f.MontoPendiente.ToString("C2", CultureInfo.CurrentCulture),
                    acumulado.ToString("C2", CultureInfo.CurrentCulture)
                };
                dgvFacturas.Rows.Add(row);
            }

            dgvFacturas.ResumeLayout();
        }

        private void UpdateAcumuladoLabel()
        {
            double totalPendiente = facturas.Where(f => f.Estado == "Pendiente").Sum(f => f.MontoPendiente);
           
            var label = this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lblAcumulado");
            if (label != null)
            {
                label.Text = $"Acumulado pendiente: {totalPendiente.ToString("C2", CultureInfo.CurrentCulture)}";
            }
        }
    }
}