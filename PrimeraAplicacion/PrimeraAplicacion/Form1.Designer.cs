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
            lblSerie = new Label();
            ltsValores = new ListBox();
            btnProcesar = new Button();
            txtSerie = new TextBox();
            SuspendLayout();
            // 
            // lblSerie
            // 
            lblSerie.AutoSize = true;
            lblSerie.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSerie.Location = new Point(47, 62);
            lblSerie.Name = "lblSerie";
            lblSerie.Size = new Size(64, 22);
            lblSerie.TabIndex = 0;
            lblSerie.Text = "SERIE";
            // 
            // ltsValores
            // 
            ltsValores.FormattingEnabled = true;
            ltsValores.Location = new Point(47, 119);
            ltsValores.Name = "ltsValores";
            ltsValores.Size = new Size(189, 244);
            ltsValores.TabIndex = 1;
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point(259, 190);
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size(154, 109);
            btnProcesar.TabIndex = 2;
            btnProcesar.Text = "PROCESAR";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // txtSerie
            // 
            txtSerie.Location = new Point(117, 60);
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(356, 27);
            txtSerie.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(529, 422);
            Controls.Add(txtSerie);
            Controls.Add(btnProcesar);
            Controls.Add(ltsValores);
            Controls.Add(lblSerie);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "SISTEMA DE TRIAGE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSerie;
        private ListBox ltsValores;
        private Button btnProcesar;
        private TextBox txtSerie;
    }
}
