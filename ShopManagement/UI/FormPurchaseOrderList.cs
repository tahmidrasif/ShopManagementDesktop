using ShopManagement.BLL;
using ShopManagement.BLL.Response;
using ShopManagement.BLL.ViewModel;
using ShopManagement.UI.Dialogue;
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
    public partial class FormPurchaseOrderList : Form
    {
        private ProductPurchaseBLL _serviceProdPurchase;
        private EnumarationBLL _serviceEnum;
        private VendorBLL _serviceVendor;
        DataTable dtPurchaseOrder;

        public FormPurchaseOrderList()
        {
            InitializeComponent();
            _serviceProdPurchase = new ProductPurchaseBLL();
            _serviceEnum = new EnumarationBLL();
            _serviceVendor = new VendorBLL();
            LoadCombo();
            CreatePurchaseOrderDataTable();
        }

        private void LoadCombo()
        {
            var statuses = _serviceEnum.GetAllByTypeDescription("PO Status");
            if (statuses != null && statuses.Count > 0)
            {
                statuses.Insert(0, new EnumarationResponse() { EnumID = 0, Name = "--All--" });
                cmbSrcOrderStatus.DataSource = statuses;
                cmbSrcOrderStatus.DisplayMember = "Name";
                cmbSrcOrderStatus.ValueMember = "EnumID";
            }

            var vendors = _serviceVendor.GetAllVendors();
            if (vendors != null && vendors.Count > 0)
            {
                vendors.Insert(0, new VendorViewModel() { VendorId = 0, VendorName = "--All--" });
                cmbSrcVendor.DataSource = vendors;
                cmbSrcVendor.DisplayMember = "VendorName";
                cmbSrcVendor.ValueMember = "VendorId";
            }

        }

        private void CreatePurchaseOrderDataTable()
        {
            dtPurchaseOrder = new DataTable(); //here insntianting the form level table. 

            dtPurchaseOrder.Columns.Add("POrderID".ToString());
            dtPurchaseOrder.Columns.Add("POrderCode".ToString());
            dtPurchaseOrder.Columns.Add("OrderDate".ToString());
            dtPurchaseOrder.Columns.Add("DeliveryDate".ToString());
            dtPurchaseOrder.Columns.Add("VendorName".ToString());
            dtPurchaseOrder.Columns.Add("SubTotal".ToString());
            dtPurchaseOrder.Columns.Add("TotalVat".ToString());
            dtPurchaseOrder.Columns.Add("TotalOtherCharge".ToString());
            dtPurchaseOrder.Columns.Add("TotalDeliveryCharge".ToString());
            dtPurchaseOrder.Columns.Add("TotalDiscount".ToString());
            dtPurchaseOrder.Columns.Add("TotalAdvance".ToString());
            dtPurchaseOrder.Columns.Add("TotalDue".ToString());
            dtPurchaseOrder.Columns.Add("GrandTotal".ToString());
            dtPurchaseOrder.Columns.Add("StatusName".ToString());
            //dtPurchaseOrder.Columns.Add("Print".ToString());
            //dtPurchaseOrder.Columns.Add("ViewAll".ToString());

            dgvPO.DataSource = null;
            //Set AutoGenerateColumns False
            dgvPO.AutoGenerateColumns = false;

            //Set Columns Count
            dgvPO.ColumnCount = 14;

            //Add Columns
            dgvPO.Columns[0].HeaderText = "POrderID";
            dgvPO.Columns[0].Name = "POrderID";
            dgvPO.Columns[0].DataPropertyName = "POrderID";
            dgvPO.Columns[0].Visible = false;

            dgvPO.Columns[1].HeaderText = "Order Code"; // header text
            dgvPO.Columns[1].Name = "POrderCode"; // name  
            dgvPO.Columns[1].DataPropertyName = "POrderCode"; // field name

            dgvPO.Columns[2].HeaderText = "Order Date";
            dgvPO.Columns[2].Name = "OrderDate";
            dgvPO.Columns[2].DataPropertyName = "OrderDate";

            dgvPO.Columns[3].HeaderText = "Delivery Date";
            dgvPO.Columns[3].Name = "DeliveryDate";
            dgvPO.Columns[3].DataPropertyName = "DeliveryDate";
            //dgvCart.Columns[3].Visible = false;


            dgvPO.Columns[4].HeaderText = "Vendor Name";
            dgvPO.Columns[4].Name = "VendorName";
            dgvPO.Columns[4].DataPropertyName = "VendorName";

            dgvPO.Columns[5].HeaderText = "Sub Total";
            dgvPO.Columns[5].Name = "SubTotal";
            dgvPO.Columns[5].DataPropertyName = "SubTotal";

            dgvPO.Columns[6].HeaderText = "Vat";
            dgvPO.Columns[6].Name = "TotalVat";
            dgvPO.Columns[6].DataPropertyName = "TotalVat";

            dgvPO.Columns[7].HeaderText = "Total Other Charge";
            dgvPO.Columns[7].Name = "TotalOtherCharge";
            dgvPO.Columns[7].DataPropertyName = "TotalOtherCharge";

            dgvPO.Columns[8].HeaderText = "Total Delivery Charge";
            dgvPO.Columns[8].Name = "TotalDeliveryCharge";
            dgvPO.Columns[8].DataPropertyName = "TotalDeliveryCharge";

            dgvPO.Columns[9].HeaderText = "Total  Discount";
            dgvPO.Columns[9].Name = "TotalDiscount";
            dgvPO.Columns[9].DataPropertyName = "TotalDiscount";

            dgvPO.Columns[10].HeaderText = "Total Advance  ";
            dgvPO.Columns[10].Name = "TotalAdvance";
            dgvPO.Columns[10].DataPropertyName = "TotalAdvance";

            dgvPO.Columns[11].HeaderText = "Total Due ";
            dgvPO.Columns[11].Name = "TotalDue";
            dgvPO.Columns[11].DataPropertyName = "TotalDue";

            dgvPO.Columns[12].HeaderText = "Grand Total ";
            dgvPO.Columns[12].Name = "GrandTotal";
            dgvPO.Columns[12].DataPropertyName = "GrandTotal";

            dgvPO.Columns[13].HeaderText = "Status";
            dgvPO.Columns[13].Name = "StatusName";
            dgvPO.Columns[13].DataPropertyName = "StatusName";

            //dgvPO.Columns[14].HeaderText = "Print";
            //dgvPO.Columns[14].Name = "Print";
            //dgvPO.Columns[14].DataPropertyName = "Print";
            //dgvPO.Columns[14].DataPropertyName = "StatusName";

            DataGridViewButtonColumn PrintButton = new DataGridViewButtonColumn();
            PrintButton.Name = "Print";
            PrintButton.Text = "Print";
            PrintButton.UseColumnTextForButtonValue = true;
            if (dgvPO.Columns["Print"] == null)
            {
                dgvPO.Columns.Insert(14, PrintButton);
            }
            DataGridViewButtonColumn ViewAllButton = new DataGridViewButtonColumn();
            ViewAllButton.Name = "ViewAll";
            ViewAllButton.Text = "View All";
            ViewAllButton.UseColumnTextForButtonValue = true;
            if (dgvPO.Columns["ViewAll"] == null)
            {
                dgvPO.Columns.Insert(15, ViewAllButton);
            }


            //and on my constructor I set gridview.DataSource=Datatable;
        }
        private void btnAddNewPO_Click(object sender, EventArgs e)
        {
            FormProductPurchase fPo = new FormProductPurchase();
            fPo.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            long orderStatus = 0;
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            string orderCode = "";
            long venodrId = 0;
            dgvPO.DataSource = null;
            if (cmbSrcOrderStatus.SelectedValue != "0")
            {
                orderStatus = Convert.ToInt64(cmbSrcOrderStatus.SelectedValue);
            }
            if (!string.IsNullOrEmpty(dtSrcFromDate.Text))
            {
                fromDate = dtSrcFromDate.Value.Date;
            }
            if (!string.IsNullOrEmpty(dtSrcToDate.Text))
            {
                toDate = dtSrcToDate.Value.Date;
                toDate = toDate.AddDays(1);
            }
            if (!string.IsNullOrEmpty(txtSrcOrderCode.Text))
            {
                orderCode = txtSrcOrderCode.Text;
            }
            if (cmbSrcOrderStatus.SelectedValue != "0")
            {
                venodrId = Convert.ToInt64(cmbSrcVendor.SelectedValue);
            }

            List<PurchaseOrderVM> poList = _serviceProdPurchase.GetOrders(orderStatus, fromDate, toDate, orderCode, venodrId);

            if (poList!=null && poList.Count > 0)
            {
                foreach (var po in poList)
                {
                    if (po.VendorID != null)
                        po.VendorName = _serviceVendor.GetById(po.VendorID).VendorName;
                    if (po.Status != null)
                    {
                        po.StatusName = _serviceEnum.GetById(po.Status).Name;
                    }
                }

                dgvPO.DataSource = poList;
               
            }
            else
            {
                MessageBox.Show("No Records Found");
            }
        }

        private void dgvPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPO.Columns["ViewAll"].Index && e.RowIndex >= 0)
            {
                long orderId = (long)dgvPO.Rows[e.RowIndex].Cells["POrderID"].Value ;

                if (orderId > 0)
                {
                    DialoguePOProductList dgPo = new DialoguePOProductList(orderId);
                    dgPo.ShowDialog();
                }
            }
        }
    }
}
