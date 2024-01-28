using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class EmployeeSalaryDTO
    {
        public int SalaryID { get; set; }  
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public int SalaryType { get; set; }
        public int? WorkDays { get; set; }
        public decimal? FixedSalary { get; set; }
        public decimal? DailySalary { get; set; }
        public int? OverTimeHours { get; set; }
        public decimal? OverTimeRate { get; set; }
        public decimal TotalSalary { get; set; }

    }
}
