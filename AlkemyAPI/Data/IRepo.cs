using AlkemyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkemyAPI.Data
{
    public interface IRepo
    {
        //Guarda los datos en la BD
        bool SaveChanges();

        #region Personaje
        IEnumerable<Personaje> GetAllPersonajes();
        Personaje GetPersonajeById(int id);
        void CreatePersonaje(Personaje perso);
        void UpdatePersonaje(Personaje perso);
        void DeletePersonaje(Personaje perso);
        #endregion

        #region Pelicula
        IEnumerable<Pelicula> GetAllPeliculas();
        Pelicula GetPeliculaById(int id);
        void CreatePelicula(Pelicula peli);
        void UpdatePelicula(Pelicula peli);
        void DeletePelicula(Pelicula peli);
        #endregion

        #region Genero
        IEnumerable<Genero> GetAllGeneroes();
        Genero GetGeneroById(int id);
        #endregion
    }
}
