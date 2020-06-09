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

        public RespuestaController()
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

        public Object Create(RespuestaDTO respuesta)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    RespuestaRepository repositorio = new RespuestaRepository(context);
                    var resp = this._mapper.Map<Respuesta>(respuesta);
                    repositorio.Create(resp);
                    context.SaveChanges();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object AumentarSel(int id)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    RespuestaRepository repositorio = new RespuestaRepository(context);
                    var r = repositorio.Get(id);
                    r.VecesSeleccionada++;
                    context.SaveChanges();
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
