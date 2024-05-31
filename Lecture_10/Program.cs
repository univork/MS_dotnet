
using System.Data;
using System.Data.SqlClient;

DataTable table = new DataTable();

table.Columns.Add(new DataColumn("title", typeof(string)));
table.Columns.Add(new DataColumn("description", typeof(string)));

table.Rows.Add(["GeForce RTX 4090 16GB", "monster"]);

foreach (DataColumn col in table.Columns)
{
    Console.WriteLine(col.ColumnName);
}

Console.WriteLine("\n------------------------------------------\n");
Console.WriteLine(table.Rows[0]["title"]);


Console.WriteLine("\n------------------------------------------\n");
string connectionString = "Data Source=KUPH\\SQLEXPRESS;Initial Catalog=store;Integrated Security=SSPI;";
using (var conn = new SqlConnection(connectionString))
{
    conn.Open();
    SqlDataAdapter adapter = new ("SELECT * FROM Product", connectionString);

    DataSet ds = new DataSet();
    adapter.Fill(ds, "Product");

    Console.WriteLine(ds.Tables[0].TableName);

    ds.Tables[0].Rows.Add([""]);
}


