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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            StoreModelContext db = new StoreModelContext();
            cbFilter.DataSource = db.Categories.ToList();
            cbFilter.DisplayMember = "Name";
            cbFilter.ValueMember = "Id";

            LoadGrid();
        }

        private void LoadGrid() {
            try {
                dtgProducts.DataSource = null;

                StoreModelContext db = new StoreModelContext();
                List<ProductDTO> products = db.Products.Select(p => new ProductDTO() {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Category = p.Category.Name
                }).ToList();

                dtgProducts.DataSource = products;
            } catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            ProductForm productForm = new ProductForm("add");
            productForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if(dtgProducts.SelectedRows.Count != 1) {
                MessageBox.Show("Please select product first");
                return;
            }

            ProductDTO product = new ProductDTO() {
                Id = (int)dtgProducts.SelectedRows[0].Cells[0].Value,
                Name = (string)dtgProducts.SelectedRows[0].Cells[1].Value,
                Quantity = (int)dtgProducts.SelectedRows[0].Cells[2].Value,
                Category = (string)dtgProducts.SelectedRows[0].Cells[3].Value,
            };

            ProductForm productForm = new ProductForm("update", product);
            productForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if(dtgProducts.SelectedRows.Count != 1) {
                MessageBox.Show("Please select product first");
                return;
            }
            
            try {
                int id = (int)dtgProducts.SelectedRows[0].Cells[0].Value;
                StoreModelContext db = new StoreModelContext();
                Product product = db.Products.Where(p => p.Id == id).First();
                db.Products.Remove(product);
                db.SaveChanges();
                LoadGrid();
            } catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void btnFilter_Click(object sender, EventArgs e) {
            int category_id = (int)cbFilter.SelectedValue;
            try {
                StoreModelContext db = new StoreModelContext();
                List<ProductDTO> products = db.Products.Where(p => p.CategoryId == category_id)
                    .Select(p => new ProductDTO() { 
                        Id = p.Id,
                        Name = p.Name,
                        Quantity = p.Quantity,
                        Category = p.Category.Name
                    }).ToList();

                dtgProducts.DataSource = null;
                dtgProducts.DataSource = products;
            } catch(Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
