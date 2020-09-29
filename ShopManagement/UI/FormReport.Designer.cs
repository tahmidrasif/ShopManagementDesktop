namespace ShopManagement.UI
{
    partial class FormReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.superShopDataSet = new ShopManagement.SuperShopDataSet();
            this.superShopDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderTableAdapter = new ShopManagement.SuperShopDataSetTableAdapters.OrderTableAdapter();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productTableAdapter = new ShopManagement.SuperShopDataSetTableAdapters.ProductTableAdapter();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.receiptDataSet = new ShopManagement.ReceiptDataSet();
            this.receiptDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receiptDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.superShopDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superShopDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // superShopDataSet
            // 
            this.superShopDataSet.DataSetName = "SuperShopDataSet";
            this.superShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // superShopDataSetBindingSource
            // 
            this.superShopDataSetBindingSource.DataSource = this.superShopDataSet;
            this.superShopDataSetBindingSource.Position = 0;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.superShopDataSetBindingSource;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.superShopDataSetBindingSource;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataMember = "Product";
            this.productBindingSource1.DataSource = this.superShopDataSetBindingSource;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.receiptDataSetBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.receiptDataSetBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ShopManagement.Reports.Receipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 23);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(589, 453);
            this.reportViewer1.TabIndex = 0;
            // 
            // receiptDataSet
            // 
            this.receiptDataSet.DataSetName = "ReceiptDataSet";
            this.receiptDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receiptDataSetBindingSource
            // 
            this.receiptDataSetBindingSource.DataSource = this.receiptDataSet;
            this.receiptDataSetBindingSource.Position = 0;
            // 
            // receiptDataSetBindingSource1
            // 
            this.receiptDataSetBindingSource1.DataSource = this.receiptDataSet;
            this.receiptDataSetBindingSource1.Position = 0;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 488);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superShopDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superShopDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource superShopDataSetBindingSource;
        private SuperShopDataSet superShopDataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private SuperShopDataSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource;
        private SuperShopDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource receiptDataSetBindingSource;
        private ReceiptDataSet receiptDataSet;
        private System.Windows.Forms.BindingSource receiptDataSetBindingSource1;
    }
}