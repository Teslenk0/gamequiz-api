using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Persistencia.Database;

namespace BusinessLogic.Controllers
{
    public class RespuestaController
    {
        private readonly IMapper _mapper;

        public RespuestaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RespuestaDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                RespuestaRepository repositorio = new RespuestaRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<RespuestaDTO>(entity);
            }
        }

        public HashSet<RespuestaDTO> GetAll()
        {
            HashSet<RespuestaDTO> respuestas = new HashSet<RespuestaDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                RespuestaRepository repositorio = new RespuestaRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    respuestas.Add(this._mapper.Map<RespuestaDTO>(entity));
                }
            }
            return respuestas;
        }

        public void Create(RespuestaDTO respuesta)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    RespuestaRepository repositorio = new RespuestaRepository(context);
                    repositorio.Create(this._mapper.Map<Respuesta>(respuesta));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
