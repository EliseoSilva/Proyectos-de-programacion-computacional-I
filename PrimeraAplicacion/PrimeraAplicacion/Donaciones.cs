using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PrimeraAplicacion
{
    public partial class frmComunidadConecta : Form
    {
        private bool modoNuevaDonacion = false;
        private bool modoEdicion = false;

        public frmComunidadConecta()
        {
            InitializeComponent();

            dgvDonaciones.CellClick += dgvDonaciones_CellContentClick;

            // Garantizar que el botón Limpiar tenga su evento conectado.
            btnLimpiar.Click -= btnLimpiar_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            CargarCombos();
            CargarDonaciones();
            PrepararModoConsulta();
        }

        // =========================================
        // CARGAR DONACIONES
        // =========================================
        private void CargarDonaciones()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    string consulta = @"
                        SELECT
                            id_donacion,
                            id_usuario,
                            id_categoria,
                            id_ubicacion,
                            titulo,
                            descripcion,
                            fecha_publicacion,
                            estado
                        FROM DONACIONES
                        ORDER BY id_donacion DESC;";

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);

                        dgvDonaciones.DataSource = tabla;
                        dgvDonaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvDonaciones.ReadOnly = true;
                        dgvDonaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvDonaciones.MultiSelect = false;
                        dgvDonaciones.AllowUserToAddRows = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las donaciones:\n" + ex.Message,
                    "Comunidad Conecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // CARGAR COMBOS
        // =========================================
        private void CargarCombos()
        {
            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT id_usuario,
                                 CONCAT(nombres, ' ', apellidos) AS nombre_completo
                          FROM USUARIOS
                          ORDER BY nombres, apellidos;", cn))
                    {
                        DataTable usuarios = new DataTable();
                        da.Fill(usuarios);
                        cmbUsuario.DataSource = usuarios;
                        cmbUsuario.DisplayMember = "nombre_completo";
                        cmbUsuario.ValueMember = "id_usuario";
                        cmbUsuario.SelectedIndex = -1;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT id_categoria, nombre
                          FROM CATEGORIAS
                          ORDER BY nombre;", cn))
                    {
                        DataTable categorias = new DataTable();
                        da.Fill(categorias);
                        cmbCategoria.DataSource = categorias;
                        cmbCategoria.DisplayMember = "nombre";
                        cmbCategoria.ValueMember = "id_categoria";
                        cmbCategoria.SelectedIndex = -1;
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(
                        @"SELECT id_ubicacion, direccion
                          FROM UBICACIONES
                          ORDER BY direccion;", cn))
                    {
                        DataTable ubicaciones = new DataTable();
                        da.Fill(ubicaciones);
                        cmbUbicacion.DataSource = ubicaciones;
                        cmbUbicacion.DisplayMember = "direccion";
                        cmbUbicacion.ValueMember = "id_ubicacion";
                        cmbUbicacion.SelectedIndex = -1;
                    }

                    cmbEstado.Items.Clear();
                    cmbEstado.Items.Add("Disponible");
                    cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbEstado.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los combos:\n" + ex.Message,
                    "Comunidad Conecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // BOTÓN NUEVA DONACIÓN / GUARDAR
        // =========================================
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Primera pulsación: preparar un nuevo registro.
            if (!modoNuevaDonacion)
            {
                LimpiarCampos();
                modoNuevaDonacion = true;
                modoEdicion = false;

                btnGuardar.Text = "Guardar";
                btnEliminar.Enabled = false;
                btnEditar.Text = "Cancelar";
                btnEditar.Enabled = true;
                HabilitarCampos(true);
                txtTitulo.Focus();
                return;
            }

            // Segunda pulsación: validar y guardar el registro nuevo.
            string faltantes = "";

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                faltantes += "- Título\n";

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                faltantes += "- Descripción\n";

            if (cmbUsuario.SelectedIndex < 0)
                faltantes += "- Usuario\n";

            if (cmbCategoria.SelectedIndex < 0)
                faltantes += "- Categoría\n";

            if (cmbUbicacion.SelectedIndex < 0)
                faltantes += "- Ubicación\n";

            if (cmbEstado.SelectedIndex < 0)
                faltantes += "- Estado\n";

            if (faltantes != "")
            {
                MessageBox.Show(
                    "Completa los siguientes campos:\n\n" + faltantes,
                    "Campos pendientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    string consulta = @"
                        INSERT INTO DONACIONES
                        (id_usuario, id_categoria, id_ubicacion,
                         titulo, descripcion, fecha_publicacion, estado)
                        VALUES
                        (@usuario, @categoria, @ubicacion,
                         @titulo, @descripcion, @fecha, @estado);";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = cmbUsuario.SelectedValue;
                        cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = cmbCategoria.SelectedValue;
                        cmd.Parameters.Add("@ubicacion", SqlDbType.Int).Value = cmbUbicacion.SelectedValue;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = txtTitulo.Text.Trim();
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txtDescripcion.Text.Trim();
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dtpFecha.Value;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = cmbEstado.Text;

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Donación guardada correctamente.",
                    "Comunidad Conecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDonaciones();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar la donación:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // SELECCIONAR DONACIÓN
        // Los campos se muestran bloqueados.
        // =========================================
        private void dgvDonaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || modoNuevaDonacion || modoEdicion)
                return;

            DataGridViewRow fila = dgvDonaciones.Rows[e.RowIndex];

            txtTitulo.Text = Convert.ToString(fila.Cells["titulo"].Value) ?? "";
            txtDescripcion.Text = Convert.ToString(fila.Cells["descripcion"].Value) ?? "";

            cmbUsuario.SelectedValue = fila.Cells["id_usuario"].Value;
            cmbCategoria.SelectedValue = fila.Cells["id_categoria"].Value;
            cmbUbicacion.SelectedValue = fila.Cells["id_ubicacion"].Value;

            if (fila.Cells["fecha_publicacion"].Value != DBNull.Value)
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["fecha_publicacion"].Value);

            string estado = Convert.ToString(fila.Cells["estado"].Value) ?? "";
            if (!cmbEstado.Items.Contains(estado))
                cmbEstado.Items.Add(estado);
            cmbEstado.SelectedItem = estado;

            btnEliminar.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Text = "Nueva donación";
            HabilitarCampos(false);
        }

        // =========================================
        // BOTÓN EDITAR
        // Primer clic habilita los campos.
        // Segundo clic guarda los cambios.
        // =========================================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (modoNuevaDonacion)
            {
                // El botón Editar actúa como Cancelar mientras se crea una donación.
                PrepararModoConsulta();
                return;
            }

            if (dgvDonaciones.CurrentRow == null || dgvDonaciones.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una donación de la tabla.");
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

            string faltantes = "";

            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
                faltantes += "- Título\n";
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                faltantes += "- Descripción\n";
            if (cmbUsuario.SelectedIndex < 0)
                faltantes += "- Usuario\n";
            if (cmbCategoria.SelectedIndex < 0)
                faltantes += "- Categoría\n";
            if (cmbUbicacion.SelectedIndex < 0)
                faltantes += "- Ubicación\n";
            if (cmbEstado.SelectedIndex < 0)
                faltantes += "- Estado\n";

            if (faltantes != "")
            {
                MessageBox.Show(
                    "Completa los siguientes campos:\n\n" + faltantes,
                    "Campos pendientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idDonacion = Convert.ToInt32(
                dgvDonaciones.CurrentRow.Cells["id_donacion"].Value);

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    string consulta = @"
                        UPDATE DONACIONES
                        SET id_usuario = @usuario,
                            id_categoria = @categoria,
                            id_ubicacion = @ubicacion,
                            titulo = @titulo,
                            descripcion = @descripcion,
                            fecha_publicacion = @fecha,
                            estado = @estado
                        WHERE id_donacion = @id;";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = cmbUsuario.SelectedValue;
                        cmd.Parameters.Add("@categoria", SqlDbType.Int).Value = cmbCategoria.SelectedValue;
                        cmd.Parameters.Add("@ubicacion", SqlDbType.Int).Value = cmbUbicacion.SelectedValue;
                        cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = txtTitulo.Text.Trim();
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = txtDescripcion.Text.Trim();
                        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dtpFecha.Value;
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = cmbEstado.Text;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idDonacion;

                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas == 0)
                        {
                            MessageBox.Show("No se encontró la donación para actualizar.");
                            return;
                        }
                    }
                }

                MessageBox.Show("Donación actualizada correctamente.");
                CargarDonaciones();
                PrepararModoConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al editar la donación:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // ELIMINAR DONACIÓN
        // =========================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (modoNuevaDonacion || modoEdicion ||
                dgvDonaciones.CurrentRow == null ||
                dgvDonaciones.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Selecciona una donación en modo consulta.");
                return;
            }

            int idDonacion = Convert.ToInt32(
                dgvDonaciones.CurrentRow.Cells["id_donacion"].Value);

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar esta donación?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection cn = conexion.ObtenerConexion())
                {
                    string consulta = "DELETE FROM DONACIONES WHERE id_donacion = @id;";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idDonacion;
                        cn.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Donación eliminada correctamente.");
                            CargarDonaciones();
                            PrepararModoConsulta();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la donación seleccionada.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar la donación. Puede estar relacionada con otros registros.\n\nDetalle: " + ex.Message,
                    "Error al eliminar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la donación:\n" + ex.Message);
            }
        }

        // =========================================
        // BOTÓN LIMPIAR
        // =========================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar siempre cancela cualquier operación y deja el formulario en consulta.
            PrepararModoConsulta();
            txtBuscar.Clear();
            dgvDonaciones.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();

            cmbUsuario.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;

            if (cmbEstado.Items.Count > 0)
                cmbEstado.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
            dgvDonaciones.ClearSelection();
        }

        // =========================================
        // CONFIGURAR MODO CONSULTA
        // =========================================
        private void PrepararModoConsulta()
        {
            modoNuevaDonacion = false;
            modoEdicion = false;

            HabilitarCampos(false);

            btnGuardar.Text = "Nueva donación";
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
            cmbEstado.Enabled = habilitar;
            dtpFecha.Enabled = habilitar;
        }

        // =========================================
        // BÚSQUEDA POR TÍTULO
        // =========================================
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (dgvDonaciones.DataSource is DataTable tabla)
            {
                string texto = txtBuscar.Text.Trim().Replace("'", "''");

                tabla.DefaultView.RowFilter = texto == ""
                    ? ""
                    : $"titulo LIKE '%{texto}%'";
            }
        }
    }
}
