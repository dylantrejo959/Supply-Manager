namespace Supply_Manager.UI.Forms
{
    partial class FrmReportes
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStockCritico = new System.Windows.Forms.TabPage();
            this.tabConsumo = new System.Windows.Forms.TabPage();
            this.tabProyeccion = new System.Windows.Forms.TabPage();
            this.dgvStockCritico = new System.Windows.Forms.DataGridView();
            this.dgvConsumo = new System.Windows.Forms.DataGridView();
            this.dgvProyeccion = new System.Windows.Forms.DataGridView();
            this.btnGenerarStockCritico = new System.Windows.Forms.Button();
            this.btnGenerarConsumo = new System.Windows.Forms.Button();
            this.btnGenerarProyeccion = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.cbAreaConsumo = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblDescStock = new System.Windows.Forms.Label();
            this.lblDescProyeccion = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccion)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabStockCritico.SuspendLayout();
            this.tabConsumo.SuspendLayout();
            this.tabProyeccion.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point> btn =
                (b, t, p) => { b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Font = font;
                    b.ForeColor = System.Drawing.Color.White; b.Location = p; b.Size = new System.Drawing.Size(180, 33); b.Text = t; b.UseVisualStyleBackColor = false; };

            System.Action<System.Windows.Forms.DataGridView> configGrid = (g) => {
                g.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                g.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                g.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                g.MultiSelect = false; g.ReadOnly = true;
            };

            // Tab 1 - Stock crítico
            this.lblDescStock.AutoSize = false; this.lblDescStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblDescStock.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDescStock.Location = new System.Drawing.Point(10, 12); this.lblDescStock.Size = new System.Drawing.Size(600, 18);
            this.lblDescStock.Text = "Muestra los insumos cuyo stock actual es igual o inferior al stock mínimo requerido.";

            btn(btnGenerarStockCritico, "Generar reporte", new System.Drawing.Point(10, 38));
            btnGenerarStockCritico.Click += new System.EventHandler(this.btnGenerarStockCritico_Click);

            configGrid(dgvStockCritico);
            this.dgvStockCritico.Location = new System.Drawing.Point(10, 85); this.dgvStockCritico.Size = new System.Drawing.Size(840, 380);

            this.tabStockCritico.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.tabStockCritico.Controls.Add(this.lblDescStock);
            this.tabStockCritico.Controls.Add(this.btnGenerarStockCritico);
            this.tabStockCritico.Controls.Add(this.dgvStockCritico);
            this.tabStockCritico.Location = new System.Drawing.Point(4, 22);
            this.tabStockCritico.Name = "tabStockCritico"; this.tabStockCritico.Size = new System.Drawing.Size(862, 480);
            this.tabStockCritico.Text = "  Stock Crítico  ";

            // Tab 2 - Consumo
            this.lblDesde.AutoSize = true; this.lblDesde.Font = font; this.lblDesde.ForeColor = dark; this.lblDesde.Location = new System.Drawing.Point(10, 15); this.lblDesde.Text = "Desde:";
            this.dtpDesde.Font = font; this.dtpDesde.Location = new System.Drawing.Point(68, 12); this.dtpDesde.Size = new System.Drawing.Size(150, 25); this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Value = System.DateTime.Today.AddMonths(-1);

            this.lblHasta.AutoSize = true; this.lblHasta.Font = font; this.lblHasta.ForeColor = dark; this.lblHasta.Location = new System.Drawing.Point(235, 15); this.lblHasta.Text = "Hasta:";
            this.dtpHasta.Font = font; this.dtpHasta.Location = new System.Drawing.Point(288, 12); this.dtpHasta.Size = new System.Drawing.Size(150, 25); this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblArea.AutoSize = true; this.lblArea.Font = font; this.lblArea.ForeColor = dark; this.lblArea.Location = new System.Drawing.Point(455, 15); this.lblArea.Text = "Área:";
            this.cbAreaConsumo.Font = font; this.cbAreaConsumo.FormattingEnabled = true;
            this.cbAreaConsumo.Location = new System.Drawing.Point(497, 12); this.cbAreaConsumo.Size = new System.Drawing.Size(180, 25);

            btn(btnGenerarConsumo, "Generar reporte", new System.Drawing.Point(10, 50));
            btnGenerarConsumo.Click += new System.EventHandler(this.btnGenerarConsumo_Click);

            configGrid(dgvConsumo);
            this.dgvConsumo.Location = new System.Drawing.Point(10, 97); this.dgvConsumo.Size = new System.Drawing.Size(840, 368);

            this.tabConsumo.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.tabConsumo.Controls.Add(this.cbAreaConsumo); this.tabConsumo.Controls.Add(this.lblArea);
            this.tabConsumo.Controls.Add(this.dtpHasta); this.tabConsumo.Controls.Add(this.lblHasta);
            this.tabConsumo.Controls.Add(this.dtpDesde); this.tabConsumo.Controls.Add(this.lblDesde);
            this.tabConsumo.Controls.Add(this.btnGenerarConsumo);
            this.tabConsumo.Controls.Add(this.dgvConsumo);
            this.tabConsumo.Location = new System.Drawing.Point(4, 22);
            this.tabConsumo.Name = "tabConsumo"; this.tabConsumo.Size = new System.Drawing.Size(862, 480);
            this.tabConsumo.Text = "  Consumo por Período  ";

            // Tab 3 - Proyección
            this.lblDescProyeccion.AutoSize = false; this.lblDescProyeccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblDescProyeccion.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDescProyeccion.Location = new System.Drawing.Point(10, 12); this.lblDescProyeccion.Size = new System.Drawing.Size(840, 18);
            this.lblDescProyeccion.Text = "Función diferencial: calcula días estimados hasta nivel mínimo y cantidad sugerida de reabastecimiento (basado en consumo de los últimos 30 días).";

            btn(btnGenerarProyeccion, "Generar proyección", new System.Drawing.Point(10, 38));
            btnGenerarProyeccion.Click += new System.EventHandler(this.btnGenerarProyeccion_Click);

            configGrid(dgvProyeccion);
            this.dgvProyeccion.Location = new System.Drawing.Point(10, 85); this.dgvProyeccion.Size = new System.Drawing.Size(840, 380);

            this.tabProyeccion.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.tabProyeccion.Controls.Add(this.lblDescProyeccion);
            this.tabProyeccion.Controls.Add(this.btnGenerarProyeccion);
            this.tabProyeccion.Controls.Add(this.dgvProyeccion);
            this.tabProyeccion.Location = new System.Drawing.Point(4, 22);
            this.tabProyeccion.Name = "tabProyeccion"; this.tabProyeccion.Size = new System.Drawing.Size(862, 480);
            this.tabProyeccion.Text = "  Proyección de Reabastecimiento  ";

            // TabControl
            this.tabControl.Controls.Add(this.tabStockCritico);
            this.tabControl.Controls.Add(this.tabConsumo);
            this.tabControl.Controls.Add(this.tabProyeccion);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Location = new System.Drawing.Point(15, 15); this.tabControl.Size = new System.Drawing.Size(870, 506);

            // Panel
            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(900, 540);

            // Header
            this.lblHeader.AutoSize = false; this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 25); this.lblHeader.Size = new System.Drawing.Size(950, 50);
            this.lblHeader.Text = "REPORTES DEL SISTEMA"; this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnCerrar
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(60, 65, 72);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 85, 92);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Size = new System.Drawing.Size(95, 28);
            this.btnCerrar.Location = new System.Drawing.Point(842, 36);
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = dark; this.ClientSize = new System.Drawing.Size(950, 640);
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Controls.Add(this.btnCerrar); this.Controls.Add(this.lblHeader); this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmReportes"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Reportes";
            this.Resize += new System.EventHandler(this.FrmReportes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProyeccion)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabStockCritico.ResumeLayout(false); this.tabStockCritico.PerformLayout();
            this.tabConsumo.ResumeLayout(false); this.tabConsumo.PerformLayout();
            this.tabProyeccion.ResumeLayout(false); this.tabProyeccion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStockCritico, tabConsumo, tabProyeccion;
        private System.Windows.Forms.DataGridView dgvStockCritico, dgvConsumo, dgvProyeccion;
        private System.Windows.Forms.Button btnGenerarStockCritico, btnGenerarConsumo, btnGenerarProyeccion, btnCerrar;
        private System.Windows.Forms.DateTimePicker dtpDesde, dtpHasta;
        private System.Windows.Forms.ComboBox cbAreaConsumo;
        private System.Windows.Forms.Label lblDesde, lblHasta, lblArea, lblDescStock, lblDescProyeccion, lblHeader;
        private System.Windows.Forms.Panel panel1;
    }
}
