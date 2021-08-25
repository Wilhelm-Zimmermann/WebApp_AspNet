using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAp.Data;
using WebAp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAp.Services
{
    public class SalesRecordService
    {
        private readonly WebApContext _context;

        public SalesRecordService(WebApContext webApContext)
        {
            _context = webApContext;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var res = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                res = res.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                res = res.Where(x => x.Date <= maxDate.Value);
            }
            return await res
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = await FindByDateAsync(minDate, maxDate);

            return result.GroupBy(x => x.Seller.Department).ToList();
        }

    }
}
