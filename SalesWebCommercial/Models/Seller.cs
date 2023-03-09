using System.ComponentModel.DataAnnotations;

namespace SalesWebCommercial.Models
{
    public class Seller
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name= "Birth Date")]
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int  DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales (SalesRecord sales)
        {
            Sales.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            double totalSalesAmount = 0;

            foreach (SalesRecord sale in Sales)
            {
                if (sale.Date >= initial && sale.Date <= final)
                {
                    totalSalesAmount += sale.Amount;
                }
            }

            return totalSalesAmount;
        }


    }
}
