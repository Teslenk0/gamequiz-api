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
	class PuntajeController
	{
		private readonly IMapper _mapper;
		
		public PuntajeController(IMapper mapper)
		{
			_mapper = mapper;
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

		public void Create(PuntajeDTO puntaje)
		{
			try
			{
				using (ModelosDBContainer context = new ModelosDBContainer())
				{
					PuntajeRepository repositorio = new PuntajeRepository(context);
					
					if (repositorio.AnyByUsuarioAndJuego(puntaje.Usuario.Id, puntaje.Juego.Id))
					{
						Puntaje p = repositorio.Get(puntaje.Usuario.Id, puntaje.Juego.Id);
						if(p.Puntos < puntaje.Puntos)
							p.Puntos = puntaje.Puntos;
					}
					else
					{
						repositorio.Create(this._mapper.Map<Puntaje>(puntaje));
					}
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


