using ShopManagement.BLL;
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
    public partial class DialoguePOProductList : Form
    {
        DataTable dtCart = null;
        private long poId = 0;
        private ProductPurchaseBLL _serviceProdPurchase = null;
        public DialoguePOProductList(long poId)
        {
            InitializeComponent();
            _serviceProdPurchase = new ProductPurchaseBLL();
            this.poId = poId;
            CreateDataTable();
            LoadGridView();
        }

        private void LoadGridView()
        {
           DataTable poDetails= _serviceProdPurchase.GetPODetailsByPOID(poId);
            if (poDetails.Rows.Count > 0)
            {
                dgvProduct.DataSource = poDetails;
                
            }
        }

        private void CreateDataTable()
        {
            dtCart = new DataTable(); //here insntianting the form level table. 

            dtCart.Columns.Add("ProductID".ToString());
            dtCart.Columns.Add("ProductName".ToString());
            dtCart.Columns.Add("ProductCode".ToString());
            dtCart.Columns.Add("AvailableQty".ToString());
            dtCart.Columns.Add("PPVat".ToString());
            dtCart.Columns.Add("UnitPurchasePrice".ToString());
            dtCart.Columns.Add("Quantity".ToString());
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


            dgvProduct.Columns[7].HeaderText = "Discount";
            dgvProduct.Columns[7].Name = "DiscountAmt";
            dgvProduct.Columns[7].DataPropertyName = "DiscountAmt";

            dgvProduct.Columns[8].HeaderText = "Total";
            dgvProduct.Columns[8].Name = "SubTotal";
            dgvProduct.Columns[8].DataPropertyName = "SubTotal";
        }
    }
}
