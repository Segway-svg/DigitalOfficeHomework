using System.Data.SqlClient;

namespace DigitalOfficeHomework.DB
{
    public class Provider
    {
        private const string CONN_STRING = @"Server=localhost\sqlexpress;Database=MusicDB;Trusted_Connection=True";
        private SqlConnection connection = new SqlConnection(CONN_STRING);
        private string query;

        public void Create(string name, string description) 
        {
            connection.Open();
            query = $"INSERT INTO Groups VALUES (NEWID(), '{name}', '{description}', GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Read()
        {
            connection.Open();
            query = "SELECT * FROM Groups";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader["Name"]} - {reader["Description"]} - {reader["ReleaseDate"]}");
            }
            reader.Close();
            command.Dispose();
            connection.Close();
        }
        
        public void Update(string name, string description, string guid)
        {
            if (name == "" && description == "")
            {
                return;
            }
            connection.Open();

            if (name != "")
            {
                query = $"UPDATE Groups SET Name='{name}' WHERE Id='{guid}'";
            }
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            
            if (name != "")
            {
                query = $"UPDATE Groups SET Description='{description}' WHERE Id='{guid}'";
            }
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public void Delete(string guid)
        {
            connection.Open();
            query = $"DELETE FROM Groups WHERE Id='{guid}'";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }
    }
}