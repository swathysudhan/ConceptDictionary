using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace ConceptDictionary
{
    public class ConceptDataAccess
    {
        private string ConnectionString;

        public ConceptDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString1 { get => ConnectionString; set => ConnectionString = value; }

        public ConceptDictionary[] ReadAllConcept(string selectedItem)
        {
            List<ConceptDictionary> result = new List<ConceptDictionary>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"select * FROM ConceptDictionary as T , Category as S where S.CategoryName = @selectedItem AND (T.CategoryID == S.CategoryID)";
                command.Parameters.AddWithValue("@selectedItem",selectedItem);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ConceptDictionary(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetInt32(5)));

                    }
                }
                connection.Close();
            }
            return result.ToArray();
        }
        public void InsertConceptValue(ConceptDictionary newConcept,int categoryID)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                newConcept.CategoryID1 = categoryID;
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"Insert into  ConceptDictionary (Title,Body,ConceptImage,ConceptLink,CategoryID) values(@Title,@Body,@ConceptImage,@ConceptLink,@CategoryID)";
                command.Parameters.AddWithValue("@Title", newConcept.Title);
                command.Parameters.AddWithValue("@Body", newConcept.Body);
                command.Parameters.AddWithValue("@ConceptImage", newConcept.ConceptImage);
                command.Parameters.AddWithValue("@ConceptLink", newConcept.ConceptLink1);
                command.Parameters.AddWithValue("@CategoryID", newConcept.CategoryID1);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

        }

        public void UpdateConceptValue(ConceptDictionary updateConcept)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                //updateConcept.CategoryID1 = categoryID;
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE ConceptDictionary SET Title = @Title, Body = @Body, ConceptImage = @ConceptImage,ConceptLink = @ConceptLink1, CategoryID=@CategoryID1 WHERE ConceptID = @ConceptID";
                command.Parameters.AddWithValue("@ConceptID", updateConcept.ConceptID1);
                command.Parameters.AddWithValue("@Title", updateConcept.Title);
                command.Parameters.AddWithValue("@Body", updateConcept.Body);
                command.Parameters.AddWithValue("@ConceptImage", updateConcept.ConceptImage);
                command.Parameters.AddWithValue("@ConceptLink1", updateConcept.ConceptLink1);
                command.Parameters.AddWithValue("@CategoryID1", updateConcept.CategoryID1);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }
        public void DeleteConceptValue(int  delConceptID)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"Delete from ConceptDictionary where ConceptID =@ConceptID";

                command.Parameters.AddWithValue("@ConceptID", delConceptID);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }

        }
    }
}
