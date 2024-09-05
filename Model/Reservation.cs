using System.Drawing;

namespace Model
{
    public class Reservation
    {
        private int id;
        public int Id { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }

        public Reservation(int id, Customer customer, Book book)
        {
            Id = id;
            Customer = customer;
            Book = book;
        }
        public Reservation(){}
        public string ToString()
        {
            return $"{Customer.ToString()} -> {Book.ToString()}";
        }

    }
}
