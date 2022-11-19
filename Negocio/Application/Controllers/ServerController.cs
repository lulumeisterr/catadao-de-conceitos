using Microsoft.AspNetCore.Mvc;

namespace Application.Controller.Negocio
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class ServerController : ControllerBase
    {
        private readonly IHandler<ServerCommandRequest, ServerCommandResponse> _commandHandler;
        private readonly IQueryHandler<ServerCommandResponse> _queryHandler;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="handler">Handler</param>
        public ServerController(ILogger<ServerController> logger , IHandler<ServerCommandRequest, ServerCommandResponse> handler, IQueryHandler<ServerCommandResponse> queryHandler)
        {
            _commandHandler = handler ?? throw new ArgumentNullException(nameof(handler));
            _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
        }

        /// <summary>
        /// Criar um server
        /// </summary>
        /// <param name="commandRequest">dados a serem cadastrados</param>
        /// <returns>Negocio inserido</returns>
        [HttpPost("/v1/servers")]
        public async Task<ActionResult<ServerCommandResponse>> createServer([FromBody] ServerCommandRequest commandRequest) 
        {
            ServerCommandResponse response = await _commandHandler.Handler(commandRequest);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        /// Consultar todos negocios
        /// </summary>
        /// <returns>Lista de negocios</returns>
        [HttpGet("/v1/servers")]
        public async Task<ActionResult<List<ServerCommandResponse>>> fetchAllServers()
        {
            List<ServerCommandResponse> response = await _queryHandler.ConsultarTodosServersQueryHandler();
            if (!response.Any())
                return NotFound();
            return Ok(response);
        }
    }
}