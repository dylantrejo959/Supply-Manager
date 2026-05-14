using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supply_Manager.Forms
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void menuInsumos_Click(object sender, EventArgs e)
        {
            FrmInsumos frm = new FrmInsumos();

            frm.ShowDialog();
        }
    }
}