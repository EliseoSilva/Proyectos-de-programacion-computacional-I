namespace PrimeraAplicacion
{
    partial class FrmMaterias
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
            gbBuscar = new GroupBox();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            drgResultadoBusqueda = new DataGridView();
            grbEdicion = new GroupBox();
            btnSalir = new Button();
            btnEliminarMateria = new Button();
            btnModificarMateria = new Button();
            btnAgregarMateria = new Button();
            grbNavegacion = new GroupBox();
            lblNavegacion = new Label();
            btnUltimoMateria = new Button();
            btnSiguienteMateria = new Button();
            btnAnteriorMateria = new Button();
            btnPrimerMateria = new Button();
            grbDatos = new GroupBox();
            txtUv = new TextBox();
            txtNombreMateria = new TextBox();
            txtCodigoMateria = new TextBox();
            lblUv = new Label();
            lblNombreMateria = new Label();
            lblCodigoMateria = new Label();
            gbBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)drgResultadoBusqueda).BeginInit();
            grbEdicion.SuspendLayout();
            grbNavegacion.SuspendLayout();
            grbDatos.SuspendLayout();
            SuspendLayout();
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(txtBuscar);
            gbBuscar.Controls.Add(lblBuscar);
            gbBuscar.Controls.Add(drgResultadoBusqueda);
            gbBuscar.Location = new Point(775, 3);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Size = new Size(830, 577);
            gbBuscar.TabIndex = 39;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(90, 73);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(454, 27);
            txtBuscar.TabIndex = 35;
            txtBuscar.TextChanged += txtBuscar_TextChanged_1;
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
            // drgResultadoBusqueda
            // 
            drgResultadoBusqueda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            drgResultadoBusqueda.Location = new Point(22, 117);
            drgResultadoBusqueda.Name = "drgResultadoBusqueda";
            drgResultadoBusqueda.RowHeadersWidth = 51;
            drgResultadoBusqueda.Size = new Size(672, 439);
            drgResultadoBusqueda.TabIndex = 34;
            // 
            // grbEdicion
            // 
            grbEdicion.Controls.Add(btnSalir);
            grbEdicion.Controls.Add(btnEliminarMateria);
            grbEdicion.Controls.Add(btnModificarMateria);
            grbEdicion.Controls.Add(btnAgregarMateria);
            grbEdicion.Location = new Point(582, 591);
            grbEdicion.Name = "grbEdicion";
            grbEdicion.Size = new Size(827, 113);
            grbEdicion.TabIndex = 38;
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
            // 
            // btnEliminarMateria
            // 
            btnEliminarMateria.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarMateria.Location = new Point(380, 41);
            btnEliminarMateria.Name = "btnEliminarMateria";
            btnEliminarMateria.Size = new Size(181, 60);
            btnEliminarMateria.TabIndex = 6;
            btnEliminarMateria.Text = "Eliminar";
            btnEliminarMateria.UseVisualStyleBackColor = true;
            // 
            // btnModificarMateria
            // 
            btnModificarMateria.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnModificarMateria.Location = new Point(193, 41);
            btnModificarMateria.Name = "btnModificarMateria";
            btnModificarMateria.Size = new Size(181, 60);
            btnModificarMateria.TabIndex = 5;
            btnModificarMateria.Text = "Modificar";
            btnModificarMateria.UseVisualStyleBackColor = true;
            // 
            // btnAgregarMateria
            // 
            btnAgregarMateria.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMateria.Location = new Point(6, 38);
            btnAgregarMateria.Name = "btnAgregarMateria";
            btnAgregarMateria.Size = new Size(181, 60);
            btnAgregarMateria.TabIndex = 4;
            btnAgregarMateria.Text = "Agregar";
            btnAgregarMateria.UseVisualStyleBackColor = true;
            // 
            // grbNavegacion
            // 
            grbNavegacion.Controls.Add(lblNavegacion);
            grbNavegacion.Controls.Add(btnUltimoMateria);
            grbNavegacion.Controls.Add(btnSiguienteMateria);
            grbNavegacion.Controls.Add(btnAnteriorMateria);
            grbNavegacion.Controls.Add(btnPrimerMateria);
            grbNavegacion.Location = new Point(2, 591);
            grbNavegacion.Name = "grbNavegacion";
            grbNavegacion.Size = new Size(507, 113);
            grbNavegacion.TabIndex = 36;
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
            // btnUltimoMateria
            // 
            btnUltimoMateria.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUltimoMateria.Location = new Point(417, 38);
            btnUltimoMateria.Name = "btnUltimoMateria";
            btnUltimoMateria.Size = new Size(79, 60);
            btnUltimoMateria.TabIndex = 3;
            btnUltimoMateria.Text = ">|";
            btnUltimoMateria.UseVisualStyleBackColor = true;
            // 
            // btnSiguienteMateria
            // 
            btnSiguienteMateria.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSiguienteMateria.Location = new Point(340, 38);
            btnSiguienteMateria.Name = "btnSiguienteMateria";
            btnSiguienteMateria.Size = new Size(79, 60);
            btnSiguienteMateria.TabIndex = 2;
            btnSiguienteMateria.Text = ">";
            btnSiguienteMateria.UseVisualStyleBackColor = true;
            // 
            // btnAnteriorMateria
            // 
            btnAnteriorMateria.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnteriorMateria.Location = new Point(87, 38);
            btnAnteriorMateria.Name = "btnAnteriorMateria";
            btnAnteriorMateria.Size = new Size(79, 60);
            btnAnteriorMateria.TabIndex = 1;
            btnAnteriorMateria.Text = "<";
            btnAnteriorMateria.UseVisualStyleBackColor = true;
            // 
            // btnPrimerMateria
            // 
            btnPrimerMateria.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrimerMateria.Location = new Point(10, 38);
            btnPrimerMateria.Name = "btnPrimerMateria";
            btnPrimerMateria.Size = new Size(79, 60);
            btnPrimerMateria.TabIndex = 0;
            btnPrimerMateria.Text = "|<";
            btnPrimerMateria.UseVisualStyleBackColor = true;
            // 
            // grbDatos
            // 
            grbDatos.Controls.Add(txtUv);
            grbDatos.Controls.Add(txtNombreMateria);
            grbDatos.Controls.Add(txtCodigoMateria);
            grbDatos.Controls.Add(lblUv);
            grbDatos.Controls.Add(lblNombreMateria);
            grbDatos.Controls.Add(lblCodigoMateria);
            grbDatos.Enabled = false;
            grbDatos.Location = new Point(2, 3);
            grbDatos.Name = "grbDatos";
            grbDatos.Size = new Size(760, 577);
            grbDatos.TabIndex = 37;
            grbDatos.TabStop = false;
            grbDatos.Text = "DATOS";
            grbDatos.Enter += grbDatos_Enter;
            // 
            // txtUv
            // 
            txtUv.Location = new Point(106, 400);
            txtUv.Name = "txtUv";
            txtUv.Size = new Size(204, 27);
            txtUv.TabIndex = 8;
            // 
            // txtNombreMateria
            // 
            txtNombreMateria.Location = new Point(106, 237);
            txtNombreMateria.Name = "txtNombreMateria";
            txtNombreMateria.Size = new Size(370, 27);
            txtNombreMateria.TabIndex = 6;
            // 
            // txtCodigoMateria
            // 
            txtCodigoMateria.Location = new Point(106, 53);
            txtCodigoMateria.Name = "txtCodigoMateria";
            txtCodigoMateria.Size = new Size(204, 27);
            txtCodigoMateria.TabIndex = 5;
            // 
            // lblUv
            // 
            lblUv.AutoSize = true;
            lblUv.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUv.Location = new Point(20, 402);
            lblUv.Name = "lblUv";
            lblUv.Size = new Size(41, 22);
            lblUv.TabIndex = 3;
            lblUv.Text = "UV:";
            // 
            // lblNombreMateria
            // 
            lblNombreMateria.AutoSize = true;
            lblNombreMateria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreMateria.Location = new Point(20, 237);
            lblNombreMateria.Name = "lblNombreMateria";
            lblNombreMateria.Size = new Size(80, 22);
            lblNombreMateria.TabIndex = 1;
            lblNombreMateria.Text = "Nombre:";
            // 
            // lblCodigoMateria
            // 
            lblCodigoMateria.AutoSize = true;
            lblCodigoMateria.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigoMateria.Location = new Point(26, 55);
            lblCodigoMateria.Name = "lblCodigoMateria";
            lblCodigoMateria.Size = new Size(74, 22);
            lblCodigoMateria.TabIndex = 0;
            lblCodigoMateria.Text = "Codigo:";
            // 
            // FrmMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 712);
            Controls.Add(gbBuscar);
            Controls.Add(grbEdicion);
            Controls.Add(grbNavegacion);
            Controls.Add(grbDatos);
            Name = "FrmMaterias";
            Text = "FrmMaterias";
            gbBuscar.ResumeLayout(false);
            gbBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)drgResultadoBusqueda).EndInit();
            grbEdicion.ResumeLayout(false);
            grbNavegacion.ResumeLayout(false);
            grbNavegacion.PerformLayout();
            grbDatos.ResumeLayout(false);
            grbDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBuscar;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView drgResultadoBusqueda;
        private GroupBox grbEdicion;
        private Button btnSalir;
        private Button btnEliminarMateria;
        private Button btnModificarMateria;
        private Button btnAgregarMateria;
        private GroupBox grbNavegacion;
        private Label lblNavegacion;
        private Button btnUltimoMateria;
        private Button btnSiguienteMateria;
        private Button btnAnteriorMateria;
        private Button btnPrimerMateria;
        private GroupBox grbDatos;
        private TextBox txtUv;
        private TextBox txtNombreMateria;
        private TextBox txtCodigoMateria;
        private Label lblUv;
        private Label lblNombreMateria;
        private Label lblCodigoMateria;
    }
}