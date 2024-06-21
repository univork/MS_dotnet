
namespace RealEstate.Forms {
    partial class UserDashboard {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DtgProperties = new System.Windows.Forms.DataGridView();
            this.BtnClose = new System.Windows.Forms.Button();
            this.MenuUser = new System.Windows.Forms.MenuStrip();
            this.MenuItemProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProperties)).BeginInit();
            this.MenuUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(209, 84);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(97, 30);
            this.BtnDelete.TabIndex = 8;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(106, 84);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(97, 30);
            this.BtnEdit.TabIndex = 7;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(3, 84);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(97, 30);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DtgProperties
            // 
            this.DtgProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgProperties.Location = new System.Drawing.Point(3, 120);
            this.DtgProperties.Name = "DtgProperties";
            this.DtgProperties.Size = new System.Drawing.Size(810, 349);
            this.DtgProperties.TabIndex = 5;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnClose.BackgroundImage = global::RealEstate.Properties.Resources.close;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Location = new System.Drawing.Point(782, 26);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(31, 23);
            this.BtnClose.TabIndex = 25;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Visible = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // MenuUser
            // 
            this.MenuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemProfile,
            this.MenuItemLogout});
            this.MenuUser.Location = new System.Drawing.Point(0, 0);
            this.MenuUser.Name = "MenuUser";
            this.MenuUser.Size = new System.Drawing.Size(816, 24);
            this.MenuUser.TabIndex = 26;
            this.MenuUser.Text = "menuStrip1";
            // 
            // MenuItemProfile
            // 
            this.MenuItemProfile.Name = "MenuItemProfile";
            this.MenuItemProfile.Size = new System.Drawing.Size(53, 20);
            this.MenuItemProfile.Text = "Profile";
            this.MenuItemProfile.Click += new System.EventHandler(this.MenuItemProfile_Click);
            // 
            // MenuItemLogout
            // 
            this.MenuItemLogout.Name = "MenuItemLogout";
            this.MenuItemLogout.Size = new System.Drawing.Size(57, 20);
            this.MenuItemLogout.Text = "Logout";
            this.MenuItemLogout.Click += new System.EventHandler(this.MenuItemLogout_Click);
            // 
            // BtnReload
            // 
            this.BtnReload.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReload.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReload.ForeColor = System.Drawing.Color.White;
            this.BtnReload.Location = new System.Drawing.Point(716, 84);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(97, 30);
            this.BtnReload.TabIndex = 8;
            this.BtnReload.Text = "Reload";
            this.BtnReload.UseVisualStyleBackColor = false;
            this.BtnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnReload);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.DtgProperties);
            this.Controls.Add(this.MenuUser);
            this.Name = "UserDashboard";
            this.Size = new System.Drawing.Size(816, 472);
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgProperties)).EndInit();
            this.MenuUser.ResumeLayout(false);
            this.MenuUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView DtgProperties;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.MenuStrip MenuUser;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProfile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLogout;
        private System.Windows.Forms.Button BtnReload;
    }
}
