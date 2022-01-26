using SiparisVeKargoYonetimi.Core.Models;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using SiparisVeKargoYonetimi.DATA.Services.IService;
using SiparisVeKargoYonetimi.DATA.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Services
{
    public class UserService :  IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IUserRepository _repo;
        public UserService(IUserRepository repo, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public User Authenticate(string username, string password)
        {
            var user = _repo.Authenticate(username, password);
            return user;
        }

        public bool IsUniqUser(string username)
        {
           return _repo.IsUniqUser(username);
        }

        public User Register(string username, string password)
        {
            var user = _repo.Register(username,password);
            _unitOfWork.Save();
            return user;
        }
    }
}
