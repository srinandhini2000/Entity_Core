using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core_Field.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserapiController : ControllerBase
    {
        // GET: api/<UserapiController>
        protected DatabaseContext db;

        public UserapiController(DatabaseContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserapiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserapiController>
        [HttpPost]
        public void Post([FromBody] User model)
        {
            db.tbl_User.Add(model);
            db.SaveChanges();
        }

        // PUT api/<UserapiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserapiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
