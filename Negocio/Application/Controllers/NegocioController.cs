using Microsoft.AspNetCore.Mvc;
namespace Application.Controller.Negocio
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class NegocioController : ControllerBase
    {
        private readonly ILogger<NegocioController> _logger;
        private readonly IHandler<NegocioCommandResponse, NegociationCommandRequest> _handler;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="handler">Handler</param>
        public NegocioController(ILogger<NegocioController> logger , IHandler<NegocioCommandResponse, NegociationCommandRequest> handler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _handler = handler ?? throw new ArgumentNullException(nameof(handler)); ;
        }

        /// <summary>
        ///  Criar negociacao
        /// </summary>
        /// <param name="commandRequest">Request a ser recebida</param>
        /// <returns>command request</returns>
        [HttpPost("/negocio")]
        public Task<NegocioCommandResponse> criarNegocio([FromBody] NegociationCommandRequest commandRequest) 
        {
            return _handler.Handler(commandRequest);
        }
    }
}