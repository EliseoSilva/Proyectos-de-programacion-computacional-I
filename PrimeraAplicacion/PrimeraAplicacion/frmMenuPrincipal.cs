using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrimeraAplicacion
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void donacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmComunidadConecta formulario = new frmComunidadConecta())
            {
                formulario.ShowDialog(this);
            }
        }

        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSolicitudesdeAyuda formulario = new frmSolicitudesdeAyuda())
            {
                formulario.ShowDialog(this);
            }
        }

        private void mascotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FrmMascotas formulario = new FrmMascotas())
            {
                formulario.ShowDialog(this);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
