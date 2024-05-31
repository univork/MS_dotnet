using System.Data;
using System.Data.SqlClient;

namespace Homework7
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();

        public Form1()
        {
            DataTable productTable = new DataTable("Product");
            productTable.Columns.Add("title",  typeof(string));
            productTable.Columns.Add("description",  typeof(string));
            productTable.Columns.Add("price", typeof(decimal));
            productTable.Columns.Add("category_id", typeof(int));

            productTable.Rows.Add(["Ryzen 5 5034U", "Not bad", 500, 2]);

            ds.Tables.Add(productTable);

            DataTable categoryTable = new DataTable("Category");
            categoryTable.Columns.Add("category_id", typeof(int));
            categoryTable.Columns.Add("title", typeof(string));

            ds.Tables.Add(categoryTable);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridProducts.DataSource = ds.Tables[0];
            cbCategory.DataSource = ds.Tables[1];
            cbCategory.ValueMember = "category_id";
            cbCategory.DisplayMember = "title";

            string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=store;Integrated Security=SSPI;";
            using SqlConnection con = new(connectionString);
            SqlDataAdapter adapter = new("SELECT * FROM Product", con);
            adapter.Fill(ds, "Product");

            SqlDataAdapter catAdapter = new("SELECT * FROM Category", con);
            catAdapter.Fill(ds, "Category");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string description = tbDescription.Text;
            decimal price = decimal.Parse(tbPrice.Text);
            int category_id = (int)cbCategory.SelectedValue;

            DataRow row = ds.Tables["Product"].NewRow();
            row["title"] = title;
            row["description"] = description;
            row["price"] = price;
            row["category_id"] = category_id;

            ds.Tables["Product"].Rows.Add(row);

            string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=store;Integrated Security=SSPI;";
            using SqlConnection con = new(connectionString);
            SqlDataAdapter adapter = new("SELECT * FROM Product", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "Product");
        }
    }
}
