namespace Supply_Manager.UI.Forms
{
    partial class FrmAreas
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
            this.lblNombreArea = new System.Windows.Forms.Label();
            this.txtNombreArea = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvAreas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            var dark = System.Drawing.Color.FromArgb(35, 40, 46);
            var font = new System.Drawing.Font("Segoe UI", 9.75F);

            System.Action<System.Windows.Forms.Button, string, System.Drawing.Point> btn =
                (b, t, p) => { b.BackColor = dark; b.FlatStyle = System.Windows.Forms.FlatStyle.Flat; b.Font = font;
                    b.ForeColor = System.Drawing.Color.White; b.Location = p; b.Size = new System.Drawing.Size(140, 33); b.Text = t; b.UseVisualStyleBackColor = false; };

            this.lblTitulo.AutoSize = true; this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = dark; this.lblTitulo.Location = new System.Drawing.Point(170, 30); this.lblTitulo.Text = "GESTIÓN DE ÁREAS";

            this.lblNombreArea.AutoSize = true; this.lblNombreArea.Font = font; this.lblNombreArea.ForeColor = dark;
            this.lblNombreArea.Location = new System.Drawing.Point(38, 78); this.lblNombreArea.Text = "Nombre del área *";

            this.txtNombreArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; this.txtNombreArea.Font = font;
            this.txtNombreArea.Location = new System.Drawing.Point(38, 98); this.txtNombreArea.Size = new System.Drawing.Size(350, 25);

            this.lblInfo.AutoSize = true; this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblInfo.Location = new System.Drawing.Point(38, 130); this.lblInfo.Text = "* Solo el Administrador puede agregar, modificar o eliminar áreas.";

            btn(btnAgregar, "Agregar", new System.Drawing.Point(38, 155));
            btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            btn(btnActualizar, "Actualizar", new System.Drawing.Point(188, 155));
            btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            btn(btnEliminar, "Eliminar", new System.Drawing.Point(338, 155));
            btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            btn(btnLimpiar, "Limpiar", new System.Drawing.Point(488, 155));
            btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.dgvAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAreas.Location = new System.Drawing.Point(38, 205); this.dgvAreas.Size = new System.Drawing.Size(580, 260);
            this.dgvAreas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAreas.MultiSelect = false; this.dgvAreas.ReadOnly = true;
            this.dgvAreas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAreas_CellClick);

            this.panel1.BackColor = System.Drawing.Color.FromArgb(237, 237, 238);
            this.panel1.Controls.Add(this.lblTitulo); this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.dgvAreas);
            this.panel1.Controls.Add(this.btnLimpiar); this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnActualizar); this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.txtNombreArea); this.panel1.Controls.Add(this.lblNombreArea);
            this.panel1.Location = new System.Drawing.Point(20, 80); this.panel1.Size = new System.Drawing.Size(660, 490);

            this.lblHeader.AutoSize = false; this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 25); this.lblHeader.Size = new System.Drawing.Size(700, 50);
            this.lblHeader.Text = "SISTEMA DE INSUMOS"; this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(60, 65, 72);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(80, 85, 92);
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Size = new System.Drawing.Size(95, 28);
            this.btnCerrar.Location = new System.Drawing.Point(592, 36);
            this.btnCerrar.Text = "✕  Cerrar";
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = dark; this.ClientSize = new System.Drawing.Size(700, 590);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Controls.Add(this.btnCerrar); this.Controls.Add(this.lblHeader); this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FrmAreas"; this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supply Manager — Áreas";
            this.Resize += new System.EventHandler(this.FrmAreas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAreas)).EndInit();
            this.panel1.ResumeLayout(false); this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblNombreArea, lblTitulo, lblHeader, lblInfo;
        private System.Windows.Forms.TextBox txtNombreArea;
        private System.Windows.Forms.Button btnAgregar, btnActualizar, btnEliminar, btnLimpiar, btnCerrar;
        private System.Windows.Forms.DataGridView dgvAreas;
        private System.Windows.Forms.Panel panel1;
    }
}
