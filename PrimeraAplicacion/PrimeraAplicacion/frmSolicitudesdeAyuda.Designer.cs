namespace PrimeraAplicacion
{
    partial class frmSolicitudesdeAyuda
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
            lblTituloDeFormulario = new Label();
            txtTitulo = new TextBox();
            txtDescripcion = new TextBox();
            cmbUsuario = new ComboBox();
            cmbCategoria = new ComboBox();
            cmbUbicacion = new ComboBox();
            dtpFecha = new DateTimePicker();
            cmbPrioridad = new ComboBox();
            cmbEstado = new ComboBox();
            txtBuscar = new TextBox();
            dgvSolicitudes = new DataGridView();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            lblUsuarios = new Label();
            lblCategoria = new Label();
            lblFecha = new Label();
            lblEstado = new Label();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            lblUbicacion = new Label();
            lblPrioridad = new Label();
            lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).BeginInit();
            SuspendLayout();
            // 
            // lblTituloDeFormulario
            // 
            lblTituloDeFormulario.AutoSize = true;
            lblTituloDeFormulario.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloDeFormulario.Location = new Point(342, 21);
            lblTituloDeFormulario.Name = "lblTituloDeFormulario";
            lblTituloDeFormulario.Size = new Size(204, 26);
            lblTituloDeFormulario.TabIndex = 0;
            lblTituloDeFormulario.Text = "Solicitudes de ayuda";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(91, 71);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(322, 27);
            txtTitulo.TabIndex = 2;
            txtTitulo.Text = "Titulo";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(147, 139);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(505, 132);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.Text = "Descripcion:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(803, 77);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(376, 28);
            cmbUsuario.TabIndex = 4;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(820, 147);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(376, 28);
            cmbCategoria.TabIndex = 5;
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(129, 298);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(376, 28);
            cmbUbicacion.TabIndex = 6;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(928, 226);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 7;
            // 
            // cmbPrioridad
            // 
            cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridad.FormattingEnabled = true;
            cmbPrioridad.Location = new Point(129, 386);
            cmbPrioridad.Name = "cmbPrioridad";
            cmbPrioridad.Size = new Size(376, 28);
            cmbPrioridad.TabIndex = 8;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(775, 349);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(376, 28);
            cmbEstado.TabIndex = 9;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(114, 553);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(582, 27);
            txtBuscar.TabIndex = 10;
            txtBuscar.Text = "Buscar";
            // 
            // dgvSolicitudes
            // 
            dgvSolicitudes.BackgroundColor = Color.WhiteSmoke;
            dgvSolicitudes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolicitudes.Location = new Point(33, 586);
            dgvSolicitudes.Name = "dgvSolicitudes";
            dgvSolicitudes.RowHeadersWidth = 51;
            dgvSolicitudes.Size = new Size(911, 313);
            dgvSolicitudes.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(33, 463);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(146, 47);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(209, 463);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(146, 47);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(400, 463);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(146, 47);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(583, 463);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(146, 47);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // lblUsuarios
            // 
            lblUsuarios.AutoSize = true;
            lblUsuarios.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuarios.Location = new Point(708, 77);
            lblUsuarios.Name = "lblUsuarios";
            lblUsuarios.Size = new Size(90, 26);
            lblUsuarios.TabIndex = 16;
            lblUsuarios.Text = "Usuario:";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(708, 149);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(106, 26);
            lblCategoria.TabIndex = 17;
            lblCategoria.Text = "Categoria:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(707, 226);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(215, 26);
            lblFecha.TabIndex = 18;
            lblFecha.Text = "Fecha de publicacion:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(689, 348);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(80, 26);
            lblEstado.TabIndex = 19;
            lblEstado.Text = "Estado:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 72);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(73, 26);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "Titulo:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(12, 139);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(129, 26);
            lblDescripcion.TabIndex = 21;
            lblDescripcion.Text = "Descripcion:";
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUbicacion.Location = new Point(12, 297);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(111, 26);
            lblUbicacion.TabIndex = 22;
            lblUbicacion.Text = "Ubicacion:";
            // 
            // lblPrioridad
            // 
            lblPrioridad.AutoSize = true;
            lblPrioridad.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrioridad.Location = new Point(12, 388);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(105, 26);
            lblPrioridad.TabIndex = 23;
            lblPrioridad.Text = "Prioridad:";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(27, 552);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(81, 26);
            lblBuscar.TabIndex = 24;
            lblBuscar.Text = "Buscar:";
            // 
            // frmSolicitudesdeAyuda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 939);
            Controls.Add(lblBuscar);
            Controls.Add(lblPrioridad);
            Controls.Add(lblUbicacion);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Controls.Add(lblEstado);
            Controls.Add(lblFecha);
            Controls.Add(lblCategoria);
            Controls.Add(lblUsuarios);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvSolicitudes);
            Controls.Add(txtBuscar);
            Controls.Add(cmbEstado);
            Controls.Add(cmbPrioridad);
            Controls.Add(dtpFecha);
            Controls.Add(cmbUbicacion);
            Controls.Add(cmbCategoria);
            Controls.Add(cmbUsuario);
            Controls.Add(txtDescripcion);
            Controls.Add(txtTitulo);
            Controls.Add(lblTituloDeFormulario);
            Name = "frmSolicitudesdeAyuda";
            Text = "frmSolicitudesdeAyuda";
            Load += frmSolicitudesdeAyuda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSolicitudes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloDeFormulario;
        private TextBox txtTitulo;
        private TextBox txtDescripcion;
        private ComboBox cmbUsuario;
        private ComboBox cmbCategoria;
        private ComboBox cmbUbicacion;
        private DateTimePicker dtpFecha;
        private ComboBox cmbPrioridad;
        private ComboBox cmbEstado;
        private TextBox txtBuscar;
        private DataGridView dgvSolicitudes;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Label lblUsuarios;
        private Label lblCategoria;
        private Label lblFecha;
        private Label lblEstado;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label lblUbicacion;
        private Label lblPrioridad;
        private Label lblBuscar;
    }
}