using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class RespuestaDTO
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public bool Correcta { get; set; }
        public long VecesSeleccionada { get; set; }
      
        public PreguntaDTO Pregunta { get; set; }
    }
}
