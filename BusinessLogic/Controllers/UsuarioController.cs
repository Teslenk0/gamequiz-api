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
    public class UsuarioController
    {

        private readonly IMapper _mapper;

        public UsuarioController()
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


        public UsuarioDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                UsuarioRepository repositorio = new UsuarioRepository(context);
                var entity = repositorio.Get(Id);

                return this._mapper.Map<UsuarioDTO>(entity);
            }
        }

        public UsuarioDTO GetByUsername(string username)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                UsuarioRepository repositorio = new UsuarioRepository(context);
                var entity = repositorio.Get(username);

                return this._mapper.Map<UsuarioDTO>(entity);
            }
        }

        public Object Login(string usuario, string contraseña)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    UsuarioRepository repositorio = new UsuarioRepository(context);

                    if (repositorio.Any(usuario))
                    {
                        throw new Exception("El usuario no existe.");
                    }

                    var entity = repositorio.Get(usuario);

                    if (repositorio.VerifyPassword(contraseña, entity.Password))
                    {
                        throw new Exception("Credenciales incorrectas");
                    }

                    var user = this._mapper.Map<UsuarioDTO>(entity);
                    var token = "nadsjknp'klmdasjkln;dasjn;klasd";
                    //var token = this.GenerateTokenJwt(user.Username);


                    return new { 
                        user,
                        token
                    };
                }
            }
            catch (Exception e)
            {
                throw e;

            }
        }




        
        public HashSet<UsuarioDTO> GetAll()
        {
            HashSet<UsuarioDTO> usuarios = new HashSet<UsuarioDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                UsuarioRepository repositorio = new UsuarioRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    usuarios.Add(this._mapper.Map<UsuarioDTO>(entity));
                }
            }
            return usuarios;
        }

        public void Create(UsuarioDTO usuario)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    UsuarioRepository repositorio = new UsuarioRepository(context);
                    if (repositorio.Any(usuario.Username))
                    {
                        throw new Exception("El usuario ya existe.");
                    }
                    repositorio.Create(this._mapper.Map<Usuario>(usuario));
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
                    UsuarioRepository repositorio = new UsuarioRepository(context);
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
