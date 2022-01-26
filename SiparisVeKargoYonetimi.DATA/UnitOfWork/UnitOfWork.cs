using Microsoft.Extensions.Options;
using SiparisVeKargoYonetimi.DATA.DataContext;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using SiparisVeKargoYonetimi.DATA.Repositories.Repository;
using SiparisVeKargoYonetimi.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly ProjectContext _context;
        private readonly IOptions<AppSettings> _appSettings;
        public UnitOfWork(ProjectContext contex, IOptions<AppSettings> appSettings)
        {
            _context = contex;
            _appSettings = appSettings;
        }
   

        public IUserRepository User =>  new UserRepository(_context,_appSettings);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
