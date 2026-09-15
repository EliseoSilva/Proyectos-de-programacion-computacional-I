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
            btnCalculo = new Button();
            txtMonto = new TextBox();
            btnLimpiar = new Button();
            lblTotal = new Label();
            lblTarifa = new Label();
            cboTarifa = new ComboBox();
            SuspendLayout();
            // 
            // lblConsumoDeAgua
            // 
            lblConsumoDeAgua.AutoSize = true;
            lblConsumoDeAgua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConsumoDeAgua.Location = new Point(172, 33);
            lblConsumoDeAgua.Name = "lblConsumoDeAgua";
            lblConsumoDeAgua.Size = new Size(198, 22);
            lblConsumoDeAgua.TabIndex = 0;
            lblConsumoDeAgua.Text = " Consumo de agua (m³):";
            // 
            // btnCalculo
            // 
            btnCalculo.Location = new Point(204, 155);
            btnCalculo.Name = "btnCalculo";
            btnCalculo.Size = new Size(154, 51);
            btnCalculo.TabIndex = 2;
            btnCalculo.Text = "CALCULO";
            btnCalculo.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(172, 58);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(198, 27);
            txtMonto.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(204, 223);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(154, 33);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(178, 279);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(170, 22);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total a pagar: $0.00";
            // 
            // lblTarifa
            // 
            lblTarifa.AutoSize = true;
            lblTarifa.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTarifa.Location = new Point(172, 102);
            lblTarifa.Name = "lblTarifa";
            lblTarifa.Size = new Size(104, 19);
            lblTarifa.TabIndex = 6;
            lblTarifa.Text = "Tipo de tarifa:";
            // 
            // cboTarifa
            // 
            cboTarifa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTarifa.Items.AddRange(new object[] { "Residencial", "No Residencial" });
            cboTarifa.Location = new Point(282, 98);
            cboTarifa.Name = "cboTarifa";
            cboTarifa.Size = new Size(150, 28);
            cboTarifa.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(549, 336);
            Controls.Add(lblTotal);
            Controls.Add(btnLimpiar);
            Controls.Add(txtMonto);
            Controls.Add(cboTarifa);
            Controls.Add(lblTarifa);
            Controls.Add(btnCalculo);
            Controls.Add(lblConsumoDeAgua);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "                                        CÁLCULO DE AGUA POTABLE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConsumoDeAgua;
        private Button btnCalculo;
        private TextBox txtMonto;
        private Button btnLimpiar;
        private Label lblTotal;
        private Label lblTarifa;
        private ComboBox cboTarifa;
    }
}
