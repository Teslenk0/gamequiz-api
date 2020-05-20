using AutoMapper;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Persistencia.Database;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Controllers
{
    class JugandoController
    {
        private readonly IMapper _mapper;

        public JugandoController()
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


        public JugandoDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JugandoRepository repositorio = new JugandoRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<JugandoDTO>(entity);
            }
        }

        public HashSet<JugandoDTO> GetAll()
        {
            HashSet<JugandoDTO> Juegos = new HashSet<JugandoDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JugandoRepository repositorio = new JugandoRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    Juegos.Add(this._mapper.Map<JugandoDTO>(entity));
                }
            }
            return Juegos;
        }

        public void Create(JugandoDTO Juego)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    JugandoRepository repositorio = new JugandoRepository(context);
                    repositorio.Create(this._mapper.Map<Jugando>(Juego));
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
                    JugandoRepository repositorio = new JugandoRepository(context);
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
