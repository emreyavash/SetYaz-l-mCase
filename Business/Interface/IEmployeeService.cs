﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        void Delete(Employee employee);
        void Update(Employee employee);
        Employee GetById(int id);
        List<Employee> GetAll();

    }
}
