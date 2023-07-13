using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PromoTik.Domain.Entities;
using PromoTik.Domain.Interfaces.Services;

namespace PromoTik.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SendMessageController : ControllerBase
    {
        private readonly IPublishChatMessageService PublishChatMessageService;

        public SendMessageController(IPublishChatMessageService publishChatMessageService)
        {
            this.PublishChatMessageService = publishChatMessageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PublishChatMessage publishChatMessage)
        {
            try
            {
                if (!await PublishChatMessageService.Add(publishChatMessage))
                    return NotFound("Não foi possível adicionar ou enviar a mensagem a um dos apps informados, verifique os dados.");

                return Ok("Messagem enviada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    $"Ocorreu um erro ao enviar a mensagem: {publishChatMessage.Title}. Erro: {ex.Message}. Descrição do erro completa {ex}");
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