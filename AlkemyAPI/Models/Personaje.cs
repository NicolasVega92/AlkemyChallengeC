namespace AlkemyAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Personaje")]
    public partial class Personaje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personaje()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string NOMBRE { get; set; }

        public int EDAD { get; set; }

        public int? PESO { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HISTORIA { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMAGEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
