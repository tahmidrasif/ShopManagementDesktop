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

namespace ShopManagement.UI
{
    public partial class FormProductSeachList : Form
    {
        public List<ProductSearchResultVM> objProductList{get; set;}
        public List<ProductSearchResultVM> objProductListDup { get; set; }
        public ProductSearchResultVM objProd { get; set; }
        public SalesProductBLL serviceSalesProduct { get; set; }

        public FormProductSeachList()
        {
            InitializeComponent();
        }

        public FormProductSeachList(List<ProductSearchResultVM> productList)
        {
            InitializeComponent();
            serviceSalesProduct = new SalesProductBLL();
            this.objProductList = productList;
            this.objProductListDup = new List<ProductSearchResultVM>();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
        
            //Set AutoGenerateColumns False
            dgvProductList.AutoGenerateColumns = false;

            //Set Columns Count
            dgvProductList.ColumnCount = 5;

            //Add Columns
            dgvProductList.Columns[0].Name = "ProductID";
            dgvProductList.Columns[0].HeaderText = "ProductID";
            dgvProductList.Columns[0].DataPropertyName = "ProductID";
            dgvProductList.Columns[0].Visible = false;

            dgvProductList.Columns[1].Name = "Name"; // name
            dgvProductList.Columns[1].HeaderText = "Product Name"; // header text
            dgvProductList.Columns[1].DataPropertyName = "ProductName"; // field name

            dgvProductList.Columns[2].Name = "ProductCode";
            dgvProductList.Columns[2].HeaderText = "Product Code";
            dgvProductList.Columns[2].DataPropertyName = "ProductCode";

            dgvProductList.Columns[3].HeaderText = "Unit";
            dgvProductList.Columns[3].Name = "Unit";
            dgvProductList.Columns[3].DataPropertyName = "UnitName";

            dgvProductList.Columns[4].HeaderText = "UnitSalesPrice";
            dgvProductList.Columns[4].Name = "Sales Price";
            dgvProductList.Columns[4].DataPropertyName = "UnitSalesPrice";

           
            dgvProductList.DataSource = objProductList;


        }

       

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string productId = dgvProductList.Rows[e.RowIndex].Cells[0].Value.ToString();
            long productIdLong= Convert.ToInt64(productId);

            if (!string.IsNullOrEmpty(productId))
            {
                var Qty = serviceSalesProduct.GetStockCountByProductId(productIdLong);
                if (Qty == 0)
                {
                    MessageBox.Show("Product is out of stock!!!");
                    return;
                }
                objProd = objProductList.FirstOrDefault(x => x.ProductID == productIdLong);
               
                
                this.Close();
            }
        }

       

    }
}
