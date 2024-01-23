//Navid-Derakhshandeh
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attend
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void iMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMS frm = new IMS();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void manageRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoom frm = new ManageRoom();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReserv frm = new ManageReserv();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MAC frm = new MAC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void financialIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fininc frm = new Fininc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void financialIncomeGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinincGraph frm = new FinincGraph();
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
