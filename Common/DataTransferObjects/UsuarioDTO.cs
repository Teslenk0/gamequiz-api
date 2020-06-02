using Newtonsoft.Json;
using System.Runtime.Serialization;
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

        [JsonIgnore]
        public string Password { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaNac { get; set; }

        
        public virtual ICollection<JuegoDTO> Juegos { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<PuntajeDTO> Puntajes { get; set; }
        public virtual JugandoDTO Jugando { get; set; }



        /**
         * SEE THE FOLLOWING POST
         * https://stackoverflow.com/questions/11564091/making-a-property-deserialize-but-not-serialize-with-json-net
         * **/
        [JsonProperty("Password")]
        private string PasswordAlternateSetter
        {
            // get is intentionally omitted here
            set { Password = value; }
        }
    }
}
