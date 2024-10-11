using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Book
    {
        public Book() { }
        public string bookId { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public decimal rentalPrice { get; set; }


        public Book(string Bookid, string Title, string Author, decimal RentalPrice)
        {
            bookId = Bookid;
            title = Title;
            author = Author;
            rentalPrice = RentalPrice;
           
        }
    }
}
