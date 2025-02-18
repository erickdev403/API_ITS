using IPTE.ITS.Aplicacion.Operador.Commands.ActivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.CrearOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.DesactivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarPasswordOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerOperadoresQuery;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerOperadorQuery;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerRolesOperadorQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    [Authorize]
    public class OperadorController : BaseController
    {
        #region GET
        [HttpGet("Catalogo")]
        public async Task<IActionResult> GetCatalogoOperador()
        {
            var queryResult = await Mediator.Send(new ObtenerOperadoresQuery { });

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperador([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerOperadorQuery { Idoperador = id });

            return Ok(queryResult);
        }

        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            var queryResult = await Mediator.Send(new ObtenerRolesOperadorQuery {});

            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostOperador([FromBody] CrearOperadorCommand command)
        {
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificaOperador([FromBody] ModificarOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Password")]
        public async Task<IActionResult> PutModificaPassword([FromBody] ModificarPasswordOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;

            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Activar")]
        public async Task<IActionResult> PutActivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ActivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Desactivar")]
        public async Task<IActionResult> PutDesactivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new DesactivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }
        #endregion
    }
}

