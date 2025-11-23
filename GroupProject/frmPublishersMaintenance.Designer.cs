namespace GroupProject
{
    partial class frmPublishersMaintenance
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
            lblPublisherCountry = new Label();
            lblPublisherState = new Label();
            lblCity = new Label();
            txtPublisherName = new TextBox();
            lblPublisherName = new Label();
            lblPublisherID = new Label();
            txtPublisherID = new TextBox();
            lblPublishersDetails = new Label();
            grdPublishers = new DataGridView();
            lblPublishersList = new Label();
            txtPublisherCity = new TextBox();
            txtPublisherState = new TextBox();
            cboPublisherCountry = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdPublishers).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Location = new Point(626, 270);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 37;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(545, 270);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 36;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(626, 241);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 35;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(545, 241);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 34;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(462, 241);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 33;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblPublisherCountry
            // 
            lblPublisherCountry.AutoSize = true;
            lblPublisherCountry.Location = new Point(482, 190);
            lblPublisherCountry.Name = "lblPublisherCountry";
            lblPublisherCountry.Size = new Size(53, 15);
            lblPublisherCountry.TabIndex = 32;
            lblPublisherCountry.Text = "Country:";
            // 
            // lblPublisherState
            // 
            lblPublisherState.AutoSize = true;
            lblPublisherState.Location = new Point(497, 151);
            lblPublisherState.Name = "lblPublisherState";
            lblPublisherState.Size = new Size(36, 15);
            lblPublisherState.TabIndex = 30;
            lblPublisherState.Text = "State:";
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(504, 113);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(31, 15);
            lblCity.TabIndex = 29;
            lblCity.Text = "City:";
            // 
            // txtPublisherName
            // 
            txtPublisherName.Location = new Point(539, 74);
            txtPublisherName.MaxLength = 40;
            txtPublisherName.Name = "txtPublisherName";
            txtPublisherName.Size = new Size(147, 23);
            txtPublisherName.TabIndex = 28;
            // 
            // lblPublisherName
            // 
            lblPublisherName.AutoSize = true;
            lblPublisherName.Location = new Point(493, 77);
            lblPublisherName.Name = "lblPublisherName";
            lblPublisherName.Size = new Size(42, 15);
            lblPublisherName.TabIndex = 27;
            lblPublisherName.Text = "Name:";
            // 
            // lblPublisherID
            // 
            lblPublisherID.AutoSize = true;
            lblPublisherID.Location = new Point(462, 41);
            lblPublisherID.Name = "lblPublisherID";
            lblPublisherID.Size = new Size(73, 15);
            lblPublisherID.TabIndex = 26;
            lblPublisherID.Text = "Publisher ID:";
            // 
            // txtPublisherID
            // 
            txtPublisherID.Location = new Point(539, 38);
            txtPublisherID.MaxLength = 4;
            txtPublisherID.Name = "txtPublisherID";
            txtPublisherID.Size = new Size(147, 23);
            txtPublisherID.TabIndex = 25;
            // 
            // lblPublishersDetails
            // 
            lblPublishersDetails.AutoSize = true;
            lblPublishersDetails.Location = new Point(452, 15);
            lblPublishersDetails.Name = "lblPublishersDetails";
            lblPublishersDetails.Size = new Size(99, 15);
            lblPublishersDetails.TabIndex = 24;
            lblPublishersDetails.Text = "Publishers Details";
            // 
            // grdPublishers
            // 
            grdPublishers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdPublishers.Location = new Point(10, 33);
            grdPublishers.Name = "grdPublishers";
            grdPublishers.ReadOnly = true;
            grdPublishers.Size = new Size(437, 259);
            grdPublishers.TabIndex = 23;
            // 
            // lblPublishersList
            // 
            lblPublishersList.AutoSize = true;
            lblPublishersList.Location = new Point(10, 15);
            lblPublishersList.Name = "lblPublishersList";
            lblPublishersList.Size = new Size(82, 15);
            lblPublishersList.TabIndex = 22;
            lblPublishersList.Text = "Publishers List";
            // 
            // txtPublisherCity
            // 
            txtPublisherCity.Location = new Point(539, 110);
            txtPublisherCity.MaxLength = 20;
            txtPublisherCity.Name = "txtPublisherCity";
            txtPublisherCity.Size = new Size(147, 23);
            txtPublisherCity.TabIndex = 42;
            // 
            // txtPublisherState
            // 
            txtPublisherState.Location = new Point(539, 148);
            txtPublisherState.MaxLength = 2;
            txtPublisherState.Name = "txtPublisherState";
            txtPublisherState.Size = new Size(147, 23);
            txtPublisherState.TabIndex = 43;
            // 
            // cboPublisherCountry
            // 
            cboPublisherCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPublisherCountry.FormattingEnabled = true;
            cboPublisherCountry.Items.AddRange(new object[] { "USA", "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Chad", "Chile", "China", "Colombia", "Comoros", "Costa Rica", "Croatia", "Cuba", "Cyprus", "Denmark", "Djibouti", "Dominica", "Ecuador", "Egypt", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Namibia", "Nauru", "Nepal", "Netherlands", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Lucia", "Samoa", "San Marino", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Somalia", "South Africa", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Kingdom", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe" });
            cboPublisherCountry.Location = new Point(539, 187);
            cboPublisherCountry.MaxLength = 30;
            cboPublisherCountry.Name = "cboPublisherCountry";
            cboPublisherCountry.Size = new Size(147, 23);
            cboPublisherCountry.TabIndex = 44;
            // 
            // frmPublishersMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 315);
            Controls.Add(cboPublisherCountry);
            Controls.Add(txtPublisherState);
            Controls.Add(txtPublisherCity);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblPublisherCountry);
            Controls.Add(lblPublisherState);
            Controls.Add(lblCity);
            Controls.Add(txtPublisherName);
            Controls.Add(lblPublisherName);
            Controls.Add(lblPublisherID);
            Controls.Add(txtPublisherID);
            Controls.Add(lblPublishersDetails);
            Controls.Add(grdPublishers);
            Controls.Add(lblPublishersList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPublishersMaintenance";
            Text = "BookStore - Publishers Maintenance";
            ((System.ComponentModel.ISupportInitialize)grdPublishers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtPrice;
        private ComboBox cboType;
        private Button btnClose;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblPublisherCountry;
        private Label lblPublisherState;
        private Label lblCity;
        private TextBox txtPublisherName;
        private Label lblPublisherName;
        private Label lblPublisherID;
        private TextBox txtPublisherID;
        private Label lblPublishersDetails;
        private DataGridView grdPublishers;
        private Label lblPublishersList;
        private TextBox txtPublisherCity;
        private TextBox txtPublisherState;
        private ComboBox cboPublisherCountry;
    }
}