namespace GroupProject
{
    partial class frmAuthorMaintenance
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
            lblAuthorsList = new Label();
            grdAuthors = new DataGridView();
            txtAuthorCity = new TextBox();
            lblCity = new Label();
            btnClose = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblAddress = new Label();
            txtAuthorAddress = new TextBox();
            lblAuthorPhone = new Label();
            lblAuthorLastName = new Label();
            txtAuthorFirstName = new TextBox();
            lblAuthorFirstName = new Label();
            lblAuthorID = new Label();
            lblAuthorDetails = new Label();
            txtAuthorLastName = new TextBox();
            txtAuthorPhoneNumber = new MaskedTextBox();
            lblStateAuthor = new Label();
            txtAuthorState = new TextBox();
            lblZip = new Label();
            txtAuthorZip = new TextBox();
            lblContract = new Label();
            grpContract = new GroupBox();
            rdoAuthorNotContracted = new RadioButton();
            rdoAuthorContracted = new RadioButton();
            txtAuthorID = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)grdAuthors).BeginInit();
            grpContract.SuspendLayout();
            SuspendLayout();
            // 
            // lblAuthorsList
            // 
            lblAuthorsList.AutoSize = true;
            lblAuthorsList.Location = new Point(12, 18);
            lblAuthorsList.Name = "lblAuthorsList";
            lblAuthorsList.Size = new Size(70, 15);
            lblAuthorsList.TabIndex = 0;
            lblAuthorsList.Text = "Authors List";
            // 
            // grdAuthors
            // 
            grdAuthors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdAuthors.Location = new Point(12, 36);
            grdAuthors.Name = "grdAuthors";
            grdAuthors.Size = new Size(437, 385);
            grdAuthors.TabIndex = 1;
            // 
            // txtAuthorCity
            // 
            txtAuthorCity.Location = new Point(538, 231);
            txtAuthorCity.MaxLength = 20;
            txtAuthorCity.Name = "txtAuthorCity";
            txtAuthorCity.Size = new Size(147, 23);
            txtAuthorCity.TabIndex = 39;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Location = new Point(503, 234);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(31, 15);
            lblCity.TabIndex = 38;
            lblCity.Text = "City:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(629, 466);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 35;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(548, 466);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 34;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(629, 437);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 33;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(548, 437);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 32;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(465, 437);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 31;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(482, 193);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 30;
            lblAddress.Text = "Address:";
            // 
            // txtAuthorAddress
            // 
            txtAuthorAddress.Location = new Point(538, 190);
            txtAuthorAddress.MaxLength = 40;
            txtAuthorAddress.Name = "txtAuthorAddress";
            txtAuthorAddress.Size = new Size(147, 23);
            txtAuthorAddress.TabIndex = 29;
            // 
            // lblAuthorPhone
            // 
            lblAuthorPhone.AutoSize = true;
            lblAuthorPhone.Location = new Point(490, 154);
            lblAuthorPhone.Name = "lblAuthorPhone";
            lblAuthorPhone.Size = new Size(44, 15);
            lblAuthorPhone.TabIndex = 28;
            lblAuthorPhone.Text = "Phone:";
            // 
            // lblAuthorLastName
            // 
            lblAuthorLastName.AutoSize = true;
            lblAuthorLastName.Location = new Point(468, 116);
            lblAuthorLastName.Name = "lblAuthorLastName";
            lblAuthorLastName.Size = new Size(66, 15);
            lblAuthorLastName.TabIndex = 27;
            lblAuthorLastName.Text = "Last Name:";
            // 
            // txtAuthorFirstName
            // 
            txtAuthorFirstName.Location = new Point(538, 77);
            txtAuthorFirstName.MaxLength = 20;
            txtAuthorFirstName.Name = "txtAuthorFirstName";
            txtAuthorFirstName.Size = new Size(147, 23);
            txtAuthorFirstName.TabIndex = 26;
            // 
            // lblAuthorFirstName
            // 
            lblAuthorFirstName.AutoSize = true;
            lblAuthorFirstName.Location = new Point(467, 80);
            lblAuthorFirstName.Name = "lblAuthorFirstName";
            lblAuthorFirstName.Size = new Size(67, 15);
            lblAuthorFirstName.TabIndex = 25;
            lblAuthorFirstName.Text = "First Name:";
            // 
            // lblAuthorID
            // 
            lblAuthorID.AutoSize = true;
            lblAuthorID.Location = new Point(473, 44);
            lblAuthorID.Name = "lblAuthorID";
            lblAuthorID.Size = new Size(61, 15);
            lblAuthorID.TabIndex = 24;
            lblAuthorID.Text = "Author ID:";
            // 
            // lblAuthorDetails
            // 
            lblAuthorDetails.AutoSize = true;
            lblAuthorDetails.Location = new Point(465, 18);
            lblAuthorDetails.Name = "lblAuthorDetails";
            lblAuthorDetails.Size = new Size(82, 15);
            lblAuthorDetails.TabIndex = 22;
            lblAuthorDetails.Text = "Author Details";
            // 
            // txtAuthorLastName
            // 
            txtAuthorLastName.Location = new Point(538, 113);
            txtAuthorLastName.MaxLength = 40;
            txtAuthorLastName.Name = "txtAuthorLastName";
            txtAuthorLastName.Size = new Size(147, 23);
            txtAuthorLastName.TabIndex = 40;
            // 
            // txtAuthorPhoneNumber
            // 
            txtAuthorPhoneNumber.Location = new Point(538, 154);
            txtAuthorPhoneNumber.Mask = "(999) 000 0000";
            txtAuthorPhoneNumber.Name = "txtAuthorPhoneNumber";
            txtAuthorPhoneNumber.Size = new Size(147, 23);
            txtAuthorPhoneNumber.TabIndex = 41;
            // 
            // lblStateAuthor
            // 
            lblStateAuthor.AutoSize = true;
            lblStateAuthor.Location = new Point(498, 275);
            lblStateAuthor.Name = "lblStateAuthor";
            lblStateAuthor.Size = new Size(36, 15);
            lblStateAuthor.TabIndex = 42;
            lblStateAuthor.Text = "State:";
            // 
            // txtAuthorState
            // 
            txtAuthorState.Location = new Point(538, 272);
            txtAuthorState.MaxLength = 2;
            txtAuthorState.Name = "txtAuthorState";
            txtAuthorState.Size = new Size(147, 23);
            txtAuthorState.TabIndex = 43;
            // 
            // lblZip
            // 
            lblZip.AutoSize = true;
            lblZip.Location = new Point(507, 317);
            lblZip.Name = "lblZip";
            lblZip.Size = new Size(27, 15);
            lblZip.TabIndex = 44;
            lblZip.Text = "Zip:";
            // 
            // txtAuthorZip
            // 
            txtAuthorZip.Location = new Point(538, 314);
            txtAuthorZip.MaxLength = 5;
            txtAuthorZip.Name = "txtAuthorZip";
            txtAuthorZip.Size = new Size(147, 23);
            txtAuthorZip.TabIndex = 45;
            // 
            // lblContract
            // 
            lblContract.AutoSize = true;
            lblContract.Location = new Point(478, 355);
            lblContract.Name = "lblContract";
            lblContract.Size = new Size(56, 15);
            lblContract.TabIndex = 46;
            lblContract.Text = "Contract:";
            // 
            // grpContract
            // 
            grpContract.Controls.Add(rdoAuthorNotContracted);
            grpContract.Controls.Add(rdoAuthorContracted);
            grpContract.Location = new Point(538, 355);
            grpContract.Name = "grpContract";
            grpContract.Size = new Size(147, 76);
            grpContract.TabIndex = 47;
            grpContract.TabStop = false;
            grpContract.Text = "Is author contracted?";
            // 
            // rdoAuthorNotContracted
            // 
            rdoAuthorNotContracted.AutoSize = true;
            rdoAuthorNotContracted.Location = new Point(6, 47);
            rdoAuthorNotContracted.Name = "rdoAuthorNotContracted";
            rdoAuthorNotContracted.Size = new Size(107, 19);
            rdoAuthorNotContracted.TabIndex = 1;
            rdoAuthorNotContracted.TabStop = true;
            rdoAuthorNotContracted.Text = "Not Contracted";
            rdoAuthorNotContracted.UseVisualStyleBackColor = true;
            // 
            // rdoAuthorContracted
            // 
            rdoAuthorContracted.AutoSize = true;
            rdoAuthorContracted.Location = new Point(6, 22);
            rdoAuthorContracted.Name = "rdoAuthorContracted";
            rdoAuthorContracted.Size = new Size(84, 19);
            rdoAuthorContracted.TabIndex = 0;
            rdoAuthorContracted.TabStop = true;
            rdoAuthorContracted.Text = "Contracted";
            rdoAuthorContracted.UseVisualStyleBackColor = true;
            // 
            // txtAuthorID
            // 
            txtAuthorID.Location = new Point(538, 41);
            txtAuthorID.Mask = "999-000-0000";
            txtAuthorID.Name = "txtAuthorID";
            txtAuthorID.Size = new Size(147, 23);
            txtAuthorID.TabIndex = 48;
            // 
            // frmAuthorMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 505);
            Controls.Add(txtAuthorID);
            Controls.Add(grpContract);
            Controls.Add(lblContract);
            Controls.Add(txtAuthorZip);
            Controls.Add(lblZip);
            Controls.Add(txtAuthorState);
            Controls.Add(lblStateAuthor);
            Controls.Add(txtAuthorPhoneNumber);
            Controls.Add(txtAuthorLastName);
            Controls.Add(txtAuthorCity);
            Controls.Add(lblCity);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblAddress);
            Controls.Add(txtAuthorAddress);
            Controls.Add(lblAuthorPhone);
            Controls.Add(lblAuthorLastName);
            Controls.Add(txtAuthorFirstName);
            Controls.Add(lblAuthorFirstName);
            Controls.Add(lblAuthorID);
            Controls.Add(lblAuthorDetails);
            Controls.Add(grdAuthors);
            Controls.Add(lblAuthorsList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmAuthorMaintenance";
            Text = "BookStore - Authors Maintenance";
            ((System.ComponentModel.ISupportInitialize)grdAuthors).EndInit();
            grpContract.ResumeLayout(false);
            grpContract.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAuthorsList;
        private DataGridView grdAuthors;
        private TextBox txtAuthorCity;
        private Label lblCity;
        private TextBox txtPrice;
        private ComboBox cboType;
        private Button btnClose;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblAddress;
        private TextBox txtAuthorAddress;
        private Label lblAuthorPhone;
        private Label lblAuthorLastName;
        private TextBox txtAuthorFirstName;
        private Label lblAuthorFirstName;
        private Label lblAuthorID;
        private Label lblAuthorDetails;
        private TextBox txtAuthorLastName;
        private MaskedTextBox txtAuthorPhoneNumber;
        private Label lblStateAuthor;
        private TextBox txtAuthorState;
        private Label lblZip;
        private TextBox txtAuthorZip;
        private Label lblContract;
        private GroupBox grpContract;
        private RadioButton rdoAuthorNotContracted;
        private RadioButton rdoAuthorContracted;
        private MaskedTextBox txtAuthorID;
    }
}