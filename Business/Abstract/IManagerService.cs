using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IManagerService
    {
        void Add(Manager manager);
        Manager GetById(int id);
        void DeleteById(int id);
        void Update(Manager manager);
        List<Manager> Search(string query);
        List<Manager> Sort(string query);
    }
}
