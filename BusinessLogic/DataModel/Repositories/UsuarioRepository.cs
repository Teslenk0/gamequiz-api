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

        public Usuario Get(string username)
        {
            var UsuarioEntity = this._context.UsuarioSet.Where(a => a.Username == username).FirstOrDefault();
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
            string hash = BCrypt.Net.BCrypt.HashPassword(usuario.Password, workFactor: 10);
            usuario.Password = hash;
            this._context.UsuarioSet.Add(usuario);
        }

        public bool VerifyPassword(string password_sent, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password_sent, hash);
        }

        public void Delete(int Id)
        {
            var entity = this.Get(Id);
            this._context.UsuarioSet.Remove(entity);
        }
    }
}
