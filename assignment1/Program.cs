using DAL;
using Model;

namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            Customer customer = new Customer(0, "lionelmessi@hotmail.com", "Lionel", "Messi");
            Customer customer1 = new Customer(0, "donhenley@gmail.com", "Don", "Henley");

            Book book = new Book(0, "Harry Potter and the Prisoner of Azkaban", "J.K. Rowling");
            Book book1 = new Book(0, "The Da Vince Code", "Dan Brown");

            Reservation reservation = new Reservation(0, customer, book1);
            Reservation reservation1 = new Reservation(0, customer1, book1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("testing customers");
            Console.ResetColor();
            Console.WriteLine(customer.ToString());
            Console.WriteLine(customer1.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("testing books");
            Console.ResetColor();
            Console.WriteLine(book.ToString());
            Console.WriteLine(book1.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("testing reservations");
            Console.ResetColor();
            Console.WriteLine(reservation.ToString());
            Console.WriteLine(reservation1.ToString());
        }
    }
}