using System;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            // Fill combo box with placeholder store options
            cboStores.DropDownStyle = ComboBoxStyle.DropDownList;

            cboStores.Items.Add("Store 1");
            cboStores.Items.Add("Store 2");
            cboStores.Items.Add("Store 3");

            cboStores.SelectedIndex = 0;

            // Set default dates
            dtStartDate.Value = DateTime.Today.AddDays(-7);
            dtEndDate.Value = DateTime.Today;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Validate the date range
            if (dtStartDate.Value.Date > dtEndDate.Value.Date)
            {
                MessageBox.Show("Start date must be BEFORE end date.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // PHASE 2: DataGridView with sample/dummy rows
            dgvReport.Rows.Clear();

            dgvReport.Rows.Add("Example Book A", 3, "$19.99", "$59.97", DateTime.Today.ToShortDateString());
            dgvReport.Rows.Add("Example Book B", 1, "$14.50", "$14.50", DateTime.Today.ToShortDateString());
            dgvReport.Rows.Add("Example Book C", 2, "$9.99", "$19.98", DateTime.Today.ToShortDateString());

            // Update total sales textbox (dummy total for now)
            txtTotalSales.Text = "$94.45";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}