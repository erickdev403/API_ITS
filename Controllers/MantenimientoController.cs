using IPTE.ITS.Aplicacion.Operador.Commands.ActivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.CrearMantenimientoCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.DesactivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarPasswordOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerMantenimientoQuery;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerOperadorQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class MantenimientoController : BaseController
    {
        #region GET
        [HttpGet("Catalogo")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> GetCatalogoMantenimiento()
        {
            var queryResult = await Mediator.Send(new ObtenerMantenimientoQuery { });

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> GetOperador([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerOperadorQuery { Idoperador = id });

            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostOperador([FromBody] CrearMantenimientoCommand command)
        {
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> PutModificaOperador([FromBody] ModificarOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Password")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> PutModificaPassword([FromBody] ModificarPasswordOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;

            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Activar")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> PutActivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ActivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Desactivar")]
        [Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> PutDesactivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new DesactivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }
        #endregion
    }
}
