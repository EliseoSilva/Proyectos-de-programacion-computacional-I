using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;

namespace PrimeraAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Conexion objConexion = new Conexion();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String accion = "nuevo";
        int posicion = 0;
        private void Form1_Load(object sender, EventArgs e)
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
            ActualizarNumeracionGrid();
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            drgResultadoBusqueda.CellClick += drgResultadoBusqueda_CellClick;
        }
        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltroBusqueda(txtBuscar.Text);
        }
        private void AplicarFiltroBusqueda(string termino)
        {
            if (dt == null)
                return;
            string filtro = string.Empty;
            termino = termino?.Trim().Replace("'", "''") ?? string.Empty;

            if (termino.Length > 0)
            {
                filtro = $"Convert([código], 'System.String') LIKE '%{termino}%' OR Convert([nombre], 'System.String') LIKE '%{termino}%' OR Convert([direccion], 'System.String') LIKE '%{termino}%' OR Convert([telefono], 'System.String') LIKE '%{termino}%' OR Convert([email], 'System.String') LIKE '%{termino}%'";
            }

            try
            {
                dt.DefaultView.RowFilter = filtro;
                ActualizarNumeracionGrid();
            }
            catch (Exception)
            {
                dt.DefaultView.RowFilter = string.Empty;
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
                    if (row["idAlumnos"] == DBNull.Value) continue;
                    if (int.TryParse(row["idAlumnos"].ToString(), out int id))
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
                if (drgResultadoBusqueda.Columns.Contains("idAlumnos"))
                    val = row.Cells["idAlumnos"].Value;
                else if (row.Cells.Count > 0)
                    val = row.Cells[0].Value;
                if (val == null) return;
                int idSeleccionado = Convert.ToInt32(val);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i]["idAlumnos"]) == idSeleccionado)
                    {
                        posicion = i;
                        mostrarDatos();
                        accion = "nuevo";
                        btnAgregarAlumno.Text = "Agregar";
                        btnModificarAlumno.Text = "Modificar";
                        btnEliminar.Enabled = true;
                        txtCodigo.ReadOnly = false;
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
            ds = objConexion.obtenerDatos();
            dt = ds.Tables["alumnos"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["idAlumnos"] };
        }
        private void mostrarDatos()
        {
            if (dt.Rows.Count > 0)
            {
                if (posicion < 0) posicion = 0;
                if (posicion >= dt.Rows.Count) posicion = dt.Rows.Count - 1;
                txtCodigo.Text = dt.Rows[posicion]["código"].ToString();
                txtNombre.Text = dt.Rows[posicion]["nombre"].ToString();
                txtDireccion.Text = dt.Rows[posicion]["direccion"].ToString();
                txtTelefono.Text = dt.Rows[posicion]["telefono"].ToString();
                txtEmail.Text = dt.Rows[posicion]["email"].ToString();
                lblNavegacion.Text = (posicion + 1) + " de " + dt.Rows.Count;
            }
            else
            {
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEmail.Text = string.Empty;
                lblNavegacion.Text = "0 de 0";
            }
        }
        private void activarDesactivarCtrls(Boolean estado)
        {
            grbDatos.Enabled = estado;
            grbNavegacion.Enabled = !estado;
        }
        private void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (btnAgregarAlumno.Text == "Agregar")
            {
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEmail.Text = string.Empty;
                accion = "nuevo";
                txtCodigo.Text = ObtenerSiguienteCodigo();
                txtCodigo.ReadOnly = true;

                btnEliminar.Enabled = false;
                btnAgregarAlumno.Text = "Guardar";
                btnModificarAlumno.Text = "Cancelar";
                activarDesactivarCtrls(true);
            }
            else
            {
                if (accion == "nuevo")
                {
                    if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        btnAgregarAlumno.Text = "Guardar";
                        btnModificarAlumno.Text = "Cancelar";
                        activarDesactivarCtrls(true);
                        return;
                    }
                    try
                    {
                        objConexion.insertarAlumno(txtCodigo.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
                        MessageBox.Show("Alumno agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerDatos();
                        posicion = dt.Rows.Count - 1;
                        mostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (accion == "modificar")
                {
                    if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnAgregarAlumno.Text = "Guardar";
                        btnModificarAlumno.Text = "Cancelar";
                        activarDesactivarCtrls(true);
                        return;
                    }
                    try
                    {
                        int id = Convert.ToInt32(dt.Rows[posicion]["idAlumnos"]);
                        objConexion.actualizarAlumno(id, txtCodigo.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
                        MessageBox.Show("Alumno modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerDatos();
                        mostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnAgregarAlumno.Text = "Agregar";
                btnModificarAlumno.Text = "Modificar";
                accion = "nuevo";
                activarDesactivarCtrls(false);
            }
        }
        private void btnModificarAlumno_Click(object sender, EventArgs e)
        {
            if (btnModificarAlumno.Text == "Modificar")
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                accion = "modificar";
                btnAgregarAlumno.Text = "Guardar";
                btnModificarAlumno.Text = "Cancelar";

                btnEliminar.Enabled = false;
                txtCodigo.ReadOnly = true;
                activarDesactivarCtrls(true);
            }
            else
            {
                accion = "nuevo";
                btnAgregarAlumno.Text = "Agregar";
                btnModificarAlumno.Text = "Modificar";

                btnEliminar.Enabled = true;
                txtCodigo.ReadOnly = false;
                activarDesactivarCtrls(false);

                obtenerDatos();
                mostrarDatos();
            }
        }
        private void btnSiguienteAlumno_Click(object sender, EventArgs e)
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
        private void btnAnteriorAlumno_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarDatos();
            }
        }
        private void btnPrimerAlumno_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }
        private void btnUltimoAlumno_Click(object sender, EventArgs e)
        {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
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
                    int id = Convert.ToInt32(dt.Rows[posicion]["idAlumnos"]);
                    objConexion.eliminarAlumno(id);
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
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}