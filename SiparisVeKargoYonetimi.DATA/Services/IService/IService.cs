using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Services.IService
{
    public interface IService<T> where T : class
    {
        Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(int id);
        Task<bool> Add(T entity);
        bool Delete(int id);
    }
}
