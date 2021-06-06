namespace AlkemyAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pelicula")]
    public partial class Pelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelicula()
        {
            Generoes = new HashSet<Genero>();
            Personajes = new HashSet<Personaje>();
        }

        [Key]
        public int ID_PELICULA { get; set; }

        [Required]
        [StringLength(40)]
        public string TITULO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        public byte? CALIFICACION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genero> Generoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}
