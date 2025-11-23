namespace GroupProject
{
    partial class frmEmployeesMaintenance
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnClose = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblEmpLastName = new Label();
            lblMidInitial = new Label();
            txtEmpFirstName = new TextBox();
            lblEmpFirstName = new Label();
            lblEmpID = new Label();
            txtEmpID = new TextBox();
            lblEmployeesDetails = new Label();
            grdEmployees = new DataGridView();
            lblEmployeesList = new Label();
            txtEmpMidInitial = new TextBox();
            txtEmpLastName = new TextBox();
            lblJobID = new Label();
            txtJobID = new TextBox();
            txtJobLevel = new TextBox();
            lblJobLevel = new Label();
            lblPubID = new Label();
            lblHireDate = new Label();
            dtpHireDate = new DateTimePicker();
            cboPubID = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdEmployees).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(624, 392);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 39;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(543, 392);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 38;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(624, 363);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 37;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(543, 363);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 36;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(460, 363);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblEmpLastName
            // 
            lblEmpLastName.AutoSize = true;
            lblEmpLastName.Location = new Point(469, 151);
            lblEmpLastName.Name = "lblEmpLastName";
            lblEmpLastName.Size = new Size(66, 15);
            lblEmpLastName.TabIndex = 32;
            lblEmpLastName.Text = "Last Name:";
            // 
            // lblMidInitial
            // 
            lblMidInitial.AutoSize = true;
            lblMidInitial.Location = new Point(456, 113);
            lblMidInitial.Name = "lblMidInitial";
            lblMidInitial.Size = new Size(79, 15);
            lblMidInitial.TabIndex = 31;
            lblMidInitial.Text = "Middle Initial:";
            // 
            // txtEmpFirstName
            // 
            txtEmpFirstName.Location = new Point(539, 74);
            txtEmpFirstName.MaxLength = 20;
            txtEmpFirstName.Name = "txtEmpFirstName";
            txtEmpFirstName.Size = new Size(147, 23);
            txtEmpFirstName.TabIndex = 30;
            // 
            // lblEmpFirstName
            // 
            lblEmpFirstName.AutoSize = true;
            lblEmpFirstName.Location = new Point(468, 77);
            lblEmpFirstName.Name = "lblEmpFirstName";
            lblEmpFirstName.Size = new Size(67, 15);
            lblEmpFirstName.TabIndex = 29;
            lblEmpFirstName.Text = "First Name:";
            // 
            // lblEmpID
            // 
            lblEmpID.AutoSize = true;
            lblEmpID.Location = new Point(487, 41);
            lblEmpID.Name = "lblEmpID";
            lblEmpID.Size = new Size(48, 15);
            lblEmpID.TabIndex = 28;
            lblEmpID.Text = "Emp ID:";
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(539, 38);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.Size = new Size(147, 23);
            txtEmpID.TabIndex = 27;
            // 
            // lblEmployeesDetails
            // 
            lblEmployeesDetails.AutoSize = true;
            lblEmployeesDetails.Location = new Point(450, 15);
            lblEmployeesDetails.Name = "lblEmployeesDetails";
            lblEmployeesDetails.Size = new Size(102, 15);
            lblEmployeesDetails.TabIndex = 26;
            lblEmployeesDetails.Text = "Employees Details";
            // 
            // grdEmployees
            // 
            grdEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdEmployees.Location = new Point(10, 33);
            grdEmployees.Name = "grdEmployees";
            grdEmployees.ReadOnly = true;
            grdEmployees.Size = new Size(437, 304);
            grdEmployees.TabIndex = 25;
            // 
            // lblEmployeesList
            // 
            lblEmployeesList.AutoSize = true;
            lblEmployeesList.Location = new Point(10, 15);
            lblEmployeesList.Name = "lblEmployeesList";
            lblEmployeesList.Size = new Size(85, 15);
            lblEmployeesList.TabIndex = 24;
            lblEmployeesList.Text = "Employees List";
            // 
            // txtEmpMidInitial
            // 
            txtEmpMidInitial.Location = new Point(539, 110);
            txtEmpMidInitial.MaxLength = 1;
            txtEmpMidInitial.Name = "txtEmpMidInitial";
            txtEmpMidInitial.Size = new Size(147, 23);
            txtEmpMidInitial.TabIndex = 46;
            // 
            // txtEmpLastName
            // 
            txtEmpLastName.Location = new Point(539, 148);
            txtEmpLastName.MaxLength = 30;
            txtEmpLastName.Name = "txtEmpLastName";
            txtEmpLastName.Size = new Size(147, 23);
            txtEmpLastName.TabIndex = 47;
            // 
            // lblJobID
            // 
            lblJobID.AutoSize = true;
            lblJobID.Location = new Point(493, 189);
            lblJobID.Name = "lblJobID";
            lblJobID.Size = new Size(42, 15);
            lblJobID.TabIndex = 48;
            lblJobID.Text = "Job ID:";
            // 
            // txtJobID
            // 
            txtJobID.Location = new Point(539, 186);
            txtJobID.MaxLength = 1;
            txtJobID.Name = "txtJobID";
            txtJobID.Size = new Size(147, 23);
            txtJobID.TabIndex = 49;
            // 
            // txtJobLevel
            // 
            txtJobLevel.Location = new Point(539, 223);
            txtJobLevel.MaxLength = 10;
            txtJobLevel.Name = "txtJobLevel";
            txtJobLevel.Size = new Size(147, 23);
            txtJobLevel.TabIndex = 51;
            // 
            // lblJobLevel
            // 
            lblJobLevel.AutoSize = true;
            lblJobLevel.Location = new Point(477, 226);
            lblJobLevel.Name = "lblJobLevel";
            lblJobLevel.Size = new Size(58, 15);
            lblJobLevel.TabIndex = 50;
            lblJobLevel.Text = "Job Level:";
            // 
            // lblPubID
            // 
            lblPubID.AutoSize = true;
            lblPubID.Location = new Point(490, 270);
            lblPubID.Name = "lblPubID";
            lblPubID.Size = new Size(45, 15);
            lblPubID.TabIndex = 52;
            lblPubID.Text = "Pub ID:";
            // 
            // lblHireDate
            // 
            lblHireDate.AutoSize = true;
            lblHireDate.Location = new Point(476, 312);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(59, 15);
            lblHireDate.TabIndex = 54;
            lblHireDate.Text = "Hire Date:";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(539, 306);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(147, 23);
            dtpHireDate.TabIndex = 55;
            // 
            // cboPubID
            // 
            cboPubID.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPubID.FormattingEnabled = true;
            cboPubID.Items.AddRange(new object[] { "9952", "0736", "0877", "1389", "1622", "1756", "9901", "9952", "9999" });
            cboPubID.Location = new Point(539, 267);
            cboPubID.Name = "cboPubID";
            cboPubID.Size = new Size(147, 23);
            cboPubID.TabIndex = 56;
            // 
            // frmEmployeesMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 432);
            Controls.Add(cboPubID);
            Controls.Add(dtpHireDate);
            Controls.Add(lblHireDate);
            Controls.Add(lblPubID);
            Controls.Add(txtJobLevel);
            Controls.Add(lblJobLevel);
            Controls.Add(txtJobID);
            Controls.Add(lblJobID);
            Controls.Add(txtEmpLastName);
            Controls.Add(txtEmpMidInitial);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblEmpLastName);
            Controls.Add(lblMidInitial);
            Controls.Add(txtEmpFirstName);
            Controls.Add(lblEmpFirstName);
            Controls.Add(lblEmpID);
            Controls.Add(txtEmpID);
            Controls.Add(lblEmployeesDetails);
            Controls.Add(grdEmployees);
            Controls.Add(lblEmployeesList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmEmployeesMaintenance";
            Text = "BookStore - Employee Maintenance";
            ((System.ComponentModel.ISupportInitialize)grdEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtPubDate;
        private Label lblPublicationDate;
        private TextBox txtPrice;
        private ComboBox cboType;
        private Button btnClose;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblPubID;
        private Label lblEmpLastName;
        private Label lblMidInitial;
        private TextBox txtEmpFirstName;
        private Label lblEmpFirstName;
        private Label lblEmpID;
        private TextBox txtEmpID;
        private Label lblEmployeesDetails;
        private DataGridView grdEmployees;
        private Label lblEmployeesList;
        private TextBox txtEmpMidInitial;
        private TextBox txtEmpLastName;
        private Label lblJobID;
        private TextBox txtJobID;
        private TextBox txtJobLevel;
        private Label lblJobLevel;
        private Label lblHireDate;
        private DateTimePicker dtpHireDate;
        private ComboBox cboPubID;
    }
}