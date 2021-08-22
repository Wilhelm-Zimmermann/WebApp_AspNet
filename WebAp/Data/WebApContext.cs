using Microsoft.EntityFrameworkCore;
using WebAp.Models;

namespace WebAp.Data
{
    public class WebApContext : DbContext
    {
        public WebApContext (DbContextOptions<WebApContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
