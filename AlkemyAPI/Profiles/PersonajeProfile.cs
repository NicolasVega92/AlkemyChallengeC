using AlkemyAPI.Dtos;
using AlkemyAPI.Models;
using AutoMapper;

namespace AlkemyAPI.Profiles
{
    public class PersonajeProfile : Profile
    {
        public PersonajeProfile()
        {
            //Source -> Target
            CreateMap<Personaje, PersonajeReadDtos>();
            CreateMap<PersonajeCreateDtos, Personaje>();
            CreateMap<PersonajeUpdateDtos, Personaje>();
            CreateMap<Personaje, PersonajeUpdateDtos>();
        }
    }
}
