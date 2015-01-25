using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInfirmationApp.BLL;
using EmployeeInfirmationApp.DAL.DAO;

namespace EmployeeInfirmationApp
{
    public partial class SearchByDepartment : Form
    {
        public SearchByDepartment()
        {
            InitializeComponent();
        }
        DesignationManager aDesignationManager = new DesignationManager();
        private void SearchByDepartment_Load(object sender, EventArgs e)
        {

        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            List<ViewEmployeeInformation> aEmployeeInformations = new List<ViewEmployeeInformation>();
            aEmployeeInformations = aDesignationManager.GetAllEmployeeByDepartment();
            foreach (ViewEmployeeInformation viewEmployeeInformation in aEmployeeInformations)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = viewEmployeeInformation.DepartmentName;
                aListViewItem.SubItems.Add(viewEmployeeInformation.NoOfEmployee);
                departmentListView.Items.Add(aListViewItem);
            }
        }
    }
}
