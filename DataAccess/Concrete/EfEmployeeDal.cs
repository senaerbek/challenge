using Core.DataAccess.Concrete.Context;
using Core.DataAccess.Concrete.Ef;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EntityRepository<Employee, ChallengeProjectContext>, IEmployeeDal
    {
        public List<Employee> Search(string query)
        {
            using (var context = new ChallengeProjectContext())
            {
                var search = (from i in context.Employees
                              select i);

                if (!string.IsNullOrEmpty(query))
                {
                    search = search.Where(p => p.Id.ToString().Contains(query)
                    || p.FirstName.Contains(query)
                    || p.LastName.Contains(query)
                    || p.Email.Contains(query)
                    || p.Salary.ToString().Contains(query)
                    );
                }
                return search.ToList();

            }
        }

        public List<Employee> Sort(string query, int id)
        {
            using (var context = new ChallengeProjectContext())
            {

                var search = (from i in context.Employees
                              join j in context.Managers
                              on i.ManagerId equals j.Id
                              where i.ManagerId == id
                              select i);

                switch (query)
                {
                    case "sort_Id":
                        search = search.OrderByDescending(p => p.Id);
                        return search.ToList();
                    case "sort_FirstName":
                        search = search.OrderBy(p => p.FirstName);
                        return search.ToList();
                    case "sort_LastName":
                        search = search.OrderBy(p => p.LastName);
                        return search.ToList();
                    case "sort_Email":
                        search = search.OrderBy(p => p.Email);
                        return search.ToList();
                    case "sort_Salary":
                        search = search.OrderBy(p => p.Salary);
                        return search.ToList();

                }
                return search.ToList();

            }
        }
    }
}
