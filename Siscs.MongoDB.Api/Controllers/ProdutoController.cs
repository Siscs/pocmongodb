using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Siscs.MongoDB.Api.Domain.Repositories;
using Siscs.MongoDB.Api.Dto;
using Siscs.MongoDB.Api.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutoController : MainController<ProdutoController>
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(ILogger<ProdutoController> logger,
                                 IProdutoRepository produtoRepository)
            : base(logger)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _logger.LogInformation("Product Controller initialized...");
        }

        [HttpGet()]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation($"Get Product Id: {id}");

            var result = await _produtoRepository.Get(id);

            if (result is null)
                return NotFound();

            return Ok(result.ToProdutoDto());
        }

        [HttpGet]
        [Route("produtos")]
        //[ProducesResponseType(typeof(IEnumerable<IActionResult>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAll()
        public async Task<IActionResult> GetAll()
        {

            _logger.LogInformation($"Get all Products");

            var result = await _produtoRepository.GetAll();

            if (result is null)
                return NotFound();

            return Ok(result.ToListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoDto dto)
        {
            _logger.LogInformation($"Post Product");
            var result = await _produtoRepository.Create(dto.ToCreateProdutoCommand());
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoDto dto)
        {
            _logger.LogInformation($"Put Product");
            var result = await _produtoRepository.Update(dto.ToProdutoCommand());
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            _logger.LogInformation($"Delete Product Id: {id}");
            if (id == Guid.Empty)
                return BadRequest();

            var result = await _produtoRepository.Delete(id);
            return Ok(result);
        }
    }
}
