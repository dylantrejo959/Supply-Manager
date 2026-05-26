using System;
using System.Windows.Forms;
using Supply_Manager.Utils;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            var usuario = SesionUsuario.UsuarioActual;
            if (usuario != null)
                lblBienvenido.Text = $"Bienvenido, {usuario.NombreUsuario}  |  Rol: {usuario.Rol}";

            // El módulo de usuarios solo es accesible para el Administrador
            menuUsuarios.Visible = SesionUsuario.EsAdministrador();
        }

        private void menuInsumos_Click(object sender, EventArgs e)
        {
            new FrmInsumos().ShowDialog();
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            new FrmProveedores().ShowDialog();
        }

        private void menuMovimientos_Click(object sender, EventArgs e)
        {
            new FrmMovimientos().ShowDialog();
        }

        private void menuAreas_Click(object sender, EventArgs e)
        {
            new FrmAreas().ShowDialog();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            new FrmUsuarios().ShowDialog();
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            new FrmReportes().ShowDialog();
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionUsuario.CerrarSesion();
            new FrmLogin().Show();
            this.Close();
        }
    }
}
