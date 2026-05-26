namespace Supply_Manager.UI.Forms
{
    partial class FrmMenuPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuInsumos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAreas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();

            // menuPrincipal
            this.menuPrincipal.BackColor = System.Drawing.SystemColors.Window;
            this.menuPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuInsumos, this.menuProveedores, this.menuMovimientos,
                this.menuAreas, this.menuUsuarios, this.menuReportes, this.menuCerrarSesion });
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(916, 27);

            // Items
            this.menuInsumos.Text = "Insumos";
            this.menuInsumos.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuInsumos.Click += new System.EventHandler(this.menuInsumos_Click);

            this.menuProveedores.Text = "Proveedores";
            this.menuProveedores.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuProveedores.Click += new System.EventHandler(this.menuProveedores_Click);

            this.menuMovimientos.Text = "Movimientos";
            this.menuMovimientos.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuMovimientos.Click += new System.EventHandler(this.menuMovimientos_Click);

            this.menuAreas.Text = "Áreas";
            this.menuAreas.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuAreas.Click += new System.EventHandler(this.menuAreas_Click);

            this.menuUsuarios.Text = "Usuarios";
            this.menuUsuarios.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);

            this.menuReportes.Text = "Reportes";
            this.menuReportes.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuReportes.Click += new System.EventHandler(this.menuReportes_Click);

            this.menuCerrarSesion.Text = "Cerrar sesión";
            this.menuCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.menuCerrarSesion.Click += new System.EventHandler(this.menuCerrarSesion_Click);

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(916, 60);
            this.lblTitulo.Text = "SISTEMA DE CONTROL DE INSUMOS";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblBienvenido
            this.lblBienvenido.AutoSize = false;
            this.lblBienvenido.BackColor = System.Drawing.Color.Transparent;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblBienvenido.Location = new System.Drawing.Point(0, 87);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(916, 30);
            this.lblBienvenido.Text = "";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // FrmMenuPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(35, 40, 46);
            this.ClientSize = new System.Drawing.Size(916, 609);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuInsumos;
        private System.Windows.Forms.ToolStripMenuItem menuProveedores;
        private System.Windows.Forms.ToolStripMenuItem menuMovimientos;
        private System.Windows.Forms.ToolStripMenuItem menuAreas;
        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuReportes;
        private System.Windows.Forms.ToolStripMenuItem menuCerrarSesion;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblTitulo;
    }
}
