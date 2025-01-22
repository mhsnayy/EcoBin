namespace Graduation_Project1
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.btnBoxForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClothesForm = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditUser = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnBoxForm
            // 
            this.btnBoxForm.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBoxForm.Appearance.Options.UseFont = true;
            this.btnBoxForm.ImageOptions.SvgImage = global::Graduation_Project1.Properties.Resources.boxes;
            this.btnBoxForm.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.btnBoxForm.Location = new System.Drawing.Point(659, 301);
            this.btnBoxForm.Name = "btnBoxForm";
            this.btnBoxForm.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBoxForm.Size = new System.Drawing.Size(169, 93);
            this.btnBoxForm.TabIndex = 0;
            this.btnBoxForm.Text = "BOXES";
            this.btnBoxForm.Click += new System.EventHandler(this.btnBoxForm_Click);
            // 
            // btnClothesForm
            // 
            this.btnClothesForm.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClothesForm.Appearance.Options.UseFont = true;
            this.btnClothesForm.ImageOptions.SvgImage = global::Graduation_Project1.Properties.Resources.kıyafetler;
            this.btnClothesForm.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.btnClothesForm.Location = new System.Drawing.Point(445, 301);
            this.btnClothesForm.Name = "btnClothesForm";
            this.btnClothesForm.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnClothesForm.Size = new System.Drawing.Size(169, 93);
            this.btnClothesForm.TabIndex = 0;
            this.btnClothesForm.Text = "CLOTHES";
            this.btnClothesForm.Click += new System.EventHandler(this.btnClothesForm_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditUser.Appearance.Options.UseFont = true;
            this.btnEditUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditUser.ImageOptions.SvgImage")));
            this.btnEditUser.ImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
            this.btnEditUser.Location = new System.Drawing.Point(555, 400);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEditUser.Size = new System.Drawing.Size(169, 93);
            this.btnEditUser.TabIndex = 0;
            this.btnEditUser.Text = "EDIT USERS";
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 821);
            this.Controls.Add(this.btnClothesForm);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnBoxForm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnBoxForm;
        private DevExpress.XtraEditors.SimpleButton btnClothesForm;
        private DevExpress.XtraEditors.SimpleButton btnEditUser;
    }
}