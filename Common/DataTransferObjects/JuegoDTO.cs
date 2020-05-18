using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    class JuegoDTO
    {
        public JuegoDTO()
        {
            this.Puntajes = new HashSet<PuntajeDTO>();
            this.Preguntas = new HashSet<PreguntaDTO>();
            this.Jugando = new HashSet<JugandoDTO>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Jugados { get; set; }
        public bool Activo { get; set; }
        public bool Privado { get; set; }
        public string Caratula { get; set; }
        public string Musica { get; set; }
        public string Uuid { get; set; }
        public string Password { get; set; }
      

        public UsuarioDTO Usuario { get; set; }
        public virtual ICollection<PuntajeDTO> Puntajes { get; set; }
        public virtual ICollection<PreguntaDTO> Preguntas { get; set; }
        public virtual ICollection<JugandoDTO> Jugando { get; set; }
    }
}
