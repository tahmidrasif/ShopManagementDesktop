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
        List<CartVM> cartVMList = new List<CartVM>();
        DataTable dtCart;
        DataGridViewRow dgvRow;
        private long productID = 0;

        public FormProductPurchase()
        {
            InitializeComponent();
            _serviceProduct = new ProductBLL();
            LoadSearchProductCombo();
            CreateCartDataTable();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;

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
                            productID = product.ProductID;//Global
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
                                productID = prod.ProductID;//Global
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
            txtSubTotalPurchasePrice.Text = String.Empty;
            txtQty.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtSubTotalPurchasePrice.Text))
                {
                    MessageBox.Show("Please Calculate Total Price");
                    return;
                }

                DataRow drCart = dtCart.NewRow();

                drCart["ProductID"] = productID;
                drCart["ProductName"] = txtProductName.Text;
                drCart["ProductCode"] = txtProductCode.Text;
                drCart["AvailableQty"] = txtQty.Text;
                drCart["UnitPurchasePrice"] = Convert.ToDecimal(txtUnitPurchasePrice.Text);
                drCart["PPVat"] = Convert.ToDecimal(txtVat.Text);
                drCart["Quantity"] = Convert.ToDecimal(txtTotalUnit.Text);
                drCart["PPOtherCharge"] = Convert.ToDecimal(txtOtherCharge.Text);
                drCart["DiscountAmt"] = Convert.ToDecimal(txtDiscount.Text);
                drCart["SubTotal"] = Convert.ToDecimal(txtSubTotalPurchasePrice.Text);


                dtCart.Rows.Add(drCart);

                dgvProduct.DataSource = dtCart;

                CartVM cartRequest = new CartVM();

                cartRequest.ProductID = productID;
                cartRequest.ProductName = txtProductName.Text;
                cartRequest.ProductCode = txtProductCode.Text;
                cartRequest.UnitSalesPrice = Convert.ToDecimal(txtTotalPrice.Text);
                cartRequest.SPVat = Convert.ToDecimal(txtVat.Text);
                cartRequest.Quantity = Convert.ToDecimal(txtTotalUnit.Text);
                cartRequest.SPOtherCharge = Convert.ToDecimal(txtOtherCharge.Text);
                cartRequest.DiscountAmt = Convert.ToDecimal(txtDiscount.Text);
                cartRequest.SubTotal = Convert.ToDecimal(txtSubTotalPurchasePrice.Text);

                cartVMList.Add(cartRequest);

                decimal totalPrice = cartVMList.Sum(x => x.UnitSalesPrice);
                decimal totalvat = cartVMList.Sum(x => x.SPVat);
                decimal othercharge = cartVMList.Sum(x => x.SPOtherCharge);
                decimal discount = cartVMList.Sum(x => x.DiscountAmt);

                txtPaymentTotal.Text = totalPrice.ToString();
                txtPaymentTotalVat.Text = totalvat.ToString();
                txtPaymentOtherCharge.Text = othercharge.ToString();
                txtPaymentDiscount.Text = discount.ToString();

                txtPaymentGrandTotal.Text = (totalPrice + totalvat + othercharge - discount).ToString();

                ClearControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error due to: " + ex.Message);
                //throw;
            }

        }

        private void CreateCartDataTable()
        {
            dtCart = new DataTable(); //here insntianting the form level table. 

            dtCart.Columns.Add("ProductID".ToString());
            dtCart.Columns.Add("ProductName".ToString());
            dtCart.Columns.Add("ProductCode".ToString());
            dtCart.Columns.Add("AvailableQty".ToString());
            dtCart.Columns.Add("PPVat".ToString());
            dtCart.Columns.Add("UnitPurchasePrice".ToString());
            dtCart.Columns.Add("Quantity".ToString());
            dtCart.Columns.Add("PPOtherCharge".ToString());
            dtCart.Columns.Add("DiscountAmt".ToString());
            dtCart.Columns.Add("SubTotal".ToString());


            dgvProduct.DataSource = null;
            //Set AutoGenerateColumns False
            dgvProduct.AutoGenerateColumns = false;

            //Set Columns Count
            dgvProduct.ColumnCount = 10;

            //Add Columns
            dgvProduct.Columns[0].HeaderText = "ProductID";
            dgvProduct.Columns[0].Name = "ProductID";
            dgvProduct.Columns[0].DataPropertyName = "ProductID";
            dgvProduct.Columns[0].Visible = false;

            dgvProduct.Columns[1].HeaderText = "Product Name"; // header text
            dgvProduct.Columns[1].Name = "ProductName"; // name  
            dgvProduct.Columns[1].DataPropertyName = "ProductName"; // field name

            dgvProduct.Columns[2].HeaderText = "Product Code";
            dgvProduct.Columns[2].Name = "ProductCode";
            dgvProduct.Columns[2].DataPropertyName = "ProductCode";

            dgvProduct.Columns[3].HeaderText = "Available Qty";
            dgvProduct.Columns[3].Name = "AvailableQty";
            dgvProduct.Columns[3].DataPropertyName = "AvailableQty";
            //dgvCart.Columns[3].Visible = false;


            dgvProduct.Columns[4].HeaderText = "Unit Purchase Price";
            dgvProduct.Columns[4].Name = "UnitPurchasePrice";
            dgvProduct.Columns[4].DataPropertyName = "UnitPurchasePrice";

            dgvProduct.Columns[5].HeaderText = "Qty";
            dgvProduct.Columns[5].Name = "Quantity";
            dgvProduct.Columns[5].DataPropertyName = "Quantity";

            dgvProduct.Columns[6].HeaderText = "Vat";
            dgvProduct.Columns[6].Name = "PPVat";
            dgvProduct.Columns[6].DataPropertyName = "PPVat";

            dgvProduct.Columns[7].HeaderText = "Other Charge";
            dgvProduct.Columns[7].Name = "PPOtherCharge";
            dgvProduct.Columns[7].DataPropertyName = "PPOtherCharge";


            dgvProduct.Columns[8].HeaderText = "Discount";
            dgvProduct.Columns[8].Name = "DiscountAmt";
            dgvProduct.Columns[8].DataPropertyName = "DiscountAmt";

            dgvProduct.Columns[9].HeaderText = "Total";
            dgvProduct.Columns[9].Name = "SubTotal";
            dgvProduct.Columns[9].DataPropertyName = "SubTotal";



            //and on my constructor I set gridview.DataSource=Datatable;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUnitPurchasePrice.Text))
                {
                    MessageBox.Show("Please Key In Unit Purchase Price");
                    return;
                }

                decimal unitparchaseprice = Convert.ToDecimal(txtUnitPurchasePrice.Text);
                decimal totalUnit = Convert.ToDecimal(txtTotalUnit.Text);
                decimal vat = Convert.ToDecimal(txtVat.Text);
                decimal otherCharge = Convert.ToDecimal(txtOtherCharge.Text);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal totalPrice = (unitparchaseprice * totalUnit) + vat + otherCharge - discount;

                txtSubTotalPurchasePrice.Text = totalPrice.ToString();
            }
            catch (Exception ex)
            {

            }

        }

        private void txtTotalUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var totalunit = Convert.ToDecimal(txtTotalUnit.Text);
                var unitPrice = Convert.ToDecimal(txtUnitPurchasePrice.Text);

                var totalPrice = totalunit * unitPrice;

                txtTotalPrice.Text = totalPrice.ToString();
            }
            catch (Exception Ex)
            {

                //throw;
            }

        }

        private void txtUnitPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var totalunit = Convert.ToDecimal(txtTotalUnit.Text);
                var unitPrice = Convert.ToDecimal(txtUnitPurchasePrice.Text);

                var totalPrice = totalunit * unitPrice;

                txtTotalPrice.Text = totalPrice.ToString();
            }
            catch (Exception Ex)
            {

                //throw;
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    //if(dgvCategory.Rows.Count>0)
            //    {
                    
            //        btnAdd.Enabled = false;
            //        btnUpdate.Enabled = true;
            //        btnRemove.Enabled = true;


            //        dgvRow = dgvProduct.Rows[e.RowIndex];
            //        dgvProduct.CurrentRow.Selected = true;


            //        productID = Convert.ToInt64(dgvProduct.Rows[e.RowIndex].Cells[0].Value);
            //        txtProductName.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].FormattedValue.ToString();
            //        txtCategoryCode.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryCode"].FormattedValue.ToString();
            //        txtCategoryDesc.Text = dgvCategory.Rows[e.RowIndex].Cells["Description"].FormattedValue.ToString();


            //    }
            //}
            //catch (Exception)
            //{


            //}
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {

        }
    }
}
