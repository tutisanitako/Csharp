using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public static class SalaryCalculator
    {
        public static decimal CalculateTotalSalary(decimal baseSalary, decimal bonusPercent)
        {
            return baseSalary + (baseSalary * bonusPercent / 100);
        }

        public static bool ValidateBonusPercent(decimal bonusPercent)
        {
            return bonusPercent >= 0 && bonusPercent <= 100;
        }
    }
}