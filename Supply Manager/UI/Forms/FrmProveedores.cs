using System;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;
using Supply_Manager.Utils;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmProveedores : Form
    {
        private readonly ProveedorService _service;
        private int _idSeleccionado = 0;

        public FrmProveedores()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _service = new ProveedorService(uow);
            ConfigurarPermisos();
            CargarProveedores();
        }

        private void ConfigurarPermisos()
        {
            bool puede = SesionUsuario.PuedeModificar();
            btnAgregar.Enabled = puede;
            btnActualizar.Enabled = puede;
            btnEliminar.Enabled = puede;
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = _service.ObtenerFiltrado(txtBuscar.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvProveedores.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdProveedor"].Value);
            txtNombre.Text = fila.Cells["NombreProveedor"].Value?.ToString();
            txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
            txtCorreo.Text = fila.Cells["Correo"].Value?.ToString();
            txtDireccion.Text = fila.Cells["Direccion"].Value?.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Insertar(new Proveedor
                {
                    NombreProveedor = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                });
                MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
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
                _service.Actualizar(new Proveedor
                {
                    IdProveedor = _idSeleccionado,
                    NombreProveedor = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                });
                MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
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
                    throw new ArgumentException("Seleccione un proveedor de la lista.");
                if (MessageBox.Show("¿Desea eliminar el proveedor seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                _service.Eliminar(_idSeleccionado);
                MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarProveedores();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void FrmProveedores_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            dgvProveedores.Width = panel1.Width - dgvProveedores.Left - margin;
            dgvProveedores.Height = panel1.Height - dgvProveedores.Top - margin;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
        }
    }
}
