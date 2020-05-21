using System;
using System.Net;
using System.Web.Http;
using Common.DataTransferObjects;
using Common.Requests;
using System.Web.Http.Cors;

namespace gamequiz_api.Controllers
{

    [AllowAnonymous]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/registrar")]
        public Object Post(UsuarioDTO usuario)
        {
            BusinessLogic.Controllers.UsuarioController userController = new BusinessLogic.Controllers.UsuarioController();
            try
            {

                userController.Create(usuario);
                var entity = userController.GetByUsername(usuario.Username);

                return Content(HttpStatusCode.Created, new ResponseDTO(entity, "Se ah creado el usuario correctamente.", true));
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "El usuario ya existe.":
                        return Content(HttpStatusCode.Conflict, new ResponseDTO(null, e.Message, true));

                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, true));
                }
            }
        }

        [HttpPost]
        [Route("api/acceder")]
        public Object Login(LoginRequest req)
        {
            BusinessLogic.Controllers.UsuarioController userController = new BusinessLogic.Controllers.UsuarioController();
            try
            {
                var result = userController.Login(req.username, req.password);
                return new ResponseDTO(result, "Inicio de sesión correctamente.", true);
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Por favor, ingrese todos los campos.":
                        return Content(HttpStatusCode.BadRequest, new ResponseDTO(null, e.Message, true));
                    case "Credenciales incorrectas":
                        return Content(HttpStatusCode.Unauthorized, new ResponseDTO(null, e.Message, true));
                    case "El usuario no existe.":
                        return Content(HttpStatusCode.NotFound, new ResponseDTO(null, e.Message, true));
                    default:
                        return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, true));
                }
            }
        }
    }
}
