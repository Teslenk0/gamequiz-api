using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Repositories
{
	public class RespuestaRepository
	{
		private readonly ModelosDBContainer _context;

		public RespuestaRepository(ModelosDBContainer context)
		{
			this._context = context;
		}

		public Respuesta Get(int Id)
		{
			var RespuestaEntity = this._context.RespuestaSet.Where(a => a.Id == Id).FirstOrDefault();
			return RespuestaEntity;
		}

		public HashSet<Respuesta> GetAll()
		{
			var entitySet = this._context.RespuestaSet.Select(s => s).ToHashSet();
			return entitySet;
		}

		public bool Any(int Id)
		{
			var exists = this._context.RespuestaSet.Any(s => s.Id == Id);
			return exists;
		}

		public void Create(Respuesta Respuesta)
		{
			this._context.RespuestaSet.Add(Respuesta);
		}
	}
}