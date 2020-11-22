using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface  IEmployeeService
    {
        List<Employee> GetListById(int managerId);
        List<Employee> Search(string query);
        List<Employee> Sort(string query, int id);
    }
}
