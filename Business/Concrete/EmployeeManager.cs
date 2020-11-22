using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public List<Employee> GetListById(int managerId)
        {
            return _employeeDal.GetList(p => p.ManagerId == managerId);
        }

        public List<Employee> Search(string query)
        {
            return _employeeDal.Search(query);
        }

        public List<Employee> Sort(string query, int id)
        {
            return _employeeDal.Sort(query, id);
        }
    }
}
