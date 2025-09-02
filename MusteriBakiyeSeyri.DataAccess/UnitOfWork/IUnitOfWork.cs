using MusteriBakiyeSeyri.DataAccess.Interfaces;
using MusteriBakiyeSeyri.Entities;

namespace MusteriBakiyeSeyri.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
