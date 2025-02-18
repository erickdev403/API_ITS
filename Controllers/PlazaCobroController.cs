using IPTE.ITS.Aplicacion.PlazaCobro.Command.CrearPlazaCobroCommand;
using IPTE.ITS.Aplicacion.PlazaCobro.Command.ModificarPlazaCobroCommand;
using IPTE.ITS.Aplicacion.PlazaCobro.Queries.ObtenerPlazaQuery;
using IPTE.ITS.Aplicacion.PlazaCobro.Queries.ObtenerPlazasQuery;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class PlazaCobroController : BaseController
    {
        #region GET

        [HttpGet]
        public async Task<IActionResult> GetCatalogo()
        {
            var queryResult = await Mediator.Send(new ObtenerPlazasQuery { });
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTramo([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerPlazaQuery { Id = id });
            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostDispositivo([FromBody] CrearPlazaCobroCommand crearDispositivoCommand)
        {
            var commandResult = await Mediator.Send(crearDispositivoCommand);
            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificarDispositivo([FromBody] ModificarPlazaCobroCommand modificarDispositivoCommand, [FromRoute] Guid id)
        {
            modificarDispositivoCommand.Id = id;

            var commandResult = await Mediator.Send(modificarDispositivoCommand);
            return FromResult(commandResult);
        }
        #endregion
    }
}
