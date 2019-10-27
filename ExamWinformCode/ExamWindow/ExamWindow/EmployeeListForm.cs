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
    public partial class EmployeeListForm : Form
    {
        private int employeeID = -1;
        public String departmentID { get; set; }
        public EmployeeListForm()
        {
            InitializeComponent();
            
        }
        public void ReloadTreeViewDepartments() {
            treeViewDepartments.Nodes.Clear();
            foreach (DataRow row in Database.Instance.GetAllDepartments().Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["DeptName"].ToString(),
                    Tag = row["DeptID"].ToString()
                };
                treeViewDepartments.Nodes.Add(child);
                ReloadEmployeeList(row["DeptID"].ToString());
            }
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ReloadTreeViewDepartments();
        }
        public void ReloadEmployeeList(String deptID) {
            
            listViewEmployees.Items.Clear();
            foreach (DataRow row in Database.Instance.GetEmployeesFromDeptID(deptID).Rows)
            {
                ListViewItem listViewItem = new ListViewItem(row["EmployeeID"].ToString());
                listViewItem.SubItems.Add(row["EmployeeName"].ToString());
                listViewItem.SubItems.Add(row["DeptID"].ToString());
                listViewItem.SubItems.Add(row["Gender"].ToString());
                listViewItem.SubItems.Add(row["BirthDate"].ToString());
                listViewItem.SubItems.Add(row["Tel"].ToString());
                listViewItem.SubItems.Add(row["Address"].ToString());
                listViewEmployees.Items.Add(listViewItem);                
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.employeeID < 0) {
                MessageBox.Show("You must select an employee to delete",
                                "Warning",
                                MessageBoxButtons.OK);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this ?",
                                "Important Question",
                                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes && this.employeeID > 0) {
                Database.Instance.DeleteEmployee(this.employeeID);
                this.ReloadEmployeeList(departmentID);
            }
        }

        private void treeViewDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            departmentID = (String)treeViewDepartments.SelectedNode.Tag;
            ReloadEmployeeList(departmentID);
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listViewEmployees.SelectedItems.Count > 0) {
                this.employeeID = Int32.Parse(listViewEmployees.SelectedItems[0].Text);                
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            EmployeeDetailForm employeeDetailForm = new EmployeeDetailForm();
            employeeDetailForm.MdiParent = this.MdiParent;
            employeeDetailForm.Dock = DockStyle.Fill;
            employeeDetailForm.employeeListForm = this;
            employeeDetailForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
