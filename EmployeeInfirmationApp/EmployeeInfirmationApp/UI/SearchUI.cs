using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeInfirmationApp.BLL;
using EmployeeInfirmationApp.DAL.DAO;

namespace EmployeeInfirmationApp.UI
{
    public partial class SearchUI : Form
    {
        public SearchUI()
        {
            InitializeComponent();
        }
        DesignationManager aDesignationManager = new DesignationManager();

        private void SearchButton_Click(object sender, EventArgs e)
        {

            Designation designationCode = (Designation)DepartmentComboBox.SelectedItem;
            string Code = designationCode.Code;
            string name = searchTextBox.Text;
            List<ViewEmployeeInformation> aDataViewList = new List<ViewEmployeeInformation>();
            aDataViewList = aDesignationManager.ShowAllEmployee(name);
            aDataViewList = aDesignationManager.ShowAllEmployee(name, Code);
            numberOfEmployee.Text = aDesignationManager.GetNumberOfEmployee(Code);
            showListView.Items.Clear();
            ListViewItem aListViewItem = new ListViewItem();
            foreach (ViewEmployeeInformation aDataView in aDataViewList)
            {
                aListViewItem = new ListViewItem();
                aListViewItem.Text = aDataView.EmployeeId;
                aListViewItem.SubItems.Add(aDataView.Name);
                aListViewItem.SubItems.Add(aDataView.Email);
                aListViewItem.SubItems.Add(aDataView.Designation);
                showListView.Items.Add(aListViewItem);
            }
            
            
        }

        private void SearchUI_Load(object sender, EventArgs e)
        {
            DepartmentComboBox.DataSource = aDesignationManager.GetTitle();
            DepartmentComboBox.DisplayMember = "Title";
            DepartmentComboBox.ValueMember = "Code";
        }
    }
}
