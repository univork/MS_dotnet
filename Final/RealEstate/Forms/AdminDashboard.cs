using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class AdminDashboard : UserControl {
        private MainForm main;
        private User admin;
        private AdminActions action;

        public AdminDashboard() {
            InitializeComponent();
        }

        public AdminDashboard(MainForm main, User admin) {
            this.main = main;
            this.admin = admin;
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e) {
            action = AdminActions.Users;
            LoadGrid();
        }

        private void LoadGrid() {
            DtgAdminView.DataSource = null;
            try {
                RealEstateEntities db = new RealEstateEntities();
                var items = new object();

                if (this.action == AdminActions.Users) {
                    items = db.Users.Select(u => new {
                        Id = u.Id, FirstName = u.FirstName,
                        LastName = u.LastName, Email = u.Email,
                        Role = u.Role.RoleName,
                    }).ToList();
                } else if (this.action == AdminActions.Categories) { 
                    items = db.Categories.Select(c => new { Id = c.Id, CategoryName = c.CategoryName }).ToList();
                } else if (this.action == AdminActions.Roles) {
                    items = db.Roles.Select(r => new { Id = r.Id, RoleName = r.RoleName }).ToList();
                } else {
                    items = db.Permissions.Select(p => new { Id = p.Id, PermissionName = p.PermissionName }).ToList();
                }

                DtgAdminView.DataSource = items;
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void MenuItemUsers_Click(object sender, EventArgs e) {
            this.action = AdminActions.Users;
            LoadGrid();
        }

        private void MenuItemRoles_Click(object sender, EventArgs e) {
            this.action = AdminActions.Roles;
            LoadGrid();
        }

        private void MenuItemPermissions_Click(object sender, EventArgs e) {
            this.action = AdminActions.Permissions;
            LoadGrid();
        }

        private void MenuItemProperties_Click(object sender, EventArgs e) {
            UserDashboard userDashboard = new UserDashboard(main, admin);
            userDashboard.Dock = DockStyle.Fill;
            main.Controls.Add(userDashboard);
            userDashboard.BringToFront();
        }
        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e) {
            this.action = AdminActions.Categories;
            LoadGrid();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (DtgAdminView.SelectedRows.Count != 1) {
                MessageBox.Show("Please select 1 item");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) {
                return;
            }

            try {
                int id = (int)DtgAdminView.SelectedRows[0].Cells[0].Value;

                RealEstateEntities db = new RealEstateEntities();

                if (this.action == AdminActions.Users) {
                    User user = db.Users.Where(u => u.Id == id).First();
                    db.Users.Remove(user);
                } else if (this.action == AdminActions.Categories) { 
                    Category category = db.Categories.Where(u => u.Id == id).First();
                    db.Categories.Remove(category);
                } else if (this.action == AdminActions.Roles) {
                    Role role = db.Roles.Where(r => r.Id == id).First();
                    db.Roles.Remove(role);
                } else {
                    Permission permission = db.Permissions.Where(u => u.Id == id).First();
                    db.Permissions.Remove(permission);
                }

                db.SaveChanges();
                LoadGrid();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            if (this.action == AdminActions.Users) {
                RegisterControl register = new RegisterControl(main, "admin");
                register.Dock = DockStyle.Fill;
                main.Controls.Add(register);
                register.BringToFront();
            } else if (this.action == AdminActions.Categories) {
                CategoryForm categoryForm = new CategoryForm(CrudAction.Create);
                categoryForm.Show();
            } else if (this.action == AdminActions.Roles) {
                RoleForm roleForm = new RoleForm(CrudAction.Create);
                roleForm.Show();
            } else if (this.action == AdminActions.Permissions) {
                PermissionForm permissionForm = new PermissionForm(CrudAction.Create);
                permissionForm.Show();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (DtgAdminView.SelectedRows.Count != 1) {
                MessageBox.Show("Please select 1 item");
                return;
            }

            int id = (int)DtgAdminView.SelectedRows[0].Cells[0].Value;

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if (this.action == AdminActions.Users) {
                        User user = db.Users.Where(u => u.Id == id).First();

                        RegisterControl register = new RegisterControl(main, "admin", user);
                        register.Dock = DockStyle.Fill;
                        main.Controls.Add(register);
                        register.BringToFront();
                    } else if (this.action == AdminActions.Categories) {
                        Category category = db.Categories.Where(c => c.Id == id).First();

                        CategoryForm categoryForm = new CategoryForm(CrudAction.Update, category);
                        categoryForm.Show();
                    } else if (this.action == AdminActions.Roles) {
                        Role role = db.Roles.Where(r => r.Id == id).First();

                        RoleForm roleForm = new RoleForm(CrudAction.Create);
                        roleForm.Show();
                    } else if (this.action == AdminActions.Permissions) {
                        Permission perm = db.Permissions.Where(p => p.Id == id).First();

                        PermissionForm permissionForm = new PermissionForm(CrudAction.Update, perm);
                        permissionForm.Show();
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }

        private void MenuItemLogout_Click(object sender, EventArgs e) {
            LoginControl login = new LoginControl(main);
            login.Dock = DockStyle.Fill;
            main.Controls.Add(login);

            main.Controls.Remove(this);
        }
    }
}
