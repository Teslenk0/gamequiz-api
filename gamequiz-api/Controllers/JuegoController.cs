using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gamequiz_api.Controllers
{
    public class JuegoController : ApiController
    {
        // GET: api/Juego
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Juego/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Juego
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Juego/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Juego/5
        public void Delete(int id)
        {
        }
    }
}
