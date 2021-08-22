using System.Linq;
using System;
using WebAp.Models.Enums;
using WebAp.Models;

namespace WebAp.Data
{
    public class SeedingService
    {
        private WebApContext _context;

        public SeedingService(WebApContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Baby");

            Seller s1 = new Seller(1, "Joseph", "joseph@gmail.com", new DateTime(2002, 6, 26), 10000.00, d1);
            Seller s2 = new Seller(2, "Jotato", "jotaro@gmail.com", new DateTime(2012, 6, 26), 16000.00, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2002, 06, 25), 20000.00, SaleStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2002, 06, 25), 20000.00, SaleStatus.Pending, s1);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1, s2);
            _context.SalesRecord.AddRange(sr1, sr2);
            _context.SaveChanges();
        }
    }
}
