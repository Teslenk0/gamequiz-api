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

        public PreguntaController()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDTO, Usuario>();
                cfg.CreateMap<Usuario, UsuarioDTO>();

                cfg.CreateMap<JuegoDTO, Juego>();
                cfg.CreateMap<Juego, JuegoDTO>();

                cfg.CreateMap<PreguntaDTO, Pregunta>();
                cfg.CreateMap<Pregunta, PreguntaDTO>();

                cfg.CreateMap<RespuestaDTO, Respuesta>();
                cfg.CreateMap<Respuesta, RespuestaDTO>();

                cfg.CreateMap<PuntajeDTO, Puntaje>();
                cfg.CreateMap<Puntaje, PuntajeDTO>();
            });
            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            _mapper = configuration.CreateMapper();
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

        public Object Create(PreguntaDTO pregunta)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    PreguntaRepository repositorio = new PreguntaRepository(context);
                    var preg = this._mapper.Map<Pregunta>(pregunta);
                    repositorio.Create(preg);
                    context.SaveChanges();
                    return preg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetImage(int id, string url)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    PreguntaRepository repositorio = new PreguntaRepository(context);

                    var pregunta = repositorio.Get(id);

                    pregunta.Imagen = url;

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
