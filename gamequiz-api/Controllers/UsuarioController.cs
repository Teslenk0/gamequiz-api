using System;
using System.Net;
using System.Web.Http;
using Common.DataTransferObjects;
using Common.Requests;
using System.Web.Http.Cors;
using System.Threading;
using System.Diagnostics;

namespace gamequiz_api.Controllers
{

    
    public class UsuarioController : ApiController
    {
        [AllowAnonymous]
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

        [AllowAnonymous]
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
        [Authorize]
        [HttpGet]
        [Route("api/me")]
        public Object FetchUserData()
        {
            BusinessLogic.Controllers.UsuarioController userController = new BusinessLogic.Controllers.UsuarioController();
            try
            {
                
                // saco el nombre de usuario a partir del token recibido
                var username = Thread.CurrentPrincipal.Identity.Name;
                var user = userController.GetByUsername(username);
              
                return new ResponseDTO(user, "Usuario encontrado.", true);
            }
            catch (Exception e)
            {
                return new ResponseDTO(null, e.Message, false);
            }
        }
    }
}
