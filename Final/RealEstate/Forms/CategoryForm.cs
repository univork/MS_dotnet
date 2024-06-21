using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RealEstate.EF;
using RealEstate.Enums;

namespace RealEstate.Forms {
    public partial class CategoryForm : Form {
        private CrudAction action;
        private Category oldCategory;

        public CategoryForm() {
            InitializeComponent();
        }

        public CategoryForm(CrudAction action) {
            this.action = action;
            InitializeComponent();
        }

        public CategoryForm(CrudAction action, Category oldCategory) {
            this.action = action;
            this.oldCategory = oldCategory;
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e) {
            if(this.action == CrudAction.Update) {
                TbCategoryName.Text = oldCategory.CategoryName;
                LbCategory.Text = "Update Category";
                BtnAdd.Text = "Update";
            } 
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            string categoryName = TbCategoryName.Text;
            bool error = false;

            if(!Regex.IsMatch(categoryName, @"^\w+( \w+)*$")) {
                TbCategoryName.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;
            
            try {
                using(RealEstateEntities db = new RealEstateEntities()) {
                    if(this.action == CrudAction.Create) {
                        Category category = new Category {
                            CategoryName = categoryName 
                        };
                        db.Categories.Add(category);
                    } else {
                        Category category = db.Categories.Where(c => c.Id == oldCategory.Id).First();
                        category.CategoryName = categoryName;
                    }

                    db.SaveChanges();
                    MessageBox.Show("Category created");
                    this.Close();
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error - {ex.Message}");
            }
        }
    }
}
