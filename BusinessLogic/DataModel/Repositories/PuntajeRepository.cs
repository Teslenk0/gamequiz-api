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

		public HashSet<Puntaje> GetAll(int juegoId)
		{
			var entitySet = this._context.PuntajeSet.Where(s => s.JuegoId == juegoId).OrderByDescending(s => s.Puntos).Take(10).ToHashSet();
			return entitySet;
		}

		public Puntaje Get(int Id)
		{
			var PuntajeEntity = this._context.PuntajeSet.Where(a => a.Id == Id).FirstOrDefault();
			return PuntajeEntity;
		}

		public void Create(Puntaje puntaje)
		{
			this._context.PuntajeSet.Add(puntaje);
		}

	}
}

