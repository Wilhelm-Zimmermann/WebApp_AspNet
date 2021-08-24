using System.Linq;
using System.Collections.Generic;
using WebAp.Data;
using WebAp.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAp.Services
{
    public class DepartmentService
    {
        private readonly WebApContext _context;

        public DepartmentService(WebApContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
