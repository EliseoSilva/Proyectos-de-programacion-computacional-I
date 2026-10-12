using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PrimeraAplicacion
{
    public partial class FrmMaterias : Form
    {
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string accion = "nuevo"; 
        int posicion = 0; 

        public FrmMaterias()
        {
            InitializeComponent();
            Load += FrmMaterias_Load;
            btnAgregarMateria.Click += btnAgregarMateria_Click;
            btnModificarMateria.Click += btnModificarMateria_Click;
            btnEliminarMateria.Click += btnEliminarMateria_Click;
            btnSalir.Click += btnSalir_Click;
            btnSiguienteMateria.Click += btnSiguienteMateria_Click;
            btnAnteriorMateria.Click += btnAnteriorMateria_Click;
            btnPrimerMateria.Click += btnPrimerMateria_Click;
            btnUltimoMateria.Click += btnUltimoMateria_Click;
        }

        private void FrmMaterias_Load(object? sender, EventArgs e)
        {
            obtenerDatos();
            posicion = 0;
            mostrarDatos();

            if (dt != null)
            {
                dt.CaseSensitive = false;
                drgResultadoBusqueda.DataSource = dt.DefaultView;
            }

            drgResultadoBusqueda.DataBindingComplete += drgResultadoBusqueda_DataBindingComplete;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            drgResultadoBusqueda.CellClick += drgResultadoBusqueda_CellClick;
            ActualizarNumeracionGrid();
        }

        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltroBusqueda(txtBuscar.Text);
        }

        private void AplicarFiltroBusqueda(string termino)
        {
            if (dt == null) return;
            string filtro = string.Empty;
            termino = termino?.Trim().Replace("'", "''") ?? string.Empty;

            if (termino.Length > 0)
            {
                filtro = $"Convert([código], 'System.String') LIKE '%{termino}%' OR Convert([nombre], 'System.String') LIKE '%{termino}%' OR Convert([UV], 'System.String') LIKE '%{termino}%'";
            }

            try
            {
                dt.DefaultView.RowFilter = filtro;
                try { drgResultadoBusqueda.DataSource = dt.DefaultView; } catch { }
                drgResultadoBusqueda.Refresh();
                ActualizarNumeracionGrid();
            }
            catch (Exception)
            {
                dt.DefaultView.RowFilter = string.Empty;
                try { drgResultadoBusqueda.DataSource = dt.DefaultView; } catch { }
                drgResultadoBusqueda.Refresh();
            }
        }

        private void drgResultadoBusqueda_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            ActualizarNumeracionGrid();
        }

        private void ActualizarNumeracionGrid()
        {
            try
            {
                if (drgResultadoBusqueda.Columns["Registro"] == null)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = "Registro";
                    col.HeaderText = "Registro";
                    col.ReadOnly = true;
                    drgResultadoBusqueda.Columns.Insert(0, col);
                }
            }
            catch { }

            for (int i = 0; i < drgResultadoBusqueda.Rows.Count; i++)
            {
                var row = drgResultadoBusqueda.Rows[i];
                if (row.IsNewRow) continue;
                try { row.Cells["Registro"].Value = (i + 1).ToString(); } catch { }
            }
        }

        private string ObtenerSiguienteCodigo()
        {
            int maxCodigo = 0;

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["código"] == DBNull.Value) continue;
                    string val = row["código"].ToString();
                    if (int.TryParse(val, out int n))
                    {
                        if (n > maxCodigo) maxCodigo = n;
                    }
                }
            }
            if (maxCodigo > 0)
                return (maxCodigo + 1).ToString().PadLeft(10, '0');
            int maxId = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["idMateria"] == DBNull.Value) continue;
                    if (int.TryParse(row["idMateria"].ToString(), out int id))
                    {
                        if (id > maxId) maxId = id;
                    }
                }
            }
            return (maxId + 1).ToString().PadLeft(10, '0');
        }

        private void drgResultadoBusqueda_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                var row = drgResultadoBusqueda.Rows[e.RowIndex];
                if (row == null) return;

                object? val = null;
                if (drgResultadoBusqueda.Columns.Contains("idMateria"))
                    val = row.Cells["idMateria"].Value;
                else if (row.Cells.Count > 0)
                    val = row.Cells[0].Value;
                if (val == null) return;
                int idSeleccionado = Convert.ToInt32(val);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["idMateria"]) == idSeleccionado)
                    {
                        posicion = i;
                        mostrarDatos();
                        accion = "nuevo";
                        btnAgregarMateria.Text = "Agregar";
                        btnModificarMateria.Text = "Modificar";
                        btnEliminarMateria.Enabled = true;
                        txtCodigoMateria.ReadOnly = false;
                        activarDesactivarCtrls(false);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al navegar al registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerDatos()
        {
            ds.Clear();
            ds = objConexion.obtenerDatosMaterias();
            if (ds.Tables.Contains("materias"))
            {
                dt = ds.Tables["materias"];
                if (dt.Columns.Contains("idMateria"))
                    dt.PrimaryKey = new DataColumn[] { dt.Columns["idMateria"] };
                try
                {
                    drgResultadoBusqueda.DataSource = dt.DefaultView;
                }
                catch { }
            }
            else
            {
                dt = new DataTable();
            }
        }

        private void mostrarDatos()
        {
            if (dt.Rows.Count > 0)
            {
                if (posicion < 0) posicion = 0;
                if (posicion >= dt.Rows.Count) posicion = dt.Rows.Count - 1;
                txtCodigoMateria.Text = dt.Rows[posicion]["código"].ToString();
                txtNombreMateria.Text = dt.Rows[posicion]["nombre"].ToString();
                txtUv.Text = dt.Rows[posicion]["UV"].ToString();
                lblNavegacion.Text = (posicion + 1) + " de " + dt.Rows.Count;
            }
            else
            {
                txtCodigoMateria.Text = string.Empty;
                txtNombreMateria.Text = string.Empty;
                txtUv.Text = string.Empty;
                lblNavegacion.Text = "0 de 0";
            }
        }

        private void activarDesactivarCtrls(Boolean estado)
        {
            grbDatos.Enabled = estado;
            grbNavegacion.Enabled = !estado;
        }

        private void btnAgregarMateria_Click(object sender, EventArgs e)
        {
            if (btnAgregarMateria.Text == "Agregar")
            {
                txtCodigoMateria.Text = string.Empty;
                txtNombreMateria.Text = string.Empty;
                txtUv.Text = string.Empty;
                accion = "nuevo";
                txtCodigoMateria.Text = ObtenerSiguienteCodigo();
                txtCodigoMateria.ReadOnly = true;

                btnEliminarMateria.Enabled = false;
                btnAgregarMateria.Text = "Guardar";
                btnModificarMateria.Text = "Cancelar";
                activarDesactivarCtrls(true);
            }
            else
            {
                if (accion == "nuevo")
                {
                    if (string.IsNullOrWhiteSpace(txtCodigoMateria.Text) || string.IsNullOrWhiteSpace(txtNombreMateria.Text) || string.IsNullOrWhiteSpace(txtUv.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnAgregarMateria.Text = "Guardar";
                        btnModificarMateria.Text = "Cancelar";
                        activarDesactivarCtrls(true);
                        return;
                    }
                    try
                    {
                        objConexion.insertarMateria(txtCodigoMateria.Text.Trim(), txtNombreMateria.Text.Trim(), txtUv.Text.Trim());
                        MessageBox.Show("Materia agregada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerDatos();
                        try { drgResultadoBusqueda.DataSource = dt.DefaultView; } catch { }
                        AplicarFiltroBusqueda(txtBuscar.Text);
                        btnEliminarMateria.Enabled = true;
                        posicion = dt.Rows.Count - 1;
                        mostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (accion == "modificar")
                {
                    if (string.IsNullOrWhiteSpace(txtCodigoMateria.Text) || string.IsNullOrWhiteSpace(txtNombreMateria.Text) || string.IsNullOrWhiteSpace(txtUv.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnAgregarMateria.Text = "Guardar";
                        btnModificarMateria.Text = "Cancelar";
                        activarDesactivarCtrls(true);
                        return;
                    }
                    try
                    {
                        int id = Convert.ToInt32(dt.Rows[posicion]["idMateria"]);
                        objConexion.actualizarMateria(id, txtCodigoMateria.Text.Trim(), txtNombreMateria.Text.Trim(), txtUv.Text.Trim());
                        MessageBox.Show("Materia modificada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerDatos();
                        try { drgResultadoBusqueda.DataSource = dt.DefaultView; } catch { }
                        AplicarFiltroBusqueda(txtBuscar.Text);
                        btnEliminarMateria.Enabled = true;
                        mostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                btnAgregarMateria.Text = "Agregar";
                btnModificarMateria.Text = "Modificar";
                accion = "nuevo";
                activarDesactivarCtrls(false);
            }
        }

        private void btnModificarMateria_Click(object sender, EventArgs e)
        {
            if (btnModificarMateria.Text == "Modificar")
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                accion = "modificar";
                btnAgregarMateria.Text = "Guardar";
                btnModificarMateria.Text = "Cancelar";

                btnEliminarMateria.Enabled = false;
                txtCodigoMateria.ReadOnly = true;
                activarDesactivarCtrls(true);
            }
            else
            {
                accion = "nuevo";
                btnAgregarMateria.Text = "Agregar";
                btnModificarMateria.Text = "Modificar";

                btnEliminarMateria.Enabled = true;
                txtCodigoMateria.ReadOnly = false;
                activarDesactivarCtrls(false);

                obtenerDatos();
                mostrarDatos();
            }
        }

        private void btnSiguienteMateria_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (posicion < dt.Rows.Count - 1)
            {
                posicion++;
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("Llegó al final de los registros.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnteriorMateria_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
        }

        private void btnPrimerMateria_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }

        private void btnUltimoMateria_Click(object sender, EventArgs e)
        {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();
        }

        private void btnEliminarMateria_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0 || posicion < 0 || posicion >= dt.Rows.Count)
            {
                MessageBox.Show("No hay ningún registro seleccionado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var resultado = MessageBox.Show("¿Seguro que desea eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dt.Rows[posicion]["idMateria"]);
                    objConexion.eliminarMateria(id);
                    MessageBox.Show("Registro eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obtenerDatos();
                    if (dt.Rows.Count == 0)
                    {
                        posicion = 0;
                    }
                    else if (posicion >= dt.Rows.Count)
                    {
                        posicion = dt.Rows.Count - 1;
                    }
                    mostrarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grbDatos_Enter(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
