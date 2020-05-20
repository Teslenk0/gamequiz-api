using AutoMapper;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Persistencia.Database;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Controllers
{
    class JugandoController
    {
        private readonly IMapper _mapper;

        public JugandoController(IMapper mapper)
        {
            _mapper = mapper;
        }


        public JugandoDTO GetById(int Id)
        {
            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JugandoRepository repositorio = new JugandoRepository(context);
                var entity = repositorio.Get(Id);
                return this._mapper.Map<JugandoDTO>(entity);
            }
        }

        public HashSet<JugandoDTO> GetAll()
        {
            HashSet<JugandoDTO> Juegos = new HashSet<JugandoDTO>();

            using (ModelosDBContainer context = new ModelosDBContainer())
            {
                JugandoRepository repositorio = new JugandoRepository(context);
                var entities = repositorio.GetAll();

                foreach (var entity in entities)
                {
                    Juegos.Add(this._mapper.Map<JugandoDTO>(entity));
                }
            }
            return Juegos;
        }

        public void Create(JugandoDTO Juego)
        {
            try
            {
                using (ModelosDBContainer context = new ModelosDBContainer())
                {
                    JugandoRepository repositorio = new JugandoRepository(context);
                    repositorio.Create(this._mapper.Map<Jugando>(Juego));
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
                    JugandoRepository repositorio = new JugandoRepository(context);
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
