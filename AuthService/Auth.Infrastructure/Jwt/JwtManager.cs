using Auth.Core.Interfaces.Jwt;
using Auth.Core.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Services
{
    public class JwtManager : IJwtManager
    {
        private readonly string _key;

        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IConfiguration _config;
        public JwtManager(IConfiguration config, IUserRepo userRepo,
            IRoleRepo roleRepo)
        {
            _config = config;
            _userRepo = userRepo;
            _roleRepo = roleRepo;   
        }

        public async Task<string> CreateToken(int userId)
        {
            string issuer = _config["Jwt:Issuer"];
            string audience = _config["Jwt:Audience"];
            string key = _config["Jwt:Key"];

            SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(key);
            var user = await _userRepo.GetUserById(userId);
            var roles =  _roleRepo.GetRolesByUserId(user.Id);

            List<Claim> roleClaims = new List<Claim>();

            foreach (var item in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, item.Name));
            }

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email,user.Email),
                }
                .Union(roleClaims)
                ),
                Expires = DateTime.UtcNow.AddHours(24),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
