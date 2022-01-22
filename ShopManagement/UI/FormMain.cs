using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagement.UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //FormProductList frmProductList=new FormProductList();
            //frmProductList.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            FormSalesProduct frmSalesprod = new FormSalesProduct();
            frmSalesprod.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEntryCategory frmCategory = new FormEntryCategory();
            frmCategory.ShowDialog();
        }

        private void productsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormBusinessLogic report=new FormBusinessLogic();
            report.Show();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormProductDetails frmProdDetails = new FormProductDetails();
            frmProdDetails.Show();
            frmProdDetails.WindowState = FormWindowState.Normal;
            frmProdDetails.BringToFront();
            frmProdDetails.TopLevel = true;
            frmProdDetails.Focus();
        }

        private void purchseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPurchaseOrderList frmPurchaseOrderList = new FormPurchaseOrderList();
            frmPurchaseOrderList.Show();
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendorList frmvVendorList=new FormVendorList();
            frmvVendorList.ShowDialog();
        }

       

       

        

       
    }
}
