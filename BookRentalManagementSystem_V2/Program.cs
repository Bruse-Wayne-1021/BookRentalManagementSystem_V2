using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mainmenu();
        }
        public static void Mainmenu()
        {
            var Repo = new BookRepository();
            while (true)
            {
                Console.WriteLine("1 . Add New Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3.Update Books");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose an Option");


                var Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":
                        Repo.CreateBook();
                        break;
                    case "2":
                        Repo.readBook();
                        break;
                    case "3":
                        Repo.UpdateBooks();
                        break;

                    case "4":
                        Repo.DeleteBook();
                        break;
                    case "5":
                        Console.WriteLine("Thank you !!!");
                        return;
                    default:
                        Console.Clear();
                        Mainmenu();
                        break;

                }
            }

        }


    }
