using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int? WorkDays { get; set; }
        public decimal? FixedSalary { get; set; }
        public decimal? DailySalary { get; set; }
        public int? OverTimeHours { get; set; }
        public decimal? OverTimeRate { get; set; }
        public decimal TotalSalary { get; set; }


    }
}
