namespace PrimeraAplicacion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblConsumoDeAgua = new Label();
            txtMonto = new TextBox();
            lblTarifa = new Label();
            cboTarifa = new ComboBox();
            btnCalculo = new Button();
            btnLimpiar = new Button();
            lblTotal = new Label();
            dgvFacturas = new DataGridView();
            dtpMes = new DateTimePicker();
            btnRegistrarFactura = new Button();
            btnMarcarPagada = new Button();
            txtPago = new TextBox();
            btnRegistrarPago = new Button();
            btnActualizarSaldo = new Button();
            lblAcumulado = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // lblConsumoDeAgua
            // 
            lblConsumoDeAgua.AutoSize = true;
            lblConsumoDeAgua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConsumoDeAgua.Location = new Point(20, 20);
            lblConsumoDeAgua.Name = "lblConsumoDeAgua";
            lblConsumoDeAgua.Size = new Size(193, 22);
            lblConsumoDeAgua.TabIndex = 0;
            lblConsumoDeAgua.Text = "Consumo de agua (m³):";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(20, 50);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(140, 27);
            txtMonto.TabIndex = 1;
            // 
            // lblTarifa
            // 
            lblTarifa.AutoSize = true;
            lblTarifa.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTarifa.Location = new Point(180, 52);
            lblTarifa.Name = "lblTarifa";
            lblTarifa.Size = new Size(104, 19);
            lblTarifa.TabIndex = 2;
            lblTarifa.Text = "Tipo de tarifa:";
            // 
            // cboTarifa
            // 
            cboTarifa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTarifa.Items.AddRange(new object[] { "Residencial", "No Residencial" });
            cboTarifa.Location = new Point(290, 50);
            cboTarifa.Name = "cboTarifa";
            cboTarifa.Size = new Size(150, 28);
            cboTarifa.TabIndex = 3;
            // 
            // btnCalculo
            // 
            btnCalculo.Location = new Point(20, 90);
            btnCalculo.Name = "btnCalculo";
            btnCalculo.Size = new Size(140, 40);
            btnCalculo.TabIndex = 4;
            btnCalculo.Text = "Calcular factura";
            btnCalculo.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(180, 90);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(100, 40);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(20, 140);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(170, 22);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total a pagar: $0.00";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.ColumnHeadersHeight = 29;
            dgvFacturas.Location = new Point(15, 174);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersWidth = 51;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(1216, 243);
            dgvFacturas.TabIndex = 11;
            // 
            // dtpMes
            // 
            dtpMes.CustomFormat = "MMMM yyyy";
            dtpMes.Format = DateTimePickerFormat.Custom;
            dtpMes.Location = new Point(20, 480);
            dtpMes.Name = "dtpMes";
            dtpMes.ShowUpDown = true;
            dtpMes.Size = new Size(180, 27);
            dtpMes.TabIndex = 12;
            // 
            // btnRegistrarFactura
            // 
            btnRegistrarFactura.Location = new Point(210, 476);
            btnRegistrarFactura.Name = "btnRegistrarFactura";
            btnRegistrarFactura.Size = new Size(150, 33);
            btnRegistrarFactura.TabIndex = 13;
            btnRegistrarFactura.Text = "Registrar factura";
            btnRegistrarFactura.UseVisualStyleBackColor = true;
            // 
            // btnMarcarPagada
            // 
            btnMarcarPagada.Location = new Point(384, 476);
            btnMarcarPagada.Name = "btnMarcarPagada";
            btnMarcarPagada.Size = new Size(150, 33);
            btnMarcarPagada.TabIndex = 14;
            btnMarcarPagada.Text = "Marcar como pagada";
            btnMarcarPagada.UseVisualStyleBackColor = true;
            // 
            // txtPago
            // 
            txtPago.Location = new Point(544, 482);
            txtPago.Name = "txtPago";
            txtPago.Size = new Size(120, 27);
            txtPago.TabIndex = 15;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(670, 476);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(120, 33);
            btnRegistrarPago.TabIndex = 16;
            btnRegistrarPago.Text = "Registrar pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // btnActualizarSaldo
            // 
            btnActualizarSaldo.Location = new Point(800, 476);
            btnActualizarSaldo.Name = "btnActualizarSaldo";
            btnActualizarSaldo.Size = new Size(120, 33);
            btnActualizarSaldo.TabIndex = 17;
            btnActualizarSaldo.Text = "Actualizar saldo";
            btnActualizarSaldo.UseVisualStyleBackColor = true;
            // 
            // lblAcumulado
            // 
            lblAcumulado.AutoSize = true;
            lblAcumulado.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAcumulado.Location = new Point(457, 426);
            lblAcumulado.Name = "lblAcumulado";
            lblAcumulado.Size = new Size(247, 23);
            lblAcumulado.TabIndex = 18;
            lblAcumulado.Text = "Acumulado pendiente: $0.00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1248, 539);
            Controls.Add(lblAcumulado);
            Controls.Add(btnActualizarSaldo);
            Controls.Add(btnRegistrarPago);
            Controls.Add(txtPago);
            Controls.Add(btnMarcarPagada);
            Controls.Add(btnRegistrarFactura);
            Controls.Add(dtpMes);
            Controls.Add(dgvFacturas);
            Controls.Add(lblTotal);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalculo);
            Controls.Add(cboTarifa);
            Controls.Add(lblTarifa);
            Controls.Add(txtMonto);
            Controls.Add(lblConsumoDeAgua);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CÁLCULO DE AGUA POTABLE Y REGISTRO DE FACTURAS";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsumoDeAgua;
        private TextBox txtMonto;
        private Label lblTarifa;
        private ComboBox cboTarifa;
        private Button btnCalculo;
        private Button btnLimpiar;
        private Label lblTotal;

        private DataGridView dgvFacturas;
        private DateTimePicker dtpMes;
        private Button btnRegistrarFactura;
        private Button btnMarcarPagada;
        private TextBox txtPago;
        private Button btnRegistrarPago;
        private Button btnActualizarSaldo;
        private Label lblAcumulado;
    }
}
