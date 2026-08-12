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
            lblNum1 = new Label();
            lblNum2 = new Label();
            txtNum1 = new TextBox();
            txtNum2 = new TextBox();
            lblRespuesta = new Label();
            rdbSuma = new RadioButton();
            rdbResta = new RadioButton();
            rdbMultiplicacion = new RadioButton();
            rdbDivision = new RadioButton();
            rdbExponente = new RadioButton();
            rdbRaiz = new RadioButton();
            rdbFactorial = new RadioButton();
            gboOperaciones = new GroupBox();
            cboOpciones = new ComboBox();
            gboOperaciones.SuspendLayout();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalcular.Location = new Point(183, 419);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(145, 85);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblNum1
            // 
            lblNum1.AutoSize = true;
            lblNum1.Font = new Font("Times New Roman", 12F);
            lblNum1.Location = new Point(43, 54);
            lblNum1.Name = "lblNum1";
            lblNum1.Size = new Size(68, 22);
            lblNum1.TabIndex = 1;
            lblNum1.Text = "Num 1:";
            // 
            // lblNum2
            // 
            lblNum2.AutoSize = true;
            lblNum2.Font = new Font("Times New Roman", 12F);
            lblNum2.Location = new Point(43, 101);
            lblNum2.Name = "lblNum2";
            lblNum2.Size = new Size(68, 22);
            lblNum2.TabIndex = 2;
            lblNum2.Text = "Num 2:";
            // 
            // txtNum1
            // 
            txtNum1.Location = new Point(117, 49);
            txtNum1.Name = "txtNum1";
            txtNum1.Size = new Size(125, 27);
            txtNum1.TabIndex = 3;
            // 
            // txtNum2
            // 
            txtNum2.Location = new Point(117, 96);
            txtNum2.Name = "txtNum2";
            txtNum2.Size = new Size(125, 27);
            txtNum2.TabIndex = 4;
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Font = new Font("Times New Roman", 12F);
            lblRespuesta.Location = new Point(24, 329);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(131, 22);
            lblRespuesta.TabIndex = 5;
            lblRespuesta.Text = "Respuesta :      ";
            // 
            // rdbSuma
            // 
            rdbSuma.AutoSize = true;
            rdbSuma.Checked = true;
            rdbSuma.Location = new Point(17, 38);
            rdbSuma.Name = "rdbSuma";
            rdbSuma.Size = new Size(71, 24);
            rdbSuma.TabIndex = 0;
            rdbSuma.TabStop = true;
            rdbSuma.Text = "SUMA";
            rdbSuma.UseVisualStyleBackColor = true;
            // 
            // rdbResta
            // 
            rdbResta.AutoSize = true;
            rdbResta.Location = new Point(17, 68);
            rdbResta.Name = "rdbResta";
            rdbResta.Size = new Size(72, 24);
            rdbResta.TabIndex = 1;
            rdbResta.TabStop = true;
            rdbResta.Text = "RESTA";
            rdbResta.UseVisualStyleBackColor = true;
            // 
            // rdbMultiplicacion
            // 
            rdbMultiplicacion.AutoSize = true;
            rdbMultiplicacion.Location = new Point(17, 98);
            rdbMultiplicacion.Name = "rdbMultiplicacion";
            rdbMultiplicacion.Size = new Size(144, 24);
            rdbMultiplicacion.TabIndex = 2;
            rdbMultiplicacion.TabStop = true;
            rdbMultiplicacion.Text = "MULTIPLICACION";
            rdbMultiplicacion.UseVisualStyleBackColor = true;
            // 
            // rdbDivision
            // 
            rdbDivision.AutoSize = true;
            rdbDivision.Location = new Point(17, 129);
            rdbDivision.Name = "rdbDivision";
            rdbDivision.Size = new Size(92, 24);
            rdbDivision.TabIndex = 3;
            rdbDivision.TabStop = true;
            rdbDivision.Text = "DIVISION";
            rdbDivision.UseVisualStyleBackColor = true;
            // 
            // rdbExponente
            // 
            rdbExponente.AutoSize = true;
            rdbExponente.Location = new Point(17, 159);
            rdbExponente.Name = "rdbExponente";
            rdbExponente.Size = new Size(112, 24);
            rdbExponente.TabIndex = 4;
            rdbExponente.TabStop = true;
            rdbExponente.Text = "EXPONENTE";
            rdbExponente.UseVisualStyleBackColor = true;
            // 
            // rdbRaiz
            // 
            rdbRaiz.AutoSize = true;
            rdbRaiz.Location = new Point(17, 189);
            rdbRaiz.Name = "rdbRaiz";
            rdbRaiz.Size = new Size(62, 24);
            rdbRaiz.TabIndex = 5;
            rdbRaiz.TabStop = true;
            rdbRaiz.Text = "RAIZ";
            rdbRaiz.UseVisualStyleBackColor = true;
            // 
            // rdbFactorial
            // 
            rdbFactorial.AutoSize = true;
            rdbFactorial.Location = new Point(17, 219);
            rdbFactorial.Name = "rdbFactorial";
            rdbFactorial.Size = new Size(103, 24);
            rdbFactorial.TabIndex = 6;
            rdbFactorial.TabStop = true;
            rdbFactorial.Text = "FACTORIAL";
            rdbFactorial.UseVisualStyleBackColor = true;
            // 
            // gboOperaciones
            // 
            gboOperaciones.Controls.Add(rdbFactorial);
            gboOperaciones.Controls.Add(rdbRaiz);
            gboOperaciones.Controls.Add(rdbExponente);
            gboOperaciones.Controls.Add(rdbDivision);
            gboOperaciones.Controls.Add(rdbMultiplicacion);
            gboOperaciones.Controls.Add(rdbResta);
            gboOperaciones.Controls.Add(rdbSuma);
            gboOperaciones.Location = new Point(268, 124);
            gboOperaciones.Name = "gboOperaciones";
            gboOperaciones.Size = new Size(250, 261);
            gboOperaciones.TabIndex = 6;
            gboOperaciones.TabStop = false;
            gboOperaciones.Text = "Opciones";
            // 
            // cboOpciones
            // 
            cboOpciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOpciones.FormattingEnabled = true;
            cboOpciones.Items.AddRange(new object[] { "SUMA", "RESTA", "MULTIPLICACION", "DIVISION", "EXPONENTE", "RAIZ", "FACTORIAL", "MODULO" });
            cboOpciones.Location = new Point(285, 48);
            cboOpciones.Name = "cboOpciones";
            cboOpciones.Size = new Size(206, 28);
            cboOpciones.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 526);
            Controls.Add(cboOpciones);
            Controls.Add(gboOperaciones);
            Controls.Add(lblRespuesta);
            Controls.Add(txtNum2);
            Controls.Add(txtNum1);
            Controls.Add(lblNum2);
            Controls.Add(lblNum1);
            Controls.Add(btnCalcular);
            Name = "Form1";
            Text = "Form1";
            gboOperaciones.ResumeLayout(false);
            gboOperaciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private Label lblNum1;
        private Label lblNum2;
        private TextBox txtNum1;
        private TextBox txtNum2;
        private Label lblRespuesta;
        private RadioButton rdbSuma;
        private RadioButton rdbResta;
        private RadioButton rdbMultiplicacion;
        private RadioButton rdbDivision;
        private RadioButton rdbExponente;
        private RadioButton rdbRaiz;
        private RadioButton rdbFactorial;
        private GroupBox gboOperaciones;
        private ComboBox cboOpciones;
    }
}
