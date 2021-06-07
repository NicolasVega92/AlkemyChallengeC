using AlkemyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlkemyAPI.Data
{
    public class SqlDisneyRepo : IRepo
    {
        private readonly DisneyContext _context;

        public SqlDisneyRepo(DisneyContext context)
        {
            _context = context;
        }

        public void CreatePelicula(Pelicula peli)
        {
            if(peli == null)
            {
                throw new ArgumentNullException(nameof(peli));
            }
            _context.Peliculas.Add(peli);
        }

        public void CreatePersonaje(Personaje perso)
        {
            if(perso == null)
            {
                throw new ArgumentNullException(nameof(perso));
            }
            _context.Personajes.Add(perso);
        }

        public void DeletePelicula(Pelicula peli)
        {
            if (peli == null)
            {
                throw new ArgumentNullException(nameof(peli));
            }
            _context.Peliculas.Remove(peli);
        }

        public void DeletePersonaje(Personaje perso)
        {
            if(perso == null)
            {
                throw new ArgumentNullException(nameof(perso));
            }
            _context.Personajes.Remove(perso);
        }

        public IEnumerable<Genero> GetAllGeneroes()
        {
            return _context.Generoes.ToList();
        }

        public IEnumerable<Pelicula> GetAllPeliculas()
        {
            return _context.Peliculas.ToList();
        }

        public IEnumerable<Personaje> GetAllPersonajes()
        {
            return _context.Personajes.ToList();
        }

        public Genero GetGeneroById(int id)
        {
            return _context.Generoes.FirstOrDefault(g => g.ID_GENERO == id);
        }

        public Pelicula GetPeliculaById(int id)
        {
            return _context.Peliculas.FirstOrDefault(p => p.ID_PELICULA == id);
        }

        public Personaje GetPersonajeByEdad(int edad)
        {
            return _context.Personajes.FirstOrDefault(p => p.EDAD == edad);
        }

        public Personaje GetPersonajeById(int id)
        {
            return _context.Personajes.FirstOrDefault(p => p.ID == id);
        }

        public Personaje GetPersonajeByNombre(string nombre)
        {
            return _context.Personajes.FirstOrDefault(p => p.NOMBRE == nombre);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePelicula(Pelicula peli)
        {
            //Nothing
        }

        public void UpdatePersonaje(Personaje perso)
        {
            //Nothing
        }
    }
}