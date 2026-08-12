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
            txtEdad = new TextBox();
            lblEdad = new Label();
            SuspendLayout();
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalcular.Location = new Point(139, 285);
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
            lblRespuesta.Location = new Point(78, 233);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(111, 22);
            lblRespuesta.TabIndex = 1;
            lblRespuesta.Text = "Respuesta:   ";
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(139, 127);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(136, 27);
            txtEdad.TabIndex = 2;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Times New Roman", 12F);
            lblEdad.Location = new Point(78, 132);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(57, 22);
            lblEdad.TabIndex = 3;
            lblEdad.Text = "Edad:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 412);
            Controls.Add(lblEdad);
            Controls.Add(txtEdad);
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
        private TextBox txtEdad;
        private Label lblEdad;
    }
}
