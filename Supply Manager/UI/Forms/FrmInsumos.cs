using System;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;
using Supply_Manager.Utils;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmInsumos : Form
    {
        private readonly InsumoService _service;
        private int _idSeleccionado = 0;

        public FrmInsumos()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _service = new InsumoService(uow);
            ConfigurarPermisos();
            CargarInsumos();
        }

        private void ConfigurarPermisos()
        {
            bool puedeModificar = SesionUsuario.PuedeModificar();
            btnAgregar.Enabled = puedeModificar;
            btnActualizar.Enabled = puedeModificar;
            btnEliminar.Enabled = puedeModificar;
        }

        private void CargarInsumos()
        {
            try
            {
                dgvInsumos.DataSource = _service.ObtenerFiltrado(
                    txtBuscar.Text.Trim(),
                    cbFiltroUnidad.SelectedIndex > 0 ? cbFiltroUnidad.Text : null,
                    chkStockCritico.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar insumos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvInsumos.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdInsumo"].Value);
            txtNombre.Text = fila.Cells["NombreInsumo"].Value?.ToString();
            txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
            txtStock.Text = fila.Cells["StockActual"].Value?.ToString();
            txtStock.ReadOnly = true;
            txtStockMinimo.Text = fila.Cells["StockMinimo"].Value?.ToString();
            cbUnidad.Text = fila.Cells["UnidadMedida"].Value?.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtStock.Text, out int stock))
                    throw new ArgumentException("El stock actual debe ser un número entero.");
                if (!int.TryParse(txtStockMinimo.Text, out int stockMin))
                    throw new ArgumentException("El stock mínimo debe ser un número entero.");

                _service.Insertar(new Insumo
                {
                    NombreInsumo = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    StockActual = stock,
                    StockMinimo = stockMin,
                    UnidadMedida = cbUnidad.Text
                });
                MessageBox.Show("Insumo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInsumos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                    throw new ArgumentException("Seleccione un insumo de la tabla para actualizar.");
                if (!int.TryParse(txtStockMinimo.Text, out int stockMin))
                    throw new ArgumentException("El stock mínimo debe ser un número entero.");

                _service.Actualizar(new Insumo
                {
                    IdInsumo = _idSeleccionado,
                    NombreInsumo = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    StockMinimo = stockMin,
                    UnidadMedida = cbUnidad.Text
                });
                MessageBox.Show("Insumo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInsumos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0)
                    throw new ArgumentException("Seleccione un insumo de la tabla para desactivar.");
                if (MessageBox.Show("¿Desea desactivar el insumo seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                _service.Desactivar(_idSeleccionado);
                MessageBox.Show("Insumo desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInsumos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarInsumos();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cbFiltroUnidad.SelectedIndex = 0;
            chkStockCritico.Checked = false;
            CargarInsumos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInsumos_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            dgvInsumos.Width = panel1.Width - dgvInsumos.Left - margin;
            dgvInsumos.Height = panel1.Height - dgvInsumos.Top - margin;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtStock.ReadOnly = false;
            txtStockMinimo.Clear();
            cbUnidad.SelectedIndex = -1;
        }
    }
}
