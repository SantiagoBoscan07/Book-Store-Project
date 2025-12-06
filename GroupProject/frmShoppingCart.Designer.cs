namespace GroupProject
{
    partial class frmShoppingCart
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
            lblTotal = new Label();
            txtTotal = new TextBox();
            txtTax = new TextBox();
            lblTax = new Label();
            txtSubtotal = new TextBox();
            lblSubtotal = new Label();
            grdCurrentOrderItem = new DataGridView();
            lblCurrentOrderItems = new Label();
            txtTitle = new TextBox();
            lblSearchTitle = new Label();
            btnSearchTitle = new Button();
            grdTitleSearchResult = new DataGridView();
            lblTitleSearchResult = new Label();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAddItem = new Button();
            btnCommitOrder = new Button();
            btnUpdateItem = new Button();
            btnClose = new Button();
            btnSelectTitle = new Button();
            lblSelectedTitle = new Label();
            txtSelectedTitle = new TextBox();
            btnClearItem = new Button();
            btnClearTitle = new Button();
            btnDeleteItem = new Button();
            lblOrdID = new Label();
            txtOrderID = new TextBox();
            lblStore = new Label();
            cboStore = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdCurrentOrderItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTitleSearchResult).BeginInit();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(859, 307);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(898, 304);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(134, 23);
            txtTotal.TabIndex = 1;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(898, 275);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(134, 23);
            txtTax.TabIndex = 3;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(868, 278);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(27, 15);
            lblTax.TabIndex = 2;
            lblTax.Text = "Tax:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(898, 246);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(134, 23);
            txtSubtotal.TabIndex = 5;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(841, 249);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(54, 15);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "Subtotal:";
            // 
            // grdCurrentOrderItem
            // 
            grdCurrentOrderItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdCurrentOrderItem.Location = new Point(607, 34);
            grdCurrentOrderItem.MultiSelect = false;
            grdCurrentOrderItem.Name = "grdCurrentOrderItem";
            grdCurrentOrderItem.ReadOnly = true;
            grdCurrentOrderItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdCurrentOrderItem.Size = new Size(425, 206);
            grdCurrentOrderItem.TabIndex = 6;
            // 
            // lblCurrentOrderItems
            // 
            lblCurrentOrderItems.AutoSize = true;
            lblCurrentOrderItems.Location = new Point(607, 16);
            lblCurrentOrderItems.Name = "lblCurrentOrderItems";
            lblCurrentOrderItems.Size = new Size(112, 15);
            lblCurrentOrderItems.TabIndex = 7;
            lblCurrentOrderItems.Text = "Current Order Items";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(86, 22);
            txtTitle.MaxLength = 80;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(207, 23);
            txtTitle.TabIndex = 11;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Location = new Point(12, 25);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(68, 15);
            lblSearchTitle.TabIndex = 10;
            lblSearchTitle.Text = "Search Title";
            // 
            // btnSearchTitle
            // 
            btnSearchTitle.Location = new Point(299, 22);
            btnSearchTitle.Name = "btnSearchTitle";
            btnSearchTitle.Size = new Size(96, 23);
            btnSearchTitle.TabIndex = 12;
            btnSearchTitle.Text = "Search Title";
            btnSearchTitle.UseVisualStyleBackColor = true;
            btnSearchTitle.Click += btnSearchTitle_Click;
            // 
            // grdTitleSearchResult
            // 
            grdTitleSearchResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTitleSearchResult.Location = new Point(12, 74);
            grdTitleSearchResult.MultiSelect = false;
            grdTitleSearchResult.Name = "grdTitleSearchResult";
            grdTitleSearchResult.ReadOnly = true;
            grdTitleSearchResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdTitleSearchResult.Size = new Size(342, 253);
            grdTitleSearchResult.TabIndex = 13;
            // 
            // lblTitleSearchResult
            // 
            lblTitleSearchResult.AutoSize = true;
            lblTitleSearchResult.Location = new Point(12, 56);
            lblTitleSearchResult.Name = "lblTitleSearchResult";
            lblTitleSearchResult.Size = new Size(103, 15);
            lblTitleSearchResult.TabIndex = 14;
            lblTitleSearchResult.Text = "Title Search Result";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(379, 176);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(53, 15);
            lblQuantity.TabIndex = 15;
            lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(434, 173);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(64, 23);
            txtQuantity.TabIndex = 16;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(375, 205);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(105, 23);
            btnAddItem.TabIndex = 17;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnCommitOrder
            // 
            btnCommitOrder.Location = new Point(375, 270);
            btnCommitOrder.Name = "btnCommitOrder";
            btnCommitOrder.Size = new Size(216, 23);
            btnCommitOrder.TabIndex = 18;
            btnCommitOrder.Text = "Commit Order";
            btnCommitOrder.UseVisualStyleBackColor = true;
            btnCommitOrder.Click += btnCommitOrder_Click;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.Location = new Point(486, 205);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(105, 23);
            btnUpdateItem.TabIndex = 19;
            btnUpdateItem.Text = "Update Item";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(375, 307);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(216, 23);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSelectTitle
            // 
            btnSelectTitle.Location = new Point(401, 22);
            btnSelectTitle.Name = "btnSelectTitle";
            btnSelectTitle.Size = new Size(96, 23);
            btnSelectTitle.TabIndex = 22;
            btnSelectTitle.Text = "Select Title";
            btnSelectTitle.UseVisualStyleBackColor = true;
            btnSelectTitle.Click += btnSelectTitle_Click;
            // 
            // lblSelectedTitle
            // 
            lblSelectedTitle.AutoSize = true;
            lblSelectedTitle.Location = new Point(398, 147);
            lblSelectedTitle.Name = "lblSelectedTitle";
            lblSelectedTitle.Size = new Size(30, 15);
            lblSelectedTitle.TabIndex = 24;
            lblSelectedTitle.Text = "Title";
            // 
            // txtSelectedTitle
            // 
            txtSelectedTitle.Location = new Point(434, 144);
            txtSelectedTitle.MaxLength = 80;
            txtSelectedTitle.Name = "txtSelectedTitle";
            txtSelectedTitle.ReadOnly = true;
            txtSelectedTitle.Size = new Size(145, 23);
            txtSelectedTitle.TabIndex = 25;
            // 
            // btnClearItem
            // 
            btnClearItem.Location = new Point(375, 234);
            btnClearItem.Name = "btnClearItem";
            btnClearItem.Size = new Size(105, 23);
            btnClearItem.TabIndex = 26;
            btnClearItem.Text = "Clear Item";
            btnClearItem.UseVisualStyleBackColor = true;
            btnClearItem.Click += btnClearItem_Click;
            // 
            // btnClearTitle
            // 
            btnClearTitle.Location = new Point(503, 22);
            btnClearTitle.Name = "btnClearTitle";
            btnClearTitle.Size = new Size(96, 23);
            btnClearTitle.TabIndex = 27;
            btnClearTitle.Text = "Clear Title";
            btnClearTitle.UseVisualStyleBackColor = true;
            btnClearTitle.Click += btnClearTitle_Click;
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.Location = new Point(486, 234);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.Size = new Size(105, 23);
            btnDeleteItem.TabIndex = 28;
            btnDeleteItem.Text = "Delete Item";
            btnDeleteItem.UseVisualStyleBackColor = true;
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // lblOrdID
            // 
            lblOrdID.AutoSize = true;
            lblOrdID.Location = new Point(381, 117);
            lblOrdID.Name = "lblOrdID";
            lblOrdID.Size = new Size(51, 15);
            lblOrdID.TabIndex = 29;
            lblOrdID.Text = "Order ID";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(434, 114);
            txtOrderID.MaxLength = 80;
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(145, 23);
            txtOrderID.TabIndex = 30;
            // 
            // lblStore
            // 
            lblStore.AutoSize = true;
            lblStore.Location = new Point(398, 87);
            lblStore.Name = "lblStore";
            lblStore.Size = new Size(34, 15);
            lblStore.TabIndex = 31;
            lblStore.Text = "Store";
            // 
            // cboStore
            // 
            cboStore.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStore.FormattingEnabled = true;
            cboStore.Location = new Point(434, 84);
            cboStore.Name = "cboStore";
            cboStore.Size = new Size(147, 23);
            cboStore.TabIndex = 57;
            // 
            // frmShoppingCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 341);
            Controls.Add(cboStore);
            Controls.Add(lblStore);
            Controls.Add(txtOrderID);
            Controls.Add(lblOrdID);
            Controls.Add(btnDeleteItem);
            Controls.Add(btnClearTitle);
            Controls.Add(btnClearItem);
            Controls.Add(txtSelectedTitle);
            Controls.Add(lblSelectedTitle);
            Controls.Add(btnSelectTitle);
            Controls.Add(btnClose);
            Controls.Add(btnUpdateItem);
            Controls.Add(btnCommitOrder);
            Controls.Add(btnAddItem);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(lblTitleSearchResult);
            Controls.Add(grdTitleSearchResult);
            Controls.Add(btnSearchTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblSearchTitle);
            Controls.Add(lblCurrentOrderItems);
            Controls.Add(grdCurrentOrderItem);
            Controls.Add(txtSubtotal);
            Controls.Add(lblSubtotal);
            Controls.Add(txtTax);
            Controls.Add(lblTax);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmShoppingCart";
            Text = "BookStore - Shopping Cart";
            ((System.ComponentModel.ISupportInitialize)grdCurrentOrderItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTitleSearchResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotal;
        private TextBox txtTotal;
        private TextBox txtTax;
        private Label lblTax;
        private TextBox txtSubtotal;
        private Label lblSubtotal;
        private DataGridView grdCurrentOrderItem;
        private Label lblCurrentOrderItems;
        private TextBox txtTitle;
        private Label lblSearchTitle;
        private Button btnSearchTitle;
        private DataGridView grdTitleSearchResult;
        private Label lblTitleSearchResult;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAddItem;
        private Button btnCommitOrder;
        private Button btnUpdateItem;
        private Button btnClose;
        private Button btnSelectTitle;
        private Label lblSelectedTitle;
        private TextBox txtSelectedTitle;
        private Button btnClearItem;
        private Button btnClearTitle;
        private Button btnDeleteItem;
        private Label lblOrdID;
        private TextBox txtOrderID;
        private Label lblStore;
        private ComboBox cboStore;
    }
}