using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Repositories
{
	class PuntajeRepository
	{
		private readonly ModelosDBContainer _context;

		public PuntajeRepository(ModelosDBContainer context)
		{
			this._context = context;
		}

		public Puntaje Get(int UsuarioId, int JuegoId)
		{
			var PuntajeEntity = this._context.PuntajeSet.Where(a => a.Usuario.Id == UsuarioId && a.Juego.Id == JuegoId).FirstOrDefault();
			return PuntajeEntity;
		}

		public HashSet<Puntaje> GetAll()
		{
			var entitySet = this._context.PuntajeSet.Select(s => s).ToHashSet();
			return entitySet;
		}

		public bool Any(int Id)
		{
			var exists = this._context.PuntajeSet.Any(s => s.Id == Id);
			return exists;
		}

		public bool AnyByUsuarioAndJuego(int UsuarioId, int JuegoId)
		{
			var exists = this._context.PuntajeSet.Any(s => s.Usuario.Id == UsuarioId && s.Juego.Id == JuegoId);
			return exists;
		}

		public void Create(Puntaje puntaje)
		{
			this._context.PuntajeSet.Add(puntaje);
		}

	}
}

