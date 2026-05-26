using Supply_Manager.Entities;
using Supply_Manager.BLL.Services;
using Supply_Manager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply_Manager.UI.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe completar todos los campos");

                return;
            }

            Usuario usuario = _authService.Login(
                txtUsuario.Text,
                txtClave.Text
            );

            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");

                return;
            }

            SesionUsuario.IniciarSesion(usuario);

            FrmMenuPrincipal menu =
                new FrmMenuPrincipal();

            menu.Show();

            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
            flowLayoutPanel1.Width = this.ClientSize.Width;
        }
    }
}
