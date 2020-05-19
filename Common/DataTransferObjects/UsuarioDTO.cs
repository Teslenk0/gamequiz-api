using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
            this.Juegos = new HashSet<JuegoDTO>();
            this.Puntajes = new HashSet<PuntajeDTO>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaNac { get; set; }

        public virtual ICollection<JuegoDTO> Juegos { get; set; }
        public virtual ICollection<PuntajeDTO> Puntajes { get; set; }
        public virtual JugandoDTO Jugando { get; set; }
    }
}
