namespace Supply_Manager.UI.Forms
{
    partial class FrmProveedores
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point, System.Drawing.Size> btn =
                (b, t, p, s) => { b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Font = font;
                    b.ForeColor = System.Drawing.Color.White; b.Location = p; b.Size = s; b.Text = t; b.UseVisualStyleBackColor = false; };

            // Labels + TextBoxes
            this.lblNombre.AutoSize = true; this.lblNombre.Font = font; this.lblNombre.ForeColor = dark; this.lblNombre.Location = new System.Drawing.Point(38, 75); this.lblNombre.Text = "Nombre *";
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtNombre.Font = font; this.txtNombre.Location = new System.Drawing.Point(38, 95); this.txtNombre.Size = new System.Drawing.Size(300, 25);

            this.lblTelefono.AutoSize = true; this.lblTelefono.Font = font; this.lblTelefono.ForeColor = dark; this.lblTelefono.Location = new System.Drawing.Point(360, 75); this.lblTelefono.Text = "Teléfono";
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtTelefono.Font = font; this.txtTelefono.Location = new System.Drawing.Point(360, 95); this.txtTelefono.Size = new System.Drawing.Size(180, 25);

            this.lblCorreo.AutoSize = true; this.lblCorreo.Font = font; this.lblCorreo.ForeColor = dark; this.lblCorreo.Location = new System.Drawing.Point(38, 138); this.lblCorreo.Text = "Correo electrónico";
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtCorreo.Font = font; this.txtCorreo.Location = new System.Drawing.Point(38, 158); this.txtCorreo.Size = new System.Drawing.Size(280, 25);

            this.lblDireccion.AutoSize = true; this.lblDireccion.Font = font; this.lblDireccion.ForeColor = dark; this.lblDireccion.Location = new System.Drawing.Point(335, 138); this.lblDireccion.Text = "Dirección";
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtDireccion.Font = font; this.txtDireccion.Location = new System.Drawing.Point(335, 158); this.txtDireccion.Size = new System.Drawing.Size(435, 25);

            // Filtro
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtBuscar.Font = font;
            this.txtBuscar.Location = new System.Drawing.Point(38, 207); this.txtBuscar.Size = new System.Drawing.Size(220, 25);

            btn(btnBuscar, "Buscar", new System.Drawing.Point(270, 205), new System.Drawing.Size(100, 28));
            btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            btn(btnMostrarTodos, "Mostrar todos", new System.Drawing.Point(378, 205), new System.Drawing.Size(130, 28));
            btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);

            // Botones CRUD
            btn(btnAgregar, "Agregar", new System.Drawing.Point(38, 250), new System.Drawing.Size(168, 33));
            btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            btn(btnActualizar, "Actualizar", new System.Drawing.Point(218, 250), new System.Drawing.Size(168, 33));
            btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            btn(btnEliminar, "Eliminar", new System.Drawing.Point(398, 250), new System.Drawing.Size(168, 33));
            btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            btn(btnLimpiar, "Limpiar", new System.Drawing.Point(578, 250), new System.Drawing.Size(168, 33));
            btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Grid
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(38, 298); this.dgvProveedores.Size = new System.Drawing.Size(800, 200);
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.MultiSelect = false; this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellClick);

            // Título en panel
            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = dark; this.lblTitulo.Location = new System.Drawing.Point(268, 32); this.lblTitulo.Text = "GESTIÓN DE PROVEEDORES";

            // Panel
            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.dgvProveedores);
            this.panel1.Controls.Add(this.btnMostrarTodos); this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.btnLimpiar); this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnActualizar); this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.txtDireccion); this.panel1.Controls.Add(this.lblDireccion);
            this.panel1.Controls.Add(this.txtCorreo); this.panel1.Controls.Add(this.lblCorreo);
            this.panel1.Controls.Add(this.txtTelefono); this.panel1.Controls.Add(this.lblTelefono);
            this.panel1.Controls.Add(this.txtNombre); this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(870, 520);

            // Header
            this.lblHeader.AutoSize = false; this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 25); this.lblHeader.Size = new System.Drawing.Size(916, 50);
            this.lblHeader.Text = "SISTEMA DE INSUMOS"; this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnCerrar
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(60, 65, 72);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 85, 92);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Size = new System.Drawing.Size(95, 28);
            this.btnCerrar.Location = new System.Drawing.Point(808, 36);
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = dark; this.ClientSize = new System.Drawing.Size(916, 620);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.btnCerrar); this.Controls.Add(this.lblHeader); this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmProveedores"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Proveedores";
            this.Resize += new System.EventHandler(this.FrmProveedores_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblNombre, lblTelefono, lblCorreo, lblDireccion, lblTitulo, lblHeader;
        private System.Windows.Forms.TextBox txtNombre, txtTelefono, txtCorreo, txtDireccion, txtBuscar;
        private System.Windows.Forms.Button btnAgregar, btnActualizar, btnEliminar, btnLimpiar, btnBuscar, btnMostrarTodos, btnCerrar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.Panel panel1;
    }
}
