using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gamequiz_api.Controllers
{

    [Authorize]
    //[AllowAnonymous]
    public class JuegoController : ApiController
    {


        public HashSet<JuegoDTO> Get(string nombre)
        {

            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                var lista = juegoController.GetAll(nombre);
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Object Get(int id)
        {
            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                var juego = juegoController.GetById(id);
                return juego;
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Juego no existente.":
                        return Content(HttpStatusCode.NotFound, new ResponseDTO(null, e.Message, false));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
                }

            }
        }


        [HttpGet]
        [Route("api/juego/Uuid/{Uuid}")]
        public Object GetByUuid(string Uuid)
        {
            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                var juego = juegoController.GetByUuid(Uuid);
                return juego;
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Juego no existente.":
                        return Content(HttpStatusCode.NotFound, new ResponseDTO(null, e.Message, false));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
                }

            }
        }


        public Object Post(JuegoDTO juego)
        {
            string BASE_URL = System.Configuration.ConfigurationManager.AppSettings["BASE_URL"].ToString();
            string BASE_PATH = System.Configuration.ConfigurationManager.AppSettings["BASE_IMAGES_PATH"].ToString();

            juego.Caratula = BASE_URL + BASE_PATH + "/default.png";
            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                var created = juegoController.Create(juego);
                return Content(HttpStatusCode.Created, new ResponseDTO(created, "Se ha creado el juego correctamente.", true));
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Validation failed for one or more entities. See 'EntityValidationErrors' property for more details.":
                        return Content(HttpStatusCode.BadRequest, new ResponseDTO(null, "Por favor, ingrese correctamente todos los datos.", false));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
                }

            }

        }


        [HttpPost]
        [Route("api/juego/cambiar_estado/{id}")]
        public Object CambiarEstado(int id)
        {
            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                juegoController.CambiarEstado(id);
                return new ResponseDTO(null, "Se ah cambiado el estado del juego correctamente", true);
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Juego no existente.":
                        return Content(HttpStatusCode.NotFound, new ResponseDTO(null, e.Message, false));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
                }
            }
        }

        [HttpPost]
        [Route("api/juego/aumentarJugados/{id}")]
        public Object AumentarJugados(int id)
        {
            try
            {
                BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
                juegoController.AumentarJugados(id);
                return new ResponseDTO(null, "Se ah aumentado correctamente", true);
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Juego no existente.":
                        return Content(HttpStatusCode.NotFound, new ResponseDTO(null, e.Message, false));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
                }
            }
        }

    }
}
