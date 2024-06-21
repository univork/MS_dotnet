using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class RoleForm : Form {
        private CrudAction action;

        public RoleForm() {
            InitializeComponent();
        }

        public RoleForm(CrudAction action) {
            this.action = action;
            InitializeComponent();
        }

        private void RoleForm_Load(object sender, EventArgs e) {
            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    //foreach(var perm in db.Permissions.ToList()) {
                    //    CheckListPermissions.Items.Add(perm, false);
                    //}
                    ((ListBox)CheckListPermissions).DataSource = db.Permissions.ToList();
                    ((ListBox)CheckListPermissions).DisplayMember = "PermissionName";
                    ((ListBox)CheckListPermissions).ValueMember = "Id";
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e) {
            string RoleName = TbRoleName.Text;
            bool error = false;

            if(!Regex.IsMatch(RoleName, @"^[a-zA-Z]+$")) {
                TbRoleName.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    List<Permission> permissions = new List<Permission>();
                    foreach (object itemChecked in CheckListPermissions.SelectedItems) {
                        MessageBox.Show(itemChecked.ToString());
                    }
                    Role role = new Role {
                        RoleName = RoleName,
                        Permissions = permissions 
                    };
                    db.Roles.Add(role);
                    db.SaveChanges();
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }
    }
}
