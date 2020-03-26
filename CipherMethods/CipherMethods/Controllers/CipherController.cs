using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;

namespace CipherMethods.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CipherController : ControllerBase
    {
        // GET: api/Cipher
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cipher/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //cesar y cifrado de ruta
        // POST: api/Cipher
        [HttpPost("{name}/{fileName}/{param}")]
        public void Post([FromForm(Name ="file")] IFormFile file, string name, string fileName, string param)
        {
            //lectura del archivo
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            if (name.ToLower().Equals("zigzag"))
            {

            }
            else
            {
                // es cifrado cesar 
            }

        }

        //zigzag
        [HttpPost("{name}/{fileName}/{param}")]
        public void Post([FromForm(Name = "file")] IFormFile file, string name, string fileName, int param)
        {
            //lectura del archivo
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            ZigZag cipherZigZag = new ZigZag();
            cipherZigZag.calculate(param, result.ToString(), fileName);

        }

        // PUT: api/Cipher/5
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
