using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DBCon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_Field.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {

        // GET: api/<LoginApiController>
        protected DatabaseContext db;
        private readonly IConfiguration _configuration;

        public LoginApiController(DatabaseContext _db, IConfiguration configuration)
        {
            
            db = _db;
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]

        public string Authenticate(User us)
        {

            string msg = string.Empty;

            if (db.tbl_User.Any(u => u.Email == us.Email && u.Password == us.Password))
            {
                return "Login successfully";
            }
            else if (db.tbl_User.Any(u => us.Email == null && us.Password == null))
            {

                return "please enter the Values";
            }
            else
            {

                return "Login Failed";
            }
          
        }
        

    }
    }
