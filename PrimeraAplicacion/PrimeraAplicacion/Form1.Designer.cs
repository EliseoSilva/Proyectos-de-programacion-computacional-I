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
            lblRespuesta = new Label();
            txtTabla = new TextBox();
            lblEdad = new Label();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalcular.Location = new Point(91, 306);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(145, 85);
            btnCalcular.TabIndex = 0;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblRespuesta
            // 
            lblRespuesta.AutoSize = true;
            lblRespuesta.Font = new Font("Times New Roman", 12F);
            lblRespuesta.Location = new Point(259, 51);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(111, 22);
            lblRespuesta.TabIndex = 1;
            lblRespuesta.Text = "Respuesta:   ";
            // 
            // txtTabla
            // 
            txtTabla.Location = new Point(12, 86);
            txtTabla.Name = "txtTabla";
            txtTabla.Size = new Size(136, 27);
            txtTabla.TabIndex = 2;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Times New Roman", 12F);
            lblEdad.Location = new Point(12, 61);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(79, 22);
            lblEdad.TabIndex = 3;
            lblEdad.Text = "Numero:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 412);
            Controls.Add(lblEdad);
            Controls.Add(txtTabla);
            Controls.Add(lblRespuesta);
            Controls.Add(btnCalcular);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCalcular;
        private Label lblRespuesta;
        private TextBox txtTabla;
        private Label lblEdad;
    }
}
