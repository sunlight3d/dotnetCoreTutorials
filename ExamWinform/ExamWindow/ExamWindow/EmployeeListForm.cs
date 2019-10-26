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
        public EmployeeListForm()
        {
            InitializeComponent();
            
        }

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            DataTable dataTable = Database.Instance.GetDataFromQuery("select * from Departments");
            foreach (DataRow row in dataTable.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row["DeptName"].ToString(),
                    Tag = row["DeptID"].ToString()
                };
                treeViewDepartments.Nodes.Add(child);
            }
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEmployees.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }
        private void reloadEmployeeList(String departmentID) {
            DataTable dataTable = Database.Instance.GetDataFromQuery("select * from Employees where DeptID = '"+departmentID+"'");
            listViewEmployees.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void treeViewDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String selectedDeptID = (String)treeViewDepartments.SelectedNode.Tag;
            reloadEmployeeList(selectedDeptID);
        }

        private void listViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
