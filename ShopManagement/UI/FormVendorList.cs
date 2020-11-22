using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopManagement.BLL;
using ShopManagement.BLL.Request;
using ShopManagement.BLL.ViewModel;

namespace ShopManagement.UI
{
    public partial class FormVendorList : Form
    {
        public List<VendorViewModel> _vendorVMList = null;
        private long vendorID = 0;
        public FormVendorList()
        {
            InitializeComponent();
            LoadSearchCategoryCombo();
            LoadGridView();
            btnSave.Enabled = true;
            btnUpdt.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void LoadSearchCategoryCombo()
        {
            throw new NotImplementedException();
        }

        private void LoadGridView()
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtVendorName.Text))
            {
                MessageBox.Show("Please Enter Vendor Name");
                return;
            }
            if (String.IsNullOrEmpty(txtPhoneNo.Text))
            {
                MessageBox.Show("Please Enter Vendor Phone No.");
                return;
            }
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please Enter Vendor Email");
                return;
            }


        }

       
    }
}
