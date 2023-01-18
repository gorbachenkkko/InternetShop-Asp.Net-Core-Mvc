using System.Linq;

namespace InternetShop.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);

        IQueryable<T> Select();

        Task Delete(T entity);

        Task<T> Update(T entity);
    }
}
