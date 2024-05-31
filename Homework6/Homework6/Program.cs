using Homework6;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=store;Integrated Security=SSPI;";


// insert
Product product = new Product("Hammer", "Hammer anyting", 120, "DIY");
InsertProductWithCategory(product, connectionString);

// read
ReadProducts(connectionString);


using (var conn = new SqlConnection(connectionString))
{
    // update
    string updateProduct = "UPDATE Product SET price = 950 WHERE title = 'Intel Core i9-9900K'";
    using (SqlCommand updateProductCommand = new(updateProduct, conn))
    {
        conn.Open();
        int updated_rows = updateProductCommand.ExecuteNonQuery();
        Console.WriteLine($"{updated_rows} products updated.");
        conn.Close();
    }

    // delete
    string deleteProduct = "DELETE FROM Product WHERE title = 'GeForce RTX 4090 16GB'";
    using (SqlCommand deleteProductCommand = new(deleteProduct, conn))
    {
        conn.Open();
        int deleted_rows = deleteProductCommand.ExecuteNonQuery();
        Console.WriteLine($"{deleted_rows} products deleted.");
        conn.Close();
    }

    string readJoinedProducts = "SELECT * FROM Product JOIN Category on Product.category_id = Category.category_id";
    conn.Open();
    SqlCommand readJoinedCommand = new(readJoinedProducts, conn);
    using (SqlDataReader reader = readJoinedCommand.ExecuteReader())
    {
        while (reader.Read())
            Console.WriteLine($"{reader["title"]}-{reader["description"]}-{reader["price"]}");
    }
    conn.Close();


    conn.Dispose();
}

static void ReadProducts(string connection_string)
{
    using (var conn = new SqlConnection(connection_string))
    {
        string readProducts = "SELECT * FROM Product";
        conn.Open();
        SqlCommand readCommand = new(readProducts, conn);
        using (SqlDataReader reader = readCommand.ExecuteReader())
        {
            while (reader.Read())
                Console.WriteLine($"{reader["title"]}");
        }
        conn.Close();
    }
}

static void InsertProductWithCategory(Product product, string connection_string)
{
    using (var conn = new SqlConnection(connection_string))
    {
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            string category_query = "INSERT INTO Category (title) VALEUS (@title)";
            int category_id;
            using (SqlCommand command = new(category_query, conn, transaction))
            {
                command.Parameters.AddWithValue("title", product.category);
                category_id = (int)command.ExecuteScalar();
            }

            string product_query = "INSERT into Product (title,description,price, category_id) VALUES (@title,@desc,@price,@category_id)";
            using(SqlCommand command = new(product_query, conn, transaction))
            {
                command.Parameters.AddWithValue("title", product.title);
                command.Parameters.AddWithValue("desc", product.description);
                command.Parameters.AddWithValue("price", product.price);
                command.Parameters.AddWithValue("category_id", category_id);
                command.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("Product added");
        } catch (Exception ex)
        {
            transaction.Rollback();
        }
    }
}

