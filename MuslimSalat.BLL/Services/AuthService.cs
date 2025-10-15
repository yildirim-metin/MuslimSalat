using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MuslimSalat.DL.Entities;

public class AuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                // new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // Crédential pour signé le token (clé + algo)
            string secretKey = _config["Jwt:Key"]!;
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Génération du token
            JwtSecurityToken token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
