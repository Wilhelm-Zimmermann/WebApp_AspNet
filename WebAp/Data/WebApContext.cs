using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<WebAp.Models.Department> Department { get; set; }
    }
}
