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
    }
}
