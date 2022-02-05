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
        private VendorBLL _serviceVendor = null;
        private ProductPurchaseBLL _serviceProdPurchase = null;
        List<CartVM> cartVMList = new List<CartVM>();
        EnumarationBLL _serviceEnum = null;
        DataTable dtCart;
        DataGridViewRow dgvRow;
        private long productID = 0;
        private long existingOrderId = 0;

        public FormProductPurchase(long? orderId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _serviceProduct = new ProductBLL();
            _serviceVendor = new VendorBLL();
            _serviceEnum = new EnumarationBLL();
            _serviceProdPurchase = new ProductPurchaseBLL();
            LoadSearchProductCombo();
            LoadPaymentTypeCombo();
            LoadVendorCombo();
            CreateCartDataTable();
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;

            if (orderId != null && orderId > 0)
            {
                existingOrderId = orderId.Value;
                LoadExistingOrder(orderId);
            }
        }

        private void LoadExistingOrder(long? orderId)
        {
            if (orderId != null && orderId > 0)
            {
                PurchaseOrderVM poVM = _serviceProdPurchase.GetPurchaseOrderById(orderId);
                if (poVM == null)
                {
                    MessageBox.Show("No Order is found");
                    this.Close();
                    return;
                }
                DataTable poDetails = _serviceProdPurchase.GetPODetailsByPOID(orderId.Value);
                if (poDetails.Rows.Count > 0)
                {
                    dgvProduct.DataSource = poDetails;
                    dtCart = poDetails;
                    //CalculateFinal();
                    txtPaymentTotal.Text = poVM.SubTotal.ToString();
                    txtPaymentTotalVat.Text = poVM.TotalVat.ToString();

                    txtPaymentDiscount.Text = poVM.TotalDiscount.ToString();
                    txtPaymentOtherCharge.Text = poVM.TotalOtherCharge.ToString();
                    txtAdditionalDiscount.Text = poVM.AdditionalDiscount.ToString();
                    txtAdvancedAmount.Text = poVM.TotalAdvance.ToString();

                    txtGrandTotal.Text = poVM.GrandTotal.ToString();
                    txtPaymentDeliveryCharge.Text = poVM.TotalDeliveryCharge.ToString();
                    txtPaymentDue.Text = poVM.TotalDue.ToString();
                    cmbVendor.SelectedValue = poVM.VendorID;
                    txtPaymentRemarks.Text = poVM.Remarks;
                }
            }
        }

        private void LoadVendorCombo()
        {
            IList<VendorViewModel> vendors = _serviceVendor.GetAllVendors();
            if (vendors != null && vendors.Count > 0)
            {
                cmbVendor.DataSource = vendors;
                cmbVendor.DisplayMember = "VendorName";
                cmbVendor.ValueMember = "VendorId";
            }
        }

        private void LoadSearchProductCombo()
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("Product Name", "Name");
                dictionary.Add("Product Code", "Code");

                cmbSearch.DataSource = new BindingSource(dictionary, null);
                cmbSearch.DisplayMember = "Key";
                cmbSearch.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        private void LoadPaymentTypeCombo()
        {
            try
            {
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("No Payment", "N/A");
                dictionary.Add("Cash", "Cash");
                dictionary.Add("Cheque", "Cheque");

                cmbPaymentType.DataSource = new BindingSource(dictionary, null);
                cmbPaymentType.DisplayMember = "Key";
                cmbPaymentType.ValueMember = "Value";
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
                //var productList = _serviceProduct.GetAllProducts();
                searchkey = searchkey.ToLower();
                if (cmbSearch.SelectedValue == "Name")
                {
                    var productList = _serviceProduct.GetAllProductsByProductName(searchkey);
                    if (productList.Count == 1)
                    {
                        foreach (var product in productList)
                        {
                            txtProductCode.Text = product.ProductCode;
                            txtProductName.Text = product.ProductName;
                            txtQty.Text = product.AvaliableQty.ToString();
                            txtUnitPurchasePrice.Text = product.UnitPurchasePrice.ToString();
                            txtVat.Text = product.PPVat.ToString();
                            //txtOtherCharge.Text = product.PPOtherCharge.ToString();

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
                                txtUnitPurchasePrice.Text = prod.UnitPurchasePrice.ToString();
                                txtVat.Text = prod.PPVat.ToString();
                                //txtOtherCharge.Text = prod.PPOtherCharge.ToString();

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
                    var productList = _serviceProduct.GetAllProductsByProductCode(searchkey);
                    if (productList.Count == 1)
                    {
                        foreach (var product in productList)
                        {
                            txtProductCode.Text = product.ProductCode;
                            txtProductName.Text = product.ProductName;
                            txtQty.Text = product.AvaliableQty.ToString();
                            txtUnitPurchasePrice.Text = product.UnitPurchasePrice.ToString();
                            txtVat.Text = product.PPVat.ToString();
                            //txtOtherCharge.Text = product.PPOtherCharge.ToString();

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
                                txtUnitPurchasePrice.Text = prod.UnitPurchasePrice.ToString();
                                txtVat.Text = prod.PPVat.ToString();
                                //txtOtherCharge.Text = prod.PPOtherCharge.ToString();

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
            //txtOtherCharge.Text = "0";
            txtDiscount.Text = "0";
            txtSubTotalPurchasePrice.Text = String.Empty;
            txtQty.Text = string.Empty;
            productID = 0;
        }

        private void ClearPaymentControl()
        {
            dgvProduct.DataSource = null;
            txtPaymentTotal.Text = "0";
            txtPaymentTotalVat.Text = "0";
            txtPaymentDiscount.Text = "0";
            txtPaymentOtherCharge.Text = "0";
            txtAdditionalDiscount.Text = "0";
            txtAdvancedAmount.Text = "0";
            txtPaymentDue.Text = "0";
            txtPaymentRemarks.Text = "";
            cmbPaymentType.SelectedIndex = 0;
            cmbVendor.SelectedIndex = 0;
            txtGrandTotal.Text = "0";
            dtCart = null;
            existingOrderId = 0;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (productID == 0)
                {
                    return;
                }

                if (Convert.ToDecimal(txtTotalUnit.Text) <= 0)
                {
                    MessageBox.Show("Please Key in Total Unit");
                    return;
                }
                if (string.IsNullOrEmpty(txtSubTotalPurchasePrice.Text))
                {
                    MessageBox.Show("Please Calculate Total Price");
                    return;
                }

                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    long gvProdId = Convert.ToInt64(row.Cells["ProductID"].Value);
                    if (gvProdId == productID)
                    {
                        DialogResult dr = MessageBox.Show("This product is already added in the cart. Do you want to add more?", "Alert", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                {
                                    decimal existingqauntity = Convert.ToDecimal(row.Cells["Quantity"].Value);
                                    decimal newQantity = Convert.ToDecimal(txtTotalUnit.Text);
                                    txtTotalUnit.Text = (existingqauntity + newQantity).ToString();
                                    int rowIndex = row.Index;
                                    dgvProduct.Rows.RemoveAt(rowIndex);
                                }
                                break;
                            case DialogResult.No:
                                ClearControl();
                                break;
                        }
                    }

                }

                DataRow drCart = dtCart.NewRow();

                drCart["ProductID"] = productID;
                drCart["ProductName"] = txtProductName.Text;
                drCart["ProductCode"] = txtProductCode.Text;
                drCart["AvailableQty"] = txtQty.Text;
                drCart["UnitPurchasePrice"] = Convert.ToDecimal(txtUnitPurchasePrice.Text);
                drCart["PPVat"] = Convert.ToDecimal(txtVat.Text);
                drCart["Quantity"] = Convert.ToDecimal(txtTotalUnit.Text);
                //drCart["PPOtherCharge"] = Convert.ToDecimal(txtOtherCharge.Text);
                drCart["DiscountAmt"] = Convert.ToDecimal(txtDiscount.Text);
                drCart["SubTotal"] = Convert.ToDecimal(txtSubTotalPurchasePrice.Text);


                dtCart.Rows.Add(drCart);

                dgvProduct.DataSource = dtCart;

                CalculateFinal();
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
            //dtCart.Columns.Add("PPOtherCharge".ToString());
            dtCart.Columns.Add("DiscountAmt".ToString());
            dtCart.Columns.Add("SubTotal".ToString());


            dgvProduct.DataSource = null;
            //Set AutoGenerateColumns False
            dgvProduct.AutoGenerateColumns = false;

            //Set Columns Count
            dgvProduct.ColumnCount = 9;

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

            //dgvProduct.Columns[7].HeaderText = "Other Charge";
            //dgvProduct.Columns[7].Name = "PPOtherCharge";
            //dgvProduct.Columns[7].DataPropertyName = "PPOtherCharge";


            dgvProduct.Columns[7].HeaderText = "Discount";
            dgvProduct.Columns[7].Name = "DiscountAmt";
            dgvProduct.Columns[7].DataPropertyName = "DiscountAmt";

            dgvProduct.Columns[8].HeaderText = "Total";
            dgvProduct.Columns[8].Name = "SubTotal";
            dgvProduct.Columns[8].DataPropertyName = "SubTotal";



            //and on my constructor I set gridview.DataSource=Datatable;
        }



        private void Calculate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtUnitPurchasePrice.Text))
                {
                    MessageBox.Show("Please Key In Unit Purchase Price");
                    return;
                }
                if (string.IsNullOrEmpty(txtTotalUnit.Text))
                {
                    MessageBox.Show("Please Key In Unit");
                    return;
                }

                decimal unitparchaseprice = Convert.ToDecimal(txtUnitPurchasePrice.Text);
                decimal totalUnit = Convert.ToDecimal(txtTotalUnit.Text);
                decimal vat = Convert.ToDecimal(txtVat.Text);
                //decimal otherCharge = Convert.ToDecimal(txtOtherCharge.Text);
                decimal discount = Convert.ToDecimal(txtDiscount.Text);
                decimal totalPrice = (unitparchaseprice * totalUnit) + vat - discount;

                txtSubTotalPurchasePrice.Text = totalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTotalUnit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalUnit.Text))
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtTotalUnit.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    txtTotalUnit.Text = txtTotalUnit.Text.Remove(txtTotalUnit.Text.Length - 1);
                    return;
                }
                Calculate();
            }
        }

        private void txtUnitPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }




        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsValidPurchase())
                {
                    PurchaseOrderVM opvm;
                    if (existingOrderId == 0)
                    {
                        opvm = new PurchaseOrderVM();
                        opvm.POrderCode = "PO-" + DateTime.Now.ToString("yyMMddhhmmss");
                        opvm.OrderType = "In-House";
                        opvm.OrderDate = DateTime.Now;
                        opvm.CreatedBy = "tahmid";
                        opvm.CreatedOn = DateTime.Now;
                        opvm.IsActive = true;
                    }
                    else
                    {
                        opvm = _serviceProdPurchase.GetPurchaseOrderById(existingOrderId);
                        opvm.UpdatedBy = "tahmid";
                        opvm.UpdatedOn = DateTime.Now;
                    }



                    opvm.VendorID = Convert.ToInt64(cmbVendor.SelectedValue);
                    var status = _serviceEnum.GetAllByTypeDescription("PO Status")?.FirstOrDefault(x => x.Name == "Pendig")?.EnumID;
                    opvm.Status = status == null ? 0 : status;


                    opvm.SubTotal = Convert.ToDecimal(txtPaymentTotal.Text);
                    opvm.IsVatIncluded = false;
                    opvm.TotalVat = Convert.ToDecimal(txtPaymentTotalVat.Text);
                    opvm.TotalDiscount = Convert.ToDecimal(txtPaymentDiscount.Text);
                    opvm.AdditionalDiscount = Convert.ToDecimal(txtAdditionalDiscount.Text);
                    opvm.TotalOtherCharge = Convert.ToDecimal(txtPaymentOtherCharge.Text);
                    opvm.TotalDeliveryCharge = Convert.ToDecimal(txtPaymentDeliveryCharge.Text);
                    opvm.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
                    opvm.TotalAdvance = Convert.ToDecimal(txtAdvancedAmount.Text);
                    opvm.TotalDue = Convert.ToDecimal(txtPaymentDue.Text);
                    opvm.Remarks = txtPaymentRemarks.Text;

                    opvm.PurchaseOrderDetails = new List<PurchaseOrderDetailsVM>();

                    foreach (DataGridViewRow row in dgvProduct.Rows)
                    {

                        PurchaseOrderDetailsVM oDetail = new PurchaseOrderDetailsVM();
                        oDetail.ProductID = Convert.ToInt64(row.Cells["ProductID"].Value);
                        oDetail.Quantity = Convert.ToInt64(row.Cells["Quantity"].Value);
                        oDetail.UnitPrice = Convert.ToDecimal(row.Cells["UnitPurchasePrice"].Value);
                        oDetail.TotalDiscount = Convert.ToDecimal(row.Cells["DiscountAmt"].Value);
                        oDetail.TotalVat = Convert.ToDecimal(row.Cells["PPVat"].Value);
                        //oDetail.OtherCharge = Convert.ToDecimal(row.Cells["PPOtherCharge"].Value);
                        oDetail.SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                        oDetail.CreatedBy = "Tahmid";
                        oDetail.CreatedOn = DateTime.Now;
                        oDetail.IsActive = true;


                        opvm.PurchaseOrderDetails.Add(oDetail);
                    }

                    string msg = _serviceProdPurchase.PlaceOrder(opvm);
                    if (msg == "Success")
                    {
                        MessageBox.Show("Product Orderd Sucessfully. In Pending Status");
                        ClearPaymentControl();
                        CreateCartDataTable();
                    }
                    else
                    {
                        MessageBox.Show(msg);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalculateFinal()
        {
            try
            {

                decimal totalPrice = 0;
                decimal totalvat = 0;
                decimal totaldiscount = 0;

                foreach (DataGridViewRow row in dgvProduct.Rows)
                {
                    long productId = Convert.ToInt64(row.Cells["ProductID"].Value);
                    int qauntity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    decimal unitprice = Convert.ToDecimal(row.Cells["UnitPurchasePrice"].Value);
                    decimal vat = Convert.ToDecimal(row.Cells["PPVat"].Value);
                    decimal discount = Convert.ToDecimal(row.Cells["DiscountAmt"].Value);

                    decimal totalUnitPrice = qauntity * unitprice;
                    totalPrice += totalUnitPrice;
                    totalvat += vat;
                    totaldiscount += discount;

                }



                txtPaymentTotal.Text = totalPrice.ToString();
                txtPaymentTotalVat.Text = totalvat.ToString();

                txtPaymentDiscount.Text = totaldiscount.ToString();
                decimal totalOtherCharge = Convert.ToDecimal(txtPaymentOtherCharge.Text);
                decimal additionalDiscount = Convert.ToDecimal(txtAdditionalDiscount.Text);
                decimal totalPay = Convert.ToDecimal(txtAdvancedAmount.Text);
                decimal deliverCharge = Convert.ToDecimal(txtPaymentDeliveryCharge.Text);
                decimal grandTotal = (totalPrice + totalvat + -totaldiscount + totalOtherCharge + deliverCharge - additionalDiscount);
                txtGrandTotal.Text = grandTotal.ToString();
                decimal totalDue = grandTotal - totalPay;
                txtPaymentDue.Text = totalDue.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValidPurchase()
        {
            try
            {
                decimal grandtotal = Convert.ToDecimal(txtGrandTotal.Text);
                decimal due = Convert.ToDecimal(txtPaymentDue.Text);

                if (grandtotal <= 0)
                {
                    MessageBox.Show("Grand Total must be greater than zero");
                    return false;
                }
                if (due < 0)
                {
                    MessageBox.Show("Due Can Not Be Negetive");
                    return false;
                }
                if (dgvProduct.Rows.Count <= 0)
                {
                    MessageBox.Show("Please add products in cart");
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }


            return true;
        }



        private void txtPaymentOtherCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateFinal();
        }

        private void txtAdditionalDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateFinal();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want to remove this item?", "Alert", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        if (dgvProduct.SelectedRows.Count == 1)
                        {
                            DataGridViewRow currentRow = dgvProduct.SelectedRows[0];
                            string productId = this.dgvProduct.SelectedRows[0].Cells["ProductCode"].Value?.ToString();
                            if (string.IsNullOrEmpty(productId))
                            {
                                MessageBox.Show("Please select correct Item");
                                return;
                            }
                            int rowIndex = dgvProduct.CurrentCell.RowIndex;
                            dgvProduct.Rows.RemoveAt(rowIndex);

                            CalculateFinal();
                            MessageBox.Show("Item Removed Successfully");
                        }
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void txtAdvancedAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateFinal();
        }

        private void txtPaymentDeliveryCharge_TextChanged(object sender, EventArgs e)
        {
            CalculateFinal();
        }

        //private void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        //{
        //    CalculateFinal();
        //}
    }
}
