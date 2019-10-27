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
    public partial class EmployeeDetailForm : Form
    {
        public EmployeeListForm employeeListForm;
        private Employee employee = new Employee();
        public EmployeeDetailForm()
        {
            InitializeComponent();
            foreach (DataRow row in Database.Instance.GetAllDepartments().Rows)
            {
                comboDepartment.Items.Add(row["DeptName"].ToString());//row["DeptName"].ToString()
            }
        }
           
        private void comboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void EmployeeDetailForm_Load(object sender, EventArgs e)
        {
            comboDepartment.Items.Clear();
            foreach (DataRow row in Database.Instance.GetAllDepartments().Rows)
            {
                comboDepartment.Items.Add(row["DeptName"]);//row["DeptName"].ToString()
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            employee.employeeName = textBoxName.Text.Trim();

            String deptName = comboDepartment.SelectedItem.ToString();
            String deptID = Database.Instance.GetDeptIDFromName(deptName);
            employee.deptID = deptID;

            if(radioMale.Checked == true) {
                employee.gender = 1;
            } else if(radioFemale.Checked == true) {
                employee.gender = 0;
            }
            employee.birthDate = dateTimeBirthDate.Value;
            employee.tel = textBoxTel.Text;
            employee.address = textBoxAddress.Text;
            String insertResult = Database.Instance.InsertEmployee(employee);
            if(insertResult.Length > 0)
            {
                MessageBox.Show("Error"+insertResult,
                                "Error",
                                MessageBoxButtons.OK);
                return;
            }
            employeeListForm.ReloadTreeViewDepartments();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
