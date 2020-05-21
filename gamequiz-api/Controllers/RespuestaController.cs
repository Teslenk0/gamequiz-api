using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace gamequiz_api.Controllers
{
    
    public class RespuestaController : ApiController
    {
        // GET: api/Respuesta
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Respuesta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Respuesta
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Respuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Respuesta/5
        public void Delete(int id)
        {
        }
    }
}
