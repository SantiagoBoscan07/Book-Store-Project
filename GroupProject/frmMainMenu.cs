using System.Configuration;
using Microsoft.Data.SqlClient;

namespace GroupProject
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        // Event handler for exit button click, closes the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Event handler for Titles Maintenance button click, opens the Titles Maintenance form.
        private void btnTitlesMaintenance_Click(object sender, EventArgs e)
        {
            frmTitlesMaintenance titlesMaintenanceForm = new frmTitlesMaintenance();
            titlesMaintenanceForm.ShowDialog();
        }

        // Event handler for Authors Maintenance button click, opens the Authors Maintenance form.
        private void btnAuthorsMaintenance_Click(object sender, EventArgs e)
        {
            frmAuthorMaintenance authorMaintenanceForm = new frmAuthorMaintenance();
            authorMaintenanceForm.ShowDialog();
        }

        // Event handler for Publishers Maintenance button click, opens the Publishers Maintenance form.
        private void btnPublishersMaintenance_Click(object sender, EventArgs e)
        {
            frmPublishersMaintenance publishersMaintenanceForm = new frmPublishersMaintenance();
            publishersMaintenanceForm.ShowDialog();
        }

        // Event handler for Stores Maintenance button click, opens the Stores Maintenance form.
        private void btnStoresMaintenance_Click(object sender, EventArgs e)
        {
            frmStoresMaintenance storeMaintenanceForm = new frmStoresMaintenance();
            storeMaintenanceForm.ShowDialog();
        }

        // Event handler for Employees Maintenance button click, opens the Employees Maintenance form.
        private void btnEmployeesMaintenance_Click(object sender, EventArgs e)
        {
            frmEmployeesMaintenance employeesMaintenanceForm = new frmEmployeesMaintenance();
            employeesMaintenanceForm.ShowDialog();
        }

        // Event handler for Reports button click, opens the Reports form.
        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports reportsForm = new frmReports();
            reportsForm.ShowDialog();
        }

        // Event handler for invoice button click, opens the Invoice form.
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            frmInvoice invoiceForm = new frmInvoice();
            invoiceForm.ShowDialog();
        }

        // Event handler for Shopping Cart button click, opens the Shopping Cart form.
        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            frmShoppingCart shoppingCartForm = new frmShoppingCart();
            shoppingCartForm.ShowDialog();
        }
    }
}
