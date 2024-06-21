using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using RealEstate.EF;

namespace RealEstate.Forms {
    public partial class LoginControl : UserControl {
        private MainForm main;
        public LoginControl() {
            InitializeComponent();
        }

        public LoginControl(MainForm main) {
            this.main = main;
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            try {
                string email = TbEmail.Text;
                string password = TbPassword.Text;

                using(RealEstateEntities db = new RealEstateEntities()) {
                    User user = db.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(password)).FirstOrDefault();
                    if(user != null) {
                        main.SetUser(user);
                        main.Controls.Remove(this);
                    } else {
                        MessageBox.Show("Incorrect Email or Password");
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error during login - {ex.Message}");
            }
        }

        private void BtnRegisterLink_Click(object sender, EventArgs e) {
            RegisterControl register = new RegisterControl(main, "user");
            register.Dock = DockStyle.Fill;
            this.main.Controls.Add(register);
            main.Controls.Remove(this);
        }
    }
}
