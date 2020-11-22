using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ManagerManager : IManagerService
    {
        private IManagerDal _managerDal;
        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public void Add(Manager manager)
        {
            _managerDal.Add(manager);
        }

        public void DeleteById(int id)
        {
             var deleted = _managerDal.Get(p => p.Id == id);
            _managerDal.Delete(deleted);
        }

        public Manager GetById(int id)
        {
            return _managerDal.Get(p=>p.Id==id);
        }

        public List<Manager> Search(string query)
        {
            return _managerDal.Search(query);
        }

        public List<Manager> Sort(string query)
        {
            return _managerDal.Sort(query);
        }

        public void Update(Manager manager)
        {
            _managerDal.Update(manager);
        }

    }
}
