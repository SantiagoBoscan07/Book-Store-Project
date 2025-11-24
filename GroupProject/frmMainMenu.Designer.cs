namespace GroupProject
{
    partial class frmMainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTitlesMaintenance = new Button();
            lblMaintenance = new Label();
            btnAuthorsMaintenance = new Button();
            btnPublishersMaintenance = new Button();
            btnStoresMaintenance = new Button();
            btnEmployeesMaintenance = new Button();
            btnShoppingCart = new Button();
            btnReports = new Button();
            lblOrderEntry = new Label();
            lblReport = new Label();
            btnExit = new Button();
            lblInvoice = new Label();
            btnInvoice = new Button();
            pnlInformation = new Panel();
            lblInfo = new Label();
            pnlInformation.SuspendLayout();
            SuspendLayout();
            // 
            // btnTitlesMaintenance
            // 
            btnTitlesMaintenance.Location = new Point(27, 60);
            btnTitlesMaintenance.Name = "btnTitlesMaintenance";
            btnTitlesMaintenance.Size = new Size(180, 32);
            btnTitlesMaintenance.TabIndex = 1;
            btnTitlesMaintenance.Text = "Titles";
            btnTitlesMaintenance.UseVisualStyleBackColor = true;
            btnTitlesMaintenance.Click += btnTitlesMaintenance_Click;
            // 
            // lblMaintenance
            // 
            lblMaintenance.AutoSize = true;
            lblMaintenance.Location = new Point(27, 41);
            lblMaintenance.Name = "lblMaintenance";
            lblMaintenance.Size = new Size(76, 15);
            lblMaintenance.TabIndex = 2;
            lblMaintenance.Text = "Maintenance";
            // 
            // btnAuthorsMaintenance
            // 
            btnAuthorsMaintenance.Location = new Point(27, 98);
            btnAuthorsMaintenance.Name = "btnAuthorsMaintenance";
            btnAuthorsMaintenance.Size = new Size(180, 32);
            btnAuthorsMaintenance.TabIndex = 3;
            btnAuthorsMaintenance.Text = "Authors";
            btnAuthorsMaintenance.UseVisualStyleBackColor = true;
            btnAuthorsMaintenance.Click += btnAuthorsMaintenance_Click;
            // 
            // btnPublishersMaintenance
            // 
            btnPublishersMaintenance.Location = new Point(27, 136);
            btnPublishersMaintenance.Name = "btnPublishersMaintenance";
            btnPublishersMaintenance.Size = new Size(180, 32);
            btnPublishersMaintenance.TabIndex = 4;
            btnPublishersMaintenance.Text = "Publishers";
            btnPublishersMaintenance.UseVisualStyleBackColor = true;
            btnPublishersMaintenance.Click += btnPublishersMaintenance_Click;
            // 
            // btnStoresMaintenance
            // 
            btnStoresMaintenance.Location = new Point(27, 174);
            btnStoresMaintenance.Name = "btnStoresMaintenance";
            btnStoresMaintenance.Size = new Size(180, 32);
            btnStoresMaintenance.TabIndex = 5;
            btnStoresMaintenance.Text = "Stores";
            btnStoresMaintenance.UseVisualStyleBackColor = true;
            btnStoresMaintenance.Click += btnStoresMaintenance_Click;
            // 
            // btnEmployeesMaintenance
            // 
            btnEmployeesMaintenance.Location = new Point(27, 212);
            btnEmployeesMaintenance.Name = "btnEmployeesMaintenance";
            btnEmployeesMaintenance.Size = new Size(180, 32);
            btnEmployeesMaintenance.TabIndex = 6;
            btnEmployeesMaintenance.Text = "Employees";
            btnEmployeesMaintenance.UseVisualStyleBackColor = true;
            btnEmployeesMaintenance.Click += btnEmployeesMaintenance_Click;
            // 
            // btnShoppingCart
            // 
            btnShoppingCart.Location = new Point(226, 60);
            btnShoppingCart.Name = "btnShoppingCart";
            btnShoppingCart.Size = new Size(180, 48);
            btnShoppingCart.TabIndex = 7;
            btnShoppingCart.Text = "Shopping Cart";
            btnShoppingCart.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(226, 136);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(180, 48);
            btnReports.TabIndex = 8;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // lblOrderEntry
            // 
            lblOrderEntry.AutoSize = true;
            lblOrderEntry.Location = new Point(226, 41);
            lblOrderEntry.Name = "lblOrderEntry";
            lblOrderEntry.Size = new Size(67, 15);
            lblOrderEntry.TabIndex = 9;
            lblOrderEntry.Text = "Order Entry";
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Location = new Point(226, 115);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(47, 15);
            lblReport.TabIndex = 10;
            lblReport.Text = "Reports";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(27, 281);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(379, 32);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Location = new Point(226, 191);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(45, 15);
            lblInvoice.TabIndex = 12;
            lblInvoice.Text = "Invoice";
            // 
            // btnInvoice
            // 
            btnInvoice.Location = new Point(226, 212);
            btnInvoice.Name = "btnInvoice";
            btnInvoice.Size = new Size(180, 48);
            btnInvoice.TabIndex = 13;
            btnInvoice.Text = "Invoice";
            btnInvoice.UseVisualStyleBackColor = true;
            btnInvoice.Click += btnInvoice_Click;
            // 
            // pnlInformation
            // 
            pnlInformation.BorderStyle = BorderStyle.Fixed3D;
            pnlInformation.Controls.Add(lblInfo);
            pnlInformation.Location = new Point(412, 41);
            pnlInformation.Name = "pnlInformation";
            pnlInformation.Size = new Size(343, 219);
            pnlInformation.TabIndex = 14;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(22, 34);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(299, 135);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Select a Function:\r\n\r\n-Maintain Titles, Authors, Publishers, Stores, Employees\r\n\r\n-Enter Customer Order\r\n\r\n-View Sales Reports\r\n\r\n-View Invoice\r\n";
            // 
            // frmMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 337);
            Controls.Add(pnlInformation);
            Controls.Add(btnInvoice);
            Controls.Add(lblInvoice);
            Controls.Add(btnExit);
            Controls.Add(lblReport);
            Controls.Add(lblOrderEntry);
            Controls.Add(btnReports);
            Controls.Add(btnShoppingCart);
            Controls.Add(btnEmployeesMaintenance);
            Controls.Add(btnStoresMaintenance);
            Controls.Add(btnPublishersMaintenance);
            Controls.Add(btnAuthorsMaintenance);
            Controls.Add(lblMaintenance);
            Controls.Add(btnTitlesMaintenance);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMainMenu";
            Text = "BookStore - MainMenu";
            pnlInformation.ResumeLayout(false);
            pnlInformation.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlInfo;
        private Button btnTitlesMaintenance;
        private Label lblMaintenance;
        private Button btnAuthorsMaintenance;
        private Button btnPublishersMaintenance;
        private Button btnStoresMaintenance;
        private Button btnEmployeesMaintenance;
        private Button btnShoppingCart;
        private Button btnReports;
        private Label lblOrderEntry;
        private Label lblReport;
        private Button btnExit;
        private Label lblInvoice;
        private Button btnInvoice;
        private Panel pnlInformation;
        private Label lblInfo;
        private Label label2;
        private Label label1;
    }
}
