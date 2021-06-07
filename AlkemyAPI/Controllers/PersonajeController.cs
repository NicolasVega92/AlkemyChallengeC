using AlkemyAPI.Data;
using AlkemyAPI.Dtos;
using AlkemyAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AlkemyAPI.Controllers
{
    [Route("api/personaje")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        //public PersonajeController(IRepo repo)
        //{
        //    _repo = repo;
        //}
        public PersonajeController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //GET api/personaje
        [HttpGet]
        public ActionResult <IEnumerable<PersonajeReadDtos>> GetAllPersonajes()
        {
            var personajesItems = _repo.GetAllPersonajes();
            return Ok(_mapper.Map<IEnumerable<PersonajeReadDtos>>(personajesItems));
        }
        //GET api/personaje/{id}
        [HttpGet("{id}", Name="GetPersonajeById")]
        public ActionResult <PersonajeReadDtos> GetPersonajeById(int id)
        {
            var personajeItem = _repo.GetPersonajeById(id);
            if(personajeItem != null)
            {
                return Ok(_mapper.Map<PersonajeReadDtos>(personajeItem));
            }
            return NotFound();
        }
        //GET api/personaje/edad/{edad}
        [HttpGet("edad/{edad}")]
        public ActionResult <PersonajeReadDtos> GetPersonajeByEdad(int edad)
        {
            var personajeItem = _repo.GetPersonajeByEdad(edad);
            if (personajeItem != null)
            {
                return Ok(_mapper.Map<PersonajeReadDtos>(personajeItem));
            }
            return NotFound();
        }
        //GET api/personaje/nombre/{nombre}
        [HttpGet("nombre/{nombre}")]
        public ActionResult<PersonajeReadDtos> GetPersonajeByNombre(string nombre)
        {
            var personajeItem = _repo.GetPersonajeByNombre(nombre);
            if (personajeItem != null)
            {
                return Ok(_mapper.Map<PersonajeReadDtos>(personajeItem));
            }
            return NotFound();
        }

        //POST api/personaje
        [HttpPost]
        public ActionResult<PersonajeReadDtos> CreatePersonaje(PersonajeCreateDtos personajeCreateDto)
        {
            var personajeModel = _mapper.Map<Personaje>(personajeCreateDto);
            _repo.CreatePersonaje(personajeModel);
            _repo.SaveChanges();

            var personajeReadDto = _mapper.Map<PersonajeReadDtos>(personajeModel);

            return CreatedAtRoute(nameof(GetPersonajeById), 
                                    new { id = personajeReadDto.ID }, personajeReadDto);
        }

        //PUT api/personaje/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePersonaje(int id, PersonajeUpdateDtos personajeUpdateDto)
        {
            var personajeModelFromRepo = _repo.GetPersonajeById(id);
            if(personajeModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(personajeUpdateDto, personajeModelFromRepo);
            _repo.UpdatePersonaje(personajeModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        //NO ME FUNCIONA EL PATCH TENGO UN RETORNO NULL QUE NO PUEDO RESOLVER POR AHORA
        //PATCH api/personaje/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPersonajeUpdate(int id, JsonPatchDocument<PersonajeUpdateDtos> patchPersona)
        {
            var personajeModelFromRepo = _repo.GetPersonajeById(id);
            if (personajeModelFromRepo == null)
            {
                return NotFound();
            }
            var personajeToPatch = _mapper.Map<PersonajeUpdateDtos>(personajeModelFromRepo); // -> ACA DEBE ESTAR EL ERROR
            patchPersona.ApplyTo(personajeToPatch, ModelState); // -> LINEA QUE LANZA LA EXCEPCION 
            if(!TryValidateModel(personajeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(personajeToPatch, personajeModelFromRepo);
            _repo.UpdatePersonaje(personajeModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        //DELETE api/personaje/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePersonaje(int id)
        {
            var personajeModelFromRepo = _repo.GetPersonajeById(id);
            if (personajeModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeletePersonaje(personajeModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}
