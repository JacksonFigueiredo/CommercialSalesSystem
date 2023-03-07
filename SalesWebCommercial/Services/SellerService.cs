using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using NuGet.Protocol.Plugins;
using SalesWebCommercial.Models;
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
            return _context.Seller.FirstOrDefault(s => s.Id == id);
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

     
    }
}
