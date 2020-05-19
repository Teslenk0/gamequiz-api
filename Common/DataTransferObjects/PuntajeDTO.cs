using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class PuntajeDTO
    {
        public int Id { get; set; }
        public long Puntos { get; set; }
    
        public virtual JuegoDTO Juego { get; set; }
        public virtual UsuarioDTO Usuario { get; set; }
    }
}
