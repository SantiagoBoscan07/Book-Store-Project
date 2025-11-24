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
            lblOrderNum = new Label();
            txtOrderNum = new TextBox();
            txtTitle = new TextBox();
            lblSearchTitle = new Label();
            btnSearch = new Button();
            grdTitleSearchResult = new DataGridView();
            lblTitleSearchResult = new Label();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAddItem = new Button();
            btnCommitOrder = new Button();
            btnUpdateItem = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)grdCurrentOrderItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTitleSearchResult).BeginInit();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(552, 307);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(591, 304);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(134, 23);
            txtTotal.TabIndex = 1;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(591, 275);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(134, 23);
            txtTax.TabIndex = 3;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(561, 278);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(27, 15);
            lblTax.TabIndex = 2;
            lblTax.Text = "Tax:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(591, 246);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(134, 23);
            txtSubtotal.TabIndex = 5;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(534, 249);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(54, 15);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "Subtotal:";
            // 
            // grdCurrentOrderItem
            // 
            grdCurrentOrderItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdCurrentOrderItem.Location = new Point(534, 34);
            grdCurrentOrderItem.Name = "grdCurrentOrderItem";
            grdCurrentOrderItem.Size = new Size(191, 206);
            grdCurrentOrderItem.TabIndex = 6;
            // 
            // lblCurrentOrderItems
            // 
            lblCurrentOrderItems.AutoSize = true;
            lblCurrentOrderItems.Location = new Point(534, 16);
            lblCurrentOrderItems.Name = "lblCurrentOrderItems";
            lblCurrentOrderItems.Size = new Size(112, 15);
            lblCurrentOrderItems.TabIndex = 7;
            lblCurrentOrderItems.Text = "Current Order Items";
            // 
            // lblOrderNum
            // 
            lblOrderNum.AutoSize = true;
            lblOrderNum.Location = new Point(5, 19);
            lblOrderNum.Name = "lblOrderNum";
            lblOrderNum.Size = new Size(67, 15);
            lblOrderNum.TabIndex = 8;
            lblOrderNum.Text = "Order Num";
            // 
            // txtOrderNum
            // 
            txtOrderNum.Location = new Point(78, 16);
            txtOrderNum.MaxLength = 20;
            txtOrderNum.Name = "txtOrderNum";
            txtOrderNum.Size = new Size(207, 23);
            txtOrderNum.TabIndex = 9;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(78, 56);
            txtTitle.MaxLength = 80;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(207, 23);
            txtTitle.TabIndex = 11;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.Location = new Point(4, 59);
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(68, 15);
            lblSearchTitle.TabIndex = 10;
            lblSearchTitle.Text = "Search Title";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(291, 56);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grdTitleSearchResult
            // 
            grdTitleSearchResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdTitleSearchResult.Location = new Point(12, 119);
            grdTitleSearchResult.Name = "grdTitleSearchResult";
            grdTitleSearchResult.Size = new Size(286, 208);
            grdTitleSearchResult.TabIndex = 13;
            // 
            // lblTitleSearchResult
            // 
            lblTitleSearchResult.AutoSize = true;
            lblTitleSearchResult.Location = new Point(13, 101);
            lblTitleSearchResult.Name = "lblTitleSearchResult";
            lblTitleSearchResult.Size = new Size(103, 15);
            lblTitleSearchResult.TabIndex = 14;
            lblTitleSearchResult.Text = "Title Search Result";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(313, 159);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(53, 15);
            lblQuantity.TabIndex = 15;
            lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(372, 156);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(64, 23);
            txtQuantity.TabIndex = 16;
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(313, 188);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(105, 23);
            btnAddItem.TabIndex = 17;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // btnCommitOrder
            // 
            btnCommitOrder.Location = new Point(313, 217);
            btnCommitOrder.Name = "btnCommitOrder";
            btnCommitOrder.Size = new Size(216, 23);
            btnCommitOrder.TabIndex = 18;
            btnCommitOrder.Text = "Commit Order";
            btnCommitOrder.UseVisualStyleBackColor = true;
            btnCommitOrder.Click += btnCommitOrder_Click;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.Location = new Point(424, 188);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(105, 23);
            btnUpdateItem.TabIndex = 19;
            btnUpdateItem.Text = "Update Item";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(313, 299);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(216, 23);
            btnClose.TabIndex = 20;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmShoppingCart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 341);
            Controls.Add(btnClose);
            Controls.Add(btnUpdateItem);
            Controls.Add(btnCommitOrder);
            Controls.Add(btnAddItem);
            Controls.Add(txtQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(lblTitleSearchResult);
            Controls.Add(grdTitleSearchResult);
            Controls.Add(btnSearch);
            Controls.Add(txtTitle);
            Controls.Add(lblSearchTitle);
            Controls.Add(txtOrderNum);
            Controls.Add(lblOrderNum);
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
        private Label lblOrderNum;
        private TextBox txtOrderNum;
        private TextBox txtTitle;
        private Label lblSearchTitle;
        private Button btnSearch;
        private DataGridView grdTitleSearchResult;
        private Label lblTitleSearchResult;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAddItem;
        private Button btnCommitOrder;
        private Button btnUpdateItem;
        private Button btnClose;
    }
}