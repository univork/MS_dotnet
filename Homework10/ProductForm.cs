using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework8 {
    public partial class ProductForm : Form {
        private string action;
        private ProductDTO product;

        public ProductForm() {
            InitializeComponent();
        }

        public ProductForm(string action) {
            InitializeComponent();
            this.action = action;
        }

        public ProductForm(string action, ProductDTO product) {
            InitializeComponent();
            this.action = action;
            this.product = product;
        }

        private void ProductForm_Load(object sender, EventArgs e) {
            StoreModelContext db = new StoreModelContext();
            cbCategory.DataSource = db.Categories.ToList();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";

            if(this.action.Equals("add")) {
                lbTitle.Text = "Add Product";
            } else {
                lbTitle.Text = "Update Product";
                tbName.Text = product.Name;
                numQuantity.Value = (decimal)product.Quantity;
                cbCategory.SelectedText = product.Category;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                StoreModelContext db = new StoreModelContext();
                if(this.action.Equals("add")) {
                    db.Products.Add(new Product() {
                        Name = tbName.Text,
                        Quantity = (int)numQuantity.Value,
                        CategoryId = (int)cbCategory.SelectedValue
                    });
                    db.SaveChanges();

                    MessageBox.Show("Successfully added product");
                } else {
                    Product product = db.Products.Where(p => p.Id == this.product.Id).First();
                    product.Name = tbName.Text;
                    product.Quantity = (int)numQuantity.Value;
                    product.CategoryId = (int)cbCategory.SelectedValue;
                    db.SaveChanges();

                    MessageBox.Show("Successfully updated product");
                }
            } catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
