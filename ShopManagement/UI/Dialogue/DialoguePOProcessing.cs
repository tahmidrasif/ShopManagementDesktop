using ShopManagement.BLL;
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
        private ProductBLL _serviceProduct = null;

        private UnitBLL _serviceUnit = null;
        private VendorBLL _serviceVendor = null;
        private ProductPurchaseBLL _serviceProdPurchase = null;
        EnumarationBLL _serviceEnum = null;

        public DialoguePOProcessing(long poId)
        {
            InitializeComponent();
            _serviceProduct = new ProductBLL();
            _serviceVendor = new VendorBLL();
            _serviceEnum = new EnumarationBLL();
            _serviceProdPurchase = new ProductPurchaseBLL();

            if (poId != null && poId > 0)
            {
                LoadExistingOrder(poId);
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


            }
        }
    }
}
