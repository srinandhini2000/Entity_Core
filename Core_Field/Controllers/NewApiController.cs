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
    public class NewApiController : ControllerBase
    {
        protected DatabaseContext db;

        public NewApiController(DatabaseContext _db)
        {
            db = _db;
        }
        // GET: api/<NewApiController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.tbl_User.ToList();
        }

        // GET api/<NewApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
