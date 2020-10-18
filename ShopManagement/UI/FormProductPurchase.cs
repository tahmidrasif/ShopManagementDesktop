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
    public partial class FormProductPurchase : Form
    {
        public List<ProductViewModel> _lstProduct = null;
        private ProductBLL _serviceProduct = null;
        private CategoryEntryBLL _serviceCategory = null;
        private UnitBLL _serviceUnit = null;
        private long porductID = 0;

        public FormProductPurchase()
        {
            InitializeComponent();
            _serviceProduct = new ProductBLL();
            LoadSearchProductCombo();
        }

        private void LoadSearchProductCombo()
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("Category Name", "Name");
                dictionary.Add("Category Code", "Code");

                cmbSearch.DataSource = new BindingSource(dictionary, null);
                cmbSearch.DisplayMember = "Key";
                cmbSearch.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            var searchkey = txtSearch.Text;
            ClearControl();
            if (String.IsNullOrEmpty(searchkey))
            {
                MessageBox.Show("Please Enter Search Key");
                return;
            }
            else
            {
                var productList = _serviceProduct.GetAllProducts();
                searchkey = searchkey.ToLower();
                if (cmbSearch.SelectedValue == "Name")
                {
                    productList = productList.Where(x => x.ProductName.ToLower().Contains(searchkey)).ToList();
                    if (productList.Count == 1)
                    {
                        foreach (var product in productList)
                        {
                            txtProductCode.Text = product.ProductCode;
                            txtProductName.Text = product.ProductName;
                            txtQty.Text = product.AvaliableQty.ToString();
                        }
                        //
                    }
                    else if (productList.Count>1)
                    {
                        using (FormProductVMSearchList frmProdList = new FormProductVMSearchList(productList))
                        {
                            frmProdList.ShowDialog();
                            if (frmProdList.objProd != null)
                            {
                                var prod = frmProdList.objProd;

                                txtProductName.Text = prod.ProductName;
                                txtProductCode.Text = prod.ProductCode;
                                txtQty.Text=prod.AvaliableQty.ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Products Found");
                        return;
                    }
                }
                if (cmbSearch.SelectedValue == "Code")
                {
                    productList = productList.Where(x => x.ProductCode.Contains(searchkey)).ToList();
                    if (productList.Count == 1)
                    {
                        foreach (var product in productList)
                        {
                            txtProductCode.Text = product.ProductCode;
                            txtProductName.Text = product.ProductName;
                            txtQty.Text = product.AvaliableQty.ToString();
                        }
                        //
                    }
                    else if (productList.Count > 1)
                    {
                        using (FormProductVMSearchList frmProdList = new FormProductVMSearchList(productList))
                        {
                            frmProdList.ShowDialog();
                            if (frmProdList.objProd != null)
                            {
                                var prod = frmProdList.objProd;

                                txtProductName.Text = prod.ProductName;
                                txtProductCode.Text = prod.ProductCode;
                                txtQty.Text = prod.AvaliableQty.ToString();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Products Found");
                        return;
                    }
                }
            }

        }

        private void ClearControl()
        {
            txtSearch.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtTotalUnit.Text = "0";
            txtUnitPurchasePrice.Text = "0";
            txtVat.Text = "0";
            txtOtherCharge.Text = "0";
            txtDiscount.Text = "0";
            txtTotalPurchasePrice.Text = "0";
            
        }
    }
}
