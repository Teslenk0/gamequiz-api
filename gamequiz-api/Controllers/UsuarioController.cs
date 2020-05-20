using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

using Common.DataTransferObjects;
using Common.Requests;
using BusinessLogic.Controllers;
using AutoMapper;

namespace gamequiz_api.Controllers
{
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
                return new ResponseDTO(usuario, "Se ah creado el usuario correctamente.", true);
            }
            catch (Exception e)
            {
                return new ResponseDTO(null, e.Message, false);
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
                return new ResponseDTO(result, "Se ah creado el usuario correctamente.", true);
            }
            catch (Exception e)
            {
                return new ResponseDTO(null, e.Message, false);

            }
        }


    }
}
