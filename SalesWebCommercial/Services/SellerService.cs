using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using NuGet.Protocol.Plugins;
using SalesWebCommercial.Models;
using SalesWebCommercial.Services.Exceptions;
using System.Threading.Channels;

namespace SalesWebCommercial.Services
{
    public class SellerService
    {
        private readonly SalesWebCommercialContext _context;
        public SellerService(SalesWebCommercialContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> FindById(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Delete(int id)
        {
            var seller = await _context.Seller.FindAsync(id);
            if (seller != null)
            {
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Insert(Seller seller)
        {
            await _context.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Seller seller)
        {    
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
