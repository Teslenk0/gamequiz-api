using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Database;
using Common.DataTransferObjects;
using Common.Utility;
using System.Diagnostics;

namespace BusinessLogic.DataModel.Repositories
{
    class JuegoRepository
    {
        private readonly ModelosDBContainer _context;

        public JuegoRepository(ModelosDBContainer context)
        {
            this._context = context;
        }

        public Juego Get(int Id)
        {
            var JuegoEntity = this._context.JuegoSet.Where(juego => juego.Id == Id).FirstOrDefault();
            return JuegoEntity;
        }

        public Juego GetByUuid(string Uuid)
        {
            var JuegoEntity = this._context.JuegoSet.Where(juego => juego.Uuid == Uuid).FirstOrDefault();
            return JuegoEntity;
        }


        public HashSet<Juego> GetAll()
        {
            var entitySet = this._context.JuegoSet.Select(s => s).ToHashSet();
            return entitySet;
        }


        public bool Any(int Id)
        {
            var exists = this._context.JuegoSet.Any(s => s.Id == Id);
            return exists;
        }

        public void Create(Juego juego)
        {
            juego.Uuid = "slug";
            juego.Jugados = 0;
            juego.Activo = true;
            juego.Caratula = "temp_image";
            DateTime myDateTime = DateTime.Now;
            
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            juego.Creado = sqlFormattedDate; 
            this._context.JuegoSet.Add(juego);
        }

        public void Delete(int Id)
        {
            var entity = this.Get(Id);
            this._context.JuegoSet.Remove(entity);
        }
    }
}