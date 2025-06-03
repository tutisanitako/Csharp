using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.EF // Keeping namespace consistent with original request
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public decimal BaseSalary { get; set; }
        public virtual Position Position { get; set; }
    }
}