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
    public class EmployeeService : IEmployeeService
    {
        private readonly SetYazılımDbContext _dbContext;

        public EmployeeService(SetYazılımDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Employee employee)
        {
            
                var addEntity = _dbContext.Add(employee);
                addEntity.State = EntityState.Added;
                _dbContext.SaveChanges();
            
        }

        public void Delete(Employee employee)
        {
           
                var addEntity = _dbContext.Entry(employee);
                addEntity.State = EntityState.Deleted;
                _dbContext.SaveChanges();
            
        }

        public List<Employee> GetAll()
        {
            
                return _dbContext.Set<Employee>().ToList();
           
        }

        public Employee GetById(int id)
        {
            
                return _dbContext.Set<Employee>().Where(x => x.Id == id).FirstOrDefault();
            
        }

        public void Update(Employee employee)
        {
            
                var addEntity = _dbContext.Entry(employee);
                addEntity.State = EntityState.Modified;
                _dbContext.SaveChanges();
            
        }
    }
}
