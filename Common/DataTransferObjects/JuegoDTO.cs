using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class JuegoDTO
    {
        public JuegoDTO()
        {
            this.Puntajes = new HashSet<PuntajeDTO>();
            this.Preguntas = new HashSet<PreguntaDTO>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Jugados { get; set; }
        public bool Activo { get; set; }
        public bool Privado { get; set; }
        public string Caratula { get; set; }
        public int Musica { get; set; }
        public string Uuid { get; set; }
        public string Password { get; set; }

        public int UsuarioId { get; set; }

        public string Creado { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public UsuarioDTO Usuario { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<PuntajeDTO> Puntajes { get; set; }

        public virtual ICollection<PreguntaDTO> Preguntas { get; set; }
    }
}
