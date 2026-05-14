using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supply_Manager.DAL.Data.UnitOfWork;
using Supply_Manager.Entities;
using Supply_Manager.Factory;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmInsumos : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public FrmInsumos()
        {
            InitializeComponent();

            IRepositoryFactory factory =
                new RepositoryFactory();

            _unitOfWork =
                factory.CrearUnidadDeTrabajo();

            CargarInsumos();
        }

        private void CargarInsumos()
        {
            dgvInsumos.DataSource = null;

            dgvInsumos.DataSource =
                _unitOfWork
                .InsumoRepository
                .ObtenerTodos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Insumo insumo = new Insumo
            {
                NombreInsumo = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                StockActual = int.Parse(txtStock.Text),
                StockMinimo = int.Parse(txtStockMinimo.Text),
                UnidadMedida = cbUnidad.Text
            };

            _unitOfWork
                .InsumoRepository
                .Insertar(insumo);

            MessageBox.Show("Insumo agregado correctamente");

            CargarInsumos();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();

            cbUnidad.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}