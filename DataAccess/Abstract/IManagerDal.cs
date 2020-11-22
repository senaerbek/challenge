using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IManagerDal : IEntityRepository<Manager>
    {
        List<Manager> Search(string query);
        List<Manager> Sort(string query);
    }
}
