using IPTE.ITS.Aplicacion.Operador.Commands.ActivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.CrearAdministradorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.DesactivarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Commands.ModificarPasswordOperadorCommand;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerAdministradoresQuery;
using IPTE.ITS.Aplicacion.Operador.Queries.ObtenerOperadorQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class AdministradorController : BaseController
    {
        #region GET
        [HttpGet("Catalogo")]
        //[Authorize(Roles = "Mantenimiento")]
        public async Task<IActionResult> GetCatalogoAdministrador()
        {
            var queryResult = await Mediator.Send(new ObtenerAdministradoresQuery { });

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> GetOperador([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerOperadorQuery { Idoperador = id });

            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> PostOperador([FromBody] CrearAdministradorCommand command)
        {
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> PutModificaOperador([FromBody] ModificarOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;
            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Password")]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> PutModificaPassword([FromBody] ModificarPasswordOperadorCommand command, [FromRoute] Guid id)
        {
            command.Idoperador = id;

            var commandResult = await Mediator.Send(command);

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Activar")]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> PutActivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ActivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }

        [HttpPut("{id}/Desactivar")]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> PutDesactivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new DesactivarOperadorCommand { Idoperador = id });

            return FromResult(commandResult);
        }
        #endregion
    }
}
