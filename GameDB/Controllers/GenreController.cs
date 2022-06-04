using AutoMapper;
using GameDB.Models.DTOs;
using GameDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreController(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName("Genres")]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _repository.GetAllAsync();
            if(genres == null)
                return NotFound("Genres have not been found.");
            var genresDTO = _mapper.Map<IEnumerable<GetGenreDTO>>(genres);
            return Ok(genresDTO);
        }

        [HttpGet(("{id}"))]
        [ActionName("GenreById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return BadRequest("Id is not related to any existing genre.");

            var genre = await _repository.GetByIdAsync(id);

            if (genre == null)
                return NotFound("Game has not been found.");

            var genreDTO = _mapper.Map<GetGenreDTO>(genre);
            return Ok(genreDTO);
        }

        // POST api/<GenreController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateGenreDTO genreDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(genreDTO);

            var genre = _mapper.Map<Genre>(genreDTO);
            
            if(genre == null)
                return BadRequest();

            await _repository.CreateAsync(genre);
            return Ok(genre);
        }

        //// PUT api/<GenreController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<GenreController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
