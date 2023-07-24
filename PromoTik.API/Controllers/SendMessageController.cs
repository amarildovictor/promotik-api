using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> Post([FromBody] PublishChatMessage publishChatMessage)
        {
            try
            {
                List<string>? message = await PublishChatMessageService.Add(publishChatMessage);
                if (message != null)
                    return NotFound(message);

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
        [AllowAnonymous]
        public IActionResult Anonimo()
        {
            return Ok("Tem permissão!");
        }
    }
}