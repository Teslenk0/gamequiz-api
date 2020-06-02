using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace gamequiz_api.Controllers
{

    [Authorize]
    //[AllowAnonymous]
    public class PuntajeController : ApiController
    {
        // GET: api/Puntaje
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Puntaje/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Puntaje
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Puntaje/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Puntaje/5
        public void Delete(int id)
        {
        }
    }
}
