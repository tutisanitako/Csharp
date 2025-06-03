using System.ComponentModel.DataAnnotations;

namespace FinalProject.EF
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalSalary { get; set; }
        public virtual Employee Employee { get; set; }
    }
}