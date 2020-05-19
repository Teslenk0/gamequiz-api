using AutoMapper;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Persistencia.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    class JuegoController
    {
        private readonly IMapper _mapper;

        public JuegoController(IMapper mapper)
        {
            _mapper = mapper;
        }


        public JuegoDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JuegoRepository repositorio = new JuegoRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<JuegoDTO>(entity);
            }
        }

        public HashSet<JuegoDTO> GetAll()
        {
            HashSet<JuegoDTO> Juegos = new HashSet<JuegoDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JuegoRepository repositorio = new JuegoRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    Juegos.Add(this._mapper.Map<JuegoDTO>(entity));
                }
            }
            return Juegos;
        }

        public void Create(JuegoDTO Juego)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    JuegoRepository repositorio = new JuegoRepository(context);
                    repositorio.Create(this._mapper.Map<Juego>(Juego));
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
                    JuegoRepository repositorio = new JuegoRepository(context);
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
