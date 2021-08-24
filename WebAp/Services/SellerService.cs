using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAp.Models;
using WebAp.Data;
using WebAp.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAp.Services
{
    public class SellerService
    {
        private readonly WebApContext _context;

        public SellerService(WebApContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {

            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
            }catch(DbUpdateException err)
            {
                throw new IntegrityException("Impossible to remove this "+err.Message);
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("This seller doesnt exist");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }catch(DbUpdateConcurrencyException err)
            {
                throw new DbConcurrencyException("Trated Error: "+err.Message);
            }


        }
    }
}
