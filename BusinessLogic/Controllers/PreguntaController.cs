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
	public class PreguntaController
	{
        private readonly IMapper _mapper;

        public PreguntaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PreguntaDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                PreguntaRepository repositorio = new PreguntaRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<PreguntaDTO>(entity);
            }
        }

        public HashSet<PreguntaDTO> GetAll()
        {
            HashSet<PreguntaDTO> preguntas = new HashSet<PreguntaDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                PreguntaRepository repositorio = new PreguntaRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    preguntas.Add(this._mapper.Map<PreguntaDTO>(entity));
                }
            }
            return preguntas;
        }

        public void Create(PreguntaDTO pregunta)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    PreguntaRepository repositorio = new PreguntaRepository(context);
                    repositorio.Create(this._mapper.Map<Pregunta>(pregunta));
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
