using AlkemyAPI.Models;
using System.Collections.Generic;

namespace AlkemyAPI.Data
{
    //FAKE DATA
    public class Mock : IRepo
    {
        public Personaje GetPersonajeById(int id)
        {
            return new Personaje
            {
                ID = 0,
                NOMBRE = "Nico",
                EDAD = 11,
                PESO = 55,
                HISTORIA = "HOLA",
                IMAGEN = null
            };
        }

        public IEnumerable<Personaje> GetAllPersonajes()
        {
            var personajes = new List<Personaje>
            {
                new Personaje
                {
                    ID = 0,
                    NOMBRE = "Nico",
                    EDAD = 11,
                    PESO = 55,
                    HISTORIA = "HOLA",
                    IMAGEN = null 
                },
                new Personaje
                {
                    ID = 1,
                    NOMBRE = "juan",
                    EDAD = 22,
                    PESO = 32,
                    HISTORIA = "chau",
                    IMAGEN = null
                },
                new Personaje
                {
                    ID = 2,
                    NOMBRE = "fede",
                    EDAD = 33,
                    PESO = 12,
                    HISTORIA = "pepe",
                    IMAGEN = null
                }
            };
            return personajes;
      
        }

        public IEnumerable<Pelicula> GetAllPeliculas()
        {
            throw new System.NotImplementedException();
        }

        public Pelicula GetPeliculaById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Genero> GetAllGeneroes()
        {
            throw new System.NotImplementedException();
        }

        public Genero GetGeneroById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void CreatePersonaje(Personaje perso)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePersonaje(Personaje perso)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePelicula(Pelicula peli)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePelicula(Pelicula peli)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePersonaje(Personaje perso)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePelicula(Pelicula peli)
        {
            throw new System.NotImplementedException();
        }

        public Personaje GetPersonajeByNombre(string nombre)
        {
            throw new System.NotImplementedException();
        }

        public Personaje GetPersonajeByEdad(int edad)
        {
            throw new System.NotImplementedException();
        }
    }
}
