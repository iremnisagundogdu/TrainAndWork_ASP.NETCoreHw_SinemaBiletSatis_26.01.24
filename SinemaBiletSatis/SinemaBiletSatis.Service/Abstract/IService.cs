using SinemaBiletSatis.Data.Abstract;
using SinemaBiletSatis.Entities;

namespace SinemaBiletSatis.Service.Abstract
{
    public interface IService<T> :IRepository<T> where T : class, IEntity,new()
    {
    }
}
