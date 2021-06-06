namespace AlkemyAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Genero")]
    public partial class Genero
    {
        [Key]
        public int ID_GENERO { get; set; }

        [Required]
        [StringLength(30)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMAGEN { get; set; }

        public int? ID_PELICULA { get; set; }

        public virtual Pelicula Pelicula { get; set; }
    }
}
