namespace PrimeraAplicacion
{
    partial class FrmMascotas
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
            lblTituloFormulario = new Label();
            lblNombre = new Label();
            lblUsuario = new Label();
            lblTipoAnimal = new Label();
            lblUbicacion = new Label();
            lblRaza = new Label();
            lblColor = new Label();
            lblDescripcion = new Label();
            lblFotografia = new Label();
            lblFechaReporte = new Label();
            txtNombre = new TextBox();
            cmbUbicacion = new ComboBox();
            cmbUsuario = new ComboBox();
            cmbTipo = new ComboBox();
            txtRaza = new TextBox();
            txtColor = new TextBox();
            txtDescripcion = new TextBox();
            txtFoto = new TextBox();
            btnSeleccionarFoto = new Button();
            dtpFechaReporte = new DateTimePicker();
            lblEstado = new Label();
            cmbEstado = new ComboBox();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            txtBuscar = new TextBox();
            dgvMascotas = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
            SuspendLayout();
            // 
            // lblTituloFormulario
            // 
            lblTituloFormulario.AutoSize = true;
            lblTituloFormulario.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloFormulario.Location = new Point(306, 9);
            lblTituloFormulario.Name = "lblTituloFormulario";
            lblTituloFormulario.Size = new Size(204, 26);
            lblTituloFormulario.TabIndex = 0;
            lblTituloFormulario.Text = "Reporte de Mascotas";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(39, 43);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(203, 26);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre de mascota:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(458, 41);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(90, 26);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario:";
            // 
            // lblTipoAnimal
            // 
            lblTipoAnimal.AutoSize = true;
            lblTipoAnimal.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTipoAnimal.Location = new Point(37, 124);
            lblTipoAnimal.Name = "lblTipoAnimal";
            lblTipoAnimal.Size = new Size(157, 26);
            lblTipoAnimal.TabIndex = 3;
            lblTipoAnimal.Text = "Tipo de animal:";
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUbicacion.Location = new Point(458, 123);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(111, 26);
            lblUbicacion.TabIndex = 4;
            lblUbicacion.Text = "Ubicación:";
            // 
            // lblRaza
            // 
            lblRaza.AutoSize = true;
            lblRaza.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRaza.Location = new Point(37, 201);
            lblRaza.Name = "lblRaza";
            lblRaza.Size = new Size(62, 26);
            lblRaza.TabIndex = 5;
            lblRaza.Text = "Raza:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblColor.Location = new Point(458, 200);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(71, 26);
            lblColor.TabIndex = 6;
            lblColor.Text = "Color:";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(37, 269);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(235, 26);
            lblDescripcion.TabIndex = 7;
            lblDescripcion.Text = "Descripción del reporte:";
            // 
            // lblFotografia
            // 
            lblFotografia.AutoSize = true;
            lblFotografia.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFotografia.Location = new Point(39, 398);
            lblFotografia.Name = "lblFotografia";
            lblFotografia.Size = new Size(114, 26);
            lblFotografia.TabIndex = 8;
            lblFotografia.Text = "Fotografía:";
            // 
            // lblFechaReporte
            // 
            lblFechaReporte.AutoSize = true;
            lblFechaReporte.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFechaReporte.Location = new Point(35, 469);
            lblFechaReporte.Name = "lblFechaReporte";
            lblFechaReporte.Size = new Size(179, 26);
            lblFechaReporte.TabIndex = 9;
            lblFechaReporte.Text = "Fecha del reporte:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(39, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(307, 27);
            txtNombre.TabIndex = 10;
            // 
            // cmbUbicacion
            // 
            cmbUbicacion.FormattingEnabled = true;
            cmbUbicacion.Location = new Point(458, 152);
            cmbUbicacion.Name = "cmbUbicacion";
            cmbUbicacion.Size = new Size(305, 28);
            cmbUbicacion.TabIndex = 11;
            // 
            // cmbUsuario
            // 
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(458, 71);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(305, 28);
            cmbUsuario.TabIndex = 12;
            // 
            // cmbTipo
            // 
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(39, 153);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(305, 28);
            cmbTipo.TabIndex = 13;
            // 
            // txtRaza
            // 
            txtRaza.Location = new Point(39, 230);
            txtRaza.Name = "txtRaza";
            txtRaza.Size = new Size(307, 27);
            txtRaza.TabIndex = 14;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(458, 229);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(307, 27);
            txtColor.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(39, 298);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(724, 84);
            txtDescripcion.TabIndex = 16;
            // 
            // txtFoto
            // 
            txtFoto.Location = new Point(39, 427);
            txtFoto.Name = "txtFoto";
            txtFoto.Size = new Size(497, 27);
            txtFoto.TabIndex = 17;
            // 
            // btnSeleccionarFoto
            // 
            btnSeleccionarFoto.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSeleccionarFoto.Location = new Point(583, 421);
            btnSeleccionarFoto.Name = "btnSeleccionarFoto";
            btnSeleccionarFoto.Size = new Size(248, 38);
            btnSeleccionarFoto.TabIndex = 18;
            btnSeleccionarFoto.Text = "Seleccionar foto";
            btnSeleccionarFoto.UseVisualStyleBackColor = true;
            // 
            // dtpFechaReporte
            // 
            dtpFechaReporte.Location = new Point(37, 498);
            dtpFechaReporte.Name = "dtpFechaReporte";
            dtpFechaReporte.Size = new Size(250, 27);
            dtpFechaReporte.TabIndex = 19;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(456, 469);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(80, 26);
            lblEstado.TabIndex = 20;
            lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(458, 497);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(303, 28);
            cmbEstado.TabIndex = 21;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(35, 559);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(389, 52);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Nueva Mascota";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(440, 559);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(389, 52);
            btnEditar.TabIndex = 23;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(37, 617);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(389, 52);
            btnEliminar.TabIndex = 24;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(440, 617);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(389, 52);
            btnLimpiar.TabIndex = 25;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(37, 675);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(792, 27);
            txtBuscar.TabIndex = 26;
            txtBuscar.Text = "Buscar mascota...";
            // 
            // dgvMascotas
            // 
            dgvMascotas.BackgroundColor = Color.WhiteSmoke;
            dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMascotas.Location = new Point(37, 708);
            dgvMascotas.Name = "dgvMascotas";
            dgvMascotas.RowHeadersWidth = 51;
            dgvMascotas.Size = new Size(792, 229);
            dgvMascotas.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Vladimir Script", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 528);
            label1.Name = "label1";
            label1.Size = new Size(803, 18);
            label1.TabIndex = 28;
            label1.Text = "---------------------------------------------------------------------------------------------------------------------------------------------------------------";
            // 
            // FrmMascotas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 943);
            Controls.Add(label1);
            Controls.Add(dgvMascotas);
            Controls.Add(txtBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbEstado);
            Controls.Add(lblEstado);
            Controls.Add(dtpFechaReporte);
            Controls.Add(btnSeleccionarFoto);
            Controls.Add(txtFoto);
            Controls.Add(txtDescripcion);
            Controls.Add(txtColor);
            Controls.Add(txtRaza);
            Controls.Add(cmbTipo);
            Controls.Add(cmbUsuario);
            Controls.Add(cmbUbicacion);
            Controls.Add(txtNombre);
            Controls.Add(lblFechaReporte);
            Controls.Add(lblFotografia);
            Controls.Add(lblDescripcion);
            Controls.Add(lblColor);
            Controls.Add(lblRaza);
            Controls.Add(lblUbicacion);
            Controls.Add(lblTipoAnimal);
            Controls.Add(lblUsuario);
            Controls.Add(lblNombre);
            Controls.Add(lblTituloFormulario);
            Name = "FrmMascotas";
            Text = "Mascotas Perdidas";
            ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTituloFormulario;
        private Label lblNombre;
        private Label lblUsuario;
        private Label lblTipoAnimal;
        private Label lblUbicacion;
        private Label lblRaza;
        private Label lblColor;
        private Label lblDescripcion;
        private Label lblFotografia;
        private Label lblFechaReporte;
        private TextBox txtNombre;
        private ComboBox cmbUbicacion;
        private ComboBox cmbUsuario;
        private ComboBox cmbTipo;
        private TextBox txtRaza;
        private TextBox txtColor;
        private TextBox txtDescripcion;
        private TextBox txtFoto;
        private Button btnSeleccionarFoto;
        private DateTimePicker dtpFechaReporte;
        private Label lblEstado;
        private ComboBox cmbEstado;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private TextBox txtBuscar;
        private DataGridView dgvMascotas;
        private Label label1;
    }
}