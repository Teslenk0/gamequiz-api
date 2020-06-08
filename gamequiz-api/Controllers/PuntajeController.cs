using Common.DataTransferObjects;
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
        public Object Post(PuntajeDTO puntaje)
        {
            try
            {
                BusinessLogic.Controllers.PuntajeController puntajeController = new BusinessLogic.Controllers.PuntajeController();
                var resp = puntajeController.Create(puntaje);
                return new ResponseDTO(resp, "Se ha creado el puntaje correctamente.", true);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }

    }
}
