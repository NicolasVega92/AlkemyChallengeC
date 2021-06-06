using AlkemyAPI.Models;
using AlkemyAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using AlkemyAPI.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace AlkemyAPI.Controllers
{
    [Route("api/pelicula")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _mapper;

        public PeliculaController(IRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //GET api/pelicula
        [HttpGet]
        public ActionResult<IEnumerable<Pelicula>> GetAllPeliculas()
        {
            var peliculasItems = _repo.GetAllPeliculas();
            return Ok(_mapper.Map<IEnumerable<PeliculaReadDtos>>(peliculasItems));
            //return Ok(peliculasItems);
        }
        //GET api/pelicula/{id}
        [HttpGet("{id}", Name = "GetPeliculaById")]
        public ActionResult<Pelicula> GetPeliculaById(int id)
        {
            var peliculaItem = _repo.GetPeliculaById(id);
            if (peliculaItem != null)
            {
                return Ok(_mapper.Map<IEnumerable<PeliculaReadDtos>>(peliculaItem));
            }
            return NotFound();
        }

        //POST api/pelicula
        [HttpPost]
        public ActionResult<PeliculaReadDtos> CreatePelicula(PeliculaCreateDtos peliculaCreateDto)
        {
            var peliculaModel = _mapper.Map<Pelicula>(peliculaCreateDto);
            _repo.CreatePelicula(peliculaModel);
            _repo.SaveChanges();

            var peliculaReadDto = _mapper.Map<PeliculaReadDtos>(peliculaModel);

            return CreatedAtRoute(nameof(GetPeliculaById),
                                    new { id = peliculaReadDto.ID_PELICULA }, peliculaReadDto);
        }

        //PUT api/pelicula/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePelicula(int id, PeliculaUpdateDtos peliculaUpdateDto)
        {
            var peliculaModelFromRepo = _repo.GetPeliculaById(id);
            if (peliculaModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(peliculaUpdateDto, peliculaModelFromRepo);
            _repo.UpdatePelicula(peliculaModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
        //NO ME FUNCIONA EL PATCH TENGO UN RETORNO NULL QUE NO PUEDO RESOLVER POR AHORA
        //PATCH api/pelicula/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPeliculaUpdate(int id, JsonPatchDocument<PeliculaUpdateDtos> patchPeli)
        {
            var peliculaModelFromRepo = _repo.GetPersonajeById(id);
            if (peliculaModelFromRepo == null)
            {
                return NotFound();
            }
            var peliculaToPatch = _mapper.Map<PeliculaUpdateDtos>(peliculaModelFromRepo); // -> ACA DEBE ESTAR EL ERROR
            patchPeli.ApplyTo(peliculaToPatch, ModelState);
            if (!TryValidateModel(peliculaToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(peliculaToPatch, peliculaModelFromRepo);
            _repo.UpdatePersonaje(peliculaModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        //DELETE api/pelicula/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePelicula(int id)
        {
            var peliculaModelFromRepo = _repo.GetPeliculaById(id);
            if (peliculaModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeletePelicula(peliculaModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}
