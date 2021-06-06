namespace AlkemyAPI.Dtos
{
    using AlkemyAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PersonajeCreateDtos
    {
        public PersonajeCreateDtos()
        {
            Peliculas = new HashSet<Pelicula>();
        }
        //public int ID { get; set; } -> Se crea directamente en la DB
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
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}


