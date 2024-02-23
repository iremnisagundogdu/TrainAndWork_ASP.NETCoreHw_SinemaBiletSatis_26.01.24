using System.Linq.Expressions;

namespace SinemaBiletSatis.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T,bool>> expression);
        T Get(Expression<Func<T,bool>> expression);
        T Find(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save();

        //Asenkron Metotlar 
        Task<T> FindAsync(int id);
        Task<T> GetASycn(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsycn();
        Task<List<T>> GetAllAsycn(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveAsync();
    }
}
