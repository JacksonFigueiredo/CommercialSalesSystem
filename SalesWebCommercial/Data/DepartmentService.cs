using SalesWebCommercial.Models;

namespace SalesWebCommercial.Data
{
    public class DepartmentService
    {
        private readonly SalesWebCommercialContext _context;
        public DepartmentService(SalesWebCommercialContext context)
        {
            _context = context;
        }

        public List<Department> ListDepartments()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
