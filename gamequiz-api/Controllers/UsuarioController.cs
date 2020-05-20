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
using BusinessLogic.Controllers;
using AutoMapper;

namespace gamequiz_api.Controllers
{
    public class UsuarioController : ApiController
    {

        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public Object Post(UsuarioDTO usuario)
        {
            BusinessLogic.Controllers.UsuarioController userController = new BusinessLogic.Controllers.UsuarioController();
            userController.Create(usuario);
            return new
            {
                Success = true,
                Message = "Se ha creado el usuario correctamente."
            };
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
