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
            btnCalcular = new Button();
            lblDe = new Label();
            lblA = new Label();
            lblCantidad = new Label();
            lblRespuesta = new Label();
            txtCantidad = new TextBox();
            cboDe = new ComboBox();
            cboA = new ComboBox();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(192, 192, 255);
            btnCalcular.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.Black;
            btnCalcular.Location = new Point(135, 293);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(281, 106);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblDe
            // 
            lblDe.AutoSize = true;
            lblDe.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDe.Location = new Point(28, 41);
            lblDe.Name = "lblDe";
            lblDe.Size = new Size(47, 26);
            lblDe.TabIndex = 1;
            lblDe.Text = "DE:";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblA.Location = new Point(312, 41);
            lblA.Name = "lblA";
            lblA.Size = new Size(34, 26);
            lblA.TabIndex = 2;
            lblA.Text = "A:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(28, 158);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(101, 26);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRespuesta.Location = new Point(205, 233);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(141, 26);
            lblRespuesta.TabIndex = 6;
            lblRespuesta.Text = "Respuesta      ";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(135, 159);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(203, 27);
            txtCantidad.TabIndex = 7;
            // 
            // cboDe
            // 
            cboDe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDe.FormattingEnabled = true;
            cboDe.Items.AddRange(new object[] { "Metros", "Cm", "Pulgadas", "Pies", "Varas", "Yardas", "Km", "Millas", "mm" });
            cboDe.Location = new Point(78, 41);
            cboDe.Name = "cboDe";
            cboDe.Size = new Size(203, 28);
            cboDe.TabIndex = 8;
            // 
            // cboA
            // 
            cboA.DropDownStyle = ComboBoxStyle.DropDownList;
            cboA.FormattingEnabled = true;
            cboA.Items.AddRange(new object[] { "Metros", "Cm", "Pulgadas", "Pies", "Varas", "Yardas", "Km", "Millas", "mm" });
            cboA.Location = new Point(351, 41);
            cboA.Name = "cboA";
            cboA.Size = new Size(203, 28);
            cboA.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 436);
            Controls.Add(cboA);
            Controls.Add(cboDe);
            Controls.Add(txtCantidad);
            Controls.Add(lblRespuesta);
            Controls.Add(lblCantidad);
            Controls.Add(lblA);
            Controls.Add(lblDe);
            Controls.Add(btnCalcular);
            Name = "Form1";
            Text = "Conversor de longitud";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private Label lblDe;
        private Label lblA;
        private Label lblCantidad;
        private Label lblRespuesta;
        private TextBox txtCantidad;
        private ComboBox cboDe;
        private ComboBox cboA;
    }
}
