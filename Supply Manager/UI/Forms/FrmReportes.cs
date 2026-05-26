using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Supply_Manager.BLL.Services;
using Supply_Manager.Entities;
using Supply_Manager.Factory;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmReportes : Form
    {
        private readonly ReporteService _reporteService;
        private readonly AreaService _areaService;
        private List<Area> _areas;

        public FrmReportes()
        {
            InitializeComponent();
            var uow = new RepositoryFactory().CrearUnidadDeTrabajo();
            _reporteService = new ReporteService(uow);
            _areaService = new AreaService(uow);
            CargarAreas();
        }

        private void CargarAreas()
        {
            try
            {
                _areas = _areaService.ObtenerTodas();
                var lista = new List<Area> { new Area { IdArea = 0, NombreArea = "(Todas las áreas)" } };
                lista.AddRange(_areas);
                cbAreaConsumo.DataSource = lista;
                cbAreaConsumo.DisplayMember = "NombreArea";
                cbAreaConsumo.ValueMember = "IdArea";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarStockCritico_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStockCritico.DataSource = _reporteService.ObtenerStockCritico();
                if (dgvStockCritico.Rows.Count == 0)
                    MessageBox.Show("No hay insumos con stock crítico actualmente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarConsumo_Click(object sender, EventArgs e)
        {
            try
            {
                int? idArea = cbAreaConsumo.SelectedValue != null && (int)cbAreaConsumo.SelectedValue > 0
                    ? (int?)cbAreaConsumo.SelectedValue : null;
                dgvConsumo.DataSource = _reporteService.ObtenerConsumo(dtpDesde.Value.Date, dtpHasta.Value.Date, idArea);
                if (dgvConsumo.Rows.Count == 0)
                    MessageBox.Show("No hay movimientos en el período seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarProyeccion_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProyeccion.DataSource = _reporteService.ObtenerProyeccion();
                if (dgvProyeccion.Rows.Count == 0)
                    MessageBox.Show("No hay insumos activos para proyectar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar proyección: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void FrmReportes_Resize(object sender, EventArgs e)
        {
            int margin = 20;
            panel1.Width = this.ClientSize.Width - margin * 2;
            panel1.Height = this.ClientSize.Height - panel1.Top - margin;
            btnCerrar.Left = this.ClientSize.Width - btnCerrar.Width - 12;
            tabControl.Width = panel1.Width - 30;
            tabControl.Height = panel1.Height - 30;

            int tabInner = tabControl.Width - 20;
            int tabH = tabControl.Height - 45;
            dgvStockCritico.Width = tabInner; dgvStockCritico.Height = tabH - dgvStockCritico.Top;
            dgvConsumo.Width = tabInner; dgvConsumo.Height = tabH - dgvConsumo.Top;
            dgvProyeccion.Width = tabInner; dgvProyeccion.Height = tabH - dgvProyeccion.Top;
        }
    }
}
