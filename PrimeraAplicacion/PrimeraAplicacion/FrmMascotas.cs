using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PrimeraAplicacion
{
    public partial class FrmMascotas : Form
    {
        private bool modoNuevaMascota;
        private bool modoEdicion;

        public FrmMascotas()
        {
            InitializeComponent();
            dgvMascotas.CellClick += dgvMascotas_CellClick;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnSeleccionarFoto.Click += btnSeleccionarFoto_Click;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            CargarCombos();
            CargarMascotas();
            PrepararModoConsulta();
        }

        private void CargarMascotas()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT id_mascota, id_usuario, id_ubicacion, nombre, tipo,
                           raza, color, descripcion, foto, estado, fecha_reporte
                    FROM MASCOTAS ORDER BY id_mascota DESC;", cn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    dgvMascotas.DataSource = tabla;
                    dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvMascotas.ReadOnly = true;
                    dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMascotas.MultiSelect = false;
                    dgvMascotas.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mascotas:\n" + ex.Message);
            }
        }

        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(@"
                        SELECT id_usuario, CONCAT(nombres, ' ', apellidos) AS nombre_completo
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
                        "SELECT id_ubicacion, direccion FROM UBICACIONES ORDER BY direccion;", cn))
                    {
                        DataTable t = new DataTable();
                        da.Fill(t);
                        cmbUbicacion.DataSource = t;
                        cmbUbicacion.DisplayMember = "direccion";
                        cmbUbicacion.ValueMember = "id_ubicacion";
                        cmbUbicacion.SelectedIndex = -1;
                    }

                    cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbTipo.Items.Clear();
                    cmbTipo.Items.AddRange(new object[] { "Perro", "Gato", "Ave", "Otro" });
                    cmbTipo.SelectedIndex = -1;

                    cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbEstado.Items.Clear();
                    cmbEstado.Items.AddRange(new object[] {
                        "Perdida", "Encontrada", "Reunida con su dueño"
                    });
                    cmbEstado.SelectedIndex = -1;
                    dtpFechaReporte.Format = DateTimePickerFormat.Short;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas:\n" + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoNuevaMascota)
            {
                LimpiarCampos();
                modoNuevaMascota = true;
                modoEdicion = false;
                btnGuardar.Text = "Guardar";
                btnEditar.Text = "Cancelar";
                btnEditar.Enabled = true;
                btnEliminar.Enabled = false;
                HabilitarCampos(true);
                txtNombre.Focus();
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO MASCOTAS
                    (id_usuario, id_ubicacion, nombre, tipo, raza, color,
                     descripcion, foto, estado, fecha_reporte)
                    VALUES
                    (@usuario, @ubicacion, @nombre, @tipo, @raza, @color,
                     @descripcion, @foto, @estado, @fecha);", cn))
                {
                    AgregarParametros(cmd);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Reporte de mascota guardado correctamente.");
                CargarMascotas();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            string faltantes = "";
            if (cmbUsuario.SelectedIndex < 0) faltantes += "- Usuario\n";
            if (cmbUbicacion.SelectedIndex < 0) faltantes += "- Ubicación\n";
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) faltantes += "- Nombre\n";
            if (cmbTipo.SelectedIndex < 0) faltantes += "- Tipo\n";
            if (string.IsNullOrWhiteSpace(txtRaza.Text)) faltantes += "- Raza\n";
            if (string.IsNullOrWhiteSpace(txtColor.Text)) faltantes += "- Color\n";
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text)) faltantes += "- Descripción\n";
            if (cmbEstado.SelectedIndex < 0) faltantes += "- Estado\n";

            if (faltantes != "")
            {
                MessageBox.Show("Completa los campos:\n\n" + faltantes);
                return false;
            }
            if (txtNombre.Text.Trim().Length > 100 ||
                txtRaza.Text.Trim().Length > 100 ||
                txtColor.Text.Trim().Length > 50 ||
                txtDescripcion.Text.Trim().Length > 500 ||
                txtFoto.Text.Trim().Length > 255)
            {
                MessageBox.Show("Revisa las longitudes: nombre/raza hasta 100, color hasta 50, descripción hasta 500 y foto hasta 255 caracteres.");
                return false;
            }
            return true;
        }

        private void AgregarParametros(SqlCommand cmd)
        {
            cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = cmbUsuario.SelectedValue;
            cmd.Parameters.Add("@ubicacion", SqlDbType.Int).Value = cmbUbicacion.SelectedValue;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtNombre.Text.Trim();
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = cmbTipo.Text;
            cmd.Parameters.Add("@raza", SqlDbType.VarChar, 100).Value = txtRaza.Text.Trim();
            cmd.Parameters.Add("@color", SqlDbType.VarChar, 50).Value = txtColor.Text.Trim();
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = txtDescripcion.Text.Trim();
            cmd.Parameters.Add("@foto", SqlDbType.VarChar, 255).Value =
                string.IsNullOrWhiteSpace(txtFoto.Text) ? (object)DBNull.Value : txtFoto.Text.Trim();
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 50).Value = cmbEstado.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = dtpFechaReporte.Value.Date;
        }

        private void dgvMascotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modoNuevaMascota || modoEdicion) return;
            DataGridViewRow f = dgvMascotas.Rows[e.RowIndex];
            txtNombre.Text = Convert.ToString(f.Cells["nombre"].Value) ?? "";
            SeleccionarValor(cmbUsuario, f.Cells["id_usuario"].Value);
            SeleccionarValor(cmbUbicacion, f.Cells["id_ubicacion"].Value);
            SeleccionarTexto(cmbTipo, f.Cells["tipo"].Value);
            txtRaza.Text = Convert.ToString(f.Cells["raza"].Value) ?? "";
            txtColor.Text = Convert.ToString(f.Cells["color"].Value) ?? "";
            txtDescripcion.Text = Convert.ToString(f.Cells["descripcion"].Value) ?? "";
            txtFoto.Text = Convert.ToString(f.Cells["foto"].Value) ?? "";
            if (f.Cells["fecha_reporte"].Value != DBNull.Value &&
                f.Cells["fecha_reporte"].Value != null)
                dtpFechaReporte.Value = Convert.ToDateTime(f.Cells["fecha_reporte"].Value);
            SeleccionarTexto(cmbEstado, f.Cells["estado"].Value);
            btnGuardar.Text = "Nueva mascota";
            btnEditar.Text = "Editar";
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            HabilitarCampos(false);
        }

        private void SeleccionarValor(ComboBox combo, object valor)
        {
            if (valor == null || valor == DBNull.Value) combo.SelectedIndex = -1;
            else combo.SelectedValue = valor;
        }

        private void SeleccionarTexto(ComboBox combo, object valor)
        {
            string texto = valor == null || valor == DBNull.Value ? "" : Convert.ToString(valor);
            combo.SelectedIndex = combo.FindStringExact(texto);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoNuevaMascota)
            {
                PrepararModoConsulta();
                return;
            }
            if (dgvMascotas.CurrentRow == null || dgvMascotas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una mascota de la tabla.");
                return;
            }
            if (!modoEdicion)
            {
                modoEdicion = true;
                HabilitarCampos(true);
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnEditar.Text = "Guardar cambios";
                txtNombre.Focus();
                return;
            }
            if (!ValidarCampos()) return;
            int id = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["id_mascota"].Value);
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE MASCOTAS SET id_usuario=@usuario, id_ubicacion=@ubicacion,
                        nombre=@nombre, tipo=@tipo, raza=@raza, color=@color,
                        descripcion=@descripcion, foto=@foto, estado=@estado,
                        fecha_reporte=@fecha
                    WHERE id_mascota=@id;", cn))
                {
                    AgregarParametros(cmd);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cn.Open();
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("No se encontró el reporte para actualizar.");
                        return;
                    }
                }
                MessageBox.Show("Reporte actualizado correctamente.");
                CargarMascotas();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar:\n" + ex.Message);
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            if (!modoNuevaMascota && !modoEdicion)
            {
                MessageBox.Show("Pulsa Nueva mascota o Editar antes de seleccionar una foto.");
                return;
            }
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Seleccionar foto de la mascota";
                dlg.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtFoto.Text = dlg.FileName;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modoNuevaMascota || modoEdicion || dgvMascotas.CurrentRow == null ||
                dgvMascotas.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona un reporte en modo consulta.");
                return;
            }
            int id = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["id_mascota"].Value);
            if (MessageBox.Show("¿Seguro que deseas eliminar este reporte?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM MASCOTAS WHERE id_mascota=@id;", cn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Reporte eliminado.");
                        CargarMascotas();
                        PrepararModoConsulta();
                    }
                    else MessageBox.Show("No se encontró el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar (puede haber registros relacionados):\n" + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            PrepararModoConsulta();
            txtBuscar.Clear();
            dgvMascotas.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtRaza.Clear();
            txtColor.Clear();
            txtDescripcion.Clear();
            txtFoto.Clear();
            cmbUsuario.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            dtpFechaReporte.Value = DateTime.Today;
            dgvMascotas.ClearSelection();
        }

        private void PrepararModoConsulta()
        {
            modoNuevaMascota = false;
            modoEdicion = false;
            HabilitarCampos(false);
            btnGuardar.Text = "Nueva mascota";
            btnGuardar.Enabled = true;
            btnEditar.Text = "Editar";
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            LimpiarCampos();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.ReadOnly = !habilitar;
            txtRaza.ReadOnly = !habilitar;
            txtColor.ReadOnly = !habilitar;
            txtDescripcion.ReadOnly = !habilitar;
            txtFoto.ReadOnly = true;
            cmbUsuario.Enabled = habilitar;
            cmbUbicacion.Enabled = habilitar;
            cmbTipo.Enabled = habilitar;
            cmbEstado.Enabled = habilitar;
            dtpFechaReporte.Enabled = habilitar;
            btnSeleccionarFoto.Enabled = habilitar;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvMascotas.DataSource is DataTable tabla)
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");
                tabla.DefaultView.RowFilter = texto == "" ? "" : $"nombre LIKE '%{texto}%'";
            }
        }
    }
}

