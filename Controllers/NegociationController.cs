using Domain.CommandHandler.Interface;
using Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NegociationController : ControllerBase
    {
        private readonly ILogger<NegociationController> _logger;
        private readonly IHandler<NegociationCommandResponse, NegociationCommandRequest> _handler;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="handler">Handler</param>
        public NegociationController(ILogger<NegociationController> logger , IHandler<NegociationCommandResponse, NegociationCommandRequest> handler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _handler = handler ?? throw new ArgumentNullException(nameof(handler)); ;
        }

        /// <summary>
        ///  Criar negociacao
        /// </summary>
        /// <param name="commandRequest"></param>
        /// <returns>objeto negociacao</returns>
        [HttpPost("/negociation")]
        public Task<NegociationCommandResponse> createNegociation([FromBody] NegociationCommandRequest commandRequest) 
        {
            return _handler.Handler(commandRequest);
        }
    }
}