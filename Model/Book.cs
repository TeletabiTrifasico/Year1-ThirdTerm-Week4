using System.Drawing;

namespace Model
{
    public class Book
    {
        private int id;
        public string Author { get;  set; }
        public string Title { get;  set; }
        public int Id { get; set; }

        public Book(int id, string title, string author)
        {
            Id = id;
            Author = author;
            Title = title;
        }
        public Book() { }
        public string ToString()
        {
            return $"'{Title}' by {Author}";
        }

    }
}