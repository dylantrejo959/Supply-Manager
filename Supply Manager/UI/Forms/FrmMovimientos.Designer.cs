namespace Supply_Manager.UI.Forms
{
    partial class FrmMovimientos
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
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.cmbInsumo = new System.Windows.Forms.ComboBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbFiltroInsumo = new System.Windows.Forms.ComboBox();
            this.cbFiltroArea = new System.Windows.Forms.ComboBox();
            this.cbFiltroTipo = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.chkFiltrarFecha = new System.Windows.Forms.CheckBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnTodosMovimientos = new System.Windows.Forms.Button();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblInsumo = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point, System.Drawing.Size> btn =
                (b, t, p, s) => { b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Font = font;
                    b.ForeColor = System.Drawing.Color.White; b.Location = p; b.Size = s; b.Text = t; b.UseVisualStyleBackColor = false; };

            // Sección de registro
            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = dark; this.lblTitulo.Location = new System.Drawing.Point(260, 30); this.lblTitulo.Text = "REGISTRO DE MOVIMIENTOS";

            this.lblTipo.AutoSize = true; this.lblTipo.Font = font; this.lblTipo.ForeColor = dark; this.lblTipo.Location = new System.Drawing.Point(38, 72); this.lblTipo.Text = "Tipo *";
            this.cbTipo.Font = font; this.cbTipo.FormattingEnabled = true; this.cbTipo.Items.AddRange(new object[] { "Entrada", "Salida" });
            this.cbTipo.SelectedIndex = 0; this.cbTipo.Location = new System.Drawing.Point(38, 92); this.cbTipo.Size = new System.Drawing.Size(130, 25);

            this.lblInsumo.AutoSize = true; this.lblInsumo.Font = font; this.lblInsumo.ForeColor = dark; this.lblInsumo.Location = new System.Drawing.Point(185, 72); this.lblInsumo.Text = "Insumo *";
            this.cmbInsumo.Font = font; this.cmbInsumo.FormattingEnabled = true; this.cmbInsumo.Location = new System.Drawing.Point(185, 92); this.cmbInsumo.Size = new System.Drawing.Size(280, 25);

            this.lblArea.AutoSize = true; this.lblArea.Font = font; this.lblArea.ForeColor = dark; this.lblArea.Location = new System.Drawing.Point(480, 72); this.lblArea.Text = "Área *";
            this.cmbArea.Font = font; this.cmbArea.FormattingEnabled = true; this.cmbArea.Location = new System.Drawing.Point(480, 92); this.cmbArea.Size = new System.Drawing.Size(240, 25);

            this.lblCantidad.AutoSize = true; this.lblCantidad.Font = font; this.lblCantidad.ForeColor = dark; this.lblCantidad.Location = new System.Drawing.Point(38, 132); this.lblCantidad.Text = "Cantidad *";
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtCantidad.Font = font;
            this.txtCantidad.Location = new System.Drawing.Point(38, 152); this.txtCantidad.Size = new System.Drawing.Size(130, 25);

            this.lblObservacion.AutoSize = true; this.lblObservacion.Font = font; this.lblObservacion.ForeColor = dark; this.lblObservacion.Location = new System.Drawing.Point(185, 132); this.lblObservacion.Text = "Observación";
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtObservacion.Font = font;
            this.txtObservacion.Location = new System.Drawing.Point(185, 152); this.txtObservacion.Size = new System.Drawing.Size(535, 25);

            btn(btnRegistrar, "Registrar movimiento", new System.Drawing.Point(38, 195), new System.Drawing.Size(200, 33));
            btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            btn(btnLimpiar, "Limpiar", new System.Drawing.Point(250, 195), new System.Drawing.Size(100, 33));
            btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // Separador
            this.lblSeparador.AutoSize = false; this.lblSeparador.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblSeparador.Location = new System.Drawing.Point(38, 242); this.lblSeparador.Size = new System.Drawing.Size(800, 1);

            // Sección de filtros
            this.cbFiltroInsumo.Font = font; this.cbFiltroInsumo.FormattingEnabled = true;
            this.cbFiltroInsumo.Location = new System.Drawing.Point(38, 258); this.cbFiltroInsumo.Size = new System.Drawing.Size(220, 25);

            this.cbFiltroArea.Font = font; this.cbFiltroArea.FormattingEnabled = true;
            this.cbFiltroArea.Location = new System.Drawing.Point(272, 258); this.cbFiltroArea.Size = new System.Drawing.Size(200, 25);

            this.cbFiltroTipo.Font = font; this.cbFiltroTipo.FormattingEnabled = true;
            this.cbFiltroTipo.Items.AddRange(new object[] { "(Todos)", "Entrada", "Salida" }); this.cbFiltroTipo.SelectedIndex = 0;
            this.cbFiltroTipo.Location = new System.Drawing.Point(486, 258); this.cbFiltroTipo.Size = new System.Drawing.Size(130, 25);

            this.chkFiltrarFecha.AutoSize = true; this.chkFiltrarFecha.Font = font; this.chkFiltrarFecha.ForeColor = dark;
            this.chkFiltrarFecha.Location = new System.Drawing.Point(38, 298); this.chkFiltrarFecha.Text = "Filtrar por fecha";

            this.dtpDesde.Font = font; this.dtpDesde.Location = new System.Drawing.Point(170, 295); this.dtpDesde.Size = new System.Drawing.Size(160, 25); this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Font = font; this.dtpHasta.Location = new System.Drawing.Point(345, 295); this.dtpHasta.Size = new System.Drawing.Size(160, 25); this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            btn(btnFiltrar, "Filtrar", new System.Drawing.Point(520, 293), new System.Drawing.Size(90, 28));
            btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            btn(btnTodosMovimientos, "Mostrar todos", new System.Drawing.Point(620, 293), new System.Drawing.Size(130, 28));
            btnTodosMovimientos.Click += new System.EventHandler(this.btnTodosMovimientos_Click);

            // Grid
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(38, 335); this.dgvMovimientos.Size = new System.Drawing.Size(800, 250);
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.MultiSelect = false; this.dgvMovimientos.ReadOnly = true;

            // Panel
            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.lblTitulo); this.panel1.Controls.Add(this.lblSeparador);
            this.panel1.Controls.Add(this.dgvMovimientos);
            this.panel1.Controls.Add(this.btnTodosMovimientos); this.panel1.Controls.Add(this.btnFiltrar);
            this.panel1.Controls.Add(this.dtpHasta); this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.chkFiltrarFecha);
            this.panel1.Controls.Add(this.cbFiltroTipo); this.panel1.Controls.Add(this.cbFiltroArea);
            this.panel1.Controls.Add(this.cbFiltroInsumo);
            this.panel1.Controls.Add(this.btnLimpiar); this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.txtObservacion); this.panel1.Controls.Add(this.lblObservacion);
            this.panel1.Controls.Add(this.txtCantidad); this.panel1.Controls.Add(this.lblCantidad);
            this.panel1.Controls.Add(this.cmbArea); this.panel1.Controls.Add(this.lblArea);
            this.panel1.Controls.Add(this.cmbInsumo); this.panel1.Controls.Add(this.lblInsumo);
            this.panel1.Controls.Add(this.cbTipo); this.panel1.Controls.Add(this.lblTipo);
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(870, 605);

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
            this.BackColor = dark; this.ClientSize = new System.Drawing.Size(916, 715);
            this.MinimumSize = new System.Drawing.Size(750, 560);
            this.Controls.Add(this.btnCerrar); this.Controls.Add(this.lblHeader); this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmMovimientos"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Movimientos";
            this.Resize += new System.EventHandler(this.FrmMovimientos_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipo, cmbInsumo, cmbArea, cbFiltroInsumo, cbFiltroArea, cbFiltroTipo;
        private System.Windows.Forms.TextBox txtCantidad, txtObservacion;
        private System.Windows.Forms.Button btnRegistrar, btnLimpiar, btnFiltrar, btnTodosMovimientos, btnCerrar;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.CheckBox chkFiltrarFecha;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader, lblTitulo, lblTipo, lblInsumo, lblArea, lblCantidad, lblObservacion, lblSeparador;
    }
}
