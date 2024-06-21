using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class RegisterControl : UserControl {
        private MainForm main;
        private string from;
        private User user;
        private CrudAction action;

        public RegisterControl() {
            InitializeComponent();
        }

        public RegisterControl(MainForm main, string from) {
            this.main = main;
            this.from = from;
            this.action = CrudAction.Create;
            InitializeComponent();
        }

        public RegisterControl(MainForm main, string from, User user) {
            this.main = main;
            this.from = from;
            this.user = user;
            this.action = CrudAction.Update;
            InitializeComponent();
        }

        private void RegisterControl_Load(object sender, EventArgs e) {
            if(this.action == CrudAction.Update) {
                BtnRegister.Text = "Update";
                LbTitle.Text = "Update Profile";
                CbUserRole.Visible = false;
                label9.Visible = false;
                LbLink.Visible = false;
                BtnLoginrLink.Visible = false;
                BtnClose.Visible = true;

                TbFirstName.Text = user.FirstName;
                TbLastName.Text = user.LastName;
                TbEmail.Text = user.Email;
                TbPassword1.Text = user.Password;
                TbPassword2.Text = user.Password;
                TbCountry.Text = user.Location.Country;
                TbCity.Text = user.Location.City;
            }

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if(this.from.Equals("admin")) {
                        BtnClose.Visible = true;
                        CbUserRole.DataSource = db.Roles.ToList();
                        CbUserRole.DisplayMember = "RoleName";
                        CbUserRole.ValueMember = "Id";
                        LbLink.Visible = false;
                        BtnLoginrLink.Visible = false;
                    } else {
                        CbUserRole.DataSource = db.Roles.Where(r => r.RoleName != "admin").ToList();
                        CbUserRole.DisplayMember = "RoleName";
                        CbUserRole.ValueMember = "Id";
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error during loading data: {ex.Message}");
            }
        }

        private void BtnLoginrLink_Click(object sender, EventArgs e) {
            LoginControl login = new LoginControl(main);
            login.Dock = DockStyle.Fill;
            this.main.Controls.Add(login);
            main.Controls.Remove(this);
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            main.Controls.Remove(this);
        }

        private void BtnRegister_Click(object sender, EventArgs e) {
            string firstname = TbFirstName.Text;
            string lastname = TbLastName.Text;
            string email = TbEmail.Text;
            string pass1 = TbPassword1.Text;
            string pass2 = TbPassword2.Text;
            string country = TbCountry.Text;
            string city = TbCity.Text;
            int roleId = (int)CbUserRole.SelectedValue;
            bool error = false;

            if(!Regex.IsMatch(firstname, @"^[a-zA-Z]+$")) {
                TbFirstName.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(lastname, @"^[a-zA-Z]+$")) {
                TbLastName.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) {
                TbEmail.BackColor = Color.Red;
                error = true;
            }
            if(pass1 != pass2) {
                TbPassword1.BackColor = Color.Red;
                TbPassword2.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(country, @"^[a-zA-Z]+$")) {
                TbCountry.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(city, @"^[a-zA-Z]+$")) {
                TbCity.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if(this.action == CrudAction.Create) {
                        db.RegisterUser(firstname, lastname, email, pass1, roleId, country, city);
                    } else {
                        User updatedUser = db.Users.Where(u => u.Id == user.Id).First();
                        updatedUser.FirstName = firstname;
                        updatedUser.LastName = lastname;
                        updatedUser.Password = pass1;
                        updatedUser.Email = email;
                        updatedUser.LocationId = db.Locations.Where(l => l.Country == country && l.City == city)
                            .Select(l => l.Id).FirstOrDefault();
                        db.SaveChanges();
                    }

                    if (this.from.Equals("admin")) {
                        main.Controls.Remove(this);
                    } else {
                        main.Controls.Remove(this);
                        LoginControl login = new LoginControl(main);
                        login.Dock = DockStyle.Fill;
                        main.Controls.Add(login);
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }
    }
}
