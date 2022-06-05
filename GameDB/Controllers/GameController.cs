using AutoMapper;
using GameDB.Models;
using GameDB.Models.DTOs;
using GameDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreGameRepository _ggRepository;
        private readonly IMapper _mapper;
        public GameController(IGameRepository gameRepository, IMapper mapper, IGenreGameRepository ggRepository)
        {
            _gameRepository = gameRepository;
            _ggRepository = ggRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGameDTO gameDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (gameDTO == null)
                return BadRequest();

            var game = _mapper.Map<Game>(gameDTO);

            await _gameRepository.CreateAsync(game);
            await _ggRepository.AddRelationWithGenreAsync(gameDTO, game);
            return Ok();          
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CreateGameDTO gameDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id == 0 || gameDTO == null)
                return BadRequest();

            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                return NotFound(game);

            _mapper.Map(gameDTO, game);
            await _gameRepository.UpdateAsync(id, game);
            await _ggRepository.UpdateRelationWithGenreAsync(game, gameDTO);

            return Ok(game);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameRepository.GetAllAsync();
            if(games == null)
                return NotFound("No games are being stored");
            
            var gamesDTO = _mapper.Map<IList<GetGameDTO>>(games);
            if (gamesDTO == null)
                return NotFound();

            return Ok(gamesDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return BadRequest("The Game has not been found.");

            var game = await _gameRepository.GetByIdAsync(id);
            var gameDTO = _mapper.Map<GetGameDTO>(game);

            if (gameDTO == null)
                return NotFound();

            return Ok(gameDTO);
        }

        [HttpGet("{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            if (genre == null)
                return BadRequest("The Genre is not available.");

            var games = await _gameRepository.GetByGenreAsync(genre);
            var gamesDTO = _mapper.Map<IList<GetGameDTO>>(games);

            if (gamesDTO == null)
                return NotFound();

            return Ok(gamesDTO);
        }

        [HttpGet("{studio}")]
        public async Task<IActionResult> GetByStudio(string studio)
        {
            if (studio == null)
                return BadRequest("The Genre is not available.");

            var games = await _gameRepository.GetByStudioAsync(studio);
            var gamesDTO = _mapper.Map<IList<GetGameDTO>>(games);

            if (gamesDTO == null)
                return NotFound();

            return Ok(gamesDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
                return BadRequest("Game has not been found.");

            await _gameRepository.DeleteByIdAsync(id);
            return Ok("The Game has been deleted successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRange(int[] range)
        {
            await _gameRepository.DeleteRangeAsync(range);
            return Ok("Games have been deleted.");
        }
    }
}
