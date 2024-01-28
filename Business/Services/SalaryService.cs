using Business.DTOs;
using Business.Interface;
using DataAccess.Entities;
using DataAccess.SetYazılımContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly SetYazılımDbContext _dbContext;

        public SalaryService(SetYazılımDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Salary salary)
        {
            
                var addEntity = _dbContext.Add(salary);
                addEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public EmployeeSalaryDTO CalculateSalary(Salary salary)
        {
            var employee = _dbContext.Set<Employee>().Where(x=>x.Id == salary.EmployeeId).FirstOrDefault();
            var salaryCheck = _dbContext.Set<Salary>().Where(x=>x.EmployeeId ==  employee.Id).FirstOrDefault();
            salary.EmployeeId = employee.Id;
            if (salary.FixedSalary != null && salary.OverTimeHours == null && salary.OverTimeRate == null)
            {
                salary.OverTimeRate = 0;
                salary.OverTimeHours = 0;
                salary.DailySalary = 0;
                salary.TotalSalary = salary.FixedSalary.GetValueOrDefault();

            }
            else if(salary.FixedSalary == null && salary.DailySalary != null && salary.WorkDays != null)
            {
                salary.FixedSalary = 0;
                salary.OverTimeHours = 0;
                salary.OverTimeRate = 0;
                salary.TotalSalary = (salary.DailySalary * salary.WorkDays).GetValueOrDefault();
            }
            else if(salary.FixedSalary != null && salary.OverTimeHours != null && salary.OverTimeRate != null)
            {
                salary.DailySalary = 0;
                salary.TotalSalary = (salary.FixedSalary + (salary.OverTimeHours*salary.OverTimeRate)).GetValueOrDefault();
            }
            if (salaryCheck == null)
            {
            Add(salary);

            }
            else
            {
                _dbContext.ChangeTracker.Clear();
                salary.Id = salaryCheck.Id;
                _dbContext.Entry(salary).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            var employeeSalary = new EmployeeSalaryDTO
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmployeeID = employee.Id,
                TcNo = employee.TcNo,
                SalaryID = salary.Id,
                DailySalary = salary.DailySalary,
                FixedSalary = salary.FixedSalary,
                OverTimeHours = salary.OverTimeHours,
                OverTimeRate = salary.OverTimeRate,
                TotalSalary = salary.TotalSalary,
                WorkDays = salary.WorkDays,
            };
            return employeeSalary;

            

        }

        public void Delete(Salary salary)
        {
           
                var addEntity = _dbContext.Entry(salary);
                addEntity.State = EntityState.Deleted;
                _dbContext.SaveChanges();
            
        }

        public List<Salary> GetAll()
        {
            
                return _dbContext.Set<Salary>().ToList();
           
        }

        public Salary GetById(int id)
        {
           
                return _dbContext.Set<Salary>().Where(x => x.Id == id).FirstOrDefault();
            
        }

        public void Update(Salary salary)
        {
          
                var addEntity = _dbContext.Entry(salary);
                addEntity.State = EntityState.Modified;
                _dbContext.SaveChanges();
            
        }
    }
}
