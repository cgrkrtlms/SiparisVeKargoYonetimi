using Microsoft.EntityFrameworkCore;
using SiparisVeKargoYonetimi.DATA.DataContext;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProjectContext _context;
        internal DbSet<T> _dbSet;
        public Repository(ProjectContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public bool Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<ICollection<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync(); 
        }

    }
}
