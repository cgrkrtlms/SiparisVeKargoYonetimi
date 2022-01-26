using SiparisVeKargoYonetimi.DATA.DataContext;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using SiparisVeKargoYonetimi.DATA.Services.IService;
using SiparisVeKargoYonetimi.DATA.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repo;
        public Service(IRepository<T> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(T entity)
        {
            await _repo.Add(entity);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public bool Delete(int id)
        {
            _repo.Delete(id);
            _unitOfWork.Save();
            return true;
        }

        public async Task<T> Get(int id)
        {
            return await _repo.Get(id);

        }

        public async Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return await _repo.GetAll(filter);
        }


    }
}
