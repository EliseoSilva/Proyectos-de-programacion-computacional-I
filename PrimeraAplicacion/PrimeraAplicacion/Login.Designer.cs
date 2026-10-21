namespace PrimeraAplicacion
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            lblUsuario = new Label();
            lblClave = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnRegistrarse = new Button();
            lblRegistrarse = new Label();
            lblTitulo = new Label();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(309, 56);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(177, 32);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Iniciar Sesion";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.White;
            lblUsuario.Location = new Point(136, 171);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(78, 22);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClave.ForeColor = Color.White;
            lblClave.Location = new Point(136, 259);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(105, 22);
            lblClave.TabIndex = 2;
            lblClave.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(220, 171);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(360, 27);
            txtUsuario.TabIndex = 3;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(247, 259);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(333, 27);
            txtContraseña.TabIndex = 4;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(288, 442);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(257, 29);
            btnRegistrarse.TabIndex = 5;
            btnRegistrarse.Text = "Registrate";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // lblRegistrarse
            // 
            lblRegistrarse.AutoSize = true;
            lblRegistrarse.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRegistrarse.ForeColor = Color.Transparent;
            lblRegistrarse.Location = new Point(349, 413);
            lblRegistrarse.Name = "lblRegistrarse";
            lblRegistrarse.Size = new Size(137, 19);
            lblRegistrarse.TabIndex = 6;
            lblRegistrarse.Text = "¿No tienes cuenta?";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.ActiveCaption;
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(220, 22);
            lblTitulo.TabIndex = 7;
            lblTitulo.Text = "SISTEMA ACADEMICO";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(830, 608);
            Controls.Add(lblTitulo);
            Controls.Add(lblRegistrarse);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblLogin);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private Label lblUsuario;
        private Label lblClave;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnRegistrarse;
        private Label lblRegistrarse;
        private Label lblTitulo;
    }
}