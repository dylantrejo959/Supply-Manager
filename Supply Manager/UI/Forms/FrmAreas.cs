using System;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;
using Supply_Manager.Utils;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmAreas : Form
    {
        private readonly AreaService _service;
        private int _idSeleccionado = 0;

        public FrmAreas()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _service = new AreaService(uow);
            ConfigurarPermisos();
            CargarAreas();
        }

        private void ConfigurarPermisos()
        {
            bool puede = SesionUsuario.EsAdministrador();
            btnAgregar.Enabled = puede;
            btnActualizar.Enabled = puede;
            btnEliminar.Enabled = puede;
        }

        private void CargarAreas()
        {
            try
            {
                dgvAreas.DataSource = _service.ObtenerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar áreas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAreas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvAreas.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdArea"].Value);
            txtNombreArea.Text = fila.Cells["NombreArea"].Value?.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Insertar(new Area { NombreArea = txtNombreArea.Text.Trim() });
                MessageBox.Show("Área agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAreas(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Actualizar(new Area { IdArea = _idSeleccionado, NombreArea = txtNombreArea.Text.Trim() });
                MessageBox.Show("Área actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAreas(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0) throw new ArgumentException("Seleccione un área de la lista.");
                if (MessageBox.Show("¿Desea eliminar el área seleccionada?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                _service.Eliminar(_idSeleccionado);
                MessageBox.Show("Área eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAreas(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void FrmAreas_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            dgvAreas.Width = panel1.Width - dgvAreas.Left - margin;
            dgvAreas.Height = panel1.Height - dgvAreas.Top - margin;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombreArea.Clear();
        }
    }
}
