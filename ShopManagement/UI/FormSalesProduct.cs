using ShopManagement.BLL;
using ShopManagement.BLL.Request;
using ShopManagement.BLL.Response;
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
    public partial class FormSalesProduct : Form
    {
        SalesProductBLL serviceSalesProduct;
        EnumarationBLL enumarationBLL;
        DataTable dtCart;
        public long productID;
        public FormSalesProduct()
        {
            InitializeComponent();
            serviceSalesProduct = new SalesProductBLL();
            enumarationBLL = new EnumarationBLL();
            LoadComboBox();
            ControlEnableDisable();
            CreateCartDataTable();
        }

        private void CreateCartDataTable()
        {
            dtCart = new DataTable(); //here insntianting the form level table. 

            dtCart.Columns.Add("ProductID".ToString());
            dtCart.Columns.Add("ProductName".ToString());
            dtCart.Columns.Add("ProductCode".ToString());
            dtCart.Columns.Add("Unit".ToString());
            dtCart.Columns.Add("SPVat".ToString());
            dtCart.Columns.Add("UnitSalesPrice".ToString());
            dtCart.Columns.Add("Quantity".ToString());
            dtCart.Columns.Add("SPOtherCharge".ToString());
            dtCart.Columns.Add("DiscountAmt".ToString());
            dtCart.Columns.Add("SubTotal".ToString());
            dtCart.Columns.Add("UnitID".ToString());

 
            dgvCart.DataSource = null;
            //Set AutoGenerateColumns False
            dgvCart.AutoGenerateColumns = false;

            //Set Columns Count
            dgvCart.ColumnCount = 11;

            //Add Columns
            dgvCart.Columns[0].HeaderText = "ProductID";
            dgvCart.Columns[0].Name = "ProductID";
            dgvCart.Columns[0].DataPropertyName = "ProductID";
            dgvCart.Columns[0].Visible = false;

            dgvCart.Columns[1].HeaderText = "Product Name"; // header text
            dgvCart.Columns[1].Name = "ProductName"; // name  
            dgvCart.Columns[1].DataPropertyName = "ProductName"; // field name

            dgvCart.Columns[2].HeaderText = "Product Code";
            dgvCart.Columns[2].Name = "ProductCode";
            dgvCart.Columns[2].DataPropertyName = "ProductCode";

            dgvCart.Columns[3].HeaderText = "Unit";
            dgvCart.Columns[3].Name = "Unit";
            dgvCart.Columns[3].DataPropertyName = "Unit";
            //dgvCart.Columns[3].Visible = false;


            dgvCart.Columns[4].HeaderText = "Sales Price";
            dgvCart.Columns[4].Name = "UnitSalesPrice";
            dgvCart.Columns[4].DataPropertyName = "UnitSalesPrice";

            dgvCart.Columns[5].HeaderText = "Qty";
            dgvCart.Columns[5].Name = "Quantity";
            dgvCart.Columns[5].DataPropertyName = "Quantity";

            dgvCart.Columns[6].HeaderText = "Vat";
            dgvCart.Columns[6].Name = "SPVat";
            dgvCart.Columns[6].DataPropertyName = "SPVat";

            dgvCart.Columns[7].HeaderText = "Other Charge";
            dgvCart.Columns[7].Name = "SPOtherCharge";
            dgvCart.Columns[7].DataPropertyName = "SPOtherCharge";


            dgvCart.Columns[8].HeaderText = "Discount";
            dgvCart.Columns[8].Name = "DiscountAmt";
            dgvCart.Columns[8].DataPropertyName = "DiscountAmt";

            dgvCart.Columns[9].HeaderText = "Total";
            dgvCart.Columns[9].Name = "SubTotal";
            dgvCart.Columns[9].DataPropertyName = "SubTotal";

            dgvCart.Columns[10].HeaderText = "UnitID";
            dgvCart.Columns[10].Name = "UnitID";
            dgvCart.Columns[10].DataPropertyName = "UnitID";
            dgvCart.Columns[10].Visible = false;

            //and on my constructor I set gridview.DataSource=Datatable;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txtSearchProductCode.Text))
                {
                    string productcode = txtSearchProductCode.Text;
                    ClearControl();

                    var product = serviceSalesProduct.SearchProducts(productcode);

                    if (product.ResponseCode == "0")
                    {
                        MessageBox.Show(product.ResponseMessage);
                    }
                    else
                    {
                        if (product.ProductSearchVMList.Count == 1)
                        {
                            if (product.ProductSearchVMList.FirstOrDefault().AvaliableQty == 0)
                            {
                                MessageBox.Show("Product is out of stock!!!");
                                return;
                            }
                            LoadControlValue(product.ProductSearchVMList.FirstOrDefault());
                        }
                        else if (product.ProductSearchVMList.Count > 1)
                        {
                            using (FormProductSeachList frmProdList = new FormProductSeachList(product.ProductSearchVMList))
                            {
                                frmProdList.ShowDialog();
                                if (frmProdList.objProd != null)
                                {
                                    LoadControlValue(frmProdList.objProd);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //ActivityLog
            }

        }

        public void LoadControlValue(ProductSearchResultVM product)
        {
            txtProductCode.Text = product.ProductCode;
            txtProdName.Text = product.ProductName;
            txtAvailableQty.Text = product.AvaliableQty.ToString();
            txtUnitPrice.Text = product.UnitSalesPrice.ToString();

            comboUnit.DataSource = product.ProductUnitType;
            comboUnit.ValueMember = "UnitID";
            comboUnit.DisplayMember = "UnitName";
            comboUnit.SelectedValue = product.ProductUnit.UnitID;

            chkVatIncluded.Checked = product.SPVatIncluded;
            txtVatPercent.Text = product.SPVatPercent.ToString();
            txtVatAmt.Text = product.SPVat.ToString();
            txtOtherCharge.Text = product.SPOtherCharge.ToString();

            productID = product.ProductID;//Global
        }

        public void ClearControl()
        {
            txtSearchProductCode.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtProdName.Text = string.Empty;
            txtAvailableQty.Text = string.Empty;

            txtQty.Text = string.Empty;

            txtTotal.Text = "0";
            txtUnitPrice.Text = "0";
            txtVatPercent.Text = "0";
            txtVatAmt.Text = "0";
            txtDiscountAmount.Text = "0";
            txtDisountPercet.Text = "0";
            txtOtherCharge.Text = "0";
            txtSubTotal.Text = "0";

            comboUnit.DataSource = null;
            chkVatIncluded.Checked = false;


        }

        private void LoadComboBox()
        {
            var discountList = enumarationBLL.GetAllByQuery("001");

            comboDiscountType.DataSource = discountList;
            comboDiscountType.ValueMember = "EnumID";
            comboDiscountType.DisplayMember = "Name";
        }

        private void ControlEnableDisable()
        {
            chkVatIncluded.Enabled = false;
            comboDiscountType.Enabled = false;
            txtDisountPercet.ReadOnly = true;
            txtDiscountAmount.ReadOnly = true;
        }

        private void comboDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                if (Convert.ToInt64(comboDiscountType.SelectedValue) == 1)
                {
                    txtDisountPercet.ReadOnly = true;
                    txtDiscountAmount.ReadOnly = true;
                }

                else if (Convert.ToInt64(comboDiscountType.SelectedValue) == 2)
                {
                    txtDisountPercet.ReadOnly = true;
                    txtDiscountAmount.ReadOnly = false;
                }

                else if (Convert.ToInt64(comboDiscountType.SelectedValue) == 3)
                {
                    txtDisountPercet.ReadOnly = false;
                    txtDiscountAmount.ReadOnly = true;
                }


            }

            catch (Exception ex)
            {
                //ActivityLog
            }
        }



        private void CalculateSubTotal()
        {
            try
            {
                decimal qty = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDecimal(txtQty.Text);
                decimal unitprice = string.IsNullOrEmpty(txtUnitPrice.Text) ? 0 : Convert.ToDecimal(txtUnitPrice.Text);
                decimal vatAmt = string.IsNullOrEmpty(txtVatAmt.Text) ? 0 : Convert.ToDecimal(txtVatAmt.Text);
                decimal discountAmt = string.IsNullOrEmpty(txtDiscountAmount.Text) ? 0 : Convert.ToDecimal(txtDiscountAmount.Text);
                decimal othercharge = string.IsNullOrEmpty(txtOtherCharge.Text) ? 0 : Convert.ToDecimal(txtOtherCharge.Text);

                vatAmt = qty * vatAmt;
                discountAmt = qty * discountAmt;
                othercharge = qty * othercharge;

                txtTotal.Text = (qty * unitprice).ToString();
                txtVatAmt.Text = vatAmt.ToString();
                txtDiscountAmount.Text = discountAmt.ToString();
                txtOtherCharge.Text = othercharge.ToString();

                txtSubTotal.Text = ((qty * unitprice) + vatAmt - discountAmt + othercharge).ToString();

            }
            catch (Exception ex)
            {
                //ActivityLog()
            }
        }



        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQty.Text))
            {
                CalculateSubTotal();

            }
        }

        private void tsbAddCart_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Please Key In Quantity");
                return;
            }
            decimal productStockQty = (decimal)serviceSalesProduct.GetStockCountByProductId(productID);
            if (productStockQty > 0)
            {
                decimal productQty = Convert.ToDecimal(txtQty.Text);
                if (productQty > productStockQty)
                {
                    MessageBox.Show("You can not select more than stock!!!");
                    return;
                }
            }

            if (serviceSalesProduct.IsProductInCart(productID))
            {
                MessageBox.Show("Product is already added in Cart!!!");
                return;

            }


            DataRow drCart = dtCart.NewRow();

            drCart["ProductID"] = productID;
            drCart["ProductName"] = txtProdName.Text;
            drCart["ProductCode"] = txtProductCode.Text;
            drCart["Unit"] = comboUnit.Text.ToString();
            drCart["UnitSalesPrice"] = Convert.ToDecimal(txtUnitPrice.Text);
            drCart["SPVat"] = Convert.ToDecimal(txtVatAmt.Text);
            drCart["Quantity"] = Convert.ToDecimal(txtQty.Text);
            drCart["SPOtherCharge"] = Convert.ToDecimal(txtOtherCharge.Text);
            drCart["DiscountAmt"] = Convert.ToDecimal(txtDisountPercet.Text);
            drCart["SubTotal"] = Convert.ToDecimal(txtSubTotal.Text);
            drCart["UnitID"] = Convert.ToInt64(comboUnit.SelectedValue);


            dtCart.Rows.Add(drCart);

            dgvCart.DataSource = dtCart;


            CartRequest objCartRequest = new CartRequest()
            {
                ProductID = productID,
                ProductCode = txtProductCode.Text,
                ProductName = txtProdName.Text,
                Quantity = Convert.ToDecimal(txtQty.Text),

                UnitID = Convert.ToInt64(comboUnit.SelectedValue),
                Unit = comboUnit.SelectedText,
                UnitSalesPrice = Convert.ToDecimal(txtUnitPrice.Text),
                TotalSalesPrice = Convert.ToDecimal(txtTotal.Text),
                SubTotal = Convert.ToDecimal(txtSubTotal.Text),

                SPVat = Convert.ToDecimal(txtVatAmt.Text),
                SPVatPercent = Convert.ToDecimal(txtVatPercent.Text),
                SPOtherCharge = Convert.ToDecimal(txtOtherCharge.Text),
                DiscountAmt = Convert.ToDecimal(txtDiscountAmount.Text),
                DiscountPercent = Convert.ToDecimal(txtDisountPercet.Text),
            };

            CartResponse cartResponse = serviceSalesProduct.AddToCart(objCartRequest);
            //LoadCartGridView(cartResponse);

            txtPaymentTotal.Text = cartResponse.TotalPrice.ToString();
            txtPaymentTotalVat.Text = cartResponse.TotalVat.ToString();
            txtPaymentOtherCharge.Text = cartResponse.TotalOtherCharge.ToString();
            txtPaymentDiscount.Text = cartResponse.TotalDiscount.ToString();
            txtPaymentGrandTotal.Text = cartResponse.GrandTotal.ToString();
            ClearControl();
        }

        private void LoadCartGridView(CartResponse cartResponse)
        {
            dgvCart.DataSource = null;


            //Set AutoGenerateColumns False
            dgvCart.AutoGenerateColumns = false;

            //Set Columns Count
            dgvCart.ColumnCount = 10;

            //Add Columns
            dgvCart.Columns[0].HeaderText = "ProductID";
            dgvCart.Columns[0].Name = "ProductID";
            dgvCart.Columns[0].DataPropertyName = "ProductID";
            dgvCart.Columns[0].Visible = false;

            dgvCart.Columns[1].HeaderText = "Product Name"; // header text
            dgvCart.Columns[1].Name = "ProductName"; // name  
            dgvCart.Columns[1].DataPropertyName = "ProductName"; // field name

            dgvCart.Columns[2].HeaderText = "Product Code";
            dgvCart.Columns[2].Name = "ProductCode";
            dgvCart.Columns[2].DataPropertyName = "ProductCode";

            dgvCart.Columns[3].HeaderText = "Unit";
            dgvCart.Columns[3].Name = "Unit";
            dgvCart.Columns[3].DataPropertyName = "Unit";
            dgvCart.Columns[3].Visible = false;

            dgvCart.Columns[4].HeaderText = "Sales Price";
            dgvCart.Columns[4].Name = "UnitSalesPrice";
            dgvCart.Columns[4].DataPropertyName = "UnitSalesPrice";

            dgvCart.Columns[5].HeaderText = "Qty";
            dgvCart.Columns[5].Name = "Quantity";
            dgvCart.Columns[5].DataPropertyName = "Quantity";

            dgvCart.Columns[6].HeaderText = "Vat";
            dgvCart.Columns[6].Name = "SPVat";
            dgvCart.Columns[6].DataPropertyName = "SPVat";

            dgvCart.Columns[7].HeaderText = "Other Charge";
            dgvCart.Columns[7].Name = "SPOtherCharge";
            dgvCart.Columns[7].DataPropertyName = "SPOtherCharge";


            dgvCart.Columns[8].HeaderText = "Discount";
            dgvCart.Columns[8].Name = "DiscountAmt";
            dgvCart.Columns[8].DataPropertyName = "DiscountAmt";

            dgvCart.Columns[9].HeaderText = "Total";
            dgvCart.Columns[9].Name = "SubTotal";
            dgvCart.Columns[9].DataPropertyName = "SubTotal";


            dgvCart.DataSource = cartResponse.CartList;
        }

        private void txtPaymentCashReceive_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandTotal = string.IsNullOrEmpty(txtPaymentGrandTotal.Text) ? 0 : Convert.ToDecimal(txtPaymentGrandTotal.Text);//Convert.ToDecimal(txtPaymentGrandTotal.Text)
                decimal cashreceive = string.IsNullOrEmpty(txtPaymentCashReceive.Text) ? 0 : Convert.ToDecimal(txtPaymentCashReceive.Text);
                decimal change = Math.Floor(cashreceive - grandTotal);//string.IsNullOrEmpty(txtPaymentChange.Text) ? 0 : Convert.ToDecimal(txtPaymentChange.Text);

                txtPaymentChange.Text = change.ToString();
            }
            catch (Exception exception)
            {
                
                
            }
           

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidatePaymentInitiation())
                {
                    PaymentRequest pr = new PaymentRequest();
                    pr.ODetails = new List<OrderDetailsVM>();

                    pr.OSubTotal = Convert.ToDecimal(txtPaymentTotal.Text);
                    pr.OTotalVat = Convert.ToDecimal(txtPaymentTotalVat.Text);
                    pr.OOtherCharge = Convert.ToDecimal(txtPaymentOtherCharge.Text);
                    pr.OTotalDiscount = Convert.ToDecimal(txtPaymentDiscount.Text);
                    pr.OGrandTotal = Convert.ToDecimal(txtPaymentGrandTotal.Text);


                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        long cartProdId = Convert.ToInt64(row.Cells["ProductID"].Value);
                        decimal cartProdQty = Convert.ToInt64(row.Cells["Quantity"].Value);
                        decimal productStockQty = (decimal)serviceSalesProduct.GetStockCountByProductId(cartProdId);
                        if (productStockQty > cartProdQty)
                        {
                            OrderDetailsVM oVm = new OrderDetailsVM()
                            {
                                DProductID = Convert.ToInt64(row.Cells["ProductID"].Value),
                                DUnitID = Convert.ToInt64(row.Cells["UnitID"].Value),
                                DUnitPrice = Convert.ToDecimal(row.Cells["UnitSalesPrice"].Value),
                                DQuantity = Convert.ToDecimal(row.Cells["Quantity"].Value),
                                DTotalVat = Convert.ToDecimal(row.Cells["SPVat"].Value),
                                DOtherCharge = Convert.ToDecimal(row.Cells["SPOtherCharge"].Value),
                                DTotalDiscount = Convert.ToDecimal(row.Cells["DiscountAmt"].Value),
                                DSubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value)
                            };
                            pr.ODetails.Add(oVm);
                        }
                        else
                        {
                            MessageBox.Show("Error In Payment");
                            return;
                        }

                    }

                    pr.TotalAmount = Convert.ToDecimal(txtPaymentGrandTotal.Text);
                    pr.PaidAmount = Convert.ToDecimal(txtPaymentCashReceive.Text);
                    pr.ChangeAmount = Convert.ToDecimal(txtPaymentChange.Text);
                    pr.IsDue = false;
                    pr.DueAmount = 0;
                    pr.PaymentMethod = 1;
                    pr.PaymentType = 1;

                    var resp = serviceSalesProduct.SellProduct(pr);

                    if (resp.ResponseCode == "000")
                    {
                        DialogResult dr = MessageBox.Show("Success. You want to print receipt?", "Success", MessageBoxButtons.YesNo);
                        ClearCart();
                        ClearPaymentControl();

                        switch (dr)
                        {
                            case DialogResult.Yes:
                                ShowReceiptForm(resp.OrderNo);
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }
                    else if (resp.ResponseCode == "998")
                    {
                        MessageBox.Show(resp.ResponseMessage+ "Please Update The Product Again.", "Error");
                        
                       
                    }
                    else
                    {
                        MessageBox.Show(resp.ResponseMessage);
                        ClearCart();
                        ClearPaymentControl();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error In Payment");
            }
        }

        private bool ValidatePaymentInitiation()
        {
            //bool result = true;
            if (string.IsNullOrEmpty(txtPaymentTotal.Text))
            {
                MessageBox.Show("Total Payment Field can not be empty");
                return false; 
            }
            if (string.IsNullOrEmpty(txtPaymentTotalVat.Text))
            {
                MessageBox.Show("Total Vat Amt Field can not be empty");
                return false; 
            }
           
            if (string.IsNullOrEmpty(txtPaymentDiscount.Text))
            {
                MessageBox.Show("Total Discount Field can not be empty");
                return false; 
            }

            if (string.IsNullOrEmpty(txtPaymentOtherCharge.Text))
            {
                MessageBox.Show("Total Other Charge Field can not be empty");
                return false;
            }
            if (string.IsNullOrEmpty(txtPaymentGrandTotal.Text))
            {
                MessageBox.Show("Grand Total Field can not be empty");
                return false; 
            }
            if (string.IsNullOrEmpty(txtPaymentCashReceive.Text))
            {
                MessageBox.Show("Total Cash Receive Field can not be empty");
                return false; 
            }
            if (string.IsNullOrEmpty(txtPaymentChange.Text))
            {
                MessageBox.Show("Total Change Field can not be empty");
                return false; 
            }

            decimal cashReceive = Convert.ToDecimal(txtPaymentCashReceive.Text);
            if (cashReceive==0)
            {
                MessageBox.Show("Payment Receive Amount Can not be Zero");
                return false; 
            }
                

            return true;
        }

        private void ShowReceiptForm(string orderNo)
        {
            FormReport oFrmRpt = new FormReport();
            oFrmRpt.ShowDialog();
        }

        private void ClearPaymentControl()
        {
            txtPaymentTotal.Text = "0";
            txtPaymentTotalVat.Text = "0";
            txtPaymentOtherCharge.Text = "0";
            txtPaymentDiscount.Text = "0";
            txtPaymentGrandTotal.Text = "0";
            txtPaymentCashReceive.Text = "0";
            txtPaymentChange.Text = "0";
            txtPaymentCustMobile.Text = String.Empty;

        }

        private void ClearCart()
        {
            dgvCart.DataSource = null;
        }

        private void btnRemoveCartItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want to remove this item?", "Alert", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                {
                    if (dgvCart.SelectedRows.Count > 0)
                    {
                        DataGridViewRow currentRow = dgvCart.SelectedRows[0];
                        string productId = this.dgvCart.SelectedRows[0].Cells["ProductCode"].Value.ToString();

                        int rowIndex = dgvCart.CurrentCell.RowIndex;
                        dgvCart.Rows.RemoveAt(rowIndex);

                        CartResponse cartResponse = serviceSalesProduct.RemoveCart(productId);
                        //LoadCartGridView(cartResponse);

                        txtPaymentTotal.Text = cartResponse.TotalPrice.ToString();
                        txtPaymentTotalVat.Text = cartResponse.TotalVat.ToString();
                        txtPaymentOtherCharge.Text = cartResponse.TotalOtherCharge.ToString();
                        txtPaymentDiscount.Text = cartResponse.TotalDiscount.ToString();
                        txtPaymentGrandTotal.Text = cartResponse.GrandTotal.ToString();
                        ClearControl();
                        MessageBox.Show("Item Removed Successfully");
                    }
                }
                    break;
                case DialogResult.No:
                    break;
            }
            
            

            //decimal productStockQty = (decimal)serviceSalesProduct.GetStockByProductId(productID).Quantity;
            //if (productStockQty != null && productStockQty > 0)
            //{
            //    decimal productQty = Convert.ToDecimal(txtQty.Text);
            //    if (productQty > productStockQty)
            //    {
            //        MessageBox.Show("You can not select more than stock!!!");
            //        return;
            //    }
            //}

            //if (serviceSalesProduct.IsProductInCart(productID))
            //{
            //    MessageBox.Show("Product is already added in Cart!!!");
            //    return;

            //}


            //DataRow drCart = dtCart.NewRow();

            //drCart["ProductID"] = productID;
            //drCart["ProductName"] = txtProdName.Text;
            //drCart["ProductCode"] = txtProductCode.Text;
            //drCart["Unit"] = Convert.ToInt64(comboUnit.SelectedValue);
            //drCart["UnitSalesPrice"] = Convert.ToDecimal(txtUnitPrice.Text);
            //drCart["SPVat"] = Convert.ToDecimal(txtVatAmt.Text);
            //drCart["Quantity"] = Convert.ToDecimal(txtQty.Text);
            //drCart["SPOtherCharge"] = Convert.ToDecimal(txtOtherCharge.Text);
            //drCart["DiscountAmt"] = Convert.ToDecimal(txtDisountPercet.Text);
            //drCart["SubTotal"] = Convert.ToDecimal(txtSubTotal.Text);


            //dtCart.Rows.Add(drCart);

            //dgvCart.DataSource = dtCart;


            //CartRequest objCartRequest = new CartRequest()
            //{
            //    ProductID = productID,
            //    ProductCode = txtProductCode.Text,
            //    ProductName = txtProdName.Text,
            //    Quantity = Convert.ToDecimal(txtQty.Text),

            //    UnitID = Convert.ToInt64(comboUnit.SelectedValue),
            //    Unit = comboUnit.SelectedText,
            //    UnitSalesPrice = Convert.ToDecimal(txtUnitPrice.Text),
            //    TotalSalesPrice = Convert.ToDecimal(txtTotal.Text),
            //    SubTotal = Convert.ToDecimal(txtSubTotal.Text),

            //    SPVat = Convert.ToDecimal(txtVatAmt.Text),
            //    SPVatPercent = Convert.ToDecimal(txtVatPercent.Text),
            //    SPOtherCharge = Convert.ToDecimal(txtOtherCharge.Text),
            //    DiscountAmt = Convert.ToDecimal(txtDiscountAmount.Text),
            //    DiscountPercent = Convert.ToDecimal(txtDisountPercet.Text),
            //};

            //CartResponse cartResponse = serviceSalesProduct.AddToCart(objCartRequest);
            ////LoadCartGridView(cartResponse);

            //txtPaymentTotal.Text = cartResponse.TotalPrice.ToString();
            //txtPaymentTotalVat.Text = cartResponse.TotalVat.ToString();
            //txtPaymentOtherCharge.Text = cartResponse.TotalOtherCharge.ToString();
            //txtPaymentDiscount.Text = cartResponse.TotalDiscount.ToString();
            //txtPaymentGrandTotal.Text = cartResponse.GrandTotal.ToString();
            //ClearControl();
        }

        private void btnClearControl_Click(object sender, EventArgs e)
        {
            ClearControl();
        }



    }
}
