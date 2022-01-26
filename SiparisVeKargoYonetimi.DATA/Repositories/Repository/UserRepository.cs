using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiparisVeKargoYonetimi.Core.Models;
using SiparisVeKargoYonetimi.DATA.DataContext;
using SiparisVeKargoYonetimi.DATA.Repositories.IRepository;
using SiparisVeKargoYonetimi.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SiparisVeKargoYonetimi.DATA.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private ProjectContext _context;
        private readonly AppSettings _appSettings;
        private readonly DbSet<User> _dbSet;
        public UserRepository(ProjectContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _dbSet = _context.Set<User>();
        }

        public User Authenticate(string username, string password)
        {
            var user = _dbSet.SingleOrDefault(x=>x.Username==username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.ID.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }

        public bool IsUniqUser(string username)
        {
            var user = _dbSet.SingleOrDefault(x=>x.Username==username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public User Register(string username, string password)
        {
            var user = new User()
            {
                Username = username,
                Password = password,
                Role = "Admin",
                Confirmation = false
            };
            _dbSet.Add(user);
            user.Password = "";
            return user;
        }

     
    }
}
