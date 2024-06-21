using System;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Forms;

namespace RealEstate {
    public partial class MainForm : Form {
        private User user;

        public MainForm() {
            InitializeComponent();
        }

        public void SetUser(User user) {
            this.user = user;
            if(user.Role.RoleName.Equals("admin")) {
                this.Text = "Admin";
                AdminDashboard admin = new AdminDashboard(this, user);
                admin.Dock = DockStyle.Fill;
                this.Controls.Add(admin);
            } else {
                this.Text = "Standard User";
                UserDashboard userDashboard = new UserDashboard(this, user);
                userDashboard.Dock = DockStyle.Fill;
                this.Controls.Add(userDashboard);
            }
        }

        public User GetUser() {
            return this.user;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if(this.user != null) {
                MessageBox.Show("Logged in");
            } else {
                LoginControl login = new LoginControl(this);
                login.Dock = DockStyle.Fill;
                this.Controls.Add(login);
            }
        }
    }
}
