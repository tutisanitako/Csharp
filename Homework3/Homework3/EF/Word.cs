using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3.EF
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string WordText { get; set; }

        [Required]
        public bool IsSelectable { get; set; } = true;

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
