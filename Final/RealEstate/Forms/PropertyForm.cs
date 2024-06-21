using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class PropertyForm : Form {
        private Property property;
        private int agentId;
        private CrudAction action;

        public PropertyForm() {
            InitializeComponent();
        }

        public PropertyForm(int agentId, CrudAction action) {
            this.agentId = agentId;
            this.action = action;
            InitializeComponent();
        }
        
        public PropertyForm(CrudAction action, Property property) {
            this.action = action;
            this.property = property;
            InitializeComponent();
        }

        private void PropertyForm_Load(object sender, EventArgs e) {
            if(this.action == CrudAction.Update) {
                LbTitle.Text = "Update Property";
                BtnAdd.Text = "Edit";

                TbPropertyName.Text = property.PropertyName;
                TbDescription.Text = property.Description;
                TbRooms.Text = property.Rooms.ToString();
                TbSize.Text = property.Size.ToString();
                TbFloors.Text = property.Floors.ToString();
                TbCountry.Text = property.Location.Country;
                TbCity.Text = property.Location.City;
            }

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    CbCategory.DataSource = db.Categories.ToList();
                    CbCategory.DisplayMember = "CategoryName";
                    CbCategory.ValueMember = "Id";
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error during loading data: {ex.Message}");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            string propName = TbPropertyName.Text;    
            string desc = TbDescription.Text;    
            string rooms_text = TbRooms.Text;
            int rooms;
            string size_text = TbSize.Text;
            float size;
            string floors_text = TbFloors.Text;
            int floors;
            string country = TbCountry.Text;    
            string city = TbCity.Text;    
            int categoryId = (int)CbCategory.SelectedValue;
            bool error = false;

            if(!Regex.IsMatch(propName, @"^\w+( \w+)*$")) {
                TbPropertyName.BackColor = Color.Red;
                error = true;
            }
            if(!int.TryParse(rooms_text, out rooms)) {
                TbRooms.BackColor = Color.Red;
                error = true;
            }
            if(!float.TryParse(size_text, out size)) {
                TbSize.BackColor = Color.Red;
                error = true;
            }
            if(!int.TryParse(floors_text, out floors)) {
                TbFloors.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(country, @"^\w+( \w+)*$")) {
                TbCountry.BackColor = Color.Red;
                error = true;
            }
            if(!Regex.IsMatch(city, @"^\w+( \w+)*$")) {
                TbCity.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;

            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if(this.action == CrudAction.Create) {
                        db.CreateProperty(propName, desc, rooms, size, floors, country, city, categoryId, this.agentId);
                    } else {
                        Property property = db.Properties.Where(p => p.Id == this.property.Id).First();
                        property.PropertyName = propName;
                        property.Description = desc;
                        property.Rooms = rooms;
                        property.Size = size;
                        property.Floors = floors;
                        property.LocationId = db.Locations.Where(l => l.Country == country && l.City == city)
                            .Select(l => l.Id).FirstOrDefault();
                        property.CategoryId = categoryId;
                        db.SaveChanges();
                    }
                    MessageBox.Show("Success");
                    this.Close();
                }

            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }
    }
}
