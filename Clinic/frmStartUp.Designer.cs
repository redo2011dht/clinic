namespace Clinic
{
    partial class frmStartUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStartUp));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBoxContent = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetting = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnOperation = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnReport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnExam = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPharmacy = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDoc = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.groupBoxContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.panelTop.Controls.Add(this.panelLogo);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(802, 72);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = global::Clinic.Properties.Resources.logo;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Location = new System.Drawing.Point(12, 17);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(45, 45);
            this.panelLogo.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SeaGreen;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(810, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(63, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Phòng khám Tâm Đức";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 72);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(10, 367);
            this.panelLeft.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(792, 72);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(10, 367);
            this.panelRight.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(10, 419);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(782, 20);
            this.panelBottom.TabIndex = 0;
            // 
            // groupBoxContent
            // 
            this.groupBoxContent.Controls.Add(this.btnExit);
            this.groupBoxContent.Controls.Add(this.btnSetting);
            this.groupBoxContent.Controls.Add(this.btnOperation);
            this.groupBoxContent.Controls.Add(this.btnReport);
            this.groupBoxContent.Controls.Add(this.btnExam);
            this.groupBoxContent.Controls.Add(this.btnPharmacy);
            this.groupBoxContent.Controls.Add(this.btnDoc);
            this.groupBoxContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxContent.Location = new System.Drawing.Point(10, 72);
            this.groupBoxContent.Name = "groupBoxContent";
            this.groupBoxContent.Size = new System.Drawing.Size(782, 347);
            this.groupBoxContent.TabIndex = 1;
            this.groupBoxContent.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(619, 318);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(157, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Thoát chương trình";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.BorderRadius = 0;
            this.btnSetting.ButtonText = "Cài đặt";
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.DisabledColor = System.Drawing.Color.Gray;
            this.btnSetting.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSetting.Iconimage = global::Clinic.Properties.Resources.setting_64x64;
            this.btnSetting.Iconimage_right = null;
            this.btnSetting.Iconimage_right_Selected = null;
            this.btnSetting.Iconimage_Selected = null;
            this.btnSetting.IconMarginLeft = 0;
            this.btnSetting.IconMarginRight = 0;
            this.btnSetting.IconRightVisible = true;
            this.btnSetting.IconRightZoom = 0D;
            this.btnSetting.IconVisible = true;
            this.btnSetting.IconZoom = 90D;
            this.btnSetting.IsTab = false;
            this.btnSetting.Location = new System.Drawing.Point(517, 217);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnSetting.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnSetting.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSetting.selected = false;
            this.btnSetting.Size = new System.Drawing.Size(167, 48);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "Cài đặt";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetting.Textcolor = System.Drawing.Color.White;
            this.btnSetting.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnOperation
            // 
            this.btnOperation.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnOperation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOperation.BorderRadius = 0;
            this.btnOperation.ButtonText = "Cận lâm sàng";
            this.btnOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOperation.DisabledColor = System.Drawing.Color.Gray;
            this.btnOperation.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOperation.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnOperation.Iconimage")));
            this.btnOperation.Iconimage_right = null;
            this.btnOperation.Iconimage_right_Selected = null;
            this.btnOperation.Iconimage_Selected = null;
            this.btnOperation.IconMarginLeft = 0;
            this.btnOperation.IconMarginRight = 0;
            this.btnOperation.IconRightVisible = true;
            this.btnOperation.IconRightZoom = 0D;
            this.btnOperation.IconVisible = true;
            this.btnOperation.IconZoom = 90D;
            this.btnOperation.IsTab = false;
            this.btnOperation.Location = new System.Drawing.Point(255, 107);
            this.btnOperation.Name = "btnOperation";
            this.btnOperation.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnOperation.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnOperation.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOperation.selected = false;
            this.btnOperation.Size = new System.Drawing.Size(250, 48);
            this.btnOperation.TabIndex = 0;
            this.btnOperation.Text = "Cận lâm sàng";
            this.btnOperation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOperation.Textcolor = System.Drawing.Color.White;
            this.btnOperation.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnReport
            // 
            this.btnReport.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReport.BorderRadius = 0;
            this.btnReport.ButtonText = "Báo cáo";
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.DisabledColor = System.Drawing.Color.Gray;
            this.btnReport.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReport.Iconimage = global::Clinic.Properties.Resources.report_64x64;
            this.btnReport.Iconimage_right = null;
            this.btnReport.Iconimage_right_Selected = null;
            this.btnReport.Iconimage_Selected = null;
            this.btnReport.IconMarginLeft = 0;
            this.btnReport.IconMarginRight = 0;
            this.btnReport.IconRightVisible = true;
            this.btnReport.IconRightZoom = 0D;
            this.btnReport.IconVisible = true;
            this.btnReport.IconZoom = 90D;
            this.btnReport.IsTab = false;
            this.btnReport.Location = new System.Drawing.Point(255, 217);
            this.btnReport.Name = "btnReport";
            this.btnReport.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnReport.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnReport.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReport.selected = false;
            this.btnReport.Size = new System.Drawing.Size(179, 48);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Báo cáo";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnReport.Textcolor = System.Drawing.Color.White;
            this.btnReport.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnExam
            // 
            this.btnExam.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnExam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExam.BorderRadius = 0;
            this.btnExam.ButtonText = "Hóa đơn";
            this.btnExam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExam.DisabledColor = System.Drawing.Color.Gray;
            this.btnExam.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExam.Iconimage = global::Clinic.Properties.Resources.doctor_64x64;
            this.btnExam.Iconimage_right = null;
            this.btnExam.Iconimage_right_Selected = null;
            this.btnExam.Iconimage_Selected = null;
            this.btnExam.IconMarginLeft = 0;
            this.btnExam.IconMarginRight = 0;
            this.btnExam.IconRightVisible = true;
            this.btnExam.IconRightZoom = 0D;
            this.btnExam.IconVisible = true;
            this.btnExam.IconZoom = 90D;
            this.btnExam.IsTab = false;
            this.btnExam.Location = new System.Drawing.Point(56, 217);
            this.btnExam.Name = "btnExam";
            this.btnExam.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnExam.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnExam.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExam.selected = false;
            this.btnExam.Size = new System.Drawing.Size(180, 48);
            this.btnExam.TabIndex = 0;
            this.btnExam.Text = "Hóa đơn";
            this.btnExam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExam.Textcolor = System.Drawing.Color.White;
            this.btnExam.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnPharmacy
            // 
            this.btnPharmacy.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnPharmacy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnPharmacy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPharmacy.BorderRadius = 0;
            this.btnPharmacy.ButtonText = "Dược";
            this.btnPharmacy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPharmacy.DisabledColor = System.Drawing.Color.Gray;
            this.btnPharmacy.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPharmacy.Iconimage = global::Clinic.Properties.Resources.pharmacy_64x64;
            this.btnPharmacy.Iconimage_right = null;
            this.btnPharmacy.Iconimage_right_Selected = null;
            this.btnPharmacy.Iconimage_Selected = null;
            this.btnPharmacy.IconMarginLeft = 0;
            this.btnPharmacy.IconMarginRight = 0;
            this.btnPharmacy.IconRightVisible = true;
            this.btnPharmacy.IconRightZoom = 0D;
            this.btnPharmacy.IconVisible = true;
            this.btnPharmacy.IconZoom = 90D;
            this.btnPharmacy.IsTab = false;
            this.btnPharmacy.Location = new System.Drawing.Point(517, 107);
            this.btnPharmacy.Name = "btnPharmacy";
            this.btnPharmacy.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnPharmacy.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnPharmacy.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPharmacy.selected = false;
            this.btnPharmacy.Size = new System.Drawing.Size(138, 48);
            this.btnPharmacy.TabIndex = 0;
            this.btnPharmacy.Text = "Dược";
            this.btnPharmacy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPharmacy.Textcolor = System.Drawing.Color.White;
            this.btnPharmacy.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPharmacy.Click += new System.EventHandler(this.btnPharmacy_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoc.BorderRadius = 0;
            this.btnDoc.ButtonText = "Hồ sơ";
            this.btnDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoc.DisabledColor = System.Drawing.Color.Gray;
            this.btnDoc.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDoc.Iconimage = global::Clinic.Properties.Resources.document_64x64;
            this.btnDoc.Iconimage_right = null;
            this.btnDoc.Iconimage_right_Selected = null;
            this.btnDoc.Iconimage_Selected = null;
            this.btnDoc.IconMarginLeft = 0;
            this.btnDoc.IconMarginRight = 0;
            this.btnDoc.IconRightVisible = true;
            this.btnDoc.IconRightZoom = 0D;
            this.btnDoc.IconVisible = true;
            this.btnDoc.IconZoom = 90D;
            this.btnDoc.IsTab = false;
            this.btnDoc.Location = new System.Drawing.Point(56, 107);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnDoc.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.btnDoc.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDoc.selected = false;
            this.btnDoc.Size = new System.Drawing.Size(158, 48);
            this.btnDoc.TabIndex = 0;
            this.btnDoc.Text = "Hồ sơ";
            this.btnDoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDoc.Textcolor = System.Drawing.Color.White;
            this.btnDoc.TextFont = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // frmStartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(802, 439);
            this.Controls.Add(this.groupBoxContent);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStartUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.groupBoxContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox groupBoxContent;
        private Bunifu.Framework.UI.BunifuFlatButton btnSetting;
        private Bunifu.Framework.UI.BunifuFlatButton btnOperation;
        private Bunifu.Framework.UI.BunifuFlatButton btnReport;
        private Bunifu.Framework.UI.BunifuFlatButton btnExam;
        private Bunifu.Framework.UI.BunifuFlatButton btnPharmacy;
        private Bunifu.Framework.UI.BunifuFlatButton btnDoc;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelLogo;
    }
}

