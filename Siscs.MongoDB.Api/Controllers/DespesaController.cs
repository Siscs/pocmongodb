using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Siscs.MongoDB.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class DespesaController : MainController<DespesaController>
    {
        private readonly ILogger<DespesaController> _logger;

        public DespesaController(ILogger<DespesaController> logger)
            : base(logger)
        {
            _logger = logger;
            _logger.LogInformation("Despesa Controller initialized...");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Task.FromResult(Ok());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if(id == Guid.Empty)
                return await Task.FromResult(BadRequest());
            var despesa = GerarDespesa(id);

            return await Task.FromResult(Ok(despesa));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DespesaDto dto)
        {
            if(dto.Id == Guid.Empty)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok(dto));
        }

        [HttpPost]
        [Route("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] DespesaDto dto)
        {
            if (dto.Id == Guid.Empty)
                return await Task.FromResult(BadRequest());
            return await Task.FromResult(Ok(dto));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return await Task.FromResult(BadRequest());

            return await Task.FromResult(Ok());
        }

        private DespesaDto GerarDespesa(Guid id)
        {
            // Guid id = Guid.NewGuid();
            Random rand = new Random();

            return new DespesaDto
            {
                Id = id,
                Titulo = id.ToString().Substring(0, 8),
                Documento = id.ToString().Substring(0, 8) + "/1",
                Parcela = rand.Next(1,24),
                Valor = rand.NextDouble(),
                Vencimento = DateTime.Now,
                DataPagamento = null,
                ValorPago = 0,
                Descricao = "Despesa "+ id.ToString().Substring(0, 5)
            };
        }
    }
}
