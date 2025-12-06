namespace GroupProject
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            cboStores = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dtStartDate = new DateTimePicker();
            label3 = new Label();
            dtEndDate = new DateTimePicker();
            btnGenerate = new Button();
            dgvReport = new DataGridView();
            label4 = new Label();
            txtTotalSales = new TextBox();
            btnClose = new Button();
            lblFirstEntry = new Label();
            lblLastEntry = new Label();
            txtFirstEntry = new MaskedTextBox();
            txtLastEntry = new MaskedTextBox();
            OrderID = new DataGridViewTextBoxColumn();
            TitleID = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // cboStores
            // 
            cboStores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStores.Font = new Font("Segoe UI", 10F);
            cboStores.FormattingEnabled = true;
            cboStores.Location = new Point(120, 20);
            cboStores.Name = "cboStores";
            cboStores.Size = new Size(240, 25);
            cboStores.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 1;
            label1.Text = "Store:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 2;
            label2.Text = "Start Date:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtStartDate
            // 
            dtStartDate.Font = new Font("Segoe UI", 10F);
            dtStartDate.Location = new Point(120, 60);
            dtStartDate.Name = "dtStartDate";
            dtStartDate.Size = new Size(240, 25);
            dtStartDate.TabIndex = 3;
            dtStartDate.Value = new DateTime(2025, 12, 6, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 100);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 4;
            label3.Text = "End Date:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtEndDate
            // 
            dtEndDate.Font = new Font("Segoe UI", 10F);
            dtEndDate.Location = new Point(120, 100);
            dtEndDate.Name = "dtEndDate";
            dtEndDate.Size = new Size(240, 25);
            dtEndDate.TabIndex = 5;
            dtEndDate.Value = new DateTime(2025, 12, 6, 0, 0, 0, 0);
            // 
            // btnGenerate
            // 
            btnGenerate.Font = new Font("Segoe UI", 10F);
            btnGenerate.Location = new Point(120, 140);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(240, 35);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate Report";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Columns.AddRange(new DataGridViewColumn[] { OrderID, TitleID, colTitle, colQty, colPrice, colSubtotal, colDate });
            dgvReport.Location = new Point(20, 200);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.Size = new Size(640, 280);
            dgvReport.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(20, 500);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 8;
            label4.Text = "Total Sales:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTotalSales
            // 
            txtTotalSales.Font = new Font("Segoe UI", 10F);
            txtTotalSales.Location = new Point(120, 500);
            txtTotalSales.Name = "txtTotalSales";
            txtTotalSales.ReadOnly = true;
            txtTotalSales.Size = new Size(150, 25);
            txtTotalSales.TabIndex = 9;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(510, 495);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 35);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblFirstEntry
            // 
            lblFirstEntry.Font = new Font("Segoe UI", 10F);
            lblFirstEntry.Location = new Point(366, 60);
            lblFirstEntry.Name = "lblFirstEntry";
            lblFirstEntry.Size = new Size(151, 25);
            lblFirstEntry.TabIndex = 11;
            lblFirstEntry.Text = "First Entry From Store:";
            lblFirstEntry.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLastEntry
            // 
            lblLastEntry.Font = new Font("Segoe UI", 10F);
            lblLastEntry.Location = new Point(366, 100);
            lblLastEntry.Name = "lblLastEntry";
            lblLastEntry.Size = new Size(151, 25);
            lblLastEntry.TabIndex = 12;
            lblLastEntry.Text = "Last Entry From Store:";
            lblLastEntry.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFirstEntry
            // 
            txtFirstEntry.Location = new Point(510, 63);
            txtFirstEntry.Name = "txtFirstEntry";
            txtFirstEntry.ReadOnly = true;
            txtFirstEntry.Size = new Size(158, 23);
            txtFirstEntry.TabIndex = 13;
            // 
            // txtLastEntry
            // 
            txtLastEntry.Location = new Point(510, 103);
            txtLastEntry.Name = "txtLastEntry";
            txtLastEntry.ReadOnly = true;
            txtLastEntry.Size = new Size(158, 23);
            txtLastEntry.TabIndex = 14;
            // 
            // OrderID
            // 
            OrderID.HeaderText = "Order ID";
            OrderID.Name = "OrderID";
            OrderID.ReadOnly = true;
            // 
            // TitleID
            // 
            TitleID.HeaderText = "Title ID";
            TitleID.Name = "TitleID";
            TitleID.ReadOnly = true;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            colTitle.Width = 180;
            // 
            // colQty
            // 
            colQty.HeaderText = "Qty";
            colQty.Name = "colQty";
            colQty.ReadOnly = true;
            colQty.Width = 60;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colSubtotal
            // 
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // frmReports
            // 
            ClientSize = new Size(680, 550);
            Controls.Add(txtLastEntry);
            Controls.Add(txtFirstEntry);
            Controls.Add(lblLastEntry);
            Controls.Add(lblFirstEntry);
            Controls.Add(btnClose);
            Controls.Add(txtTotalSales);
            Controls.Add(label4);
            Controls.Add(dgvReport);
            Controls.Add(btnGenerate);
            Controls.Add(dtEndDate);
            Controls.Add(label3);
            Controls.Add(dtStartDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboStores);
            Name = "frmReports";
            Text = "Reports";
            Load += frmReports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalSales;
        private System.Windows.Forms.Button btnClose;
        private Label lblFirstEntry;
        private Label lblLastEntry;
        private MaskedTextBox txtFirstEntry;
        private MaskedTextBox txtLastEntry;
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn TitleID;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colSubtotal;
        private DataGridViewTextBoxColumn colDate;
    }
}
