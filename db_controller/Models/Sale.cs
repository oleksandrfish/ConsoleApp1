using System;

namespace db_controller.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
    }
}
