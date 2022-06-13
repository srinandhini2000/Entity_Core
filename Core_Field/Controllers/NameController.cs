using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core_Field.Models;
using DBCon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_Field.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        protected DatabaseContext db1;
        private readonly JWTSetting jwt;
        private readonly IRefreshToken token1;
        public NameController(DatabaseContext db,IOptions<JWTSetting> options, IRefreshToken refreshToken)
        {
            db1 = db;
            jwt = options.Value;

            token1 = refreshToken;

        }
     
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db1.tbl_User.ToList();
        }
        [NonAction]
        public TokenResponse Authenticate(string username,Claim[] claims)
        {
            TokenResponse tk = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(jwt.securitykey);
            var tokenhandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                );
            tk.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
            tk.RefreshToken = token1.GenerateToken(username);
               
            
            return tk;
        }
        [Route("Authenticate")]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Cred cred)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var user = db1.tbl_User.FirstOrDefault(o => o.Email == cred.Email && o.Password == cred.Password);
            if(user==null)
            {
                return Unauthorized();
            }
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(jwt.securitykey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
             {
                    new Claim(ClaimTypes.Name,cred.Email)
                   

             }),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(tokenkey),SecurityAlgorithms.HmacSha256)
              
            };
        var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);
            tokenResponse.JWTToken = finaltoken;
            tokenResponse.RefreshToken = token1.GenerateToken(cred.Email);
            return Ok(tokenResponse);
        }
        [Route("Refresh")]
        [HttpPost]
        public IActionResult Refresh([FromBody] TokenResponse token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenhandler.ValidateToken(token.JWTToken, new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.securitykey)),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out securityToken);
            var _token = securityToken as JwtSecurityToken;
            if(_token!=null&& !_token.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return Unauthorized();
            }
            var username = principal.Identity.Name;
            var _reftable = db1.tbl_Refreshtoken.FirstOrDefault(o => o.Userid == username && o.Refreshtoken == token.RefreshToken);
            if(_reftable==null)
            {
                return Unauthorized();
            }
            TokenResponse _result = Authenticate(username, principal.Claims.ToArray());
            return Ok(_result);
        }
   
    }
}
