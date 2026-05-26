namespace Supply_Manager.UI.Forms
{
    partial class FrmInsumos
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.cbUnidad = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbFiltroUnidad = new System.Windows.Forms.ComboBox();
            this.chkStockCritico = new System.Windows.Forms.CheckBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblFiltroUnidad = new System.Windows.Forms.Label();
            this.dgvInsumos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            // lblNombre
            this.lblNombre.AutoSize = true; this.lblNombre.Font = font; this.lblNombre.ForeColor = dark;
            this.lblNombre.Location = new System.Drawing.Point(38, 80); this.lblNombre.Text = "Nombre";

            // txtNombre
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtNombre.Font = font;
            this.txtNombre.Location = new System.Drawing.Point(41, 100); this.txtNombre.Size = new System.Drawing.Size(225, 25);

            // lblDescripcion
            this.lblDescripcion.AutoSize = true; this.lblDescripcion.Font = font; this.lblDescripcion.ForeColor = dark;
            this.lblDescripcion.Location = new System.Drawing.Point(292, 80); this.lblDescripcion.Text = "Descripción";

            // txtDescripcion
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtDescripcion.Font = font;
            this.txtDescripcion.Location = new System.Drawing.Point(295, 100); this.txtDescripcion.Size = new System.Drawing.Size(491, 25);

            // lblStock
            this.lblStock.AutoSize = true; this.lblStock.Font = font; this.lblStock.ForeColor = dark;
            this.lblStock.Location = new System.Drawing.Point(38, 140); this.lblStock.Text = "Stock actual";

            // txtStock
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtStock.Font = font;
            this.txtStock.Location = new System.Drawing.Point(41, 160); this.txtStock.Size = new System.Drawing.Size(225, 25);

            // lblStockMinimo
            this.lblStockMinimo.AutoSize = true; this.lblStockMinimo.Font = font; this.lblStockMinimo.ForeColor = dark;
            this.lblStockMinimo.Location = new System.Drawing.Point(292, 140); this.lblStockMinimo.Text = "Stock mínimo";

            // txtStockMinimo
            this.txtStockMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtStockMinimo.Font = font;
            this.txtStockMinimo.Location = new System.Drawing.Point(293, 160); this.txtStockMinimo.Size = new System.Drawing.Size(226, 25);

            // lblUnidad
            this.lblUnidad.AutoSize = true; this.lblUnidad.Font = font; this.lblUnidad.ForeColor = dark;
            this.lblUnidad.Location = new System.Drawing.Point(543, 140); this.lblUnidad.Text = "Unidad";

            // cbUnidad
            this.cbUnidad.Font = font; this.cbUnidad.FormattingEnabled = true;
            this.cbUnidad.Items.AddRange(new object[] { "Unidad", "Caja", "Paquete", "Litro", "Kilogramo", "Metro", "Rollo" });
            this.cbUnidad.Location = new System.Drawing.Point(546, 160); this.cbUnidad.Size = new System.Drawing.Size(240, 25);

            // Botones principales
            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point> configBtn = (b, t, p) => {
                b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                b.Font = font; b.ForeColor = System.Drawing.Color.White;
                b.Location = p; b.Size = new System.Drawing.Size(168, 33); b.Text = t;
                b.UseVisualStyleBackColor = false;
            };
            configBtn(btnAgregar, "Agregar", new System.Drawing.Point(40, 205));
            btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            configBtn(btnActualizar, "Actualizar", new System.Drawing.Point(222, 205));
            btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            configBtn(btnEliminar, "Desactivar", new System.Drawing.Point(404, 205));
            btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            configBtn(btnLimpiar, "Limpiar", new System.Drawing.Point(586, 205));
            btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Sección de filtros
            this.lblBuscar.AutoSize = true; this.lblBuscar.Font = font; this.lblBuscar.ForeColor = dark;
            this.lblBuscar.Location = new System.Drawing.Point(38, 255); this.lblBuscar.Text = "Buscar:";

            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtBuscar.Font = font;
            this.txtBuscar.Location = new System.Drawing.Point(95, 252); this.txtBuscar.Size = new System.Drawing.Size(175, 25);

            this.lblFiltroUnidad.AutoSize = true; this.lblFiltroUnidad.Font = font; this.lblFiltroUnidad.ForeColor = dark;
            this.lblFiltroUnidad.Location = new System.Drawing.Point(285, 255); this.lblFiltroUnidad.Text = "Unidad:";

            this.cbFiltroUnidad.Font = font; this.cbFiltroUnidad.FormattingEnabled = true;
            this.cbFiltroUnidad.Items.AddRange(new object[] { "(Todas)", "Unidad", "Caja", "Paquete", "Litro", "Kilogramo", "Metro", "Rollo" });
            this.cbFiltroUnidad.SelectedIndex = 0;
            this.cbFiltroUnidad.Location = new System.Drawing.Point(340, 252); this.cbFiltroUnidad.Size = new System.Drawing.Size(140, 25);

            this.chkStockCritico.AutoSize = true; this.chkStockCritico.Font = font; this.chkStockCritico.ForeColor = dark;
            this.chkStockCritico.Location = new System.Drawing.Point(495, 255); this.chkStockCritico.Text = "Solo stock crítico";

            configBtn(btnBuscar, "Buscar", new System.Drawing.Point(630, 248));
            btnBuscar.Size = new System.Drawing.Size(90, 28);
            btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            configBtn(btnMostrarTodos, "Mostrar todos", new System.Drawing.Point(728, 248));
            btnMostrarTodos.Size = new System.Drawing.Size(110, 28);
            btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);

            // dgvInsumos
            this.dgvInsumos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumos.Location = new System.Drawing.Point(38, 290); this.dgvInsumos.Size = new System.Drawing.Size(800, 220);
            this.dgvInsumos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInsumos.MultiSelect = false; this.dgvInsumos.ReadOnly = true;
            this.dgvInsumos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsumos_CellClick);

            // panel1
            this.panel1.AutoSize = false;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgvInsumos);
            this.panel1.Controls.Add(this.btnMostrarTodos);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.chkStockCritico);
            this.panel1.Controls.Add(this.cbFiltroUnidad);
            this.panel1.Controls.Add(this.lblFiltroUnidad);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.lblBuscar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.cbUnidad);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.txtStockMinimo);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.lblUnidad);
            this.panel1.Controls.Add(this.lblStockMinimo);
            this.panel1.Controls.Add(this.lblStock);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.ForeColor = dark;
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(870, 530);

            // label1 (in panel)
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = dark; this.label1.Location = new System.Drawing.Point(290, 30); this.label1.Text = "GESTIÓN DE INSUMOS";

            // pictureBox1
            this.pictureBox1.Image = global::Supply_Manager.Properties.Resources.box2;
            this.pictureBox1.Location = new System.Drawing.Point(248, 16); this.pictureBox1.Size = new System.Drawing.Size(38, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // label2 (header)
            this.label2.AutoSize = false; this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 25); this.label2.Size = new System.Drawing.Size(916, 50);
            this.label2.Text = "SISTEMA DE INSUMOS"; this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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

            // FrmInsumos
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = dark;
            this.ClientSize = new System.Drawing.Size(916, 640);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmInsumos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Insumos";
            this.Resize += new System.EventHandler(this.FrmInsumos_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblNombre, lblDescripcion, lblStock, lblStockMinimo, lblUnidad;
        private System.Windows.Forms.Label lblBuscar, lblFiltroUnidad, label1, label2;
        private System.Windows.Forms.TextBox txtNombre, txtDescripcion, txtStockMinimo, txtStock, txtBuscar;
        private System.Windows.Forms.ComboBox cbUnidad, cbFiltroUnidad;
        private System.Windows.Forms.CheckBox chkStockCritico;
        private System.Windows.Forms.Button btnAgregar, btnActualizar, btnEliminar, btnLimpiar, btnBuscar, btnMostrarTodos, btnCerrar;
        private System.Windows.Forms.DataGridView dgvInsumos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
