using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PrimeraAplicacion
{
    public partial class frmSolicitudesdeAyuda : Form
    {
        private bool modoNuevaSolicitud = false;
        private bool modoEdicion = false;

        public frmSolicitudesdeAyuda()
        {
            InitializeComponent();
            CargarCombos();
            CargarSolicitudes();
            PrepararModoConsulta();

            dgvSolicitudes.CellClick += dgvSolicitudes_CellClick;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
        }

        private void CargarSolicitudes()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT id_solicitud, id_usuario, id_categoria, id_ubicacion,
                           titulo, descripcion, fecha_publicacion, prioridad, estado
                    FROM SOLICITUDES_AYUDA
                    ORDER BY id_solicitud DESC;", cn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    dgvSolicitudes.DataSource = tabla;
                    dgvSolicitudes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvSolicitudes.ReadOnly = true;
                    dgvSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvSolicitudes.MultiSelect = false;
                    dgvSolicitudes.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las solicitudes:\n" + ex.Message);
            }
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT id_usuario, CONCAT(nombres, ' ', apellidos) AS nombre_completo
                          FROM USUARIOS ORDER BY nombres, apellidos;", cn))
                    {
                        DataTable t = new DataTable();
                        da.Fill(t);
                        cmbUsuario.DataSource = t;
                        cmbUsuario.DisplayMember = "nombre_completo";
                        cmbUsuario.ValueMember = "id_usuario";
                        cmbUsuario.SelectedIndex = -1;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_categoria, nombre FROM CATEGORIAS ORDER BY nombre;", cn))
                    {
                        DataTable t = new DataTable();
                        da.Fill(t);
                        cmbCategoria.DataSource = t;
                        cmbCategoria.DisplayMember = "nombre";
                        cmbCategoria.ValueMember = "id_categoria";
                        cmbCategoria.SelectedIndex = -1;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT id_ubicacion, direccion FROM UBICACIONES ORDER BY direccion;", cn))
                    {
                        DataTable t = new DataTable();
                        da.Fill(t);
                        cmbUbicacion.DataSource = t;
                        cmbUbicacion.DisplayMember = "direccion";
                        cmbUbicacion.ValueMember = "id_ubicacion";
                        cmbUbicacion.SelectedIndex = -1;
                    }

                    cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbPrioridad.Items.Clear();
                    cmbPrioridad.Items.AddRange(new object[] { "Baja", "Media", "Alta" });
                    cmbPrioridad.SelectedIndex = -1;

                    cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.AddRange(new object[] { "Pendiente", "En proceso", "Resuelta" });
                    cmbEstado.SelectedIndex = -1;

                    dtpFecha.Format = DateTimePickerFormat.Short;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas desplegables:\n" + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoNuevaSolicitud)
            {
                LimpiarCampos();
                modoNuevaSolicitud = true;
                modoEdicion = false;
                btnGuardar.Text = "Guardar";
                btnEditar.Text = "Cancelar";
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                HabilitarCampos(true);
                txtTitulo.Focus();
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO SOLICITUDES_AYUDA
                    (id_usuario, id_categoria, id_ubicacion, titulo, descripcion,
                     fecha_publicacion, prioridad, estado)
                    VALUES (@usuario, @categoria, @ubicacion, @titulo, @descripcion,
                            @fecha, @prioridad, @estado);", cn))
                {
                    AgregarParametros(cmd);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Solicitud guardada correctamente.");
                CargarSolicitudes();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la solicitud:\n" + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            string faltantes = "";
            if (string.IsNullOrWhiteSpace(txtTitulo.Text)) faltantes += "- Título\n";
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) faltantes += "- Descripción\n";
            if (cmbUsuario.SelectedIndex < 0) faltantes += "- Usuario\n";
            if (cmbCategoria.SelectedIndex < 0) faltantes += "- Categoría\n";
            if (cmbUbicacion.SelectedIndex < 0) faltantes += "- Ubicación\n";
            if (cmbPrioridad.SelectedIndex < 0) faltantes += "- Prioridad\n";
            if (cmbEstado.SelectedIndex < 0) faltantes += "- Estado\n";

            if (faltantes.Length > 0)
            {
                MessageBox.Show("Completa los siguientes campos:\n\n" + faltantes);
                return false;
            }
            if (txtTitulo.Text.Trim().Length > 100)
            {
                MessageBox.Show("El título no puede superar los 100 caracteres.");
                txtTitulo.Focus();
                return false;
            }
            if (txtDescripcion.Text.Trim().Length > 500)
            {
                MessageBox.Show("La descripción no puede superar los 500 caracteres.");
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void AgregarParametros(SqlCommand cmd)
        {
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = cmbUsuario.SelectedValue;
            cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = cmbCategoria.SelectedValue;
            cmd.Parameters.Add("@ubicacion", SqlDbType.Int).Value = cmbUbicacion.SelectedValue;
            cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 100).Value = txtTitulo.Text.Trim();
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = txtDescripcion.Text.Trim();
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFecha.Value.Date;
            cmd.Parameters.Add("@prioridad", SqlDbType.VarChar, 20).Value = cmbPrioridad.Text;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = cmbEstado.Text;
        }

        private void dgvSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modoNuevaSolicitud || modoEdicion) return;

            DataGridViewRow fila = dgvSolicitudes.Rows[e.RowIndex];
            txtTitulo.Text = Convert.ToString(fila.Cells["titulo"].Value) ?? "";
            txtDescripcion.Text = Convert.ToString(fila.Cells["descripcion"].Value) ?? "";
            SeleccionarValor(cmbUsuario, fila.Cells["id_usuario"].Value);
            SeleccionarValor(cmbCategoria, fila.Cells["id_categoria"].Value);
            SeleccionarValor(cmbUbicacion, fila.Cells["id_ubicacion"].Value);
            if (fila.Cells["fecha_publicacion"].Value != DBNull.Value &&
                fila.Cells["fecha_publicacion"].Value != null)
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["fecha_publicacion"].Value);

            SeleccionarTexto(cmbPrioridad, fila.Cells["prioridad"].Value);
            SeleccionarTexto(cmbEstado, fila.Cells["estado"].Value);
            btnGuardar.Text = "Nueva solicitud";
            btnEditar.Text = "Editar";
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            HabilitarCampos(false);
        }

        private void SeleccionarValor(ComboBox combo, object valor)
        {
            combo.SelectedValue = valor == null || valor == DBNull.Value ? null : valor;
            if (valor == null || valor == DBNull.Value) combo.SelectedIndex = -1;
        }

        private void SeleccionarTexto(ComboBox combo, object valor)
        {
            string texto = valor == null || valor == DBNull.Value ? "" : Convert.ToString(valor);
            combo.SelectedIndex = combo.FindStringExact(texto);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoNuevaSolicitud)
            {
                PrepararModoConsulta();
                return;
            }

            if (dgvSolicitudes.CurrentRow == null || dgvSolicitudes.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una solicitud de la tabla.");
                return;
            }

            if (!modoEdicion)
            {
                modoEdicion = true;
                HabilitarCampos(true);
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnEditar.Text = "Guardar cambios";
                txtTitulo.Focus();
                return;
            }

            if (!ValidarCampos()) return;
            int id = Convert.ToInt32(dgvSolicitudes.CurrentRow.Cells["id_solicitud"].Value);

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE SOLICITUDES_AYUDA
                    SET id_usuario=@usuario, id_categoria=@categoria, id_ubicacion=@ubicacion,
                        titulo=@titulo, descripcion=@descripcion, fecha_publicacion=@fecha,
                        prioridad=@prioridad, estado=@estado
                    WHERE id_solicitud=@id;", cn))
                {
                    AgregarParametros(cmd);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    if (filas == 0)
                    {
                        MessageBox.Show("No se encontró la solicitud para actualizar.");
                        return;
                    }
                }
                MessageBox.Show("Solicitud actualizada correctamente.");
                CargarSolicitudes();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la solicitud:\n" + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modoNuevaSolicitud || modoEdicion || dgvSolicitudes.CurrentRow == null ||
                dgvSolicitudes.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una solicitud en modo consulta.");
                return;
            }

            int id = Convert.ToInt32(dgvSolicitudes.CurrentRow.Cells["id_solicitud"].Value);
            if (MessageBox.Show("¿Deseas eliminar esta solicitud?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM SOLICITUDES_AYUDA WHERE id_solicitud=@id;", cn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cn.Open();
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        MessageBox.Show("Solicitud eliminada correctamente.");
                        CargarSolicitudes();
                        PrepararModoConsulta();
                    }
                    else MessageBox.Show("No se encontró la solicitud seleccionada.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se pudo eliminar la solicitud. Puede estar relacionada con otros registros.\n\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la solicitud:\n" + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            PrepararModoConsulta();
            txtBuscar.Clear();
            dgvSolicitudes.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            cmbUsuario.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;
            cmbPrioridad.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            dgvSolicitudes.ClearSelection();
        }

        private void PrepararModoConsulta()
        {
            modoNuevaSolicitud = false;
            modoEdicion = false;
            HabilitarCampos(false);
            btnGuardar.Text = "Nueva solicitud";
            btnGuardar.Enabled = true;
            btnEditar.Text = "Editar";
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            LimpiarCampos();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtTitulo.ReadOnly = !habilitar;
            txtDescripcion.ReadOnly = !habilitar;
            cmbUsuario.Enabled = habilitar;
            cmbCategoria.Enabled = habilitar;
            cmbUbicacion.Enabled = habilitar;
            cmbPrioridad.Enabled = habilitar;
            cmbEstado.Enabled = habilitar;
            dtpFecha.Enabled = habilitar;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvSolicitudes.DataSource is DataTable tabla)
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                tabla.DefaultView.RowFilter = texto == ""
                    ? ""
                    : $"titulo LIKE '%{texto}%'";
            }
        }

        private void frmSolicitudesdeAyuda_Load(object sender, EventArgs e)
        {

        }
    }
}
