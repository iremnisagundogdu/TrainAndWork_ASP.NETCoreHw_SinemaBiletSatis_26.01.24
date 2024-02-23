using SinemaBiletSatis.Data;
using SinemaBiletSatis.Data.Concrete;
using SinemaBiletSatis.Entities;
using SinemaBiletSatis.Service.Abstract;

namespace SinemaBiletSatis.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)
        {
        }
    }
}
