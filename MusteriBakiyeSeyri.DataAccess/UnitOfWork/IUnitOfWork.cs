using MusteriBakiyeSeyri.DataAccess.Interfaces;
using MusteriBakiyeSeyri.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
