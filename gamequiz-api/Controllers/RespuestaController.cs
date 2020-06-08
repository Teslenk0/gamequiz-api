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
    public class RespuestaController : ApiController
    {
        // GET: api/Respuesta
        [AllowAnonymous]
        public HashSet<RespuestaDTO> Get()
        {
            BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
            var lista = respuestaController.GetAll();
            return lista;
        }

        // GET: api/Respuesta/5
        [AllowAnonymous]
        public RespuestaDTO Get(int id)
        {
            BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
            var respuesta = respuestaController.GetById(id);
            return respuesta;
        }

        // POST: api/Respuesta
        [Authorize]
        public Object Post(RespuestaDTO respuesta)
        {
            try
            {
                BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
                var resp = respuestaController.Create(respuesta);
                return new ResponseDTO(resp, "Se ha creado la respuesta correctamente.", true);
            }
            catch (Exception e) {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/respuesta/aumentar/{id}")]
        public Object AumentarSel(int id)
        {
            try
            {
                BusinessLogic.Controllers.RespuestaController respuestaController = new BusinessLogic.Controllers.RespuestaController();
                var resp = respuestaController.AumentarSel(id);
                return new ResponseDTO(resp, "Se ha incrementado correctamente.", true);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }
    }
}
