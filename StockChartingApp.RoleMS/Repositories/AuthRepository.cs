using EntityLibraryStockChartingApp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockChartingApp.RoleMS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockChartingApp.RoleMS.Repositories
{
    public class AuthRepository : IRepository<Role>
    {
        private AuthContext context;
        private IConfiguration config;

        public AuthRepository(AuthContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public Tuple<bool, TokenDetails> Login(string uname, string pass)
        {
            Tuple<bool, TokenDetails> t;
            try
            {
                var roleholder = context.Role.FirstOrDefault(u => u.RoleName == uname && u.Password == pass && u.Confirmed);
                if (roleholder == null) t = new Tuple<bool, TokenDetails>(false, null);
                else
                {
                    var token = GenerateJwtToken(roleholder);
                    t = new Tuple<bool, TokenDetails>(true, new TokenDetails() { Name = roleholder.RoleName, RoleType=roleholder.RoleType, Token = token});
                }
                return t;
            }
            catch (Exception ex) { throw ex; }

        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool Signup(Role entity)
        {
            try
            {
                context.Role.Add(entity);
                var u = context.SaveChanges();

                if (u > 0) return true;
                return false;
            }
            catch (Exception) { return false; }
        }


        //----------Generate JWT---------------


        private string GenerateJwtToken(Role roleholder)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, roleholder.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, roleholder.RoleType.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays( Convert.ToDouble(config["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                config["JwtIssuer"],
                config["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
