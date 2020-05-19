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
    class UsuarioController
    {

        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
        }


        public UsuarioDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                UsuarioRepository repositorio = new UsuarioRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<UsuarioDTO>(entity);
            }
        }

        public HashSet<UsuarioDTO> GetAll()
        {
            HashSet<UsuarioDTO> usuarios = new HashSet<UsuarioDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                UsuarioRepository repositorio = new UsuarioRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    usuarios.Add(this._mapper.Map<UsuarioDTO>(entity));
                }
            }
            return usuarios;
        }

        public void Create(UsuarioDTO usuario)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    UsuarioRepository repositorio = new UsuarioRepository(context);
                    if (repositorio.Any(usuario.Username))
                    {
                        throw new Exception("El usuario ya existe.");
                    }
                    repositorio.Create(this._mapper.Map<Usuario>(usuario));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    UsuarioRepository repositorio = new UsuarioRepository(context);
                    repositorio.Delete(Id);
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
