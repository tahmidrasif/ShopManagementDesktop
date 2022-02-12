namespace ShopManagement.UI.Dialogue
{
    partial class DialoguePOProcessingOperation
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
            this.lblTxt = new System.Windows.Forms.Label();
            this.btnPayAdvance = new System.Windows.Forms.Button();
            this.btnPayPartial = new System.Windows.Forms.Button();
            this.btnFullPay = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTxt
            // 
            this.lblTxt.AutoSize = true;
            this.lblTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt.Location = new System.Drawing.Point(53, 18);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(70, 28);
            this.lblTxt.TabIndex = 0;
            this.lblTxt.Text = "label1";
            // 
            // btnPayAdvance
            // 
            this.btnPayAdvance.BackColor = System.Drawing.Color.DarkCyan;
            this.btnPayAdvance.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnPayAdvance.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPayAdvance.Location = new System.Drawing.Point(58, 153);
            this.btnPayAdvance.Margin = new System.Windows.Forms.Padding(4);
            this.btnPayAdvance.Name = "btnPayAdvance";
            this.btnPayAdvance.Size = new System.Drawing.Size(156, 49);
            this.btnPayAdvance.TabIndex = 246;
            this.btnPayAdvance.Text = "Pay Advance";
            this.btnPayAdvance.UseVisualStyleBackColor = false;
            // 
            // btnPayPartial
            // 
            this.btnPayPartial.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPayPartial.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnPayPartial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPayPartial.Location = new System.Drawing.Point(268, 153);
            this.btnPayPartial.Margin = new System.Windows.Forms.Padding(4);
            this.btnPayPartial.Name = "btnPayPartial";
            this.btnPayPartial.Size = new System.Drawing.Size(156, 49);
            this.btnPayPartial.TabIndex = 247;
            this.btnPayPartial.Text = "Partial Pay";
            this.btnPayPartial.UseVisualStyleBackColor = false;
            // 
            // btnFullPay
            // 
            this.btnFullPay.BackColor = System.Drawing.Color.DarkBlue;
            this.btnFullPay.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnFullPay.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFullPay.Location = new System.Drawing.Point(478, 153);
            this.btnFullPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnFullPay.Name = "btnFullPay";
            this.btnFullPay.Size = new System.Drawing.Size(156, 49);
            this.btnFullPay.TabIndex = 248;
            this.btnFullPay.Text = "Full Pay";
            this.btnFullPay.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(54, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 249;
            this.label5.Text = "Order Code";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Location = new System.Drawing.Point(168, 81);
            this.txtOrderCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.Size = new System.Drawing.Size(156, 22);
            this.txtOrderCode.TabIndex = 250;
            // 
            // DialoguePOProcessingOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 229);
            this.Controls.Add(this.txtOrderCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFullPay);
            this.Controls.Add(this.btnPayPartial);
            this.Controls.Add(this.btnPayAdvance);
            this.Controls.Add(this.lblTxt);
            this.Name = "DialoguePOProcessingOperation";
            this.Text = "Payment Operation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTxt;
        private System.Windows.Forms.Button btnPayAdvance;
        private System.Windows.Forms.Button btnPayPartial;
        private System.Windows.Forms.Button btnFullPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderCode;
    }
}