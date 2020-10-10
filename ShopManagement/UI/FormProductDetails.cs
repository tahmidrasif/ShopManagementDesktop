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
        public FormProductDetails()
        {
            _serviceCategory = new CategoryEntryBLL();
            InitializeComponent();
            InitializeProductGrid();
            LoadSearchCategoryCombo();
            LoadSearchSubCategoryCombo();
            LoadCategoryCombo();
            LoadSubCategoryCombo();
        }

        private void LoadSubCategoryCombo()
        {
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
            long categodyId= Convert.ToInt64(cmbCategory.SelectedValue);
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

       
      
    }
}
