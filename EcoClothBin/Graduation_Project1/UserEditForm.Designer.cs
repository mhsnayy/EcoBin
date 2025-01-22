namespace Graduation_Project1
{
    partial class UserEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEditForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnHomePage = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteUser = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddUser = new DevExpress.XtraEditors.SimpleButton();
            this.txtDistrict = new DevExpress.XtraEditors.TextEdit();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.txtUserPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Coral;
            this.splitContainer1.Panel1.Controls.Add(this.simpleButton1);
            this.splitContainer1.Panel1.Controls.Add(this.btnHomePage);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteUser);
            this.splitContainer1.Panel1.Controls.Add(this.radioGroup1);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditUser);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddUser);
            this.splitContainer1.Panel1.Controls.Add(this.txtDistrict);
            this.splitContainer1.Panel1.Controls.Add(this.txtCity);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserID);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserPassword);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 821);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnHomePage
            // 
            this.btnHomePage.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHomePage.Appearance.Options.UseFont = true;
            this.btnHomePage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHomePage.ImageOptions.SvgImage")));
            this.btnHomePage.Location = new System.Drawing.Point(174, 560);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnHomePage.Size = new System.Drawing.Size(170, 48);
            this.btnHomePage.TabIndex = 23;
            this.btnHomePage.Text = "Home Page";
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteUser.Appearance.Options.UseFont = true;
            this.btnDeleteUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDeleteUser.ImageOptions.SvgImage")));
            this.btnDeleteUser.Location = new System.Drawing.Point(174, 507);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnDeleteUser.Size = new System.Drawing.Size(170, 47);
            this.btnDeleteUser.TabIndex = 22;
            this.btnDeleteUser.Text = "DELETE USER";
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // radioGroup1
            // 
            this.radioGroup1.AutoSizeInLayoutControl = true;
            this.radioGroup1.Location = new System.Drawing.Point(193, 317);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Columns = 1;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Admin", true, null, "Admin"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "User", true, null, "User")});
            this.radioGroup1.Size = new System.Drawing.Size(170, 67);
            this.radioGroup1.TabIndex = 21;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditUser.Appearance.Options.UseFont = true;
            this.btnEditUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditUser.ImageOptions.SvgImage")));
            this.btnEditUser.Location = new System.Drawing.Point(174, 454);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEditUser.Size = new System.Drawing.Size(170, 47);
            this.btnEditUser.TabIndex = 19;
            this.btnEditUser.Text = "EDIT USER";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddUser.Appearance.Options.UseFont = true;
            this.btnAddUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAddUser.ImageOptions.SvgImage")));
            this.btnAddUser.Location = new System.Drawing.Point(174, 390);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAddUser.Size = new System.Drawing.Size(170, 47);
            this.btnAddUser.TabIndex = 20;
            this.btnAddUser.Text = "ADD USER";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(193, 278);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDistrict.Properties.Appearance.Options.UseFont = true;
            this.txtDistrict.Size = new System.Drawing.Size(170, 30);
            this.txtDistrict.TabIndex = 4;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(193, 238);
            this.txtCity.Name = "txtCity";
            this.txtCity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCity.Properties.Appearance.Options.UseFont = true;
            this.txtCity.Size = new System.Drawing.Size(170, 30);
            this.txtCity.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(193, 88);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Size = new System.Drawing.Size(170, 30);
            this.txtUserID.TabIndex = 0;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(193, 192);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserPassword.Properties.Appearance.Options.UseFont = true;
            this.txtUserPassword.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtUserPassword.Properties.ContextImageOptions.SvgImage")));
            this.txtUserPassword.Size = new System.Drawing.Size(170, 36);
            this.txtUserPassword.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(193, 136);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtUserName.Properties.ContextImageOptions.SvgImage")));
            this.txtUserName.Size = new System.Drawing.Size(170, 36);
            this.txtUserName.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(30, 192);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(157, 35);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "USER PASSWORD:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(73, 134);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 38);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "USER NAME:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(94, 281);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(93, 38);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "DISTRICT:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(136, 233);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 48);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "CITY:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(101, 83);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 38);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "USER ID:";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(833, 797);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(174, 614);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(170, 52);
            this.simpleButton1.TabIndex = 24;
            this.simpleButton1.Text = "LOG OUT";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 821);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Edit";
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton btnEditUser;
        private DevExpress.XtraEditors.SimpleButton btnAddUser;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.TextEdit txtUserPassword;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.SimpleButton btnDeleteUser;
        private DevExpress.XtraEditors.TextEdit txtDistrict;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnHomePage;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}