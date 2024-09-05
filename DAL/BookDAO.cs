using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data.Common;
using System.Configuration;
using System.Net;

namespace DAL
{
    public class BookDAO
    {
        private SqlConnection dbConnection;
        public BookDAO()
        {
            string connString = ConfigurationManager.ConnectionStrings["Programming3Week4"].ConnectionString;
            dbConnection = new SqlConnection(connString);
        }
        public List<Book> GetAllBooks()
        {
            dbConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Books", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                Book book = ReadBook(reader);
                books.Add(book);
            }
            reader.Close();
            dbConnection.Close();

            return books;
        }

        private List<Book> ReadBook(DataTable dataTable)
        {
            List<Book> books = new List<Book>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Book book = new Book
                {
                    Id = (int)dr["Id"],
                    Title = dr["Title"].ToString(),
                    Author = dr["Author"].ToString(),
                };
                books.Add(book);
            }
            return books;
        }

        private Book ReadBook(SqlDataReader reader)
        {
            int id = (int)reader["Id"];
            string title = reader["Title"].ToString();
            string author = reader["Author"].ToString();

            return new Book(id, title, author);
        }

        public Book GetById(int bookId)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Customers WHERE id = @Id", dbConnection);
            command.Parameters.AddWithValue("@Id", bookId);

            SqlDataReader reader = command.ExecuteReader();
            Book book = null;
            if (reader.Read())
                book = ReadBook(reader);
            reader.Close();
            dbConnection.Close();

            return book;

        }

        public List<Book> GetByAuthor(string AuthorName)
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE Author = @Author", dbConnection);
            command.Parameters.AddWithValue("@Author", AuthorName);

            SqlDataReader reader = command.ExecuteReader();
            List<Book> books = new List<Book>();
            
            while(reader.Read())
                books.Add(ReadBook(reader));
            reader.Close();
            dbConnection.Close();

            return books;
        }
    }
}
