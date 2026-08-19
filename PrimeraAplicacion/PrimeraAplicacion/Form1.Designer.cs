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
            lblDatosDelPaciente = new Label();
            lblNombre = new Label();
            lblEdad = new Label();
            txtNombre = new TextBox();
            txtEdad = new TextBox();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblSignos = new Label();
            lblTemperatura = new Label();
            lblPresion = new Label();
            lblSaturacion = new Label();
            txtTemperatura = new TextBox();
            txtPresion = new TextBox();
            txtSaturacion = new TextBox();
            lblEvaluacion = new Label();
            chkEmergencia = new CheckBox();
            chkInconsciente = new CheckBox();
            chkRespiracion = new CheckBox();
            chkDeshidratacion = new CheckBox();
            chkDescompensado = new CheckBox();
            chkAdultoMayor = new CheckBox();
            chkEmbarazada = new CheckBox();
            chkEmbarazadaEmergencia = new CheckBox();
            lblResultado = new Label();
            lblPrioridad = new Label();
            lblTiempo = new Label();
            lblArea = new Label();
            btnClasificar = new Button();
            btnLimpiar = new Button();
            lblGrados = new Label();
            lblHg = new Label();
            lblPorcentaje = new Label();
            chkDiscapacidad = new CheckBox();
            SuspendLayout();
            // 
            // lblDatosDelPaciente
            // 
            lblDatosDelPaciente.AutoSize = true;
            lblDatosDelPaciente.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatosDelPaciente.Location = new Point(195, 9);
            lblDatosDelPaciente.Name = "lblDatosDelPaciente";
            lblDatosDelPaciente.Size = new Size(211, 22);
            lblDatosDelPaciente.TabIndex = 0;
            lblDatosDelPaciente.Text = "DATOS DEL PACIENTE";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(12, 48);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(80, 22);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEdad.Location = new Point(12, 84);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(57, 22);
            lblEdad.TabIndex = 2;
            lblEdad.Text = "Edad:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(98, 46);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(388, 27);
            txtNombre.TabIndex = 3;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(98, 79);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(125, 27);
            txtEdad.TabIndex = 4;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMotivo.Location = new Point(12, 118);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(188, 22);
            lblMotivo.TabIndex = 5;
            lblMotivo.Text = "Motivo de la consulta:";
            // 
            // txtMotivo
            // 
            txtMotivo.BackColor = Color.White;
            txtMotivo.Location = new Point(12, 143);
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(594, 27);
            txtMotivo.TabIndex = 6;
            // 
            // lblSignos
            // 
            lblSignos.AutoSize = true;
            lblSignos.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSignos.Location = new Point(223, 189);
            lblSignos.Name = "lblSignos";
            lblSignos.Size = new Size(162, 22);
            lblSignos.TabIndex = 7;
            lblSignos.Text = "SIGNOS VITALES";
            // 
            // lblTemperatura
            // 
            lblTemperatura.AutoSize = true;
            lblTemperatura.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTemperatura.Location = new Point(12, 225);
            lblTemperatura.Name = "lblTemperatura";
            lblTemperatura.Size = new Size(115, 22);
            lblTemperatura.TabIndex = 8;
            lblTemperatura.Text = "Temperatura:";
            // 
            // lblPresion
            // 
            lblPresion.AutoSize = true;
            lblPresion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPresion.Location = new Point(12, 260);
            lblPresion.Name = "lblPresion";
            lblPresion.Size = new Size(76, 22);
            lblPresion.TabIndex = 9;
            lblPresion.Text = "Presion:";
            // 
            // lblSaturacion
            // 
            lblSaturacion.AutoSize = true;
            lblSaturacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSaturacion.Location = new Point(12, 293);
            lblSaturacion.Name = "lblSaturacion";
            lblSaturacion.Size = new Size(100, 22);
            lblSaturacion.TabIndex = 10;
            lblSaturacion.Text = "Saturacion:";
            // 
            // txtTemperatura
            // 
            txtTemperatura.Location = new Point(133, 225);
            txtTemperatura.Name = "txtTemperatura";
            txtTemperatura.Size = new Size(94, 27);
            txtTemperatura.TabIndex = 11;
            // 
            // txtPresion
            // 
            txtPresion.Location = new Point(133, 258);
            txtPresion.Name = "txtPresion";
            txtPresion.Size = new Size(94, 27);
            txtPresion.TabIndex = 12;
            // 
            // txtSaturacion
            // 
            txtSaturacion.Location = new Point(133, 293);
            txtSaturacion.Name = "txtSaturacion";
            txtSaturacion.Size = new Size(94, 27);
            txtSaturacion.TabIndex = 13;
            // 
            // lblEvaluacion
            // 
            lblEvaluacion.AutoSize = true;
            lblEvaluacion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEvaluacion.Location = new Point(238, 335);
            lblEvaluacion.Name = "lblEvaluacion";
            lblEvaluacion.Size = new Size(131, 22);
            lblEvaluacion.TabIndex = 14;
            lblEvaluacion.Text = "EVALUACION";
            // 
            // chkEmergencia
            // 
            chkEmergencia.AutoSize = true;
            chkEmergencia.Cursor = Cursors.Hand;
            chkEmergencia.Location = new Point(12, 373);
            chkEmergencia.Name = "chkEmergencia";
            chkEmergencia.Size = new Size(178, 24);
            chkEmergencia.TabIndex = 15;
            chkEmergencia.Text = "Signos de emergencia";
            chkEmergencia.UseVisualStyleBackColor = true;
            // 
            // chkInconsciente
            // 
            chkInconsciente.AutoSize = true;
            chkInconsciente.Cursor = Cursors.Hand;
            chkInconsciente.Location = new Point(12, 403);
            chkInconsciente.Name = "chkInconsciente";
            chkInconsciente.Size = new Size(172, 24);
            chkInconsciente.TabIndex = 16;
            chkInconsciente.Text = "Paciente inconsciente";
            chkInconsciente.UseVisualStyleBackColor = true;
            // 
            // chkRespiracion
            // 
            chkRespiracion.AutoSize = true;
            chkRespiracion.Cursor = Cursors.Hand;
            chkRespiracion.Location = new Point(11, 433);
            chkRespiracion.Name = "chkRespiracion";
            chkRespiracion.Size = new Size(176, 24);
            chkRespiracion.TabIndex = 17;
            chkRespiracion.Text = "Dificultad respiratoria";
            chkRespiracion.UseVisualStyleBackColor = true;
            // 
            // chkDeshidratacion
            // 
            chkDeshidratacion.AutoSize = true;
            chkDeshidratacion.Cursor = Cursors.Hand;
            chkDeshidratacion.Location = new Point(11, 463);
            chkDeshidratacion.Name = "chkDeshidratacion";
            chkDeshidratacion.Size = new Size(131, 24);
            chkDeshidratacion.TabIndex = 18;
            chkDeshidratacion.Text = "Deshidratacion";
            chkDeshidratacion.UseVisualStyleBackColor = true;
            // 
            // chkDescompensado
            // 
            chkDescompensado.AutoSize = true;
            chkDescompensado.Cursor = Cursors.Hand;
            chkDescompensado.Location = new Point(12, 601);
            chkDescompensado.Name = "chkDescompensado";
            chkDescompensado.Size = new Size(219, 24);
            chkDescompensado.TabIndex = 22;
            chkDescompensado.Text = "Enfermedad desconpensada";
            chkDescompensado.UseVisualStyleBackColor = true;
            // 
            // chkAdultoMayor
            // 
            chkAdultoMayor.AutoSize = true;
            chkAdultoMayor.Cursor = Cursors.Hand;
            chkAdultoMayor.Location = new Point(11, 550);
            chkAdultoMayor.Name = "chkAdultoMayor";
            chkAdultoMayor.Size = new Size(122, 24);
            chkAdultoMayor.TabIndex = 21;
            chkAdultoMayor.Text = "Adulto mayor";
            chkAdultoMayor.UseVisualStyleBackColor = true;
            // 
            // chkEmbarazada
            // 
            chkEmbarazada.AutoSize = true;
            chkEmbarazada.Cursor = Cursors.Hand;
            chkEmbarazada.Location = new Point(12, 520);
            chkEmbarazada.Name = "chkEmbarazada";
            chkEmbarazada.Size = new Size(114, 24);
            chkEmbarazada.TabIndex = 20;
            chkEmbarazada.Text = "Embarazada";
            chkEmbarazada.UseVisualStyleBackColor = true;
            // 
            // chkEmbarazadaEmergencia
            // 
            chkEmbarazadaEmergencia.AutoSize = true;
            chkEmbarazadaEmergencia.Cursor = Cursors.Hand;
            chkEmbarazadaEmergencia.Location = new Point(12, 490);
            chkEmbarazadaEmergencia.Name = "chkEmbarazadaEmergencia";
            chkEmbarazadaEmergencia.Size = new Size(224, 24);
            chkEmbarazadaEmergencia.TabIndex = 19;
            chkEmbarazadaEmergencia.Text = "Embarazada con emergencia";
            chkEmbarazadaEmergencia.UseVisualStyleBackColor = true;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResultado.Location = new Point(249, 643);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(120, 22);
            lblResultado.TabIndex = 23;
            lblResultado.Text = "RESULTADO";
            // 
            // lblPrioridad
            // 
            lblPrioridad.AutoSize = true;
            lblPrioridad.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrioridad.Location = new Point(160, 689);
            lblPrioridad.Name = "lblPrioridad";
            lblPrioridad.Size = new Size(92, 22);
            lblPrioridad.TabIndex = 24;
            lblPrioridad.Text = "Prioridad:";
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTiempo.Location = new Point(160, 722);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(76, 22);
            lblTiempo.TabIndex = 25;
            lblTiempo.Text = "Tiempo:";
            // 
            // lblArea
            // 
            lblArea.AutoSize = true;
            lblArea.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblArea.Location = new Point(160, 754);
            lblArea.Name = "lblArea";
            lblArea.Size = new Size(55, 22);
            lblArea.TabIndex = 26;
            lblArea.Text = "Area:";
            // 
            // btnClasificar
            // 
            btnClasificar.Cursor = Cursors.Hand;
            btnClasificar.Font = new Font("Times New Roman", 12F);
            btnClasificar.Location = new Point(149, 817);
            btnClasificar.Name = "btnClasificar";
            btnClasificar.Size = new Size(327, 29);
            btnClasificar.TabIndex = 30;
            btnClasificar.Text = "CLASIFICAR PACIENTE";
            btnClasificar.UseVisualStyleBackColor = true;
            btnClasificar.Click += btnClasificar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Times New Roman", 12F);
            btnLimpiar.Location = new Point(238, 883);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(131, 29);
            btnLimpiar.TabIndex = 31;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // lblGrados
            // 
            lblGrados.AutoSize = true;
            lblGrados.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGrados.Location = new Point(233, 227);
            lblGrados.Name = "lblGrados";
            lblGrados.Size = new Size(31, 22);
            lblGrados.TabIndex = 32;
            lblGrados.Text = "°C";
            // 
            // lblHg
            // 
            lblHg.AutoSize = true;
            lblHg.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHg.Location = new Point(233, 263);
            lblHg.Name = "lblHg";
            lblHg.Size = new Size(61, 22);
            lblHg.TabIndex = 33;
            lblHg.Text = "mmHg";
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPorcentaje.Location = new Point(233, 298);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(27, 22);
            lblPorcentaje.TabIndex = 34;
            lblPorcentaje.Text = "%";
            // 
            // chkDiscapacidad
            // 
            chkDiscapacidad.AutoSize = true;
            chkDiscapacidad.Cursor = Cursors.Hand;
            chkDiscapacidad.Location = new Point(11, 576);
            chkDiscapacidad.Name = "chkDiscapacidad";
            chkDiscapacidad.Size = new Size(202, 24);
            chkDiscapacidad.TabIndex = 35;
            chkDiscapacidad.Text = "Persona con discapacidad";
            chkDiscapacidad.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 255);
            ClientSize = new Size(661, 927);
            Controls.Add(chkDiscapacidad);
            Controls.Add(lblPorcentaje);
            Controls.Add(lblHg);
            Controls.Add(lblGrados);
            Controls.Add(btnLimpiar);
            Controls.Add(btnClasificar);
            Controls.Add(lblArea);
            Controls.Add(lblTiempo);
            Controls.Add(lblPrioridad);
            Controls.Add(lblResultado);
            Controls.Add(chkDescompensado);
            Controls.Add(chkAdultoMayor);
            Controls.Add(chkEmbarazada);
            Controls.Add(chkEmbarazadaEmergencia);
            Controls.Add(chkDeshidratacion);
            Controls.Add(chkRespiracion);
            Controls.Add(chkInconsciente);
            Controls.Add(chkEmergencia);
            Controls.Add(lblEvaluacion);
            Controls.Add(txtSaturacion);
            Controls.Add(txtPresion);
            Controls.Add(txtTemperatura);
            Controls.Add(lblSaturacion);
            Controls.Add(lblPresion);
            Controls.Add(lblTemperatura);
            Controls.Add(lblSignos);
            Controls.Add(txtMotivo);
            Controls.Add(lblMotivo);
            Controls.Add(txtEdad);
            Controls.Add(txtNombre);
            Controls.Add(lblEdad);
            Controls.Add(lblNombre);
            Controls.Add(lblDatosDelPaciente);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "SISTEMA DE TRIAGE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDatosDelPaciente;
        private Label lblNombre;
        private Label lblEdad;
        private TextBox txtNombre;
        private TextBox txtEdad;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblSignos;
        private Label lblTemperatura;
        private Label lblPresion;
        private Label lblSaturacion;
        private TextBox txtTemperatura;
        private TextBox txtPresion;
        private TextBox txtSaturacion;
        private Label lblEvaluacion;
        private CheckBox chkEmergencia;
        private CheckBox chkInconsciente;
        private CheckBox chkRespiracion;
        private CheckBox chkDeshidratacion;
        private CheckBox chkDescompensado;
        private CheckBox chkAdultoMayor;
        private CheckBox chkEmbarazada;
        private CheckBox chkEmbarazadaEmergencia;
        private Label lblResultado;
        private Label lblPrioridad;
        private Label lblTiempo;
        private Label lblArea;
        private Button btnClasificar;
        private Button btnLimpiar;
        private Label lblGrados;
        private Label lblHg;
        private Label lblPorcentaje;
        private CheckBox chkDiscapacidad;
    }
}
