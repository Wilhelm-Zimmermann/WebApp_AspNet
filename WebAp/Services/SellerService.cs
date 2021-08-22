using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAp.Models;
using WebAp.Data;

namespace WebAp.Services
{
    public class SellerService
    {
        private readonly WebApContext _context;

        public SellerService(WebApContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
