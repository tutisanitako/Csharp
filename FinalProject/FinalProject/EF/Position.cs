using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.EF // Keeping namespace consistent with original request
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal BonusPercent { get; set; }
    }
}