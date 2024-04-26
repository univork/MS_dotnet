using System.Data;
using System.Data.SqlClient;

string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=People;Integrated Security=SSPI;";


using (var conn = new SqlConnection(connectionString))
{
    // insert
    string query = "INSERT into Persons (FirstName, LastName, Address, Email, Salary) VALUES (@FirstName, @LastName, @Address, @Email, @Salary)";
    using (SqlCommand command = new(query, conn))
    {
        command.Parameters.AddWithValue("FirstName", "Abraham");
        command.Parameters.AddWithValue("LastName", "Lincoln");
        command.Parameters.AddWithValue("Address", "Washington DC");
        command.Parameters.AddWithValue("Email", "abroli@usa.gov.ge");
        command.Parameters.AddWithValue("Salary", 1000000);
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }


    // read
    query = "SELECT * FROM Persons";
    conn.Open();
    SqlCommand readCommand = new(query , conn);
    using (SqlDataReader reader = readCommand.ExecuteReader())
    {
        while (reader.Read())
            Console.WriteLine($"{reader["FirstName"]} - {reader["LastName"]}");
    }
    conn.Close();



    // update
    query = "UPDATE Persons SET Salary = 100000 WHERE FirstName = 'Abraham' AND LastName = 'Lincoln'";
    using (SqlCommand updateProductCommand = new(query, conn))
    {
        conn.Open();
        int updated_rows = updateProductCommand.ExecuteNonQuery();
        Console.WriteLine($"{updated_rows} people updated.");
        conn.Close();
    }

    // delete
    query = "DELETE FROM Persons WHERE Salary >= 100000";
    using (SqlCommand deleteProductCommand = new(query, conn))
    {
        conn.Open();
        int deleted_rows = deleteProductCommand.ExecuteNonQuery();
        Console.WriteLine($"{deleted_rows} people deleted.");
        conn.Close();
    }
}

