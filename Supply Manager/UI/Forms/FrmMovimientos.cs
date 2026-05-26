using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;
using Supply_Manager.Utils;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmMovimientos : Form
    {
        private readonly MovimientoService _movService;
        private readonly AreaService _areaService;
        private readonly InsumoService _insumoService;
        private List<Insumo> _insumos;
        private List<Area> _areas;

        public FrmMovimientos()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _movService = new MovimientoService(uow);
            _areaService = new AreaService(uow);
            _insumoService = new InsumoService(uow);

            ConfigurarPermisos();
            CargarCombos();
            CargarMovimientos();
        }

        private void ConfigurarPermisos()
        {
            btnRegistrar.Enabled = SesionUsuario.PuedeModificar();
        }

        private void CargarCombos()
        {
            try
            {
                _insumos = _insumoService.ObtenerTodos();
                _areas = _areaService.ObtenerTodas();

                cmbInsumo.DataSource = new List<Insumo>(_insumos);
                cmbInsumo.DisplayMember = "NombreInsumo";
                cmbInsumo.ValueMember = "IdInsumo";
                cmbInsumo.SelectedIndex = -1;

                cmbArea.DataSource = new List<Area>(_areas);
                cmbArea.DisplayMember = "NombreArea";
                cmbArea.ValueMember = "IdArea";
                cmbArea.SelectedIndex = -1;

                // Combos de filtro
                var insumosFiltro = new List<Insumo> { new Insumo { IdInsumo = 0, NombreInsumo = "(Todos)" } };
                insumosFiltro.AddRange(_insumos);
                cbFiltroInsumo.DataSource = insumosFiltro;
                cbFiltroInsumo.DisplayMember = "NombreInsumo";
                cbFiltroInsumo.ValueMember = "IdInsumo";

                var areasFiltro = new List<Area> { new Area { IdArea = 0, NombreArea = "(Todas)" } };
                areasFiltro.AddRange(_areas);
                cbFiltroArea.DataSource = areasFiltro;
                cbFiltroArea.DisplayMember = "NombreArea";
                cbFiltroArea.ValueMember = "IdArea";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMovimientos()
        {
            try
            {
                int? idInsumo = cbFiltroInsumo.SelectedValue != null && (int)cbFiltroInsumo.SelectedValue > 0
                    ? (int?)cbFiltroInsumo.SelectedValue : null;
                int? idArea = cbFiltroArea.SelectedValue != null && (int)cbFiltroArea.SelectedValue > 0
                    ? (int?)cbFiltroArea.SelectedValue : null;
                string tipo = cbFiltroTipo.SelectedIndex > 0 ? cbFiltroTipo.Text : null;
                DateTime? desde = chkFiltrarFecha.Checked ? (DateTime?)dtpDesde.Value.Date : null;
                DateTime? hasta = chkFiltrarFecha.Checked ? (DateTime?)dtpHasta.Value.Date : null;

                dgvMovimientos.DataSource = _movService.ObtenerFiltrado(idInsumo, idArea, tipo, desde, hasta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar movimientos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbInsumo.SelectedValue == null || (int)cmbInsumo.SelectedValue <= 0)
                    throw new ArgumentException("Debe seleccionar un insumo.");
                if (cmbArea.SelectedValue == null || (int)cmbArea.SelectedValue <= 0)
                    throw new ArgumentException("Debe seleccionar un área.");
                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                    throw new ArgumentException("La cantidad debe ser un número entero mayor a cero.");

                _movService.Registrar(new Movimiento
                {
                    TipoMovimiento = cbTipo.Text,
                    Cantidad = cantidad,
                    Observacion = txtObservacion.Text.Trim(),
                    IdInsumo = (int)cmbInsumo.SelectedValue,
                    IdArea = (int)cmbArea.SelectedValue,
                    IdUsuario = SesionUsuario.UsuarioActual.IdUsuario,
                    FechaMovimiento = DateTime.Now
                });
                MessageBox.Show("Movimiento registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btnTodosMovimientos_Click(object sender, EventArgs e)
        {
            cbFiltroInsumo.SelectedIndex = 0;
            cbFiltroArea.SelectedIndex = 0;
            cbFiltroTipo.SelectedIndex = 0;
            chkFiltrarFecha.Checked = false;
            CargarMovimientos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void FrmMovimientos_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            dgvMovimientos.Width = panel1.Width - dgvMovimientos.Left - margin;
            dgvMovimientos.Height = panel1.Height - dgvMovimientos.Top - margin;
        }

        private void LimpiarFormulario()
        {
            cmbInsumo.SelectedIndex = -1;
            cmbArea.SelectedIndex = -1;
            cbTipo.SelectedIndex = 0;
            txtCantidad.Clear();
            txtObservacion.Clear();
        }
    }
}
