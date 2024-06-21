using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class PermissionForm : Form {
        private CrudAction action;
        private Permission perm;

        public PermissionForm() {
            InitializeComponent();
        }

        public PermissionForm(CrudAction action) {
            this.action = action;
            InitializeComponent();
        }

        public PermissionForm(CrudAction action, Permission perm) {
            this.action = action;
            this.perm = perm;
            InitializeComponent();
        }

        private void PermissionForm_Load(object sender, EventArgs e) {
            if(this.action == CrudAction.Update) {
                TbPermissionName.Text = perm.PermissionName;
                LbTitle.Text = "Update Permission";
                BtnAdd.Text = "Update";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            string PermissionName = TbPermissionName.Text;
            bool error = false;

            if(!Regex.IsMatch(PermissionName, @"^[a-zA-Z]+$")) {
                TbPermissionName.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;
            
            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if(this.action == CrudAction.Create) {
                        Permission permission = new Permission {
                            PermissionName = PermissionName
                        };
                        db.Permissions.Add(permission);
                    } else {
                        Permission permission = db.Permissions.Where(c => c.Id == perm.Id).First();
                        permission.PermissionName = PermissionName;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Permission created");
                    this.Close();
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }
    }
}
