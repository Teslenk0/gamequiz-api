using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class PreguntaDTO
    {
        public PreguntaDTO()
        {
            this.Respuestas = new HashSet<RespuestaDTO>();
        }

        public int Id { get; set; }
        public string Mensaje { get; set; }
        public long Tiempo { get; set; }
        public long Puntos { get; set; }
        public string Video { get; set; }
        public string Imagen { get; set; }
        public bool Quiz { get; set; }

        public int JuegoId { get; set; }

        public int FinVideo { get; set; }

        public int InicioVideo { get; set; }


        public virtual ICollection<RespuestaDTO> Respuestas { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public JuegoDTO Juego { get; set; }
    }
}
