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
    public class ClothingService : Service<Clothing>, IClothingService
    {
        public ClothingService(IRepository<Clothing> repo, IUnitOfWork unitOfWork) : base(repo, unitOfWork)
        {
        }
    }
}
