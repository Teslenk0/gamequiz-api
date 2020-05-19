using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.Database;
using Common.DataTransferObjects;


namespace BusinessLogic.DataModel.Repositories
{
    class UsuarioRepository
    {
        private readonly ModelosDBContainer _context;

        public UsuarioRepository(ModelosDBContainer context)
        {
            this._context = context;
        }

        public Usuario Get(int Id)
        {
            var UsuarioEntity = this._context.UsuarioSet.Where(a => a.Id == Id).FirstOrDefault();
            return UsuarioEntity;
        }


        public HashSet<Usuario> GetAll()
        {
            var entitySet = this._context.UsuarioSet.Select(s => s).ToHashSet();
            return entitySet;
        }


        public bool Any(int Id)
        {
            var exists = this._context.UsuarioSet.Any(s => s.Id == Id);
            return exists;
        }

        public bool Any(string Username)
        {
            var exists = this._context.UsuarioSet.Any(s => s.Username == Username);
            return exists;
        }

        public void Create(Usuario usuario)
        {
            this._context.UsuarioSet.Add(usuario);
        }

        public void Delete(int Id)
        {
            var entity = this.Get(Id);
            this._context.UsuarioSet.Remove(entity);
        }

        /*public Usuario Update(int Id, Usuario usuario)
        {
            var entity = this.Get(Id);

            if(usuario.Nombre != entity.Nombre)
            {
                entity.Nombre = usuario.Nombre;
            }

            if (usuario.Apellido != entity.Apellido)
            {
                entity.Apellido = usuario.Apellido;
            }

            if (usuario. != entity.Nombre)
            {
                entity.Nombre = usuario.Nombre;
            }

            if (usuario.Nombre != entity.Nombre)
            {
                entity.Nombre = usuario.Nombre;
            }

            if (usuario.Nombre != entity.Nombre)
            {
                entity.Nombre = usuario.Nombre;
            }

        }*/


    }
}
