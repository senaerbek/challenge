using Core.DataAccess.Concrete.Context;
using Core.DataAccess.Concrete.Ef;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfManagerDal : EntityRepository<Manager, ChallengeProjectContext>, IManagerDal
    {
        public List<Manager> Search(string query)
        {
            using (var context = new ChallengeProjectContext())
            {
                var search = (from i in context.Managers
                              select i);

                if (!string.IsNullOrEmpty(query))
                {
                    search = search.Where(p => p.FirstName.Contains(query)
                    || p.LastName.Contains(query)
                    || p.Email.Contains(query)
                    || p.PhoneNumber.Contains(query)
                    || p.Id.ToString().Contains(query)
                    );
                }
                return search.ToList();

            }
        }

        public List<Manager> Sort(string query)
        {
            using (var context = new ChallengeProjectContext())
            {
                var search = (from i in context.Managers
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
                    case "sort_PhoneNumber":
                        search = search.OrderBy(p => p.PhoneNumber);
                        return search.ToList();
                }
                return search.ToList();

            }
        }
    }
}
