using DAL;
using Model;

namespace assignment2
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
            CustomerDAO customerDAO = new CustomerDAO();
            List<Customer> customers = customerDAO.GetAllCustomers();

            foreach(Customer customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            Console.WriteLine();
            Console.Write("Enter customer id: ");
            int customerId = int.Parse(Console.ReadLine());
            Customer customer1 = new Customer();
            customer1 = customerDAO.GetById(customerId);
            if(customer1 != null)
                Console.WriteLine(customer1.ToString());
            else
                Console.WriteLine($"No customer with id: {customerId}");

            BookDAO bookDAO = new BookDAO();   
            List<Book> books = bookDAO.GetAllBooks();

            foreach(Book book in books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine();
            Console.Write("Enter book id: ");
            int bookId = int.Parse(Console.ReadLine());
            Book book1 = new Book();
            book1 = bookDAO.GetById(bookId);
            if (book1 != null)
                Console.WriteLine(book1.ToString());
            else
                Console.WriteLine($"No customer with id: {bookId}");
        }
    }
}