using Microsoft.EntityFrameworkCore;
using SalesWebCommercial.Models;

namespace SalesWebCommercial.Services
{
    public class DepartmentService
    {
        private readonly SalesWebCommercialContext _context;
        public DepartmentService(SalesWebCommercialContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> ListDepartments()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
