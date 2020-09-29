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
    public partial class FormEntryCategory : Form
    {
        #region Global variables

        CategoryEntryBLL serviceCatEntry;
        private long CategoryId = 0;
        private long SubCategoryId = 0;
        private CategoryVM categoryVm = null;
        private SubCatVM subCatVm = null;
        #endregion


        public FormEntryCategory()
        {
            InitializeComponent();
            serviceCatEntry = new CategoryEntryBLL();

            btnCategoryRemove.Enabled = false;
            btnCategoryUpdt.Enabled = false;
            btnSubCatUpdate.Enabled = false;
            btnSubCatRemove.Enabled = false;

            IntializeCatGrid();
            InitializeSubCatGrid();
            LoadSubCatagoryCombo();
        }



        #region Category

        #region Events
        private void btnCategorySave_Click(object sender, EventArgs e)
        {
            try
            {

                string categoryName = txtCategoryName.Text;
                string categoryCode = txtCategoryCode.Text;
                string description = txtCategoryDesc.Text;

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Please Key-In Category Name");
                    return;
                }
                if (string.IsNullOrEmpty(categoryCode))
                {
                    MessageBox.Show("Please Key-In Category Code");
                    return;
                }
                if (CategoryCodeExist(categoryCode))
                {
                    MessageBox.Show("Category Code Already Exist");
                    return;
                }
                if (CategoryNameExist(categoryName))
                {
                    MessageBox.Show("Category Name Already Exist");
                    return;
                }
                CategoryEntryRequest oCategoryEntryRequest = new CategoryEntryRequest()
                {
                    CategoryCode = categoryCode,
                    CategoryName = categoryName,
                    Description = description,
                    UserName = "Tahmid"
                };
                serviceCatEntry.InsertCategory(oCategoryEntryRequest);
                MessageBox.Show("Successfully Saved");
                LoadGridView(null);
                LoadSubCatagoryCombo();
                ClearCategoryControl();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                //if(dgvCategory.Rows.Count>0)
                {
                    btnCategorySave.Enabled = false;
                    btnCategoryUpdt.Enabled = true;
                    btnCategoryRemove.Enabled = true;
                    btnCategoryClear.Enabled = true;
                    txtCategoryCode.ReadOnly = true;
                    DataGridViewRow dgvRow = dgvCategory.Rows[e.RowIndex];
                    dgvCategory.CurrentRow.Selected = true;


                    CategoryId = Convert.ToInt64(dgvCategory.Rows[e.RowIndex].Cells[0].Value);
                    txtCategoryName.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryName"].FormattedValue.ToString();
                    txtCategoryCode.Text = dgvCategory.Rows[e.RowIndex].Cells["CategoryCode"].FormattedValue.ToString();
                    txtCategoryDesc.Text = dgvCategory.Rows[e.RowIndex].Cells["Description"].FormattedValue.ToString();


                }
            }
            catch (Exception)
            {


            }

        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text;
                CategorySearchResponse resp = serviceCatEntry.GetCategoryByProductNameOrCode(categoryName, "Name");

                if (resp != null)
                {
                    LoadGridView(resp.CategoryVM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void txtCategoryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string categoryCode = txtCategoryCode.Text;
                CategorySearchResponse resp = serviceCatEntry.GetCategoryByProductNameOrCode(categoryCode, "Code");

                if (resp != null)
                {
                    LoadGridView(resp.CategoryVM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnCategoryClear_Click(object sender, EventArgs e)
        {
            CategoryClear();

        }

        private void btnCategoryUpdt_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text;
                string categoryCode = txtCategoryCode.Text;
                string description = txtCategoryDesc.Text;

                if (string.IsNullOrEmpty(categoryName))
                {
                    MessageBox.Show("Please Key-In Category Name");
                    return;
                }
                if (string.IsNullOrEmpty(categoryCode))
                {
                    MessageBox.Show("Please Key-In Category Code");
                    return;
                }

                if (CategoryId > 0)
                {

                    CategoryUpdateRequest oCategoryEntryRequest = new CategoryUpdateRequest()
                    {

                        CategoryName = categoryName,
                        Description = description,
                        UserName = "Tahmid"
                    };
                    CrudResponse resp = serviceCatEntry.UpdateCategory(CategoryId, oCategoryEntryRequest);
                    MessageBox.Show(resp.ResponseMessage);

                    CategoryClear();
                    LoadSubCatagoryCombo();

                }

            }
            catch (Exception exception)
            {

                MessageBox.Show("Error");
            }

        }

        private void btnCategoryRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (CategoryId > 0)
                {

                    DialogResult dr = MessageBox.Show("Do you want to delete Category?", "Warning", MessageBoxButtons.YesNo);


                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    CrudResponse resp = serviceCatEntry.DeleteCategory(CategoryId);
                    MessageBox.Show(resp.ResponseMessage);

                    CategoryClear();
                    LoadSubCatagoryCombo();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }

        }
        #endregion


        #region User Defined Function
        private void IntializeCatGrid()
        {
            dgvCategory.DataSource = null;

            //Set AutoGenerateColumns False
            dgvCategory.AutoGenerateColumns = false;

            ////Set Columns Count
            dgvCategory.ColumnCount = 4;

            ////Add Columns
            dgvCategory.Columns[0].HeaderText = "CategoryID";
            dgvCategory.Columns[0].Name = "CategoryID";
            dgvCategory.Columns[0].DataPropertyName = "CategoryID";
            dgvCategory.Columns[0].Visible = false;

            dgvCategory.Columns[1].HeaderText = "Category Name"; // header text
            dgvCategory.Columns[1].Name = "CategoryName"; // name  
            dgvCategory.Columns[1].DataPropertyName = "CategoryName"; // field name

            dgvCategory.Columns[2].HeaderText = "Category Code";
            dgvCategory.Columns[2].Name = "CategoryCode";
            dgvCategory.Columns[2].DataPropertyName = "CategoryCode";

            dgvCategory.Columns[3].HeaderText = "Description";
            dgvCategory.Columns[3].Name = "Description";
            dgvCategory.Columns[3].DataPropertyName = "Description";

            LoadGridView(null);
        }

        private void LoadGridView(List<CategoryVM> categoryVM)
        {
            try
            {
                dgvCategory.DataSource = null;
                if (categoryVM == null)
                {
                    CategorySearchResponse resp = serviceCatEntry.GetAllCategory();
                    if (resp.ResponseCode == "000")
                        dgvCategory.DataSource = resp.CategoryVM;
                }
                else if (categoryVM.Count > 0)
                {
                    dgvCategory.DataSource = categoryVM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }

        private void ClearCategoryControl()
        {
            txtCategoryName.Text = string.Empty;
            txtCategoryCode.Text = string.Empty;
            txtCategoryDesc.Text = string.Empty;
        }

        private bool CategoryNameExist(string categoryCode)
        {
            return serviceCatEntry.IsCatNameExist(categoryCode);
        }

        private bool CategoryCodeExist(string categoryCode)
        {
            return serviceCatEntry.IsCatCodeExist(categoryCode);
        }

        private void CategoryClear()
        {
            btnCategorySave.Enabled = true;
            btnCategoryUpdt.Enabled = false;
            btnCategoryRemove.Enabled = false;
            txtCategoryCode.ReadOnly = false;
            ClearCategoryControl();
            LoadGridView(null);
        }


        #endregion


        #endregion



        #region SubCategory

        #region Events

        private void btnSubCatSave_Click(object sender, EventArgs e)
        {
            try
            {

                string subcatName = txtSubCatName.Text;
                string subCatCode = txtSubCatCode.Text;
                string description = txtSubCatDesc.Text;
                string categoryId = cmbCatType.SelectedValue.ToString();

                if (string.IsNullOrEmpty(subcatName))
                {
                    MessageBox.Show("Please Key-In Sub Category Name");
                    return;
                }
                if (string.IsNullOrEmpty(subCatCode))
                {
                    MessageBox.Show("Please Key-In Sub Category Code");
                    return;
                }
                if (categoryId == "0")
                {
                    MessageBox.Show("Please select Catagory");
                    return;
                }
                if (SubCategoryCodeExist(subCatCode))
                {
                    MessageBox.Show("Sub Category Code Already Exist");
                    return;
                }
                if (SubCategoryNameExist(subcatName))
                {
                    MessageBox.Show("Sub Category Name Already Exist");
                    return;
                }
                SubCatEntryRequest osubcatentryReq = new SubCatEntryRequest()
                {
                    SubCategoryCode = subCatCode,
                    Name = subcatName,
                    Description = description,
                    CategoryID = Convert.ToInt64(categoryId),
                    UserName = "Tahmid"
                };
                CrudResponse crudResponse = serviceCatEntry.InsertSubCategory(osubcatentryReq);
                MessageBox.Show(crudResponse.ResponseMessage);
                LoadSubCatGridView(null);
                LoadSubCatagoryCombo();
                ClearCategoryControl();
                ClearSubCategoryCombo();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }

        }

        private void btnSubCatUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string subcatName = txtSubCatName.Text;
                string subCatCode = txtSubCatCode.Text;
                string description = txtSubCatDesc.Text;
                string categoryId = cmbCatType.SelectedValue.ToString();

                if (string.IsNullOrEmpty(subcatName))
                {
                    MessageBox.Show("Please Key-In Sub Category Name");
                    return;
                }
                if (string.IsNullOrEmpty(subCatCode))
                {
                    MessageBox.Show("Please Key-In Sub Category Code");
                    return;
                }
                if (categoryId == "0")
                {
                    MessageBox.Show("Please select Catagory");
                    return;
                }
                if (SubCategoryCodeExist(subCatCode))
                {
                    MessageBox.Show("Sub Category Code Already Exist");
                    return;
                }
                if (SubCategoryNameExist(subcatName))
                {
                    MessageBox.Show("Sub Category Name Already Exist");
                    return;
                }


                SubCatUpdateRequest oSubCatUpdateRequest = new SubCatUpdateRequest()
                {
                    Name = subcatName,
                    Description = description,
                    CategoryID = Convert.ToInt64(categoryId),
                    UserName = "Tahmid"
                };
                serviceCatEntry.UpdateSubCategory(SubCategoryId, oSubCatUpdateRequest);
                MessageBox.Show("Successfully Saved");
                LoadSubCatGridView(null);
                LoadSubCatagoryCombo();
                ClearSubCategoryCombo();
                SubCategoryClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnSubCatRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (SubCategoryId > 0)
                {

                    DialogResult dr = MessageBox.Show("Do you want to delete Sub Category?", "Warning", MessageBoxButtons.YesNo);


                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    CrudResponse resp = serviceCatEntry.DeleteSubCategory(SubCategoryId);
                    MessageBox.Show(resp.ResponseMessage);

                    ClearSubCategoryCombo();
                    SubCategoryClear();

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void btnSubCatClear_Click(object sender, EventArgs e)
        {
            SubCategoryClear();
            ClearSubCategoryCombo();
        }

        private void txtSubCatName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string subcategoryName = txtSubCatName.Text;
                SubCatSearchResponse resp = serviceCatEntry.GetSubCategory(subcategoryName, "Name");

                if (resp != null)
                {
                    LoadSubCatGridView(resp.SubCategoryVM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }



        private void txtSubCatCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string subCatCode = txtSubCatCode.Text;
                SubCatSearchResponse resp = serviceCatEntry.GetSubCategory(subCatCode, "Code");

                if (resp != null)
                {
                    LoadSubCatGridView(resp.SubCategoryVM);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void dgvSubCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                //if(dgvCategory.Rows.Count>0)
                {
                    btnSubCatSave.Enabled = false;
                    btnSubCatUpdate.Enabled = true;
                    btnSubCatRemove.Enabled = true;
                    btnCategoryClear.Enabled = true;
                    txtSubCatCode.ReadOnly = true;
                    DataGridViewRow dgvRow = dgvSubCat.Rows[e.RowIndex];
                    dgvSubCat.CurrentRow.Selected = true;


                    SubCategoryId = Convert.ToInt64(dgvSubCat.Rows[e.RowIndex].Cells[0].Value);
                    txtSubCatName.Text = dgvSubCat.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                    txtSubCatCode.Text = dgvSubCat.Rows[e.RowIndex].Cells["SubCategoryCode"].FormattedValue.ToString();
                    txtSubCatDesc.Text = dgvSubCat.Rows[e.RowIndex].Cells["Description"].FormattedValue.ToString();

                    long categoryId = Convert.ToInt64(dgvSubCat.Rows[e.RowIndex].Cells["CategoryID"].FormattedValue);
                    cmbCatType.SelectedIndex = (int)categoryId;
                }
            }
            catch (Exception)
            {


            }

        }


        #endregion


        #region User Defined Function

        private void InitializeSubCatGrid()
        {
            dgvSubCat.DataSource = null;

            //Set AutoGenerateColumns False
            dgvSubCat.AutoGenerateColumns = false;

            ////Set Columns Count
            dgvSubCat.ColumnCount = 6;

            ////Add Columns
            dgvSubCat.Columns[0].HeaderText = "SubCategoryID";
            dgvSubCat.Columns[0].Name = "SubCategoryID";
            dgvSubCat.Columns[0].DataPropertyName = "SubCategoryID";
            dgvSubCat.Columns[0].Visible = false;

            dgvSubCat.Columns[1].HeaderText = "Name"; // header text
            dgvSubCat.Columns[1].Name = "Name"; // name  
            dgvSubCat.Columns[1].DataPropertyName = "Name"; // field name

            dgvSubCat.Columns[2].HeaderText = "Sub Category Code";
            dgvSubCat.Columns[2].Name = "SubCategoryCode";
            dgvSubCat.Columns[2].DataPropertyName = "SubCategoryCode";

            dgvSubCat.Columns[3].HeaderText = "Description";
            dgvSubCat.Columns[3].Name = "Description";
            dgvSubCat.Columns[3].DataPropertyName = "Description";

            dgvSubCat.Columns[4].HeaderText = "Category Name";
            dgvSubCat.Columns[4].Name = "CategoryName";
            dgvSubCat.Columns[4].DataPropertyName = "CategoryName";

            dgvSubCat.Columns[5].HeaderText = "CategoryID";
            dgvSubCat.Columns[5].Name = "CategoryID";
            dgvSubCat.Columns[5].DataPropertyName = "CategoryID";
            dgvSubCat.Columns[5].Visible = false;

            LoadSubCatGridView(null);
        }

        private void LoadSubCatagoryCombo()
        {
            var resp = serviceCatEntry.GetCategoryByProductNameOrCode("", "");
            resp.CategoryVM.Insert(0, new CategoryVM() { CategoryID = 0, CategoryName = "--Select--" });
            cmbCatType.DataSource = resp.CategoryVM;
            cmbCatType.DisplayMember = "CategoryName";
            cmbCatType.ValueMember = "CategoryID";

        }

        private void ClearSubCategoryCombo()
        {
            txtSubCatCode.Text = string.Empty;
            txtSubCatName.Text = string.Empty;
            txtSubCatDesc.Text = string.Empty;
            cmbCatType.SelectedIndex = 0;
        }

        private bool SubCategoryNameExist(string subcatName)
        {
            return false;
        }

        private bool SubCategoryCodeExist(string subCatCode)
        {
            return false;
        }

        private void SubCategoryClear()
        {
            btnSubCatSave.Enabled = true;
            btnSubCatUpdate.Enabled = false;
            btnSubCatRemove.Enabled = false;
            txtSubCatCode.ReadOnly = false;
            ClearCategoryControl();
            LoadGridView(null);
        }

        private void LoadSubCatGridView(List<SubCatVM> list)
        {
            try
            {

                dgvSubCat.DataSource = null;
                if (list == null)
                {
                    SubCatSearchResponse resp = serviceCatEntry.GetSubCategory("", "");
                    dgvSubCat.DataSource = resp.SubCategoryVM;
                }
                else if (list.Count > 0)
                {
                    dgvSubCat.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
        #endregion


        #endregion

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string categoryName = txtCategoryName.Text;
            //    CategorySearchResponse resp = serviceCatEntry.GetCategoryByProductNameOrCode(categoryName, "Name");

            //    if (resp != null)
            //    {
            //        LoadGridView(resp.CategoryVM);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error");
            //}

        }

        private void txtCategoryCode_TextChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    string categoryCode = txtCategoryCode.Text;
            //    CategorySearchResponse resp = serviceCatEntry.GetCategoryByProductNameOrCode(categoryCode, "Code");

            //    if (resp != null)
            //    {
            //        LoadGridView(resp.CategoryVM);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error");
            //}

        }

    }
}
