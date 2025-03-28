using db_controller.Models;
using System.Collections.Generic;
using System.Linq;

namespace db_controller.Repositories
{
    public class SaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Record(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }
    }
}
