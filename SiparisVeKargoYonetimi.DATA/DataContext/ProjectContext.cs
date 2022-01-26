using Microsoft.EntityFrameworkCore;
using SiparisVeKargoYonetimi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.DataContext
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) :base(options)
        {

        }

        public DbSet<ArasCargo> ArasCargos { get; set; }
        public DbSet<YurticiCargo> YurticiCargos { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
