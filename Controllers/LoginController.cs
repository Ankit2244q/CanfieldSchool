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
using CanfieldSchool.Database_context;
using Microsoft.Extensions.Configuration;
using System.Text;
using CanfieldSchool.Models;
using Microsoft.AspNetCore.Authorization;

namespace CanfieldSchool.Controllers
{
   
    public class LoginController : ControllerBase
    {
        public static User user = new User();
         private readonly CanfieldDbContext _userLogin;
        private readonly IConfiguration _configuration;

        public LoginController(CanfieldDbContext logincontext , IConfiguration configuration)
        {
            _userLogin  = logincontext;
            _configuration = configuration;
        }

    
        [HttpPost("Register")]

        public async Task<ActionResult<UserLogin>> Register(UserLogin request)
        {

                
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = request.UserName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (user != null)
            {
                var createLogin = _userLogin.users.Add(request);
                await _userLogin.SaveChangesAsync();
                return request;
                
            }
            else
            {
                return BadRequest("cant add user");
            }
            
        }
        //save login details


       
 
        [HttpPost("login")]
       // [Authorize(Roles ="Manager")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Email == "ankit" && user.Password == "ankit")
            {


    //            var claims = new List<Claim>
    //{
    //    new Claim(ClaimTypes.Name, user.UserName),
    //    new Claim(ClaimTypes.Role, "Manager")
    //};

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7119",
                    audience: "https://localhost:7119",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }

            return Unauthorized();
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.UserName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("appsettings:Token").Value));
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
