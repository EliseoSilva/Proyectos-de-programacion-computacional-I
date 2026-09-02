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
            lblActividadEconomica = new Label();
            btnProcesar = new Button();
            txtEconomia = new TextBox();
            lblTotal = new Label();
            SuspendLayout();
            // 
            // lblActividadEconomica
            // 
            lblActividadEconomica.AutoSize = true;
            lblActividadEconomica.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActividadEconomica.Location = new Point(12, 64);
            lblActividadEconomica.Name = "lblActividadEconomica";
            lblActividadEconomica.Size = new Size(185, 22);
            lblActividadEconomica.TabIndex = 0;
            lblActividadEconomica.Text = "Actividad economica:";
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(240, 218);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(229, 55);
            btnProcesar.TabIndex = 2;
            btnProcesar.Text = "PROCESAR";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // txtEconomia
            // 
            txtEconomia.Location = new Point(203, 62);
            txtEconomia.Name = "txtEconomia";
            txtEconomia.Size = new Size(356, 27);
            txtEconomia.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(271, 153);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(146, 22);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total impuestos: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(687, 298);
            Controls.Add(lblTotal);
            Controls.Add(txtEconomia);
            Controls.Add(btnProcesar);
            Controls.Add(lblActividadEconomica);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "Calculador de impuestos";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblActividadEconomica;
        private Button btnProcesar;
        private TextBox txtEconomia;
        private Label lblTotal;
    }
}
