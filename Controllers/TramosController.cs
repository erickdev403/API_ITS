using IPTE.ITS.Aplicacion.Tramo.Commands.CrearTramoCommand;
using IPTE.ITS.Aplicacion.Tramo.Commands.ModificarTramoCommand;
using IPTE.ITS.Aplicacion.Tramo.Queries.ObtenerTramoQuery;
using IPTE.ITS.Aplicacion.Tramo.Queries.ObtenerTramosQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class TramosController : BaseController
    {

        #region GET

        [HttpGet]
        public async Task<IActionResult> GetCatalogo()
        {
            var queryResult = await Mediator.Send(new ObtenerTramosQuery { });
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTramo([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerTramoQuery { Id = id });
            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostDispositivo([FromBody] CrearTramoCommand crearDispositivoCommand)
        {
            var commandResult = await Mediator.Send(crearDispositivoCommand);
            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificarDispositivo([FromBody] ModificarTramoCommand modificarDispositivoCommand, [FromRoute] Guid id)
        {
            modificarDispositivoCommand.IdTramo = id;

            var commandResult = await Mediator.Send(modificarDispositivoCommand);
            return FromResult(commandResult);
        }
        #endregion
    }
}
