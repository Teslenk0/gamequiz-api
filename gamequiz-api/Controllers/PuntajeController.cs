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
    public class PuntajeController : ApiController
    {
        // GET: api/Puntaje
        [AllowAnonymous]
        [HttpGet]
        [Route("api/Puntaje/ranking")]
        public HashSet<PuntajeDTO> GetRanking(int juegoId)
        {
            try
            {
                BusinessLogic.Controllers.PuntajeController puntajeController = new BusinessLogic.Controllers.PuntajeController();
                var lista = puntajeController.GetAll(juegoId);
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: api/Puntaje
        [AllowAnonymous]
        public Object Post(PuntajeDTO puntaje)
        {
            try
            {
                BusinessLogic.Controllers.PuntajeController puntajeController = new BusinessLogic.Controllers.PuntajeController();
                puntajeController.Create(puntaje);
                return new ResponseDTO(HttpStatusCode.Created, "Se ha creado el puntaje correctamente.", true);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }

    }
}
