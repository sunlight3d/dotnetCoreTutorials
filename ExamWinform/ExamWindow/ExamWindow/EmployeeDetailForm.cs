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
        public EmployeeDetailForm()
        {
            InitializeComponent();
            DataTable dataTable = Database.Instance.GetDataFromQuery("select * from Departments");
            foreach (DataRow row in dataTable.Rows)
            {
                comboDepartment.Items.Add(row);//row["DeptName"].ToString()
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void comboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void EmployeeDetailForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = Database.Instance.GetDataFromQuery("select * from Departments");
            comboDepartment.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                comboDepartment.Items.Add(row);//row["DeptName"].ToString()
            }
        }
    }
}
