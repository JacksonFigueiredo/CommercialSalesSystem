using SalesWebCommercial.Models;

namespace SalesWebCommercial.Data
{
    public class SeedingService
    {
        private SalesWebCommercialContext _context;

        public SeedingService(SalesWebCommercialContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if (!_context.Department.Any() || _context.Seller.Any())
            {
                Department department1 = new Department(1, "Computers");
                Department department2 = new Department(2, "Electronics");
                Department department3 = new Department(3, "Fashion");
                Department department4 = new Department(4, "Books");

                Seller seller1 = new Seller(1,"Jackson","jack@hotmail.com",DateTime.Parse("1991-02-10"),1000, department1);
                Seller seller2 = new Seller(2, "Jasse", "jay@gmail.com", DateTime.Parse("1990-02-10"), 1000, department2);

                _context.Department.AddRange(department1,department2,department3,department4);
                _context.Seller.AddRange(seller1,seller2);

                _context.SaveChanges();
            }


        }
    }
}
