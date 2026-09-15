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
            lblMonto = new Label();
            ltsIssIsrAfp = new ListBox();
            btnCalculo = new Button();
            txtMonto = new TextBox();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(47, 62);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(87, 22);
            lblMonto.TabIndex = 0;
            lblMonto.Text = "MONTO:";
            // 
            // ltsIssIsrAfp
            // 
            ltsIssIsrAfp.FormattingEnabled = true;
            ltsIssIsrAfp.Location = new Point(47, 119);
            ltsIssIsrAfp.Name = "ltsIssIsrAfp";
            ltsIssIsrAfp.Size = new Size(249, 244);
            ltsIssIsrAfp.TabIndex = 1;
            // 
            // btnCalculo
            // 
            btnCalculo.Location = new Point(319, 119);
            btnCalculo.Name = "btnCalculo";
            btnCalculo.Size = new Size(154, 109);
            btnCalculo.TabIndex = 2;
            btnCalculo.Text = "CALCULO";
            btnCalculo.UseVisualStyleBackColor = true;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(140, 62);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(156, 27);
            txtMonto.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(319, 245);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(154, 109);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(615, 519);
            Controls.Add(btnLimpiar);
            Controls.Add(txtMonto);
            Controls.Add(btnCalculo);
            Controls.Add(ltsIssIsrAfp);
            Controls.Add(lblMonto);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "DEDUCCIONES DE LEY";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMonto;
        private ListBox ltsIssIsrAfp;
        private Button btnCalculo;
        private TextBox txtMonto;
        private Button btnLimpiar;
    }
}
