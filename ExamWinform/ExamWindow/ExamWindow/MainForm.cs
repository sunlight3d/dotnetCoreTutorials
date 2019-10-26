using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamWindow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.MdiParent = this;
            this.Dock = DockStyle.Fill;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void employeesProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeListForm employeeListForm = new EmployeeListForm();
            employeeListForm.Show();
            employeeListForm.MdiParent = this;
        }
    }
}
