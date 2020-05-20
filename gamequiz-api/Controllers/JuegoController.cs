using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gamequiz_api.Controllers
{
    public class JuegoController : ApiController
    {
        // GET: api/Juego
        public HashSet<JuegoDTO> Get()
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            var lista = juegoController.GetAll();
            return lista;
        }

        // GET: api/Juego/5
        public JuegoDTO Get(int id)
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            var juego = juegoController.GetById(id);
            return juego;
        }

        // POST: api/Juego
        public Object Post(JuegoDTO juego)
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            juegoController.Create(juego);
            return new ResponseDTO(juego, "Se ha creado el juego correctamente.", true);
        }

        // PUT: api/Juego/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Juego/5
        public void Delete(int id)
        {
        }
    }
}
