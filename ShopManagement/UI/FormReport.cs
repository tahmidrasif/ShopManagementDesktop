using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ShopManagement.UI
{
    public partial class FormBusinessLogic : Form
    {
        public FormBusinessLogic()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'superShopDataSet.Product' table. You can move, or remove it, as needed.
            //this.productTableAdapter.Fill(this.superShopDataSet.Product);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "ShopManagement.Reports.Receipt.rdlc";
            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();

            ReportParameter orderid  = new ReportParameter("orderid", "10012");
            this.reportViewer1.LocalReport.SetParameters(orderid);
            this.reportViewer1.RefreshReport();
        }

     
    }
}
