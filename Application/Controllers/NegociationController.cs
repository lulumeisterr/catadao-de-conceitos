using Application.Command.Interface.IHandler;
using Application.ViewModel.NegociacaoRequest;
using Application.ViewModel.response;
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
        /// <param name="commandRequest">Request a ser recebida</param>
        /// <returns>command request</returns>
        [HttpPost("/negocio")]
        public Task<NegociationCommandResponse> criarNegocio([FromBody] NegociationCommandRequest commandRequest) 
        {
            return _handler.Handler(commandRequest);
        }

        /// <summary>
        ///  Consultar todos negocios
        /// </summary>
        /// <param name="commandRequest">Request a ser recebida</param>
        /// <returns>command request</returns>
        [HttpGet("/negocio")]
        public Task<NegociationCommandResponse> consultarNegocios() 
        {
            return null;
        }
    }
}