using AlkemyAPI.Dtos;
using AlkemyAPI.Models;
using AutoMapper;

namespace AlkemyAPI.Profiles
{
    public class PeliculaProfile : Profile
    {
        public PeliculaProfile()
        {
            //Source -> Target
            CreateMap<Pelicula, PeliculaReadDtos>();
            CreateMap<PeliculaCreateDtos, Pelicula>();
            CreateMap<PeliculaUpdateDtos, Pelicula>();
            CreateMap<Pelicula, PeliculaUpdateDtos>();
        }
    }
}
