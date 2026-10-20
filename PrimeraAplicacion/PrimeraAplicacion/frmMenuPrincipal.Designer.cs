namespace PrimeraAplicacion
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            donacionesToolStripMenuItem = new ToolStripMenuItem();
            solicitudesToolStripMenuItem = new ToolStripMenuItem();
            mascotasToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, donacionesToolStripMenuItem, solicitudesToolStripMenuItem, mascotasToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(961, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inicioToolStripMenuItem.Image = Properties.Resources.home;
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(90, 26);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // donacionesToolStripMenuItem
            // 
            donacionesToolStripMenuItem.Font = new Font("Times New Roman", 12F);
            donacionesToolStripMenuItem.Image = (Image)resources.GetObject("donacionesToolStripMenuItem.Image");
            donacionesToolStripMenuItem.Name = "donacionesToolStripMenuItem";
            donacionesToolStripMenuItem.Size = new Size(137, 26);
            donacionesToolStripMenuItem.Text = "Donaciones";
            donacionesToolStripMenuItem.Click += donacionesToolStripMenuItem_Click;
            // 
            // solicitudesToolStripMenuItem
            // 
            solicitudesToolStripMenuItem.Font = new Font("Times New Roman", 12F);
            solicitudesToolStripMenuItem.Image = Properties.Resources.ayuda;
            solicitudesToolStripMenuItem.Name = "solicitudesToolStripMenuItem";
            solicitudesToolStripMenuItem.Size = new Size(133, 26);
            solicitudesToolStripMenuItem.Text = "Solicitudes";
            solicitudesToolStripMenuItem.Click += solicitudesToolStripMenuItem_Click;
            // 
            // mascotasToolStripMenuItem
            // 
            mascotasToolStripMenuItem.Font = new Font("Times New Roman", 12F);
            mascotasToolStripMenuItem.Image = Properties.Resources.mascotas;
            mascotasToolStripMenuItem.Name = "mascotasToolStripMenuItem";
            mascotasToolStripMenuItem.Size = new Size(119, 26);
            mascotasToolStripMenuItem.Text = "Mascotas";
            mascotasToolStripMenuItem.Click += mascotasToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            salirToolStripMenuItem.Font = new Font("Times New Roman", 12F);
            salirToolStripMenuItem.Image = Properties.Resources.Salir;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(83, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(961, 670);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COMUNIDAD CONECTA";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem donacionesToolStripMenuItem;
        private ToolStripMenuItem solicitudesToolStripMenuItem;
        private ToolStripMenuItem mascotasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}