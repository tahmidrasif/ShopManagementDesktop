﻿using ShopManagement.BLL;
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

namespace ShopManagement.UI.Dialogue
{
    public partial class DialoguePOProcessing : Form
    {
        PurchaseOrderVM poVM = null;
        private ProductBLL _serviceProduct = null;
        private UnitBLL _serviceUnit = null;
        private VendorBLL _serviceVendor = null;
        private ProductPurchaseBLL _serviceProdPurchase = null;
        private EnumarationBLL _serviceEnum = null;
        private TransactionBLL _transactionBLL = null;

        public DialoguePOProcessing(long poId)
        {
            InitializeComponent();
            _serviceProduct = new ProductBLL();
            _serviceVendor = new VendorBLL();
            _serviceEnum = new EnumarationBLL();
            _serviceProdPurchase = new ProductPurchaseBLL();
            _transactionBLL = new TransactionBLL();

            if (poId != null && poId > 0)
            {
                LoadExistingOrder(poId);
            }
            LoadPaymentTypeCombo();
        }

        private void LoadPaymentTypeCombo()
        {
            var paymentTypes = _serviceEnum.GetAllByTypeDescription("PaymentType");
            cmbPaymentType.DataSource = paymentTypes;
            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "EnumID";
        }

        private void LoadExistingOrder(long? orderId)
        {
            if (orderId != null && orderId > 0)
            {
                poVM = _serviceProdPurchase.GetPurchaseOrderById(orderId);
                if (poVM == null)
                {
                    MessageBox.Show("No Order is found");
                    this.Close();
                    return;
                }

                txtOrderCode.Text = poVM.POrderCode;
                txtOrderDate.Text = poVM.OrderDate.Value.ToString("yyyy-MM-dd");

                txtPaymentTotal.Text = poVM.SubTotal.ToString();
                txtPaymentTotalVat.Text = poVM.TotalVat.ToString();

                txtPaymentDiscount.Text = poVM.TotalDiscount.ToString();
                txtPaymentOtherCharge.Text = poVM.TotalOtherCharge.ToString();
                txtPaymentAdditionalDiscount.Text = poVM.AdditionalDiscount.ToString();
                txtAdvancedAmount.Text = poVM.TotalAdvance.ToString();

                txtGrandTotal.Text = poVM.GrandTotal.ToString();
                txtPaymentDeliveryCharge.Text = poVM.TotalDeliveryCharge.ToString();
                txtPaymentDue.Text = poVM.TotalDue.ToString();
                txtVendorName.Text = poVM.VendorName;
                var statusEnum = _serviceEnum.GetAllByTypeDescription("PO Status");


                if (poVM.Status != null && poVM.Status > 0)
                {
                    var statusText = statusEnum.FirstOrDefault(x => x.EnumID == poVM.Status);
                    txtCurrentStatus.Text = statusText.Name;
                }

                LoadStatusCombo(statusEnum, poVM.Status.Value);
            }
        }

        //When status is pending Proceed Button click pop up appear do you want to pay Advance Amount
        //When status is sent to vendor and selected status is received then proceed button click pop up 
        // do you want to pay full amount now?
        ///When status is sent to vendor and selected status is cancel then proceed button click pop up 
        // Do you want to reverse advance payment

        private void LoadStatusCombo(List<EnumarationResponse> list, long status)
        {
            List<EnumarationResponse> copyList = list;

            var statusEnum = copyList.FirstOrDefault(x => x.EnumID == status);
            if (statusEnum.Name == "Pendig")
            {
                copyList = copyList.Where(x => x.Name == "Sent To Vendor").ToList();
                cmbStatus.DataSource = copyList;
                cmbStatus.DisplayMember = "Name";
                cmbStatus.ValueMember = "EnumID";
                return;
            }
            if (statusEnum.Name == "Sent To Vendor")
            {
                copyList = copyList.Where(x => x.Name == "Received" || x.Name == "Return" || x.Name == "Partial Received").ToList();
                cmbStatus.DataSource = copyList;
                cmbStatus.DisplayMember = "Name";
                cmbStatus.ValueMember = "EnumID";
                //cmbStatus.SelectedValue = "EnumID";
                return;
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (poVM == null)
            {
                MessageBox.Show("No Order is found");
                this.Close();
                return;
            }
            var statusEnum = _serviceEnum.GetAllByTypeDescription("PO Status");
            if (statusEnum == null)
            {
                MessageBox.Show("Internal Error");
                this.Close();
                return;
            }
            if (poVM.Status == statusEnum.FirstOrDefault(x => x.Name == "Pending").EnumID)
            {
                //_service
                DialogResult dr = MessageBox.Show("Do you Want to Proceed?", "Alert", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        {

                            poVM.Status = statusEnum.FirstOrDefault(x => x.Name == "Sent To Vendor").EnumID;
                            poVM.UpdatedBy = "tahmid";
                            poVM.UpdatedOn = DateTime.Now;

                            long paymentType = (long)cmbPaymentType.SelectedValue;
                            string msg=_serviceProdPurchase.POSendToVendor(poVM, paymentType);
                            if (msg == "Success")
                            {
                                MessageBox.Show("Order Sent to Vendor: " + poVM.VendorName + " successfully");
                            }
                        }
                        break;


                }
            }
            if (poVM.Status == statusEnum.FirstOrDefault(x => x.Name == "Sent To Vendor").EnumID)
            {

            }
        }


    }
}