using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Omnific.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace Omnific.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// The context
        /// </summary>
        private readonly OmnificContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="omnificContext"></param>
        public AuthenticationService(OmnificContext omnificContext, IConfiguration configuration) 
        {
            _context = omnificContext;
            _configuration = configuration;
        }
        /// <summary>
        /// public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        /// creates a passwordSalt and passwordHash from a password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        /// <summary>
        /// public string Login(string userName, string password)
        /// returns a token for the user logged in
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string Login(User user)
        {
            
            string token = CreateToken(user);

            //var refreshToken = GenerateRefreshToken();
            //SetRefreshToken(refreshToken);

            return token;
        }
        /// <summary>
        /// public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        /// checks if the password is equal to passwordSalt and passwordHash
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyPasswordHash(User user, string password)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }
        /// <summary>
        /// private string CreateToken(string userName)
        /// creates a 30 minutes life time token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
