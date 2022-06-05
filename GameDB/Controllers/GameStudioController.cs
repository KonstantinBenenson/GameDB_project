using AutoMapper;
using GameDB.Models;
using GameDB.Models.DTOs;
using GameDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameDB.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GameStudioController : Controller
    {
        private readonly IGameStudioRepository _repository;
        private readonly IMapper _mapper;
        public GameStudioController(IGameStudioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateGameStudioDTO studioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(studioDTO);

            var studio = _mapper.Map<GameStudio>(studioDTO);

            if (studio == null)
                return NotFound();

            await _repository.CreateAsync(studio);
            return Ok(studioDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            var studio = await _repository.GetByIdAsync(id);
            if (studio == null)
                return NotFound(studio);

            var studioDTO = _mapper.Map<GetGameStudioDTO>(studio);
            return Ok(studioDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studios = await _repository.GetAllAsync();
            var studiosDTO = _mapper.Map<IList<GetGameStudioDTO>>(studios);
            return Ok(studiosDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateGameStudioDTO gsDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id == 0 || gsDTO == null)
                return BadRequest();

            var gameStudio = await _repository.GetByIdAsync(id);
            _mapper.Map(gsDTO, gameStudio);
            await _repository.UpdateAsync(id, gameStudio);     
            
            return Ok(gsDTO);
        }
    }
}
