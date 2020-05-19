using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Database;
using Common.DataTransferObjects;


namespace BusinessLogic.DataModel.Repositories
{
	public class PreguntaRepository
	{
		private readonly ModelosDBContainer _context;

		public PreguntaRepository(ModelosDBContainer context)
		{
			this._context = context;
		}

		public Pregunta Get(int Id)
		{
			var PreguntaEntity = this._context.PreguntaSet.Where(a => a.Id == Id).FirstOrDefault();
			return PreguntaEntity;
		}

		public HashSet<Pregunta> GetAll()
		{
			var entitySet = this._context.PreguntaSet.Select(s => s).ToHashSet();
			return entitySet;
		}

		public bool Any(int Id)
		{
			var exists = this._context.PreguntaSet.Any(s => s.Id == Id);
			return exists;
		}

		public void Create(Pregunta pregunta)
		{
			this._context.PreguntaSet.Add(pregunta);
		}
	}
}
