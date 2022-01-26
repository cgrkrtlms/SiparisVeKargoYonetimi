using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        IUserRepository User { get; }
        Task SaveAsync();
        void Save();

    }
}
