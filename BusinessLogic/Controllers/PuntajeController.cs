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
	public class PuntajeController
	{
		private readonly IMapper _mapper;
		
		public PuntajeController()
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

		public PuntajeDTO GetByUsuarioAndJuego(int UsuarioId, int JuegoId)
		{
			using (ModelosDBContainer context = new ModelosDBContainer())
			{
				PuntajeRepository repositorio = new PuntajeRepository(context);
				var entity = repositorio.Get(UsuarioId,JuegoId);
				return this._mapper.Map<PuntajeDTO>(entity);
			}
		}

		public HashSet<PuntajeDTO> GetAll()
		{
			HashSet<PuntajeDTO> puntajes = new HashSet<PuntajeDTO>();

			using (ModelosDBContainer context = new ModelosDBContainer())
			{
				PuntajeRepository repositorio = new PuntajeRepository(context);
				var entities = repositorio.GetAll();

				foreach (var entity in entities)
				{
					puntajes.Add(this._mapper.Map<PuntajeDTO>(entity));
				}
			}
			return puntajes;
		}

		public Object Create(PuntajeDTO puntaje)
		{
			try
			{
				using (ModelosDBContainer context = new ModelosDBContainer())
				{
					PuntajeRepository repositorio = new PuntajeRepository(context);

					if (repositorio.AnyByUsuarioAndJuego(puntaje.UsuarioId, puntaje.JuegoId))
					{
						Puntaje p = repositorio.Get(puntaje.UsuarioId, puntaje.JuegoId);
						if (p.Puntos < puntaje.Puntos)
							p.Puntos = puntaje.Puntos;
					}
					else
					{
						repositorio.Create(this._mapper.Map<Puntaje>(puntaje));
					}
					var pu = repositorio.Get(puntaje.UsuarioId, puntaje.JuegoId);
					context.SaveChanges();
					return pu;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}


