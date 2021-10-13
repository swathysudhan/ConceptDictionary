using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace ConceptDictionary
{
    public class CategoryDataAccess
    {
        private string ConnectionString;

        public CategoryDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString1 { get => ConnectionString; set => ConnectionString = value; }
        
        //Read data from the category table. 
        public Category[] ReadAllCategory()
        {
            List<Category> result = new List<Category>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"select * from Category";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Category(reader.GetInt16(0), reader.GetString(1)));

                    }
                }
                connection.Close();
            }
            return result.ToArray();
        }
    }
}
