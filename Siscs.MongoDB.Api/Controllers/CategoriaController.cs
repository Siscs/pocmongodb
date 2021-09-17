using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Siscs.MongoDB.Api.Domain.Repositories;
using Siscs.MongoDB.Api.Dto;
using Siscs.MongoDB.Api.Mappers;

namespace Siscs.MongoDB.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriaController : MainController<CategoriaController>
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ILogger<CategoriaController> logger, 
                                   ICategoriaRepository categoriaRepository)
            : base(logger)
        {
            _logger = logger;
            _categoriaRepository = categoriaRepository;
            _logger.LogInformation("Category Controller initialized...");
        }

        [HttpGet()]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Get Category Id: {id}");

            var result = await _categoriaRepository.Get(id);

            if (result is null)
                return NotFound();

            return Ok(result.ToCategoriaDto());
        }

        [HttpGet]
        [Route("categorias")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Get all Categories");
            var result = await _categoriaRepository.GetAll();

            if (result is null)
                return NotFound();

            return Ok(result.ToListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDto dto)
        {
            _logger.LogInformation($"Post Category");
            var result = await _categoriaRepository.Create(dto.ToCreateCategoriaCommand());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoriaDto dto)
        {
            _logger.LogInformation($"Put Category");
            var result = await _categoriaRepository.Update(dto.ToCategoriaCommand());
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _logger.LogInformation($"Delete Category Id: {id}");
            if (id == Guid.Empty)
                return BadRequest();

            var result = await _categoriaRepository.Delete(id);
            return Ok(result);
        }
        
    }
}