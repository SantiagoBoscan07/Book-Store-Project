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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblInvoice = new Label();
            lblOrderID = new Label();
            txtOrderID = new TextBox();
            btnSearch = new Button();
            dgvInvoiceItems = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colExtendedPrice = new DataGridViewTextBoxColumn();
            lblSubtotal = new Label();
            lblTax = new Label();
            lblTotal = new Label();
            txtSubtotal = new TextBox();
            txtTax = new TextBox();
            txtTotal = new TextBox();
            btnClose = new Button();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).BeginInit();
            SuspendLayout();
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Location = new Point(37, 19);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(56, 20);
            lblInvoice.TabIndex = 0;
            lblInvoice.Text = "Invoice";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(37, 65);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(69, 20);
            lblOrderID.TabIndex = 1;
            lblOrderID.Text = "Order ID:";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(123, 62);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(125, 27);
            txtOrderID.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(268, 62);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 27);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvInvoiceItems
            // 
            dgvInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoiceItems.Columns.AddRange(new DataGridViewColumn[] { colTitle, colQuantity, colPrice, colExtendedPrice });
            dgvInvoiceItems.Location = new Point(37, 111);
            dgvInvoiceItems.Name = "dgvInvoiceItems";
            dgvInvoiceItems.RowHeadersWidth = 51;
            dgvInvoiceItems.Size = new Size(738, 188);
            dgvInvoiceItems.TabIndex = 4;
            // 
            // colTitle
            // 
            colTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTitle.DefaultCellStyle = dataGridViewCellStyle1;
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            // 
            // colQuantity
            // 
            colQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            colQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 6;
            colQuantity.Name = "colQuantity";
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            colPrice.DefaultCellStyle = dataGridViewCellStyle3;
            colPrice.HeaderText = "Price";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            // 
            // colExtendedPrice
            // 
            colExtendedPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            colExtendedPrice.DefaultCellStyle = dataGridViewCellStyle4;
            colExtendedPrice.HeaderText = "Extended Price";
            colExtendedPrice.MinimumWidth = 6;
            colExtendedPrice.Name = "colExtendedPrice";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(445, 333);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(68, 20);
            lblSubtotal.TabIndex = 5;
            lblSubtotal.Text = "Subtotal:";
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(446, 368);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(67, 20);
            lblTax.TabIndex = 6;
            lblTax.Text = "Tax (6%):";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(465, 404);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 7;
            lblTotal.Text = "Total:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(519, 326);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(125, 27);
            txtSubtotal.TabIndex = 8;
            // 
            // txtTax
            // 
            txtTax.Location = new Point(519, 365);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(125, 27);
            txtTax.TabIndex = 9;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(519, 398);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 10;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(195, 326);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 29);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(37, 326);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(135, 29);
            btnPrint.TabIndex = 12;
            btnPrint.Text = "Print Invoice";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // frmInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            Controls.Add(txtTotal);
            Controls.Add(txtTax);
            Controls.Add(txtSubtotal);
            Controls.Add(lblTotal);
            Controls.Add(lblTax);
            Controls.Add(lblSubtotal);
            Controls.Add(dgvInvoiceItems);
            Controls.Add(btnSearch);
            Controls.Add(txtOrderID);
            Controls.Add(lblOrderID);
            Controls.Add(lblInvoice);
            Name = "frmInvoice";
            Text = "frmInvoice";
            ((System.ComponentModel.ISupportInitialize)dgvInvoiceItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInvoice;
        private Label lblOrderID;
        private TextBox txtOrderID;
        private Button btnSearch;
        private DataGridView dgvInvoiceItems;
        private Label lblSubtotal;
        private Label lblTax;
        private Label lblTotal;
        private TextBox txtSubtotal;
        private TextBox txtTax;
        private TextBox txtTotal;
        private Button btnClose;
        private Button btnPrint;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colExtendedPrice;
    }
}