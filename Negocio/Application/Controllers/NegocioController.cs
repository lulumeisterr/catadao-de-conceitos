using Microsoft.AspNetCore.Mvc;
using Query.Application.Query.Interfaces;

namespace Application.Controller.Negocio
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class NegocioController : ControllerBase
    {
        private readonly ILogger<NegocioController> _logger;
        private readonly IHandler<NegociationCommandRequest,NegocioCommandResponse> _commandHandler;
        private readonly IQueryHandler<NegocioCommandResponse> _queryHandler;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="handler">Handler</param>
        public NegocioController(ILogger<NegocioController> logger , IHandler<NegociationCommandRequest, NegocioCommandResponse> handler, IQueryHandler<NegocioCommandResponse> queryHandler)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _commandHandler = handler ?? throw new ArgumentNullException(nameof(handler));
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
        }

    
        /// <summary>
        /// Criar um negocio
        /// </summary>
        /// <param name="version">versionamento da api</param>
        /// <param name="commandRequest">dados a serem cadastrados</param>
        /// <returns>Negocio inserido</returns>
        [HttpPost("/v1/negocios")]
        public async Task<ActionResult<NegocioCommandResponse>> criarNegocio([FromQuery] string version,[FromBody] NegociationCommandRequest commandRequest) 
        {
            NegocioCommandResponse response = await _commandHandler.Handler(commandRequest);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Consultar todos negocios
        /// </summary>
        /// <param name="version">Versionamento da api</param>
        /// <returns>Lista de negocios</returns>
        [HttpGet("/v1/negocios")]
        public async Task<ActionResult<List<NegocioCommandResponse>>> consultarTodosNegocios([FromQuery] string version)
        {
            List<NegocioCommandResponse> response = await _queryHandler.ConsultarTodosNegociosQueryHandler();
            if (!response.Any())
                return NotFound();
            return Ok(response);
        }
    }
}