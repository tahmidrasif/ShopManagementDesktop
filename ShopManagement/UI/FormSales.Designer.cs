using System.Drawing;

namespace ShopManagement.UI
{
    partial class FormSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSales));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtSaleQty = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtAvailableQty = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddCart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscountPer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.payment = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtTaxAmt = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.txtTaxPer = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.dtpBillDate);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.txtTotalAmount);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtProductName);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.txtSaleQty);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.txtPrice);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.txtAvailableQty);
            this.GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox1.Location = new System.Drawing.Point(11, 69);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(592, 226);
            this.GroupBox1.TabIndex = 108;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Product Details";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(26, 176);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 17);
            this.Label3.TabIndex = 103;
            this.Label3.Text = "Invoice Date";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpBillDate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(138, 170);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(120, 24);
            this.dtpBillDate.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(508, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 22);
            this.label7.TabIndex = 94;
            this.label7.Text = "$";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(370, 126);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(132, 24);
            this.txtTotalAmount.TabIndex = 93;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label11.Location = new System.Drawing.Point(26, 126);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(57, 17);
            this.Label11.TabIndex = 89;
            this.Label11.Text = "Sale Qty.";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(26, 44);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 17);
            this.Label5.TabIndex = 74;
            this.Label5.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(138, 39);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(364, 24);
            this.txtProductName.TabIndex = 1;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(26, 86);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(61, 17);
            this.Label12.TabIndex = 87;
            this.Label12.Text = "Unit Price";
            // 
            // txtSaleQty
            // 
            this.txtSaleQty.Location = new System.Drawing.Point(138, 126);
            this.txtSaleQty.Name = "txtSaleQty";
            this.txtSaleQty.Size = new System.Drawing.Size(89, 24);
            this.txtSaleQty.TabIndex = 4;
            this.txtSaleQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(271, 86);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(81, 17);
            this.Label9.TabIndex = 75;
            this.Label9.Text = "Available Qty";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(138, 79);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(89, 24);
            this.txtPrice.TabIndex = 3;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(271, 126);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(85, 17);
            this.Label10.TabIndex = 76;
            this.Label10.Text = "Total Amount";
            // 
            // txtAvailableQty
            // 
            this.txtAvailableQty.Location = new System.Drawing.Point(370, 79);
            this.txtAvailableQty.Name = "txtAvailableQty";
            this.txtAvailableQty.ReadOnly = true;
            this.txtAvailableQty.Size = new System.Drawing.Size(89, 24);
            this.txtAvailableQty.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(620, 132);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(671, 366);
            this.dataGridView1.TabIndex = 109;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCart,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1296, 55);
            this.toolStrip1.TabIndex = 110;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddCart
            // 
            this.btnAddCart.AutoSize = false;
            this.btnAddCart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddCart.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCart.Image")));
            this.btnAddCart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCart.Name = "btnAddCart";
            this.btnAddCart.Size = new System.Drawing.Size(65, 55);
            this.btnAddCart.Text = "toolStripButton1";
            this.btnAddCart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddCart.ToolTipText = "Add To Cart";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 55);
            this.toolStripButton2.Text = "toolStripButton1";
            this.toolStripButton2.ToolTipText = "Clear Cart";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 55);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Generate Invoice";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(65, 55);
            this.toolStripButton3.Text = "toolStripButton1";
            this.toolStripButton3.ToolTipText = "Print Receipt";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUserName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 644);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1296, 22);
            this.statusStrip1.TabIndex = 111;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "User";
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(121, 17);
            this.lblUserName.Text = "toolStripStatusLabel2";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(620, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 49);
            this.panel1.TabIndex = 113;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(588, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Category";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(426, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 20);
            this.textBox1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 301);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(591, 325);
            this.dataGridView2.TabIndex = 114;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(899, 529);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 22);
            this.label21.TabIndex = 136;
            this.label21.Text = "$";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(899, 597);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 22);
            this.label20.TabIndex = 135;
            this.label20.Text = "$";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(899, 563);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 22);
            this.label18.TabIndex = 134;
            this.label18.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1169, 602);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 22);
            this.label6.TabIndex = 133;
            this.label6.Text = "$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1169, 569);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 22);
            this.label4.TabIndex = 132;
            this.label4.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1169, 538);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 22);
            this.label8.TabIndex = 131;
            this.label8.Text = "$";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(823, 597);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(70, 20);
            this.txtDiscountAmount.TabIndex = 120;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(790, 597);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 21);
            this.label17.TabIndex = 130;
            this.label17.Text = "%";
            // 
            // txtDiscountPer
            // 
            this.txtDiscountPer.Location = new System.Drawing.Point(732, 598);
            this.txtDiscountPer.Name = "txtDiscountPer";
            this.txtDiscountPer.Size = new System.Drawing.Size(52, 20);
            this.txtDiscountPer.TabIndex = 116;
            this.txtDiscountPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(635, 601);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 17);
            this.label13.TabIndex = 129;
            this.label13.Text = "Discount";
            // 
            // txtChange
            // 
            this.txtChange.Location = new System.Drawing.Point(1082, 602);
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(81, 20);
            this.txtChange.TabIndex = 121;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCash
            // 
            this.txtCash.Location = new System.Drawing.Point(1082, 569);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(81, 20);
            this.txtCash.TabIndex = 117;
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(985, 602);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(50, 17);
            this.Label19.TabIndex = 128;
            this.Label19.Text = "Change";
            // 
            // payment
            // 
            this.payment.AutoSize = true;
            this.payment.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment.Location = new System.Drawing.Point(985, 570);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(35, 17);
            this.payment.TabIndex = 127;
            this.payment.Text = "Cash";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(1082, 536);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(81, 20);
            this.txtTotal.TabIndex = 122;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(985, 536);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(75, 17);
            this.Label16.TabIndex = 126;
            this.Label16.Text = "Grand Total";
            // 
            // txtTaxAmt
            // 
            this.txtTaxAmt.Location = new System.Drawing.Point(823, 562);
            this.txtTaxAmt.Name = "txtTaxAmt";
            this.txtTaxAmt.ReadOnly = true;
            this.txtTaxAmt.Size = new System.Drawing.Size(70, 20);
            this.txtTaxAmt.TabIndex = 119;
            this.txtTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.BackColor = System.Drawing.Color.Transparent;
            this.Label24.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(790, 562);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(23, 21);
            this.Label24.TabIndex = 125;
            this.Label24.Text = "%";
            // 
            // txtTaxPer
            // 
            this.txtTaxPer.Location = new System.Drawing.Point(732, 563);
            this.txtTaxPer.Name = "txtTaxPer";
            this.txtTaxPer.Size = new System.Drawing.Size(52, 20);
            this.txtTaxPer.TabIndex = 115;
            this.txtTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(636, 566);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(55, 17);
            this.Label15.TabIndex = 124;
            this.Label15.Text = "VAT+ST";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(732, 529);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(161, 20);
            this.txtSubTotal.TabIndex = 118;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(635, 531);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(61, 17);
            this.Label14.TabIndex = 123;
            this.Label14.Text = "Sub Total";
            // 
            // FormSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 666);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDiscountAmount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtDiscountPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.payment);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.txtTaxAmt);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.txtTaxPer);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GroupBox1);
            this.Name = "FormSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSales";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtTotalAmount;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtProductName;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox txtSaleQty;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtPrice;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtAvailableQty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblUserName;
        private System.Windows.Forms.ToolStripButton btnAddCart;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtDiscountAmount;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox txtDiscountPer;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtChange;
        internal System.Windows.Forms.TextBox txtCash;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label payment;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox txtTaxAmt;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.TextBox txtTaxPer;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtSubTotal;
        internal System.Windows.Forms.Label Label14;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}