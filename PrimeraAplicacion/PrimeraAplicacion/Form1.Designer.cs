namespace PrimeraAplicacion
{
    partial class frmComunidadConecta
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
            lblTitulo = new Label();
            lblDescripcion = new Label();
            txtTitulo = new TextBox();
            grbDonaciones = new GroupBox();
            dgvDonaciones = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            cmbUbicacion = new ComboBox();
            lblUbicacion = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            cmbUsuario = new ComboBox();
            lblUsuario = new Label();
            txtDescripcion = new TextBox();
            grbDonaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonaciones).BeginInit();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(26, 35);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(73, 26);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Titulo:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(29, 78);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(129, 26);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripcion:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(105, 34);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(431, 27);
            txtTitulo.TabIndex = 2;
            // 
            // grbDonaciones
            // 
            grbDonaciones.Controls.Add(dgvDonaciones);
            grbDonaciones.Controls.Add(txtBuscar);
            grbDonaciones.Controls.Add(lblBuscar);
            grbDonaciones.Controls.Add(btnLimpiar);
            grbDonaciones.Controls.Add(btnEliminar);
            grbDonaciones.Controls.Add(btnEditar);
            grbDonaciones.Controls.Add(btnGuardar);
            grbDonaciones.Controls.Add(cmbEstado);
            grbDonaciones.Controls.Add(lblEstado);
            grbDonaciones.Controls.Add(dtpFecha);
            grbDonaciones.Controls.Add(lblFecha);
            grbDonaciones.Controls.Add(cmbUbicacion);
            grbDonaciones.Controls.Add(lblUbicacion);
            grbDonaciones.Controls.Add(cmbCategoria);
            grbDonaciones.Controls.Add(lblCategoria);
            grbDonaciones.Controls.Add(cmbUsuario);
            grbDonaciones.Controls.Add(lblUsuario);
            grbDonaciones.Controls.Add(txtDescripcion);
            grbDonaciones.Controls.Add(txtTitulo);
            grbDonaciones.Controls.Add(lblTitulo);
            grbDonaciones.Controls.Add(lblDescripcion);
            grbDonaciones.Location = new Point(12, 12);
            grbDonaciones.Name = "grbDonaciones";
            grbDonaciones.Size = new Size(1231, 779);
            grbDonaciones.TabIndex = 3;
            grbDonaciones.TabStop = false;
            grbDonaciones.Text = "Donaciones";
            // 
            // dgvDonaciones
            // 
            dgvDonaciones.BackgroundColor = SystemColors.ControlLight;
            dgvDonaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonaciones.Location = new Point(26, 439);
            dgvDonaciones.Name = "dgvDonaciones";
            dgvDonaciones.RowHeadersWidth = 51;
            dgvDonaciones.Size = new Size(1179, 314);
            dgvDonaciones.TabIndex = 20;
            dgvDonaciones.CellContentClick += dgvDonaciones_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(113, 406);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(431, 27);
            txtBuscar.TabIndex = 19;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(26, 406);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(81, 26);
            lblBuscar.TabIndex = 18;
            lblBuscar.Text = "Buscar:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(777, 330);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(177, 55);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 128, 128);
            btnEliminar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(561, 330);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(177, 55);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar:";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(333, 330);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(177, 55);
            btnEditar.TabIndex = 15;
            btnEditar.Text = "Editar:";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(128, 255, 128);
            btnGuardar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(103, 330);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(177, 55);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(632, 263);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(122, 28);
            cmbEstado.TabIndex = 13;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(546, 265);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(80, 26);
            lblEstado.TabIndex = 12;
            lblEstado.Text = "Estado:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(874, 34);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(289, 27);
            dtpFecha.TabIndex = 11;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(653, 35);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(215, 26);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Fecha de publicacion:";
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(133, 263);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(308, 28);
            cmbUbicacion.TabIndex = 9;
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUbicacion.Location = new Point(16, 265);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(111, 26);
            lblUbicacion.TabIndex = 8;
            lblUbicacion.Text = "Ubicacion:";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(737, 225);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(217, 28);
            cmbCategoria.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(625, 225);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(106, 26);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoria:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(113, 223);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(436, 28);
            cmbUsuario.TabIndex = 5;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(17, 225);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(90, 26);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(164, 77);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(599, 73);
            txtDescripcion.TabIndex = 3;
            // 
            // frmComunidadConecta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(1255, 803);
            Controls.Add(grbDonaciones);
            Name = "frmComunidadConecta";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "Comunidad Conecta";
            grbDonaciones.ResumeLayout(false);
            grbDonaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDonaciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private TextBox txtTitulo;
        private GroupBox grbDonaciones;
        private ComboBox cmbUbicacion;
        private Label lblUbicacion;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private ComboBox cmbUsuario;
        private Label lblUsuario;
        private TextBox txtDescripcion;
        private Label lblBuscar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private DataGridView dgvDonaciones;
        private TextBox txtBuscar;
    }
}
