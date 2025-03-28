using System;

namespace db_controller.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsSequel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
