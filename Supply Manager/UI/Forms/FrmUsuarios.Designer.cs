namespace Supply_Manager.UI.Forms
{
    partial class FrmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point> btn =
                (b, t, p) => { b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Font = font;
                    b.ForeColor = System.Drawing.Color.White; b.Location = p; b.Size = new System.Drawing.Size(155, 33); b.Text = t; b.UseVisualStyleBackColor = false; };

            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = dark; this.lblTitulo.Location = new System.Drawing.Point(190, 30); this.lblTitulo.Text = "GESTIÓN DE USUARIOS";

            this.lblAviso.AutoSize = false; this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(180, 100, 0);
            this.lblAviso.Location = new System.Drawing.Point(38, 72); this.lblAviso.Size = new System.Drawing.Size(700, 22);
            this.lblAviso.Text = "⚠  Solo el Administrador puede gestionar usuarios del sistema.";

            this.lblUsuario.AutoSize = true; this.lblUsuario.Font = font; this.lblUsuario.ForeColor = dark; this.lblUsuario.Location = new System.Drawing.Point(38, 105); this.lblUsuario.Text = "Nombre de usuario *";
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtUsuario.Font = font;
            this.txtUsuario.Location = new System.Drawing.Point(38, 125); this.txtUsuario.Size = new System.Drawing.Size(220, 25);

            this.lblClave.AutoSize = true; this.lblClave.Font = font; this.lblClave.ForeColor = dark; this.lblClave.Location = new System.Drawing.Point(278, 105); this.lblClave.Text = "Contraseña *";
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtClave.Font = font;
            this.txtClave.PasswordChar = '●';
            this.txtClave.Location = new System.Drawing.Point(278, 125); this.txtClave.Size = new System.Drawing.Size(180, 25);

            this.lblRol.AutoSize = true; this.lblRol.Font = font; this.lblRol.ForeColor = dark; this.lblRol.Location = new System.Drawing.Point(480, 105); this.lblRol.Text = "Rol *";
            this.cbRol.Font = font; this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(480, 125); this.cbRol.Size = new System.Drawing.Size(200, 25);

            btn(btnAgregar, "Crear usuario", new System.Drawing.Point(38, 175));
            btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            btn(btnActualizar, "Actualizar", new System.Drawing.Point(203, 175));
            btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            btn(btnDesactivar, "Desactivar", new System.Drawing.Point(368, 175));
            btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            btn(btnLimpiar, "Limpiar", new System.Drawing.Point(533, 175));
            btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(38, 225); this.dgvUsuarios.Size = new System.Drawing.Size(680, 250);
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect = false; this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);

            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.lblTitulo); this.panel1.Controls.Add(this.lblAviso);
            this.panel1.Controls.Add(this.dgvUsuarios);
            this.panel1.Controls.Add(this.btnLimpiar); this.panel1.Controls.Add(this.btnDesactivar);
            this.panel1.Controls.Add(this.btnActualizar); this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.cbRol); this.panel1.Controls.Add(this.lblRol);
            this.panel1.Controls.Add(this.txtClave); this.panel1.Controls.Add(this.lblClave);
            this.panel1.Controls.Add(this.txtUsuario); this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(755, 500);

            this.lblHeader.AutoSize = false; this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 25); this.lblHeader.Size = new System.Drawing.Size(800, 50);
            this.lblHeader.Text = "SISTEMA DE INSUMOS"; this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(60, 65, 72);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 85, 92);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Size = new System.Drawing.Size(95, 28);
            this.btnCerrar.Location = new System.Drawing.Point(692, 36);
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = dark; this.ClientSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.btnCerrar); this.Controls.Add(this.lblHeader); this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmUsuarios"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Usuarios";
            this.Resize += new System.EventHandler(this.FrmUsuarios_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblUsuario, lblClave, lblRol, lblTitulo, lblHeader, lblAviso;
        private System.Windows.Forms.TextBox txtUsuario, txtClave;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Button btnAgregar, btnActualizar, btnDesactivar, btnLimpiar, btnCerrar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel panel1;
    }
}
