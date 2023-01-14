using Microsoft.AspNetCore.Mvc;
using CanfieldSchool.Login_Register;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Azure.Core;
using System.Security.Claims;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;

namespace CanfieldSchool.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("Resgister")]

        public async Task<ActionResult<User>> Register(UserLogin request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLogin request)
        {
            
            if (user.UserName != request.UserName)
            {
                return BadRequest("Account is not register");
            }
       
            if(!VerifyPassWordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password!");
            }
            string token = CreateToken(user);
           return Ok(token);
                
            
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.UserName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

      


        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordSalt)
        {
            using (var haac = new HMACSHA512())
            {
                passwordSalt = haac.Key;
                passwordhash = haac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassWordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var haac = new HMACSHA512(passwordSalt))
            {
                var computeHashed = haac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHashed.SequenceEqual(passwordHash);
                
            }
        }
    }
}
