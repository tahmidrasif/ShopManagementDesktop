namespace ShopManagement.UI
{
    partial class FormEntryCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchCat = new System.Windows.Forms.Button();
            this.comboSearchCat = new System.Windows.Forms.ComboBox();
            this.txtSearcCat = new System.Windows.Forms.TextBox();
            this.btnCategoryClear = new System.Windows.Forms.Button();
            this.txtCategoryCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.btnCategoryRemove = new System.Windows.Forms.Button();
            this.btnCategoryUpdt = new System.Windows.Forms.Button();
            this.btnCategorySave = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCategoryDesc = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSearchSubCat = new System.Windows.Forms.Button();
            this.comboSearchSubCat = new System.Windows.Forms.ComboBox();
            this.txtSearchSubCat = new System.Windows.Forms.TextBox();
            this.cmbCatType = new System.Windows.Forms.ComboBox();
            this.txtSubCatCode = new System.Windows.Forms.TextBox();
            this.txtSubCatName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubCatClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSubCat = new System.Windows.Forms.DataGridView();
            this.btnSubCatRemove = new System.Windows.Forms.Button();
            this.btnSubCatUpdate = new System.Windows.Forms.Button();
            this.btnSubCatSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubCatDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSearchCat);
            this.groupBox1.Controls.Add(this.comboSearchCat);
            this.groupBox1.Controls.Add(this.txtSearcCat);
            this.groupBox1.Controls.Add(this.btnCategoryClear);
            this.groupBox1.Controls.Add(this.txtCategoryCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvCategory);
            this.groupBox1.Controls.Add(this.btnCategoryRemove);
            this.groupBox1.Controls.Add(this.btnCategoryUpdt);
            this.groupBox1.Controls.Add(this.btnCategorySave);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtCategoryDesc);
            this.groupBox1.Controls.Add(this.txtCategoryName);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 658);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Entry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 176;
            this.label6.Text = "Search";
            // 
            // btnSearchCat
            // 
            this.btnSearchCat.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchCat.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearchCat.Location = new System.Drawing.Point(478, 32);
            this.btnSearchCat.Name = "btnSearchCat";
            this.btnSearchCat.Size = new System.Drawing.Size(78, 29);
            this.btnSearchCat.TabIndex = 175;
            this.btnSearchCat.Text = "Search";
            this.btnSearchCat.UseVisualStyleBackColor = false;
            this.btnSearchCat.Click += new System.EventHandler(this.btnSearchCat_Click);
            // 
            // comboSearchCat
            // 
            this.comboSearchCat.FormattingEnabled = true;
            this.comboSearchCat.Location = new System.Drawing.Point(330, 37);
            this.comboSearchCat.Name = "comboSearchCat";
            this.comboSearchCat.Size = new System.Drawing.Size(121, 21);
            this.comboSearchCat.TabIndex = 174;
            // 
            // txtSearcCat
            // 
            this.txtSearcCat.Location = new System.Drawing.Point(136, 37);
            this.txtSearcCat.Name = "txtSearcCat";
            this.txtSearcCat.Size = new System.Drawing.Size(166, 20);
            this.txtSearcCat.TabIndex = 173;
            // 
            // btnCategoryClear
            // 
            this.btnCategoryClear.BackColor = System.Drawing.Color.Violet;
            this.btnCategoryClear.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategoryClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategoryClear.Location = new System.Drawing.Point(430, 284);
            this.btnCategoryClear.Name = "btnCategoryClear";
            this.btnCategoryClear.Size = new System.Drawing.Size(78, 40);
            this.btnCategoryClear.TabIndex = 172;
            this.btnCategoryClear.Text = "Clear";
            this.btnCategoryClear.UseVisualStyleBackColor = false;
            this.btnCategoryClear.Click += new System.EventHandler(this.btnCategoryClear_Click);
            // 
            // txtCategoryCode
            // 
            this.txtCategoryCode.Location = new System.Drawing.Point(136, 142);
            this.txtCategoryCode.Name = "txtCategoryCode";
            this.txtCategoryCode.Size = new System.Drawing.Size(420, 20);
            this.txtCategoryCode.TabIndex = 171;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 170;
            this.label1.Text = "Category Code";
            // 
            // dgvCategory
            // 
            this.dgvCategory.AllowUserToAddRows = false;
            this.dgvCategory.AllowUserToDeleteRows = false;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Location = new System.Drawing.Point(23, 360);
            this.dgvCategory.MultiSelect = false;
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategory.Size = new System.Drawing.Size(607, 273);
            this.dgvCategory.TabIndex = 169;
            this.dgvCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategory_CellClick);
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnCategoryRemove.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategoryRemove.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategoryRemove.Location = new System.Drawing.Point(330, 284);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(78, 40);
            this.btnCategoryRemove.TabIndex = 168;
            this.btnCategoryRemove.Text = "Delete";
            this.btnCategoryRemove.UseVisualStyleBackColor = false;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoryRemove_Click);
            // 
            // btnCategoryUpdt
            // 
            this.btnCategoryUpdt.BackColor = System.Drawing.Color.Orange;
            this.btnCategoryUpdt.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategoryUpdt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategoryUpdt.Location = new System.Drawing.Point(233, 284);
            this.btnCategoryUpdt.Name = "btnCategoryUpdt";
            this.btnCategoryUpdt.Size = new System.Drawing.Size(78, 40);
            this.btnCategoryUpdt.TabIndex = 164;
            this.btnCategoryUpdt.Text = "Update";
            this.btnCategoryUpdt.UseVisualStyleBackColor = false;
            this.btnCategoryUpdt.Click += new System.EventHandler(this.btnCategoryUpdt_Click);
            // 
            // btnCategorySave
            // 
            this.btnCategorySave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCategorySave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnCategorySave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCategorySave.Location = new System.Drawing.Point(136, 282);
            this.btnCategorySave.Name = "btnCategorySave";
            this.btnCategorySave.Size = new System.Drawing.Size(78, 40);
            this.btnCategorySave.TabIndex = 163;
            this.btnCategorySave.Text = "Save";
            this.btnCategorySave.UseVisualStyleBackColor = false;
            this.btnCategorySave.Click += new System.EventHandler(this.btnCategorySave_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(20, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 17);
            this.label21.TabIndex = 129;
            this.label21.Text = "Description";
            // 
            // txtCategoryDesc
            // 
            this.txtCategoryDesc.Location = new System.Drawing.Point(136, 190);
            this.txtCategoryDesc.Multiline = true;
            this.txtCategoryDesc.Name = "txtCategoryDesc";
            this.txtCategoryDesc.Size = new System.Drawing.Size(420, 72);
            this.txtCategoryDesc.TabIndex = 128;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(136, 94);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(420, 20);
            this.txtCategoryName.TabIndex = 127;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(20, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(95, 17);
            this.label22.TabIndex = 126;
            this.label22.Text = "Category Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnSearchSubCat);
            this.groupBox2.Controls.Add(this.comboSearchSubCat);
            this.groupBox2.Controls.Add(this.txtSearchSubCat);
            this.groupBox2.Controls.Add(this.cmbCatType);
            this.groupBox2.Controls.Add(this.txtSubCatCode);
            this.groupBox2.Controls.Add(this.txtSubCatName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnSubCatClear);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgvSubCat);
            this.groupBox2.Controls.Add(this.btnSubCatRemove);
            this.groupBox2.Controls.Add(this.btnSubCatUpdate);
            this.groupBox2.Controls.Add(this.btnSubCatSave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtSubCatDesc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(717, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 658);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sub Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 189;
            this.label7.Text = "Search";
            // 
            // btnSearchSubCat
            // 
            this.btnSearchSubCat.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchSubCat.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchSubCat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearchSubCat.Location = new System.Drawing.Point(483, 19);
            this.btnSearchSubCat.Name = "btnSearchSubCat";
            this.btnSearchSubCat.Size = new System.Drawing.Size(78, 29);
            this.btnSearchSubCat.TabIndex = 188;
            this.btnSearchSubCat.Text = "Search";
            this.btnSearchSubCat.UseVisualStyleBackColor = false;
            this.btnSearchSubCat.Click += new System.EventHandler(this.btnSearchSubCat_Click);
            // 
            // comboSearchSubCat
            // 
            this.comboSearchSubCat.FormattingEnabled = true;
            this.comboSearchSubCat.Location = new System.Drawing.Point(335, 24);
            this.comboSearchSubCat.Name = "comboSearchSubCat";
            this.comboSearchSubCat.Size = new System.Drawing.Size(121, 21);
            this.comboSearchSubCat.TabIndex = 187;
            // 
            // txtSearchSubCat
            // 
            this.txtSearchSubCat.Location = new System.Drawing.Point(141, 24);
            this.txtSearchSubCat.Name = "txtSearchSubCat";
            this.txtSearchSubCat.Size = new System.Drawing.Size(166, 20);
            this.txtSearchSubCat.TabIndex = 186;
            // 
            // cmbCatType
            // 
            this.cmbCatType.FormattingEnabled = true;
            this.cmbCatType.Location = new System.Drawing.Point(141, 163);
            this.cmbCatType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCatType.Name = "cmbCatType";
            this.cmbCatType.Size = new System.Drawing.Size(205, 21);
            this.cmbCatType.TabIndex = 185;
            // 
            // txtSubCatCode
            // 
            this.txtSubCatCode.Location = new System.Drawing.Point(141, 111);
            this.txtSubCatCode.Name = "txtSubCatCode";
            this.txtSubCatCode.Size = new System.Drawing.Size(420, 20);
            this.txtSubCatCode.TabIndex = 184;
            //this.txtSubCatCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubCatCode_KeyPress);
            // 
            // txtSubCatName
            // 
            this.txtSubCatName.Location = new System.Drawing.Point(141, 64);
            this.txtSubCatName.Name = "txtSubCatName";
            this.txtSubCatName.Size = new System.Drawing.Size(420, 20);
            this.txtSubCatName.TabIndex = 184;
            //this.txtSubCatName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubCatName_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 182;
            this.label5.Text = "Category Type";
            // 
            // btnSubCatClear
            // 
            this.btnSubCatClear.BackColor = System.Drawing.Color.Violet;
            this.btnSubCatClear.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubCatClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubCatClear.Location = new System.Drawing.Point(435, 314);
            this.btnSubCatClear.Name = "btnSubCatClear";
            this.btnSubCatClear.Size = new System.Drawing.Size(78, 40);
            this.btnSubCatClear.TabIndex = 173;
            this.btnSubCatClear.Text = "Clear";
            this.btnSubCatClear.UseVisualStyleBackColor = false;
            this.btnSubCatClear.Click += new System.EventHandler(this.btnSubCatClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 180;
            this.label2.Text = "Sub Category Code";
            // 
            // dgvSubCat
            // 
            this.dgvSubCat.AllowUserToAddRows = false;
            this.dgvSubCat.AllowUserToDeleteRows = false;
            this.dgvSubCat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCat.Location = new System.Drawing.Point(28, 362);
            this.dgvSubCat.Name = "dgvSubCat";
            this.dgvSubCat.Size = new System.Drawing.Size(607, 273);
            this.dgvSubCat.TabIndex = 179;
            this.dgvSubCat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubCat_CellClick);
            // 
            // btnSubCatRemove
            // 
            this.btnSubCatRemove.BackColor = System.Drawing.Color.Crimson;
            this.btnSubCatRemove.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubCatRemove.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubCatRemove.Location = new System.Drawing.Point(335, 314);
            this.btnSubCatRemove.Name = "btnSubCatRemove";
            this.btnSubCatRemove.Size = new System.Drawing.Size(78, 40);
            this.btnSubCatRemove.TabIndex = 178;
            this.btnSubCatRemove.Text = "Delete";
            this.btnSubCatRemove.UseVisualStyleBackColor = false;
            this.btnSubCatRemove.Click += new System.EventHandler(this.btnSubCatRemove_Click);
            // 
            // btnSubCatUpdate
            // 
            this.btnSubCatUpdate.BackColor = System.Drawing.Color.Orange;
            this.btnSubCatUpdate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubCatUpdate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubCatUpdate.Location = new System.Drawing.Point(238, 314);
            this.btnSubCatUpdate.Name = "btnSubCatUpdate";
            this.btnSubCatUpdate.Size = new System.Drawing.Size(78, 40);
            this.btnSubCatUpdate.TabIndex = 177;
            this.btnSubCatUpdate.Text = "Update";
            this.btnSubCatUpdate.UseVisualStyleBackColor = false;
            this.btnSubCatUpdate.Click += new System.EventHandler(this.btnSubCatUpdate_Click);
            // 
            // btnSubCatSave
            // 
            this.btnSubCatSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSubCatSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubCatSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSubCatSave.Location = new System.Drawing.Point(141, 311);
            this.btnSubCatSave.Name = "btnSubCatSave";
            this.btnSubCatSave.Size = new System.Drawing.Size(78, 40);
            this.btnSubCatSave.TabIndex = 176;
            this.btnSubCatSave.Text = "Save";
            this.btnSubCatSave.UseVisualStyleBackColor = false;
            this.btnSubCatSave.Click += new System.EventHandler(this.btnSubCatSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 175;
            this.label3.Text = "Description";
            // 
            // txtSubCatDesc
            // 
            this.txtSubCatDesc.Location = new System.Drawing.Point(141, 211);
            this.txtSubCatDesc.Multiline = true;
            this.txtSubCatDesc.Name = "txtSubCatDesc";
            this.txtSubCatDesc.Size = new System.Drawing.Size(420, 72);
            this.txtSubCatDesc.TabIndex = 174;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 172;
            this.label4.Text = "Sub Category Name";
            // 
            // FormEntryCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1366, 680);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormEntryCategory";
            this.Text = "Category Entry Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtCategoryDesc;
        internal System.Windows.Forms.TextBox txtCategoryName;
        internal System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnCategorySave;
        private System.Windows.Forms.Button btnCategoryUpdt;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Button btnCategoryRemove;
        internal System.Windows.Forms.TextBox txtCategoryCode;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSubCat;
        private System.Windows.Forms.Button btnSubCatRemove;
        private System.Windows.Forms.Button btnSubCatUpdate;
        private System.Windows.Forms.Button btnSubCatSave;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtSubCatDesc;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCategoryClear;
        private System.Windows.Forms.ComboBox cmbCatType;
        internal System.Windows.Forms.TextBox txtSubCatCode;
        internal System.Windows.Forms.TextBox txtSubCatName;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubCatClear;
        private System.Windows.Forms.Button btnSearchCat;
        private System.Windows.Forms.ComboBox comboSearchCat;
        internal System.Windows.Forms.TextBox txtSearcCat;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchSubCat;
        private System.Windows.Forms.ComboBox comboSearchSubCat;
        internal System.Windows.Forms.TextBox txtSearchSubCat;
    }
}