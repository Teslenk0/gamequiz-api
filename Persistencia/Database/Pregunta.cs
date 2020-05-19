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
    
    public partial class Pregunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pregunta()
        {
            this.Respuestas = new HashSet<Respuesta>();
        }
    
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public long Tiempo { get; set; }
        public long Puntos { get; set; }
        public string Video { get; set; }
        public string Imagen { get; set; }
        public bool Quiz { get; set; }
        public int JuegoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuesta> Respuestas { get; set; }
        public virtual Juego Juego { get; set; }
    }
}