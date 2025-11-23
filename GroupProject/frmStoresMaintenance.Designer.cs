namespace GroupProject
{
    partial class frmStoresMaintenance
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
            txtStoreZip = new TextBox();
            lblStoreZip = new Label();
            btnClose = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblStoreState = new Label();
            txtStoreState = new TextBox();
            lblStoreCity = new Label();
            lblStoreAddress = new Label();
            txtStoreName = new TextBox();
            lblStoreName = new Label();
            lblStoreID = new Label();
            txtStoreID = new TextBox();
            lblStoresDetails = new Label();
            grdStores = new DataGridView();
            lblStoresList = new Label();
            txtStoreAddress = new TextBox();
            txtStoreCity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)grdStores).BeginInit();
            SuspendLayout();
            // 
            // txtStoreZip
            // 
            txtStoreZip.Location = new Point(539, 229);
            txtStoreZip.MaxLength = 5;
            txtStoreZip.Name = "txtStoreZip";
            txtStoreZip.Size = new Size(147, 23);
            txtStoreZip.TabIndex = 43;
            // 
            // lblStoreZip
            // 
            lblStoreZip.AutoSize = true;
            lblStoreZip.Location = new Point(506, 232);
            lblStoreZip.Name = "lblStoreZip";
            lblStoreZip.Size = new Size(27, 15);
            lblStoreZip.TabIndex = 42;
            lblStoreZip.Text = "Zip:";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(624, 298);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 39;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(543, 298);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 38;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += this.btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(624, 269);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 37;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(543, 269);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 36;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(460, 269);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblStoreState
            // 
            lblStoreState.AutoSize = true;
            lblStoreState.Location = new Point(497, 187);
            lblStoreState.Name = "lblStoreState";
            lblStoreState.Size = new Size(36, 15);
            lblStoreState.TabIndex = 34;
            lblStoreState.Text = "State:";
            // 
            // txtStoreState
            // 
            txtStoreState.Location = new Point(539, 187);
            txtStoreState.MaxLength = 2;
            txtStoreState.Name = "txtStoreState";
            txtStoreState.Size = new Size(147, 23);
            txtStoreState.TabIndex = 33;
            // 
            // lblStoreCity
            // 
            lblStoreCity.AutoSize = true;
            lblStoreCity.Location = new Point(502, 148);
            lblStoreCity.Name = "lblStoreCity";
            lblStoreCity.Size = new Size(31, 15);
            lblStoreCity.TabIndex = 32;
            lblStoreCity.Text = "City:";
            // 
            // lblStoreAddress
            // 
            lblStoreAddress.AutoSize = true;
            lblStoreAddress.Location = new Point(483, 113);
            lblStoreAddress.Name = "lblStoreAddress";
            lblStoreAddress.Size = new Size(52, 15);
            lblStoreAddress.TabIndex = 31;
            lblStoreAddress.Text = "Address:";
            // 
            // txtStoreName
            // 
            txtStoreName.Location = new Point(539, 74);
            txtStoreName.MaxLength = 40;
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(147, 23);
            txtStoreName.TabIndex = 30;
            // 
            // lblStoreName
            // 
            lblStoreName.AutoSize = true;
            lblStoreName.Location = new Point(491, 77);
            lblStoreName.Name = "lblStoreName";
            lblStoreName.Size = new Size(42, 15);
            lblStoreName.TabIndex = 29;
            lblStoreName.Text = "Name:";
            // 
            // lblStoreID
            // 
            lblStoreID.AutoSize = true;
            lblStoreID.Location = new Point(482, 41);
            lblStoreID.Name = "lblStoreID";
            lblStoreID.Size = new Size(51, 15);
            lblStoreID.TabIndex = 28;
            lblStoreID.Text = "Store ID:";
            // 
            // txtStoreID
            // 
            txtStoreID.Location = new Point(539, 38);
            txtStoreID.MaxLength = 4;
            txtStoreID.Name = "txtStoreID";
            txtStoreID.Size = new Size(147, 23);
            txtStoreID.TabIndex = 27;
            // 
            // lblStoresDetails
            // 
            lblStoresDetails.AutoSize = true;
            lblStoresDetails.Location = new Point(458, 15);
            lblStoresDetails.Name = "lblStoresDetails";
            lblStoresDetails.Size = new Size(77, 15);
            lblStoresDetails.TabIndex = 26;
            lblStoresDetails.Text = "Stores Details";
            // 
            // grdStores
            // 
            grdStores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdStores.Location = new Point(10, 33);
            grdStores.Name = "grdStores";
            grdStores.ReadOnly = true;
            grdStores.Size = new Size(437, 259);
            grdStores.TabIndex = 25;
            // 
            // lblStoresList
            // 
            lblStoresList.AutoSize = true;
            lblStoresList.Location = new Point(10, 15);
            lblStoresList.Name = "lblStoresList";
            lblStoresList.Size = new Size(60, 15);
            lblStoresList.TabIndex = 24;
            lblStoresList.Text = "Stores List";
            // 
            // txtStoreAddress
            // 
            txtStoreAddress.Location = new Point(539, 110);
            txtStoreAddress.MaxLength = 40;
            txtStoreAddress.Name = "txtStoreAddress";
            txtStoreAddress.Size = new Size(147, 23);
            txtStoreAddress.TabIndex = 46;
            // 
            // txtStoreCity
            // 
            txtStoreCity.Location = new Point(539, 145);
            txtStoreCity.MaxLength = 20;
            txtStoreCity.Name = "txtStoreCity";
            txtStoreCity.Size = new Size(147, 23);
            txtStoreCity.TabIndex = 47;
            // 
            // frmStoresMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 338);
            Controls.Add(txtStoreCity);
            Controls.Add(txtStoreAddress);
            Controls.Add(txtStoreZip);
            Controls.Add(lblStoreZip);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblStoreState);
            Controls.Add(txtStoreState);
            Controls.Add(lblStoreCity);
            Controls.Add(lblStoreAddress);
            Controls.Add(txtStoreName);
            Controls.Add(lblStoreName);
            Controls.Add(lblStoreID);
            Controls.Add(txtStoreID);
            Controls.Add(lblStoresDetails);
            Controls.Add(grdStores);
            Controls.Add(lblStoresList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmStoresMaintenance";
            Text = "BookStore - Store Maintenance";
            ((System.ComponentModel.ISupportInitialize)grdStores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker txtPubDate;
        private Label lblPublicationDate;
        private TextBox txtStoreZip;
        private Label lblStoreZip;
        private TextBox txtPrice;
        private ComboBox cboType;
        private Button btnClose;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblStoreState;
        private TextBox txtStoreState;
        private Label lblStoreCity;
        private Label lblStoreAddress;
        private TextBox txtStoreName;
        private Label lblStoreName;
        private Label lblStoreID;
        private TextBox txtStoreID;
        private Label lblStoresDetails;
        private DataGridView grdStores;
        private Label lblStoresList;
        private TextBox txtStoreAddress;
        private TextBox txtStoreCity;
    }
}