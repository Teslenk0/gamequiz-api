using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gamequiz_api.Controllers
{
    public class PreguntaController : ApiController
    {
        // GET: api/Pregunta
        public HashSet<PreguntaDTO> Get()
        {
            BusinessLogic.Controllers.PreguntaController preguntaController = new BusinessLogic.Controllers.PreguntaController();
            var lista = preguntaController.GetAll();
            return lista;
        }

        // GET: api/Pregunta/5
        public PreguntaDTO Get(int id)
        {
            BusinessLogic.Controllers.PreguntaController preguntaController = new BusinessLogic.Controllers.PreguntaController();
            var pregunta = preguntaController.GetById(id);
            return pregunta;
        }

        // POST: api/Pregunta
        public Object Post(PreguntaDTO pregunta)
        {
            BusinessLogic.Controllers.PreguntaController preguntaController = new BusinessLogic.Controllers.PreguntaController();
            preguntaController.Create(pregunta);
            return new ResponseDTO(pregunta, "Se ha creado la pregunta correctamente.", true);
        }
    }
}
