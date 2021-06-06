namespace AlkemyAPI.Dtos
{
    using AlkemyAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PersonajeReadDtos
    {
        public PersonajeReadDtos()
        {
            Peliculas = new HashSet<Pelicula>();
        }
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int EDAD { get; set; }
        public int? PESO { get; set; }
        public string HISTORIA { get; set; }
        public byte[] IMAGEN { get; set; }
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}

