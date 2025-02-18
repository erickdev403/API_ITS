using IPTE.ITS.Aplicacion.FuncionMibs.Commands.CrearFuncionMibCommand;
using IPTE.ITS.Aplicacion.FuncionMibs.Commands.ModificarFuncionMibCommand;
using IPTE.ITS.Aplicacion.FuncionMibs.Queries.ObtenerFuncionesMibsQuery;
using IPTE.ITS.Aplicacion.FuncionMibs.Queries.ObtenerFuncionMibsQuery;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class FuncionMibsController : BaseController
    {
        #region GET
        [HttpGet]
        public async Task<IActionResult> GetFuncionesMibs()
        {
            var query = await Mediator.Send(new ObtenerFuncionesMibsQuery { });
            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionMibs([FromRoute] Guid id)
        {
            var query = await Mediator.Send(new ObtenerFuncionMibsQuery { Id = id });
            return Ok(query);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostFuncionMibs([FromBody] CrearFuncionMibCommand command)
        {
            var query = await Mediator.Send(command);
            return FromResult(query);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionMibs([FromRoute] Guid id, [FromBody] ModificarFuncionMibCommand command)
        {
            command.Id = id;
            var query = await Mediator.Send(command);
            return FromResult(query);
        }
        #endregion
    }
}
