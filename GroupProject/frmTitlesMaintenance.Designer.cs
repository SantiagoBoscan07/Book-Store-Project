namespace GroupProject
{
    partial class frmTitlesMaintenance
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
            lblTitlesList = new Label();
            grdTitles = new DataGridView();
            lblTitlesDetails = new Label();
            txtTitleID = new TextBox();
            lblTitleID = new Label();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblType = new Label();
            lblPrice = new Label();
            txtPubID = new TextBox();
            lblPubID = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnClose = new Button();
            cboType = new ComboBox();
            txtPrice = new TextBox();
            lblNote = new Label();
            txtNote = new TextBox();
            ((System.ComponentModel.ISupportInitialize)grdTitles).BeginInit();
            SuspendLayout();
            // 
            // lblTitlesList
            // 
            lblTitlesList.AutoSize = true;
            lblTitlesList.Location = new Point(12, 19);
            lblTitlesList.Name = "lblTitlesList";
            lblTitlesList.Size = new Size(56, 15);
            lblTitlesList.TabIndex = 0;
            lblTitlesList.Text = "Titles List";
            // 
            // grdTitles
            // 
            grdTitles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTitles.Location = new Point(12, 37);
            grdTitles.Name = "grdTitles";
            grdTitles.ReadOnly = true;
            grdTitles.Size = new Size(437, 259);
            grdTitles.TabIndex = 1;
            // 
            // lblTitlesDetails
            // 
            lblTitlesDetails.AutoSize = true;
            lblTitlesDetails.Location = new Point(468, 19);
            lblTitlesDetails.Name = "lblTitlesDetails";
            lblTitlesDetails.Size = new Size(73, 15);
            lblTitlesDetails.TabIndex = 2;
            lblTitlesDetails.Text = "Titles Details";
            // 
            // txtTitleID
            // 
            txtTitleID.Location = new Point(541, 42);
            txtTitleID.Name = "txtTitleID";
            txtTitleID.Size = new Size(147, 23);
            txtTitleID.TabIndex = 3;
            // 
            // lblTitleID
            // 
            lblTitleID.AutoSize = true;
            lblTitleID.Location = new Point(488, 45);
            lblTitleID.Name = "lblTitleID";
            lblTitleID.Size = new Size(47, 15);
            lblTitleID.TabIndex = 4;
            lblTitleID.Text = "Title ID:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(502, 81);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(33, 15);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(541, 78);
            txtTitle.MaxLength = 80;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(147, 23);
            txtTitle.TabIndex = 6;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(502, 117);
            lblType.Name = "lblType";
            lblType.Size = new Size(35, 15);
            lblType.TabIndex = 7;
            lblType.Text = "Type:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(499, 155);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 15);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price:";
            // 
            // txtPubID
            // 
            txtPubID.Location = new Point(541, 191);
            txtPubID.MaxLength = 4;
            txtPubID.Name = "txtPubID";
            txtPubID.Size = new Size(147, 23);
            txtPubID.TabIndex = 11;
            // 
            // lblPubID
            // 
            lblPubID.AutoSize = true;
            lblPubID.Location = new Point(492, 194);
            lblPubID.Name = "lblPubID";
            lblPubID.Size = new Size(45, 15);
            lblPubID.TabIndex = 12;
            lblPubID.Text = "Pub ID:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(468, 273);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(551, 273);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(632, 273);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(551, 302);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(632, 302);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 17;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "UNDECIDED", "business", "mod_cook", "popular_comp", "psychology", "trad_cook" });
            cboType.Location = new Point(541, 114);
            cboType.Name = "cboType";
            cboType.Size = new Size(147, 23);
            cboType.TabIndex = 18;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(541, 152);
            txtPrice.MaxLength = 4;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(147, 23);
            txtPrice.TabIndex = 19;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(501, 235);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(36, 15);
            lblNote.TabIndex = 20;
            lblNote.Text = "Note:";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(541, 232);
            txtNote.MaxLength = 200;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(147, 23);
            txtNote.TabIndex = 21;
            // 
            // frmTitlesMaintenance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 337);
            Controls.Add(txtNote);
            Controls.Add(lblNote);
            Controls.Add(txtPrice);
            Controls.Add(cboType);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblPubID);
            Controls.Add(txtPubID);
            Controls.Add(lblPrice);
            Controls.Add(lblType);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(lblTitleID);
            Controls.Add(txtTitleID);
            Controls.Add(lblTitlesDetails);
            Controls.Add(grdTitles);
            Controls.Add(lblTitlesList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmTitlesMaintenance";
            Text = "BookStore - Titles Maintenance";
            ((System.ComponentModel.ISupportInitialize)grdTitles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitlesList;
        private DataGridView grdTitles;
        private Label lblTitlesDetails;
        private TextBox txtTitleID;
        private Label lblTitleID;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblType;
        private Label lblPrice;
        private TextBox txtPubID;
        private Label lblPubID;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnClose;
        private ComboBox cboType;
        private TextBox txtPrice;
        private Label lblNote;
        private TextBox txtNote;
    }
}