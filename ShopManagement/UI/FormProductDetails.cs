using ShopManagement.BLL;
using ShopManagement.BLL.Request;
using ShopManagement.BLL.ViewModel;
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
    public partial class FormProductDetails : Form
    {
        public List<ProductViewModel> _lstProduct = null;
        private ProductBLL _serviceProduct = null;
        private CategoryEntryBLL _serviceCategory = null;
        private UnitBLL _serviceUnit = null;
        public FormProductDetails()
        {
            _serviceCategory = new CategoryEntryBLL();
            _serviceUnit = new UnitBLL();
            _serviceProduct = new ProductBLL();
            InitializeComponent();
            InitializeProductGrid();
            LoadSearchCategoryCombo();
            LoadSearchSubCategoryCombo();
            LoadCategoryCombo();
            LoadSubCategoryCombo();
            LoadUnitCombo();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
     
        }

        private void LoadUnitCombo()
        {
            
            var unitLst = _serviceUnit.GetAllUnit();
            unitLst.Insert(0,new UnitVM(){UnitID = 0,UnitName = "--Select--"});
            cmbUnit.DataSource = unitLst;
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.ValueMember = "UnitID";
            
        }

        private void LoadSubCategoryCombo()
        {
            cmbSubCategory.DataSource = null;
            var subcat = _serviceCategory.GetAllSubCategory();
            if(subcat.ResponseCode=="000")
            {
                subcat.SubCategoryVM.Insert(0, new SubCatVM() { SubCategoryID = 0, Name = "--Select--" });
                cmbSubCategory.DataSource = subcat.SubCategoryVM;
                cmbSubCategory.DisplayMember = "Name";
                cmbSubCategory.ValueMember = "SubCategoryID";
            }
            else
            {
                cmbSubCategory.DataSource = null;
            }
        }

        private void LoadCategoryCombo()
        {
            var cat = _serviceCategory.GetAllCategory();
            if (cat.ResponseCode == "000")
            {
                cat.CategoryVM.Insert(0, new CategoryVM() { CategoryID = 0, CategoryName = "--Select--" });
                cmbCategory.DataSource = cat.CategoryVM;
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
            }
            else
            {
                cmbCategory.DataSource = null;
            }
        }

        private void LoadSearchSubCategoryCombo()
        {
            var subcat = _serviceCategory.GetAllSubCategory();
            if (subcat.ResponseCode == "000")
            {
                subcat.SubCategoryVM.Insert(0, new SubCatVM() { SubCategoryID = 0, Name = "--Select--" });
                cmbSearchSubCat.DataSource = subcat.SubCategoryVM;
                cmbSearchSubCat.DisplayMember = "Name";
                cmbSearchSubCat.ValueMember = "SubCategoryID";
            }
            else
            {
                cmbSearchSubCat.DataSource = null;
            }
        }

        private void LoadSearchCategoryCombo()
        {
            var cat = _serviceCategory.GetAllCategory();
            if (cat.ResponseCode == "000")
            {
                cat.CategoryVM.Insert(0, new CategoryVM() { CategoryID = 0, CategoryName = "--Select--" });
                cmbSearchCat.DataSource = cat.CategoryVM;
                cmbSearchCat.DisplayMember = "CategoryName";
                cmbSearchCat.ValueMember = "CategoryID";
            }
            else
            {
                cmbSearchCat.DataSource = null;
            }
        }

        private void InitializeProductGrid()
        {
            dgvProduct.DataSource = null;

            //Set AutoGenerateColumns False
            dgvProduct.AutoGenerateColumns = false;

            ////Set Columns Count
            dgvProduct.ColumnCount = 10;

            ////Add Columns
            dgvProduct.Columns[0].HeaderText = "ProductID";
            dgvProduct.Columns[0].Name = "ProductID";
            dgvProduct.Columns[0].DataPropertyName = "ProductID";
            dgvProduct.Columns[0].Visible = false;

            dgvProduct.Columns[1].HeaderText = "Product Name"; // header text
            dgvProduct.Columns[1].Name = "ProductName"; // name  
            dgvProduct.Columns[1].DataPropertyName = "ProductName"; // field name

            dgvProduct.Columns[2].HeaderText = "Product Code"; // header text
            dgvProduct.Columns[2].Name = "ProductCode"; // name  
            dgvProduct.Columns[2].DataPropertyName = "ProductCode"; // field name

            dgvProduct.Columns[3].HeaderText = "Category";
            dgvProduct.Columns[3].Name = "CategoryName";
            dgvProduct.Columns[3].DataPropertyName = "CategoryName";

            dgvProduct.Columns[4].HeaderText = "Sub Category";
            dgvProduct.Columns[4].Name = "SubCategoryName";
            dgvProduct.Columns[4].DataPropertyName = "SubCategoryName";

            dgvProduct.Columns[5].HeaderText = "Unit Price";
            dgvProduct.Columns[5].Name = "UnitSalesPrice";
            dgvProduct.Columns[5].DataPropertyName = "UnitSalesPrice";

            dgvProduct.Columns[6].HeaderText = "Vat";
            dgvProduct.Columns[6].Name = "SPVat";
            dgvProduct.Columns[6].DataPropertyName = "SPVat";

            dgvProduct.Columns[7].HeaderText = "Other Charge";
            dgvProduct.Columns[7].Name = "SPOtherCharge";
            dgvProduct.Columns[7].DataPropertyName = "SPOtherCharge";

            dgvProduct.Columns[8].HeaderText = "Total Sales Price";
            dgvProduct.Columns[8].Name = "TotalSalesPrice";
            dgvProduct.Columns[8].DataPropertyName = "TotalSalesPrice";

            dgvProduct.Columns[9].HeaderText = "Available Qty";
            dgvProduct.Columns[9].Name = "AvaliableQty";
            dgvProduct.Columns[9].DataPropertyName = "AvaliableQty";

            LoadGridView();
        }

        private void LoadGridView()
        {
            try
            {
                _serviceProduct = new ProductBLL();
                _lstProduct = _serviceProduct.GetAllProducts();

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = _lstProduct;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            long categodyId = 0;
            try
            {
               categodyId = Convert.ToInt64(cmbCategory.SelectedValue);
            }
            catch (Exception)
            { 
               
            }
            
            var subcat = _serviceCategory.GetAllSubCategoryByCategoryId(categodyId);
            if (subcat.ResponseCode == "000")
            {
                subcat.SubCategoryVM.Insert(0, new SubCatVM() { SubCategoryID = 0, Name = "--Select--" });
                cmbSubCategory.DataSource = subcat.SubCategoryVM;
                cmbSubCategory.DisplayMember = "Name";
                cmbSubCategory.ValueMember = "SubCategoryID";
            }
            else
            {
                cmbSubCategory.DataSource = null;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Please Enter Product Name");
                return;
            }
            if (cmbCategory.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Please Select Category");
                return;
            }
            if (cmbSubCategory.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Sub-Category");
                return;
            }
            if (String.IsNullOrEmpty(txtProductCode.Text))
            {
                MessageBox.Show("Please Enter Product Code");
                return;
            }

            if (String.IsNullOrEmpty(txtTotalPrice.Text))
            {
                MessageBox.Show("Please Calculate Total Price");
                return;
            }

            ProductViewModel productVM=new ProductViewModel();
            productVM.ProductName = txtProductName.Text;
            productVM.ProductCode = txtProductCode.Text;
            productVM.CategoryID = (long)cmbCategory.SelectedValue;
            productVM.SubCategoryID = (long)cmbSubCategory.SelectedValue;
            productVM.UnitID = (long)cmbUnit.SelectedValue;
            productVM.UnitSalesPrice = Convert.ToDecimal(txtUnitSalePrice.Text);
            productVM.SPVat = Convert.ToDecimal(txtVat.Text);
            productVM.SPOtherCharge = Convert.ToDecimal(txtOtherCharge.Text);
            productVM.Discount = Convert.ToDecimal(txtDiscount.Text);
            productVM.TotalSalesPrice = Convert.ToDecimal(txtTotalPrice.Text);

            string msg=_serviceProduct.InsertProduct(productVM);
            MessageBox.Show(msg);
            LoadGridView();
            ClearControl();
        }

        private void ClearControl()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            cmbCategory.SelectedIndex = 0;
            LoadSubCategoryCombo();
            cmbSubCategory.SelectedIndex = 0;
            txtDescription.Text = string.Empty;
            cmbUnit.SelectedIndex = 0;
            txtUnitSalePrice.Text = string.Empty;
            txtVat.Text = string.Empty;
            txtOtherCharge.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
            LoadGridView();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal unitsalesprice = Convert.ToDecimal(txtUnitSalePrice.Text);
            decimal vat = Convert.ToDecimal(txtVat.Text);
            decimal otherCharge = Convert.ToDecimal(txtOtherCharge.Text);

            decimal totalPrice = unitsalesprice + vat + otherCharge;

            txtTotalPrice.Text = totalPrice.ToString();
        }

    
       
      
    }
}
