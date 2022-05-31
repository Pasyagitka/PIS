using System.Linq.Expressions;

namespace Lab8.Models
{
    public interface IRepository<T> where T : class
    {
        Task<bool> CreateAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
