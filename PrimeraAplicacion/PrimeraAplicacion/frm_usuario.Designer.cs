namespace PrimeraAplicacion
{
    partial class frm_usuario
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
            grbUsuarios = new GroupBox();
            grbNavegacion = new GroupBox();
            lblNavegacion = new Label();
            btnUltimo = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnPrimero = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtNombre = new TextBox();
            textBox1 = new TextBox();
            txtUsuario = new TextBox();
            txtIdUsuario = new TextBox();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblNombre = new Label();
            lblClave = new Label();
            lblUsuario = new Label();
            lblIdUsuario = new Label();
            grbUsuarios.SuspendLayout();
            grbNavegacion.SuspendLayout();
            SuspendLayout();
            // 
            // grbUsuarios
            // 
            grbUsuarios.Controls.Add(grbNavegacion);
            grbUsuarios.Controls.Add(btnEliminar);
            grbUsuarios.Controls.Add(btnModificar);
            grbUsuarios.Controls.Add(btnAgregar);
            grbUsuarios.Controls.Add(txtTelefono);
            grbUsuarios.Controls.Add(txtDireccion);
            grbUsuarios.Controls.Add(txtNombre);
            grbUsuarios.Controls.Add(textBox1);
            grbUsuarios.Controls.Add(txtUsuario);
            grbUsuarios.Controls.Add(txtIdUsuario);
            grbUsuarios.Controls.Add(lblTelefono);
            grbUsuarios.Controls.Add(lblDireccion);
            grbUsuarios.Controls.Add(lblNombre);
            grbUsuarios.Controls.Add(lblClave);
            grbUsuarios.Controls.Add(lblUsuario);
            grbUsuarios.Controls.Add(lblIdUsuario);
            grbUsuarios.Location = new Point(12, 12);
            grbUsuarios.Name = "grbUsuarios";
            grbUsuarios.Size = new Size(768, 635);
            grbUsuarios.TabIndex = 0;
            grbUsuarios.TabStop = false;
            grbUsuarios.Text = "Usuarios";
            // 
            // grbNavegacion
            // 
            grbNavegacion.Controls.Add(lblNavegacion);
            grbNavegacion.Controls.Add(btnUltimo);
            grbNavegacion.Controls.Add(btnAnterior);
            grbNavegacion.Controls.Add(btnSiguiente);
            grbNavegacion.Controls.Add(btnPrimero);
            grbNavegacion.Location = new Point(6, 535);
            grbNavegacion.Name = "grbNavegacion";
            grbNavegacion.Size = new Size(756, 100);
            grbNavegacion.TabIndex = 15;
            grbNavegacion.TabStop = false;
            grbNavegacion.Text = "Navegacion";
            // 
            // lblNavegacion
            // 
            lblNavegacion.AutoSize = true;
            lblNavegacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNavegacion.Location = new Point(339, 54);
            lblNavegacion.Name = "lblNavegacion";
            lblNavegacion.Size = new Size(57, 22);
            lblNavegacion.TabIndex = 6;
            lblNavegacion.Text = "x de n";
            // 
            // btnUltimo
            // 
            btnUltimo.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUltimo.Location = new Point(623, 33);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(127, 53);
            btnUltimo.TabIndex = 3;
            btnUltimo.Text = ">|";
            btnUltimo.UseVisualStyleBackColor = true;
            // 
            // btnAnterior
            // 
            btnAnterior.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnterior.Location = new Point(134, 33);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(127, 53);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "<";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSiguiente.Location = new Point(499, 33);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(127, 53);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = ">";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrimero.Location = new Point(10, 33);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(127, 53);
            btnPrimero.TabIndex = 0;
            btnPrimero.Text = "|<";
            btnPrimero.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(230, 462);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(272, 53);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(411, 397);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(272, 53);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(55, 397);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(272, 53);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(389, 312);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(336, 27);
            txtTelefono.TabIndex = 11;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(22, 276);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(305, 93);
            txtDireccion.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(389, 167);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(336, 27);
            txtNombre.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 167);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(305, 27);
            textBox1.TabIndex = 8;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(389, 71);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(336, 27);
            txtUsuario.TabIndex = 7;
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(22, 71);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.Size = new Size(305, 27);
            txtIdUsuario.TabIndex = 6;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(389, 287);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(86, 22);
            lblTelefono.TabIndex = 5;
            lblTelefono.Text = "Telefono:";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDireccion.Location = new Point(22, 251);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(95, 22);
            lblDireccion.TabIndex = 4;
            lblDireccion.Text = "Direccion:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(389, 131);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 22);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClave.Location = new Point(22, 131);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(63, 22);
            lblClave.TabIndex = 2;
            lblClave.Text = "Clave:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(389, 46);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(78, 22);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIdUsuario.Location = new Point(22, 46);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(99, 22);
            lblIdUsuario.TabIndex = 0;
            lblIdUsuario.Text = "Id Usuario:";
            // 
            // frm_usuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 659);
            Controls.Add(grbUsuarios);
            Name = "frm_usuario";
            Text = "Usuario";
            grbUsuarios.ResumeLayout(false);
            grbUsuarios.PerformLayout();
            grbNavegacion.ResumeLayout(false);
            grbNavegacion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbUsuarios;
        private Label lblUsuario;
        private Label lblIdUsuario;
        private Button btnAgregar;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtNombre;
        private TextBox textBox1;
        private TextBox txtUsuario;
        private TextBox txtIdUsuario;
        private Label lblTelefono;
        private Label lblDireccion;
        private Label lblNombre;
        private Label lblClave;
        private GroupBox grbNavegacion;
        private Button btnPrimero;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Label lblNavegacion;
    }
}