using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class JugandoDTO
    {
        public int Id { get; set; }

        public UsuarioDTO Usuario { get; set; }
        public JuegoDTO Juego { get; set; }
    }
}
