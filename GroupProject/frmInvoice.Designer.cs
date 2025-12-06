namespace GroupProject
{
    partial class frmInvoice
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
            lblInvoice = new Label();
            lblOrderID = new Label();
            txtOrderID = new TextBox();
            btnSearch = new Button();
            grdInvoiceItems = new DataGridView();
            lblSubtotal = new Label();
            lblTax = new Label();
            lblTotal = new Label();
            txtSubtotal = new TextBox();
            txtTax = new TextBox();
            txtTotal = new TextBox();
            btnClose = new Button();
            btnPrint = new Button();
            btnClearSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)grdInvoiceItems).BeginInit();
            SuspendLayout();
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Location = new Point(32, 14);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(45, 15);
            lblInvoice.TabIndex = 0;
            lblInvoice.Text = "Invoice";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(32, 49);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(54, 15);
            lblOrderID.TabIndex = 1;
            lblOrderID.Text = "Order ID:";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(108, 46);
            txtOrderID.Margin = new Padding(3, 2, 3, 2);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(110, 23);
            txtOrderID.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(234, 46);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(118, 20);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grdInvoiceItems
            // 
            grdInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdInvoiceItems.Location = new Point(32, 83);
            grdInvoiceItems.Margin = new Padding(3, 2, 3, 2);
            grdInvoiceItems.MultiSelect = false;
            grdInvoiceItems.Name = "grdInvoiceItems";
            grdInvoiceItems.ReadOnly = true;
            grdInvoiceItems.RowHeadersWidth = 51;
            grdInvoiceItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdInvoiceItems.Size = new Size(646, 141);
            grdInvoiceItems.TabIndex = 4;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(389, 250);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(54, 15);
            lblSubtotal.TabIndex = 5;
            lblSubtotal.Text = "Subtotal:";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(390, 276);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(54, 15);
            lblTax.TabIndex = 6;
            lblTax.Text = "Tax (6%):";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(407, 303);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 15);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(454, 244);
            txtSubtotal.Margin = new Padding(3, 2, 3, 2);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(110, 23);
            txtSubtotal.TabIndex = 8;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(454, 274);
            txtTax.Margin = new Padding(3, 2, 3, 2);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(110, 23);
            txtTax.TabIndex = 9;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(454, 298);
            txtTotal.Margin = new Padding(3, 2, 3, 2);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(110, 23);
            txtTotal.TabIndex = 10;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(171, 244);
            btnClose.Margin = new Padding(3, 2, 3, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(118, 22);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(32, 244);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(118, 22);
            btnPrint.TabIndex = 12;
            btnPrint.Text = "Print Invoice";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(358, 46);
            btnClearSearch.Margin = new Padding(3, 2, 3, 2);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(118, 20);
            btnClearSearch.TabIndex = 13;
            btnClearSearch.Text = "Clear Search";
            btnClearSearch.UseVisualStyleBackColor = true;
            btnClearSearch.Click += btnClearSearch_Click;
            // 
            // frmInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnClearSearch);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            Controls.Add(txtTotal);
            Controls.Add(txtTax);
            Controls.Add(txtSubtotal);
            Controls.Add(lblTotal);
            Controls.Add(lblTax);
            Controls.Add(lblSubtotal);
            Controls.Add(grdInvoiceItems);
            Controls.Add(btnSearch);
            Controls.Add(txtOrderID);
            Controls.Add(lblOrderID);
            Controls.Add(lblInvoice);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmInvoice";
            Text = "frmInvoice";
            ((System.ComponentModel.ISupportInitialize)grdInvoiceItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInvoice;
        private Label lblOrderID;
        private TextBox txtOrderID;
        private Button btnSearch;
        private DataGridView grdInvoiceItems;
        private Label lblSubtotal;
        private Label lblTax;
        private Label lblTotal;
        private TextBox txtSubtotal;
        private TextBox txtTax;
        private TextBox txtTotal;
        private Button btnClose;
        private Button btnPrint;
        private Button btnClearSearch;
    }
}