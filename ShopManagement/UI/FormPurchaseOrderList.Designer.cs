namespace ShopManagement.UI
{
    partial class FormPurchaseOrderList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtSrcToDate = new System.Windows.Forms.DateTimePicker();
            this.dtSrcFromDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSrcVendor = new System.Windows.Forms.ComboBox();
            this.cmbSrcOrderStatus = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSrcOrderCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.btnAddNewPO = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtSrcToDate);
            this.panel1.Controls.Add(this.dtSrcFromDate);
            this.panel1.Controls.Add(this.cmbSrcVendor);
            this.panel1.Controls.Add(this.cmbSrcOrderStatus);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtSrcOrderCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(13, 73);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1898, 60);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Date Range";
            // 
            // dtSrcToDate
            // 
            this.dtSrcToDate.CustomFormat = "dd-MM-yyyy";
            this.dtSrcToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSrcToDate.Location = new System.Drawing.Point(606, 21);
            this.dtSrcToDate.Name = "dtSrcToDate";
            this.dtSrcToDate.Size = new System.Drawing.Size(112, 22);
            this.dtSrcToDate.TabIndex = 16;
            // 
            // dtSrcFromDate
            // 
            this.dtSrcFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtSrcFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSrcFromDate.Location = new System.Drawing.Point(460, 21);
            this.dtSrcFromDate.Name = "dtSrcFromDate";
            this.dtSrcFromDate.Size = new System.Drawing.Size(112, 22);
            this.dtSrcFromDate.TabIndex = 15;
            // 
            // cmbSrcVendor
            // 
            this.cmbSrcVendor.FormattingEnabled = true;
            this.cmbSrcVendor.Location = new System.Drawing.Point(1206, 20);
            this.cmbSrcVendor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSrcVendor.Name = "cmbSrcVendor";
            this.cmbSrcVendor.Size = new System.Drawing.Size(112, 24);
            this.cmbSrcVendor.TabIndex = 14;
            // 
            // cmbSrcOrderStatus
            // 
            this.cmbSrcOrderStatus.FormattingEnabled = true;
            this.cmbSrcOrderStatus.Location = new System.Drawing.Point(168, 20);
            this.cmbSrcOrderStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSrcOrderStatus.Name = "cmbSrcOrderStatus";
            this.cmbSrcOrderStatus.Size = new System.Drawing.Size(112, 24);
            this.cmbSrcOrderStatus.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(752, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 25);
            this.label15.TabIndex = 12;
            this.label15.Text = "Order Code";
            // 
            // txtSrcOrderCode
            // 
            this.txtSrcOrderCode.Location = new System.Drawing.Point(896, 21);
            this.txtSrcOrderCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtSrcOrderCode.Name = "txtSrcOrderCode";
            this.txtSrcOrderCode.Size = new System.Drawing.Size(112, 22);
            this.txtSrcOrderCode.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1042, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vendor Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1352, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 28);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 25);
            this.label13.TabIndex = 5;
            this.label13.Text = "Order Status";
            // 
            // dgvPO
            // 
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Location = new System.Drawing.Point(13, 156);
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.RowTemplate.Height = 24;
            this.dgvPO.Size = new System.Drawing.Size(1899, 456);
            this.dgvPO.TabIndex = 14;
            // 
            // btnAddNewPO
            // 
            this.btnAddNewPO.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewPO.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNewPO.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddNewPO.Location = new System.Drawing.Point(13, 13);
            this.btnAddNewPO.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewPO.Name = "btnAddNewPO";
            this.btnAddNewPO.Size = new System.Drawing.Size(215, 49);
            this.btnAddNewPO.TabIndex = 164;
            this.btnAddNewPO.Text = "New Purchase Order";
            this.btnAddNewPO.UseVisualStyleBackColor = false;
            this.btnAddNewPO.Click += new System.EventHandler(this.btnAddNewPO_Click);
            // 
            // FormPurchaseOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.btnAddNewPO);
            this.Controls.Add(this.dgvPO);
            this.Controls.Add(this.panel1);
            this.Name = "FormPurchaseOrderList";
            this.Text = "Purchase Order List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtSrcToDate;
        private System.Windows.Forms.DateTimePicker dtSrcFromDate;
        private System.Windows.Forms.ComboBox cmbSrcVendor;
        private System.Windows.Forms.ComboBox cmbSrcOrderStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSrcOrderCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.Button btnAddNewPO;
    }
}