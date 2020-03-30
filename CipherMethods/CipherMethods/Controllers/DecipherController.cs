using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CipherMethods.Controllers
{
    [Route("[controller]")]
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
        [HttpGet("{name}/{fileName}/{param}")]
        public string Get([FromForm(Name = "file")] IFormFile file, string name, string fileName, string param)
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
                ZigZag zigzagCipher = new ZigZag();
                zigzagCipher.decipher(int.Parse(param), result, fileName);
                return "Texto desencriptado, método: ZigZag";
            }
            else if (name.ToLower().Equals("caesar"))
            {
                Caesar caesarCipher = new Caesar(param);
                caesarCipher.buildAlphabet();
                caesarCipher.cipher(result, fileName);
                return "Texto desencriptado, método: Caesar";
            }
            else if (name.ToLower().Equals("ruta"))
            {
                return "Texto desencriptado, método: Ruta";
            }
            else
            {
                return "MÉTODO INCORRECTO";
            }
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
