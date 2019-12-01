namespace Array
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.txtKQ = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.KhungSapXep = new System.Windows.Forms.GroupBox();
            this.radioSXG = new System.Windows.Forms.RadioButton();
            this.radioSXT = new System.Windows.Forms.RadioButton();
            this.btnNhap = new System.Windows.Forms.Button();
            this.KhungSapXep.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kết quả mảng:";
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(98, 41);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(246, 20);
            this.txtNhap.TabIndex = 1;
            // 
            // txtKQ
            // 
            this.txtKQ.Location = new System.Drawing.Point(98, 71);
            this.txtKQ.Name = "txtKQ";
            this.txtKQ.Size = new System.Drawing.Size(246, 20);
            this.txtKQ.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(369, 39);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(369, 71);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(15, 119);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 45);
            this.btnAction.TabIndex = 3;
            this.btnAction.Text = "Thực hiện:";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // KhungSapXep
            // 
            this.KhungSapXep.Controls.Add(this.radioSXG);
            this.KhungSapXep.Controls.Add(this.radioSXT);
            this.KhungSapXep.Location = new System.Drawing.Point(98, 106);
            this.KhungSapXep.Name = "KhungSapXep";
            this.KhungSapXep.Size = new System.Drawing.Size(346, 100);
            this.KhungSapXep.TabIndex = 4;
            this.KhungSapXep.TabStop = false;
            this.KhungSapXep.Text = "Sắp xếp";
            // 
            // radioSXG
            // 
            this.radioSXG.AutoSize = true;
            this.radioSXG.Location = new System.Drawing.Point(239, 41);
            this.radioSXG.Name = "radioSXG";
            this.radioSXG.Size = new System.Drawing.Size(89, 17);
            this.radioSXG.TabIndex = 0;
            this.radioSXG.TabStop = true;
            this.radioSXG.Text = "Sắp xếp giảm";
            this.radioSXG.UseVisualStyleBackColor = true;
            // 
            // radioSXT
            // 
            this.radioSXT.AutoSize = true;
            this.radioSXT.Location = new System.Drawing.Point(31, 41);
            this.radioSXT.Name = "radioSXT";
            this.radioSXT.Size = new System.Drawing.Size(88, 17);
            this.radioSXT.TabIndex = 0;
            this.radioSXT.TabStop = true;
            this.radioSXT.Text = "Sắp xếp tăng";
            this.radioSXT.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(12, 39);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 23);
            this.btnNhap.TabIndex = 2;
            this.btnNhap.Text = "Nhập mảng:";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btn_Nhap);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 261);
            this.Controls.Add(this.KhungSapXep);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtKQ);
            this.Controls.Add(this.txtNhap);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Mảng Số Thực";
            this.KhungSapXep.ResumeLayout(false);
            this.KhungSapXep.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.TextBox txtKQ;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.GroupBox KhungSapXep;
        private System.Windows.Forms.RadioButton radioSXG;
        private System.Windows.Forms.RadioButton radioSXT;
        private System.Windows.Forms.Button btnNhap;
    }
}

