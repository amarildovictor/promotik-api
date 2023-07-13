using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoTik.Domain.Entities.Scheduled;
using PromoTik.Domain.Interfaces.Services.Scheduled;

namespace PromoTik.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineExecutionController : ControllerBase
    {
        private readonly ILineExecutionService LineExecutionService;

        public LineExecutionController(ILineExecutionService lineExecutionService)
        {
            this.LineExecutionService = lineExecutionService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LineExecution lineExecution)
        {
            try
            {
                if (LineExecutionService.Add(lineExecution) == null)
                    return NotFound("Não foi possível adicionar ou enviar a mensagem na fila de execução, verifique os dados.");

                return Ok("Messagem adicionada na fila de execução com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  $"Ocorreu um erro ao adicionar a mensagem na fila de execução: {lineExecution.PublishChatMessage.Title}. Erro: {ex.Message}. Descrição do erro completa {ex}");
            }
        }

        [HttpGet]
        [Route("anonimo")]
        public IActionResult Anonimo()
        {
            return Ok("Tem permissão!");
        }
    }
}