using Business.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ISalaryService
    {
        void Add(Salary salary);
        void Delete(Salary salary);
        void Update(Salary salary);
        EmployeeSalaryDTO CalculateSalary(Salary salary);
        Salary GetById(int id);
        List<Salary> GetAll();

    }
}
