using AlkemyAPI.Data;
using AlkemyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlkemyAPI.Controllers
{
    [Route("api/genero")]
    [ApiController]
    public class GeneroControllers : ControllerBase
    {
        private readonly IRepo _repo;

        public GeneroControllers(IRepo repo)
        {
            _repo = repo;
        }

        //GET api/genero
        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetAllGeneros()
        {
            var generoesItems = _repo.GetAllGeneroes();
            return Ok(generoesItems);
        }
        //GET api/genero/{id}
        [HttpGet("{id}")]
        public ActionResult<Genero> GetGeneroById(int id)
        {
            var generoItem = _repo.GetGeneroById(id);
            if(generoItem != null)
            {
                return Ok(generoItem);
            }
            return NotFound();
        }
    }
}

