//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persistencia.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            this.Juegos = new HashSet<Juego>();
            this.Puntajes = new HashSet<Puntaje>();
        }
    
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaNac { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Juego> Juegos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puntaje> Puntajes { get; set; }
        public virtual Jugando Jugando { get; set; }
    }
}