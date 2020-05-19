using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DataTransferObjects;
using Persistencia.Database;

namespace BusinessLogic
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<JuegoDTO, Juego>();
            CreateMap<Juego, JuegoDTO>();

            CreateMap<JugandoDTO, Jugando>();
            CreateMap<Jugando, JugandoDTO>();

            CreateMap<PreguntaDTO, Pregunta>();
            CreateMap<Pregunta, PreguntaDTO>();

            CreateMap<RespuestaDTO, Respuesta>();
            CreateMap<Respuesta, RespuestaDTO>();

            CreateMap<PuntajeDTO, Puntaje>();
            CreateMap<Puntaje, PuntajeDTO>();
        }
    }
}
