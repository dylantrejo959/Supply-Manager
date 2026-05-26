using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioService _service;
        private int _idSeleccionado = 0;
        private List<Rol> _roles;

        public FrmUsuarios()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _service = new UsuarioService(uow);
            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            try
            {
                _roles = _service.ObtenerRoles();
                cbRol.DataSource = _roles;
                cbRol.DisplayMember = "NombreRol";
                cbRol.ValueMember = "IdRol";
                cbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = _service.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvUsuarios.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);
            txtUsuario.Text = fila.Cells["NombreUsuario"].Value?.ToString();
            txtClave.Clear();
            string rolNombre = fila.Cells["Rol"].Value?.ToString();
            foreach (Rol r in _roles)
            {
                if (r.NombreRol == rolNombre) { cbRol.SelectedValue = r.IdRol; break; }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbRol.SelectedValue == null) throw new ArgumentException("Debe seleccionar un rol.");
                _service.Insertar(txtUsuario.Text.Trim(), txtClave.Text, (int)cbRol.SelectedValue);
                MessageBox.Show("Usuario creado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbRol.SelectedValue == null) throw new ArgumentException("Debe seleccionar un rol.");
                _service.Actualizar(_idSeleccionado, txtUsuario.Text.Trim(), (int)cbRol.SelectedValue);
                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_idSeleccionado == 0) throw new ArgumentException("Seleccione un usuario de la lista.");
                if (MessageBox.Show("¿Desea desactivar el usuario seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                _service.Desactivar(_idSeleccionado);
                MessageBox.Show("Usuario desactivado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios(); LimpiarCampos();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarCampos(); }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void FrmUsuarios_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            dgvUsuarios.Width = panel1.Width - dgvUsuarios.Left - margin;
            dgvUsuarios.Height = panel1.Height - dgvUsuarios.Top - margin;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            txtUsuario.Clear();
            txtClave.Clear();
            cbRol.SelectedIndex = -1;
        }
    }
}
