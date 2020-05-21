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

    //[Authorize]
    [AllowAnonymous]
    public class RespuestaController : ApiController
    {
        // GET: api/Respuesta
        public HashSet<RespuestaDTO> Get()
        {
            BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
            var lista = respuestaController.GetAll();
            return lista;
        }

        // GET: api/Respuesta/5
        public RespuestaDTO Get(int id)
        {
            BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
            var respuesta = respuestaController.GetById(id);
            return respuesta;
        }

        // POST: api/Respuesta
        public Object Post(RespuestaDTO respuesta)
        {
            BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
            respuestaController.Create(respuesta);
            return new ResponseDTO(respuesta, "Se ha creado la respuesta correctamente.", true);
        }
    }
}
