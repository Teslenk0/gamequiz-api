using AutoMapper;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Persistencia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class JuegoController
    {
        private readonly IMapper _mapper;

        public JuegoController()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDTO, Usuario>();
                cfg.CreateMap<Usuario, UsuarioDTO>();

                cfg.CreateMap<JuegoDTO, Juego>();
                cfg.CreateMap<Juego, JuegoDTO>();

                cfg.CreateMap<JugandoDTO, Jugando>();
                cfg.CreateMap<Jugando, JugandoDTO>();

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


        public JuegoDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JuegoRepository repositorio = new JuegoRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<JuegoDTO>(entity);
            }
        }

        public HashSet<JuegoDTO> GetAll()
        {
            HashSet<JuegoDTO> Juegos = new HashSet<JuegoDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JuegoRepository repositorio = new JuegoRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    Juegos.Add(this._mapper.Map<JuegoDTO>(entity));
                }
            }
            return Juegos;
        }

        public void Create(JuegoDTO Juego)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    JuegoRepository repositorio = new JuegoRepository(context);
                    repositorio.Create(this._mapper.Map<Juego>(Juego));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    JuegoRepository repositorio = new JuegoRepository(context);
                    repositorio.Delete(Id);
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
