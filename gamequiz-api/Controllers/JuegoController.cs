using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gamequiz_api.Controllers
{

    //[Authorize]
    [AllowAnonymous]
    public class JuegoController : ApiController
    {


        public HashSet<JuegoDTO> Get()
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            var lista = juegoController.GetAll();
            return lista;
        }


        public JuegoDTO Get(int id)
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            var juego = juegoController.GetById(id);
            return juego;
        }


        public Object Post(JuegoDTO juego)
        {
            BusinessLogic.Controllers.JuegoController juegoController = new BusinessLogic.Controllers.JuegoController();
            juegoController.Create(juego);
            return new ResponseDTO(juego, "Se ha creado el juego correctamente.", true);
        }
    }
}
