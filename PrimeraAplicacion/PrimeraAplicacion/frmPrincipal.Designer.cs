namespace PrimeraAplicacion
{
    partial class frmPrincipal
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
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            aplicaciónToolStripMenuItem = new ToolStripMenuItem();
            estudiantesToolStripMenuItem = new ToolStripMenuItem();
            asignaturasToolStripMenuItem = new ToolStripMenuItem();
            periodosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            calificacionesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, aplicaciónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(974, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            salirToolStripMenuItem.Image = Properties.Resources.salir;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            salirToolStripMenuItem.Size = new Size(174, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // aplicaciónToolStripMenuItem
            // 
            aplicaciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { estudiantesToolStripMenuItem, asignaturasToolStripMenuItem, periodosToolStripMenuItem, toolStripMenuItem1, calificacionesToolStripMenuItem });
            aplicaciónToolStripMenuItem.Name = "aplicaciónToolStripMenuItem";
            aplicaciónToolStripMenuItem.Size = new Size(93, 24);
            aplicaciónToolStripMenuItem.Text = "Aplicación";
            // 
            // estudiantesToolStripMenuItem
            // 
            estudiantesToolStripMenuItem.Image = Properties.Resources.estudiantes;
            estudiantesToolStripMenuItem.Name = "estudiantesToolStripMenuItem";
            estudiantesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            estudiantesToolStripMenuItem.Size = new Size(236, 26);
            estudiantesToolStripMenuItem.Text = "Estudiantes";
            estudiantesToolStripMenuItem.Click += estudiantesToolStripMenuItem_Click;
            // 
            // asignaturasToolStripMenuItem
            // 
            asignaturasToolStripMenuItem.Image = Properties.Resources.materias;
            asignaturasToolStripMenuItem.Name = "asignaturasToolStripMenuItem";
            asignaturasToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            asignaturasToolStripMenuItem.Size = new Size(236, 26);
            asignaturasToolStripMenuItem.Text = "Asignaturas";
            // 
            // periodosToolStripMenuItem
            // 
            periodosToolStripMenuItem.Image = Properties.Resources.periodos;
            periodosToolStripMenuItem.Name = "periodosToolStripMenuItem";
            periodosToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            periodosToolStripMenuItem.Size = new Size(236, 26);
            periodosToolStripMenuItem.Text = "Periodos";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 6);
            // 
            // calificacionesToolStripMenuItem
            // 
            calificacionesToolStripMenuItem.Image = Properties.Resources.notas;
            calificacionesToolStripMenuItem.Name = "calificacionesToolStripMenuItem";
            calificacionesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            calificacionesToolStripMenuItem.Size = new Size(236, 26);
            calificacionesToolStripMenuItem.Text = "Calificaciones";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 763);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem aplicaciónToolStripMenuItem;
        private ToolStripMenuItem estudiantesToolStripMenuItem;
        private ToolStripMenuItem asignaturasToolStripMenuItem;
        private ToolStripMenuItem periodosToolStripMenuItem;
        private ToolStripMenuItem calificacionesToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
    }
}