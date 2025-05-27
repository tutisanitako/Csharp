using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizNew.EF
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public decimal UnitPrice { get; set; }

        [StringLength(30)]
        public string Package { get; set; }

        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}