using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookRepository
    {

        public string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=BookRentalManagement";



        public void CreateBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INRO Book (BookId,Title,Author,RentalPrice values(@BookId,@Title,@Author,RentalPrice)", conn))
                {
                    cmd.Parameters.AddWithValue("@BookId", book.bookId);
                    cmd.Parameters.AddWithValue("@Title", book.title);
                    cmd.Parameters.AddWithValue("@Author", book.author);
                    cmd.Parameters.AddWithValue("@RentalPrice", book.rentalPrice);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"eX MESSAGE :{ex.Message}");
                    }



                }
            }
        }


        public List<Book> readBook()
        {
            var booklist = new List<Book>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Book", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var book = new Book
                                {
                                    bookId = reader["BookId"].ToString(),
                                    title = reader["Title"].ToString(),
                                    author = reader["Author"].ToString(),
                                    rentalPrice = (decimal)reader["RentalPrice"]
                                };
                                booklist.Add(book);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ex mesaaage {ex.Message}");
                    }
                }
            }
            return booklist;
        }

        public string GetbookBYid(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("Select * from Where BookId=@BookId", conn))
                {
                    command.Parameters.AddWithValue("@BookId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return ($"BookId: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, RentalPrice: {reader["RentalPrice"]}");
                        }

                    }
                    return null;
                }
            }
        }


        public void UpdateBooks(Book book)
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("UPDATE Book SET  BookId=@BookId Title=@Title, Author=@Author, RentalPrice=@RentalPrice WHERE BookId=@BookId", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@BookId", book.bookId);
                        sqlCommand.Parameters.AddWithValue("@Title", book.title);
                        sqlCommand.Parameters.AddWithValue("@Author", book.author);
                        sqlCommand.Parameters.AddWithValue("@RentalPrice", book.rentalPrice);
                        sqlCommand.Parameters.AddWithValue("@BookId", book.bookId);

                        int rowsAffected = sqlCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Book updated successfully");
                        }
                        else
                        {
                            Console.WriteLine("Book not found!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message} {ex.StackTrace}");
                }
            }
        }


        public void DeleteBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM Book WHERE BookId=@BookId", connection))
                    {
                        command.Parameters.AddWithValue("@BookId", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Book deleted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Error while deleting book");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }


}
