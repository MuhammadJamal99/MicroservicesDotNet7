using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Services.PlatformRepository;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : Controller
    {
        private readonly IPlatformRepository Repository;
        private readonly IMapper Mapper;
        private readonly ILogger<PlatformController> Logger;

        public PlatformController(IPlatformRepository repository, IMapper mapper, ILogger<PlatformController> logger)
        {
            Mapper = mapper;
            Repository = repository;
            Logger = logger;
        }

        [HttpGet("GetAllPlatforms")]
        public ActionResult<IEnumerable<PlatformDto>> GetAllPlatforms()
        {
            var Platforms = Repository.GetList();
            var result = Mapper.Map<IEnumerable<PlatformDto>>(Platforms);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetPlatform")]
        public ActionResult<PlatformDto> GetPlatform(int id)
        {
            var platform = Repository.GetPlatformById(id);
            if(platform is null)
                return NotFound();
            else 
            {
                var result = Mapper.Map<PlatformDto>(platform);
                return Ok(result);
            }
            
        }

        [HttpPost("CreatePlatform")]
        public ActionResult<PlatformDto> CreatePlatform(PlatformCreateDto NewItem)
        {
            var newPlatform = Mapper.Map<Platform>(NewItem);
            var result = Repository.CreatePlatform(newPlatform);
            var addedPlatform = Mapper.Map<PlatformDto>(newPlatform);

            return CreatedAtRoute(nameof(GetPlatform), new { id = newPlatform.Id }, addedPlatform);
        }
    }
}
