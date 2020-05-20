using System.Collections.Generic;
using System.Linq;

using Persistencia.Database;


namespace BusinessLogic.DataModel.Repositories
{
    class JugandoRepository
    {
        private readonly ModelosDBContainer _context;

        public JugandoRepository(ModelosDBContainer context)
        {
            this._context = context;
        }

        public Jugando Get(int Id)
        {
            var JugandoEntity = this._context.JugandoSet.Where(a => a.Id == Id).FirstOrDefault();
            return JugandoEntity;
        }

        public HashSet<Jugando> GetAll()
        {
            var entitySet = this._context.JugandoSet.Select(s => s).ToHashSet();
            return entitySet;
        }


        public bool Any(int Id)
        {
            var exists = this._context.JugandoSet.Any(s => s.Id == Id);
            return exists;
        }

        public void Create(Jugando Juego)
        {
            this._context.JugandoSet.Add(Juego);
        }

        public void Delete(int Id)
        {
            var entity = this.Get(Id);
            this._context.JugandoSet.Remove(entity);
        }
    }
}