using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CipherMethods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecipherController : ControllerBase
    {
        // GET: api/Decipher
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Decipher/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Decipher
        [HttpPost("{name}")]
        public void Post([FromForm(Name = "file")] IFormFile file, string name)
        {
        }

        // PUT: api/Decipher/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
