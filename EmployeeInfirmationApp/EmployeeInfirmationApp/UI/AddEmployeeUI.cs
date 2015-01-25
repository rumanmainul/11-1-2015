using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeInfirmationApp.BLL;

namespace EmployeeInfirmationApp.UI
{
    public partial class AddEmployeeUi : Form
    {
        public AddEmployeeUi()
        {
            InitializeComponent();
        }

       
        private void AddEmployeeUI_Load(object sender, EventArgs e)
        {
            DesignationManager aDesignationManager = new DesignationManager();
            designationComboBox.DataSource = aDesignationManager.GetTitle();
            designationComboBox.DisplayMember = "Title";
            designationComboBox.ValueMember = "Code";
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Employee aEmployee = new Employee();  
            DesignationManager aDesignationManager = new DesignationManager();
            aEmployee.EmployeeName = nameTextBox.Text;
            aEmployee.Email = emailTextBox.Text;
            aEmployee.Address = addressTextBox.Text;
            Designation aDesignation = (Designation) designationComboBox.SelectedItem;
            aEmployee.Code = aDesignation.Code;
            string alert = aDesignationManager.AddEmployee(aEmployee);
            MessageBox.Show(alert);
        }

        
    }
}
