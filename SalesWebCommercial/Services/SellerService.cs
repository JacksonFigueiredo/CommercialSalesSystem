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

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Delete(int id)
        {
            var seller = _context.Seller.Find(id);
            if (seller != null)
            {
                _context.Seller.Remove(seller);
                _context.SaveChanges();
            }
        }

        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {    
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
