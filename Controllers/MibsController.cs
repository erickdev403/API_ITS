using IPTE.ITS.Aplicacion.Mib.Commands.ActivarMibCommand;
using IPTE.ITS.Aplicacion.Mib.Commands.CrearMibCommand;
using IPTE.ITS.Aplicacion.Mib.Commands.DesactivarMibCommand;
using IPTE.ITS.Aplicacion.Mib.Commands.ModificarMibCommand;
using IPTE.ITS.Aplicacion.Mib.Commands.ModificarNivelAccesoMibCommand;
using IPTE.ITS.Aplicacion.Mib.Queries.CatalogoMibsQuery;
using IPTE.ITS.Aplicacion.Mib.Queries.ObtenerMibQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    [Authorize]
    public class MibsController : BaseController
    {
        #region GET
        [HttpGet("Catalogo")]
        public async Task<IActionResult> GetCatalogoMibs()
        {
            var queryResult = await Mediator.Send(new CatalogoMibsQuery { });

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMib([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerMibQuery { Id = id});

            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostMib([FromBody] CrearMibCommand command)
        {
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificaMib([FromBody] ModificarMibCommand command, [FromRoute] Guid id)
        {
            command.Id = id;
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/ModificarNivelAcceso")]
        public async Task<IActionResult> PutModificaNAccesoMib([FromBody] ModificarNivelAccesoMibCommand command, [FromRoute] Guid id)
        {
            command.Id = id;

            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/ActivarMib")]
        public async Task<IActionResult> PutActivarMib([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ActivarMibCommand { Id = id });

            return FromResult(commandResult);
        }

        [HttpPut("{id}/DesactivarMib")]
        public async Task<IActionResult> PutDesactivarMib([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new DesactivarMibCommand { Id = id });

            return FromResult(commandResult);
        }
        #endregion
    }
}
