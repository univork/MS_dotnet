using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class UserDashboard : UserControl {
        private User user;
        private MainForm main;

        public UserDashboard() {
            InitializeComponent();
        }

        public UserDashboard(MainForm main, User user) {
            this.main = main;
            this.user = user;
            InitializeComponent();
        }

        private void UserDashboard_Load(object sender, EventArgs e) {
            if(user.Role.RoleName.Equals("buyer")) {
                BtnAdd.Visible = false;
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }
            if(user.Role.RoleName.Equals("admin")) {
                BtnClose.Visible = true;
                MenuUser.Visible = false;
            }
            LoadGrid();
        }

        private void LoadGrid() {
            DtgProperties.DataSource = null;
            try {
                RealEstateEntities db = new RealEstateEntities();
                var items = new object();

                if(user.Role.Equals("agent")) {
                    items = db.Properties.Where(p => p.AgentId == user.Id)
                        .Select(p => new {
                            Id = p.Id,
                            PropertyName = p.PropertyName,
                            Description = p.Description,
                            Category = p.Category.CategoryName,
                            Rooms = p.Rooms,
                            Size = p.Size,
                            Floors = p.Floors,
                            Country = p.Location.Country,
                            City = p.Location.City,
                            AgentEmail = p.User.Email
                        }).ToList();
                } else {
                    items = db.Properties.Select(p => new {
                        Id = p.Id,
                        PropertyName = p.PropertyName,
                        Description = p.Description,
                        Category = p.Category.CategoryName,
                        Rooms = p.Rooms,
                        Size = p.Size,
                        Floors = p.Floors,
                        Country = p.Location.Country,
                        City = p.Location.City,
                        AgentEmail = p.User.Email
                    }).ToList();
                }

                DtgProperties.DataSource = items;
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            PropertyForm propertyForm = new PropertyForm(main.GetUser().Id, CrudAction.Create);
            propertyForm.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (DtgProperties.SelectedRows.Count != 1) {
                MessageBox.Show("Please select 1 item");
                return;
            }

            int id = (int)DtgProperties.SelectedRows[0].Cells[0].Value;

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    Property prop = db.Properties.Where(p => p.Id == id).First();

                    PropertyForm propertyForm= new PropertyForm(CrudAction.Update, prop);
                    propertyForm.Show();
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (DtgProperties.SelectedRows.Count != 1) {
                MessageBox.Show("Please select 1 item");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) {
                return;
            }
            int id = (int)DtgProperties.SelectedRows[0].Cells[0].Value;

            try {
                using (RealEstateEntities db = new RealEstateEntities()) {
                    Property property = db.Properties.Where(p => p.Id == id).First();
                    db.Properties.Remove(property);

                    db.SaveChanges();
                    LoadGrid();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BtnReload_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            main.Controls.Remove(this);
        }

        private void MenuItemProfile_Click(object sender, EventArgs e) {
            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    User user = db.Users.Where(u => u.Id == this.user.Id).First();

                    RegisterControl register = new RegisterControl(main, "user", user);
                    register.Dock = DockStyle.Fill;
                    main.Controls.Add(register);
                    register.BringToFront();
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
