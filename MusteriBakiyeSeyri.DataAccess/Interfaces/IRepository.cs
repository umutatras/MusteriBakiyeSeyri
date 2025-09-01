using MusteriBakiyeSeyri.SharedLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusteriBakiyeSeyri.DataAccess.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC);

    Task<T> FindAsync(int id);

    Task<T> GetById(int id);

    IQueryable<T> GetQuery();

    void Remove(T entity);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);
}