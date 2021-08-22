using System.Linq;
using System.Collections.Generic;
using WebAp.Data;
using WebAp.Models;

namespace WebAp.Services
{
    public class DepartmentService
    {
        private readonly WebApContext _context;

        public DepartmentService(WebApContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
