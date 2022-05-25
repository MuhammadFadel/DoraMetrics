using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
