using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.DataTransferObjects
{
    public class PuntajeDTO
    {
        public int Id { get; set; }
        public long Puntos { get; set; }
        public string Username { get; set; }
        public int JuegoId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual JuegoDTO Juego { get; set; }

    }
}

