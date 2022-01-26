using SiparisVeKargoYonetimi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Repositories.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqUser(string username);
        User Authenticate(string username,string password);
        User Register(string username,string password);

    }
}
