namespace PrimeraAplicacion
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLimpiar = new Button();
            grbDatos = new GroupBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblDireccion = new Label();
            lblNombre = new Label();
            lblCodigo = new Label();
            grbNavegacion = new GroupBox();
            lblNavegacion = new Label();
            btnUltimoAlumno = new Button();
            btnSiguienteAlumno = new Button();
            btnAnteriorAlumno = new Button();
            btnPrimerAlumno = new Button();
            grbEdicion = new GroupBox();
            btnSalir = new Button();
            btnEliminar = new Button();
            btnModificarAlumno = new Button();
            btnAgregarAlumno = new Button();
            drgResultadoBusqueda = new DataGridView();
            gbBuscar = new GroupBox();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            grbDatos.SuspendLayout();
            grbNavegacion.SuspendLayout();
            grbEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drgResultadoBusqueda).BeginInit();
            gbBuscar.SuspendLayout();
            SuspendLayout();
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Times New Roman", 12F);
            btnLimpiar.Location = new Point(238, 883);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(131, 29);
            btnLimpiar.TabIndex = 31;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            grbDatos.Controls.Add(txtEmail);
            grbDatos.Controls.Add(txtTelefono);
            grbDatos.Controls.Add(txtDireccion);
            grbDatos.Controls.Add(txtNombre);
            grbDatos.Controls.Add(txtCodigo);
            grbDatos.Controls.Add(lblEmail);
            grbDatos.Controls.Add(lblTelefono);
            grbDatos.Controls.Add(lblDireccion);
            grbDatos.Controls.Add(lblNombre);
            grbDatos.Controls.Add(lblCodigo);
            grbDatos.Enabled = false;
            grbDatos.Location = new Point(12, 12);
            grbDatos.Name = "grbDatos";
            grbDatos.Size = new Size(760, 577);
            grbDatos.TabIndex = 32;
            grbDatos.TabStop = false;
            grbDatos.Text = "DATOS";
            txtEmail.Location = new Point(95, 508);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 27);
            txtEmail.TabIndex = 9;
            txtTelefono.Location = new Point(112, 406);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(204, 27);
            txtTelefono.TabIndex = 8;
            txtDireccion.Location = new Point(127, 251);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(573, 121);
            txtDireccion.TabIndex = 7;
            txtNombre.Location = new Point(112, 164);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(370, 27);
            txtNombre.TabIndex = 6;
            txtCodigo.Location = new Point(106, 53);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(204, 27);
            txtCodigo.TabIndex = 5;
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(26, 513);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(63, 22);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefono.Location = new Point(26, 408);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(86, 22);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Telefono:";
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDireccion.Location = new Point(26, 251);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(95, 22);
            lblDireccion.TabIndex = 2;
            lblDireccion.Text = "Direccion:";
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(26, 164);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 22);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(26, 55);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(74, 22);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Codigo:";
            // 
            // grbNavegacion
            // 
            grbNavegacion.Controls.Add(lblNavegacion);
            grbNavegacion.Controls.Add(btnUltimoAlumno);
            grbNavegacion.Controls.Add(btnSiguienteAlumno);
            grbNavegacion.Controls.Add(btnAnteriorAlumno);
            grbNavegacion.Controls.Add(btnPrimerAlumno);
            grbNavegacion.Location = new Point(12, 600);
            grbNavegacion.Name = "grbNavegacion";
            grbNavegacion.Size = new Size(507, 113);
            grbNavegacion.TabIndex = 5;
            grbNavegacion.TabStop = false;
            grbNavegacion.Text = "Navegacion";
            // 
            // lblNavegacion
            // 
            lblNavegacion.AutoSize = true;
            lblNavegacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNavegacion.Location = new Point(197, 57);
            lblNavegacion.Name = "lblNavegacion";
            lblNavegacion.Size = new Size(57, 22);
            lblNavegacion.TabIndex = 10;
            lblNavegacion.Text = "x de n";
            // 
            // btnUltimoAlumno
            // 
            btnUltimoAlumno.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUltimoAlumno.Location = new Point(417, 38);
            btnUltimoAlumno.Name = "btnUltimoAlumno";
            btnUltimoAlumno.Size = new Size(79, 60);
            btnUltimoAlumno.TabIndex = 3;
            btnUltimoAlumno.Text = ">|";
            btnUltimoAlumno.UseVisualStyleBackColor = true;
            btnUltimoAlumno.Click += btnUltimoAlumno_Click;
            // 
            // btnSiguienteAlumno
            // 
            btnSiguienteAlumno.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSiguienteAlumno.Location = new Point(340, 38);
            btnSiguienteAlumno.Name = "btnSiguienteAlumno";
            btnSiguienteAlumno.Size = new Size(79, 60);
            btnSiguienteAlumno.TabIndex = 2;
            btnSiguienteAlumno.Text = ">";
            btnSiguienteAlumno.UseVisualStyleBackColor = true;
            btnSiguienteAlumno.Click += btnSiguienteAlumno_Click;
            // 
            // btnAnteriorAlumno
            // 
            btnAnteriorAlumno.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnteriorAlumno.Location = new Point(87, 38);
            btnAnteriorAlumno.Name = "btnAnteriorAlumno";
            btnAnteriorAlumno.Size = new Size(79, 60);
            btnAnteriorAlumno.TabIndex = 1;
            btnAnteriorAlumno.Text = "<";
            btnAnteriorAlumno.UseVisualStyleBackColor = true;
            btnAnteriorAlumno.Click += btnAnteriorAlumno_Click;
            // 
            // btnPrimerAlumno
            // 
            btnPrimerAlumno.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrimerAlumno.Location = new Point(10, 38);
            btnPrimerAlumno.Name = "btnPrimerAlumno";
            btnPrimerAlumno.Size = new Size(79, 60);
            btnPrimerAlumno.TabIndex = 0;
            btnPrimerAlumno.Text = "|<";
            btnPrimerAlumno.UseVisualStyleBackColor = true;
            btnPrimerAlumno.Click += btnPrimerAlumno_Click;
            // 
            // grbEdicion
            // 
            grbEdicion.Controls.Add(btnSalir);
            grbEdicion.Controls.Add(btnEliminar);
            grbEdicion.Controls.Add(btnModificarAlumno);
            grbEdicion.Controls.Add(btnAgregarAlumno);
            grbEdicion.Location = new Point(592, 600);
            grbEdicion.Name = "grbEdicion";
            grbEdicion.Size = new Size(827, 113);
            grbEdicion.TabIndex = 33;
            grbEdicion.TabStop = false;
            grbEdicion.Text = "Edicion";
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(640, 38);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(181, 60);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(380, 41);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(181, 60);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificarAlumno
            // 
            btnModificarAlumno.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarAlumno.Location = new Point(193, 41);
            btnModificarAlumno.Name = "btnModificarAlumno";
            btnModificarAlumno.Size = new Size(181, 60);
            btnModificarAlumno.TabIndex = 5;
            btnModificarAlumno.Text = "Modificar";
            btnModificarAlumno.UseVisualStyleBackColor = true;
            btnModificarAlumno.Click += btnModificarAlumno_Click;
            // 
            // btnAgregarAlumno
            // 
            btnAgregarAlumno.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarAlumno.Location = new Point(6, 38);
            btnAgregarAlumno.Name = "btnAgregarAlumno";
            btnAgregarAlumno.Size = new Size(181, 60);
            btnAgregarAlumno.TabIndex = 4;
            btnAgregarAlumno.Text = "Agregar";
            btnAgregarAlumno.UseVisualStyleBackColor = true;
            btnAgregarAlumno.Click += btnAgregarAlumno_Click;
            // 
            // drgResultadoBusqueda
            // 
            drgResultadoBusqueda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            drgResultadoBusqueda.Location = new Point(22, 117);
            drgResultadoBusqueda.Name = "drgResultadoBusqueda";
            drgResultadoBusqueda.RowHeadersWidth = 51;
            drgResultadoBusqueda.Size = new Size(678, 439);
            drgResultadoBusqueda.TabIndex = 34;
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(txtBuscar);
            gbBuscar.Controls.Add(lblBuscar);
            gbBuscar.Controls.Add(drgResultadoBusqueda);
            gbBuscar.Location = new Point(785, 12);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(715, 577);
            gbBuscar.TabIndex = 35;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(90, 73);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(610, 27);
            txtBuscar.TabIndex = 35;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(22, 75);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(71, 22);
            lblBuscar.TabIndex = 10;
            lblBuscar.Text = "Buscar:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1524, 737);
            Controls.Add(gbBuscar);
            Controls.Add(grbEdicion);
            Controls.Add(grbNavegacion);
            Controls.Add(grbDatos);
            Controls.Add(btnLimpiar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "SISTEMA ACADEMICO";
            Load += Form1_Load;
            grbDatos.ResumeLayout(false);
            grbDatos.PerformLayout();
            grbNavegacion.ResumeLayout(false);
            grbNavegacion.PerformLayout();
            grbEdicion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)drgResultadoBusqueda).EndInit();
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            ResumeLayout(false);
        }


        private Button btnLimpiar;
        private GroupBox grbDatos;
        private Label lblCodigo;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblDireccion;
        private Label lblNombre;
        private GroupBox grbNavegacion;
        private GroupBox grbEdicion;
        private Label lblNavegacion;
        private Button btnUltimoAlumno;
        private Button btnSiguienteAlumno;
        private Button btnAnteriorAlumno;
        private Button btnPrimerAlumno;
        private Button btnModificarAlumno;
        private Button btnAgregarAlumno;
        private Button btnEliminar;
        private DataGridView drgResultadoBusqueda;
        private GroupBox gbBuscar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private Button btnSalir;
    }
}
