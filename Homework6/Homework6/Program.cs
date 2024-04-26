using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=store;Integrated Security=SSPI;";


using (var conn = new SqlConnection(connectionString))
{
    // insert
    string addProduct = "INSERT into Product (title,description,price, category_id) VALUES (@title,@desc,@price,@category_id)";
    using (SqlCommand addProductCommand = new(addProduct, conn))
    {
        addProductCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = "Intel Core i9-9900K";
        addProductCommand.Parameters.Add("@desc", SqlDbType.NVarChar).Value = "Runs anything";
        addProductCommand.Parameters.Add("@price", SqlDbType.Money).Value = 900;
        addProductCommand.Parameters.Add("@category_id", SqlDbType.Int).Value = 2;
        conn.Open();
        addProductCommand.ExecuteNonQuery();
        conn.Close();
    }


    // read
    string readProducts = "SELECT * FROM Product";
    conn.Open();
    SqlCommand readCommand = new(readProducts, conn);
    using (SqlDataReader reader = readCommand.ExecuteReader())
    {
        while (reader.Read())
            Console.WriteLine($"{reader["title"]}");
    }
    conn.Close();


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
    string deleteProduct = "DELETE FROM Product WHERE title = 'Hammer'";
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
    using (SqlDataReader reader = readCommand.ExecuteReader())
    {
        while (reader.Read())
            Console.WriteLine($"{reader["title"]}-{reader["description"]}-{reader["price"]}");
    }
    conn.Close();


    conn.Dispose();
}