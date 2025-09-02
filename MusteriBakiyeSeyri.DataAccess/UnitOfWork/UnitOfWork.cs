using MusteriBakiyeSeyri.DataAccess.Context;
using MusteriBakiyeSeyri.DataAccess.Interfaces;
using MusteriBakiyeSeyri.DataAccess.Repositories;
using MusteriBakiyeSeyri.Entities;

namespace MusteriBakiyeSeyri.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusteriBakiyeSeyriDb _context;

        public UnitOfWork(MusteriBakiyeSeyriDb context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
