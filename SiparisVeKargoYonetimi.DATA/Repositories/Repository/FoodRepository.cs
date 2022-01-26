using SiparisVeKargoYonetimi.Core.Models;
using SiparisVeKargoYonetimi.DATA.DataContext;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Repositories.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        private ProjectContext _context;

        public FoodRepository(ProjectContext context) : base(context)
        {
        }
    }
}
