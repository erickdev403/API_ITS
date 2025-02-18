using IPTE.ITS.Aplicacion.Dispositivo.Commands.ActivarDipositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Commands.CrearDispositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Commands.CrearPuertoDispositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Commands.DesactivarDispositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Commands.EliminarPuertoDispositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Commands.ModificarDispositivoCommand;
using IPTE.ITS.Aplicacion.Dispositivo.Queries.ConsultarCatalogoDispositivosQuery;
using IPTE.ITS.Aplicacion.Dispositivo.Queries.ConsultarCatDispositivosQuery;
using IPTE.ITS.Aplicacion.Dispositivo.Queries.ConsultarDispositivoQuery;
using IPTE.ITS.Aplicacion.Dispositivo.Queries.ConsultarPuertosQuery;
using IPTE.ITS.Aplicacion.Dispositivo.Queries.ObtenerPorOperadorDispositivosQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class DispositivoController : BaseController
    {
        #region GET
        [Authorize(Roles="Administrador,Mantenimiento")]
        [HttpGet("Catalogo")]
        public async Task<IActionResult> GetCatalogoDispositivos()
        {
            var queryResult = await Mediator.Send(new ConsultarCatalogoDispositivosQuery { });
            return Ok(queryResult);
        }

        [HttpGet("{id}/Operador")]
        public async Task<IActionResult> GetCatalogoPorOperadroDispositivos([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ObtenerPorOperadorDispositivosQuery 
            {
                Id = id
            });
            return Ok(queryResult);
        }

        [HttpGet("TiposDispositivos")]
        public async Task<IActionResult> GetCatDispositivos()
        {
            var queryResult = await Mediator.Send(new ConsultarCatDispositivosQuery { });
            return Ok(queryResult);
        }

        [HttpGet("Puertos")]
        public async Task<IActionResult> GetPuertosDispositivos()
        {
            var queryResult = await Mediator.Send(new ConsultarPuertosQuery { });
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDispositivo([FromRoute] Guid id)
        {
            var queryResult = await Mediator.Send(new ConsultarDispositivoQuery { Id = id});
            return Ok(queryResult);
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IActionResult> PostDispositivo([FromBody] CrearDispositivoCommand crearDispositivoCommand)
        {
            var commandResult = await Mediator.Send(crearDispositivoCommand);
            return FromResult(commandResult);
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModificarDispositivo([FromBody] ModificarDispositivoCommand modificarDispositivoCommand, [FromRoute] Guid id)
        {
            modificarDispositivoCommand.Id = id;

            var commandResult = await Mediator.Send(modificarDispositivoCommand);
            return FromResult(commandResult);
        }

        [HttpPut("{id}/AgregaPuerto")]
        public async Task<IActionResult> PutAgregaPuertoDispositivo([FromBody] CrearPuertoDispositivoCommand modificarDispositivoCommand, [FromRoute] Guid id)
        {
            modificarDispositivoCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(modificarDispositivoCommand);
            return FromResult(commandResult);
        }

        [HttpPut("{id}/EliminaPuerto")]
        public async Task<IActionResult> PutEliminaPuertoDispositivo([FromBody] EliminarPuertoDispositivoCommand modificarDispositivoCommand, [FromRoute] Guid id)
        {
            modificarDispositivoCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(modificarDispositivoCommand);
            return FromResult(commandResult);
        }

        [HttpPut("{id}/Activar")]
        public async Task<IActionResult> PutActivarDispositivo([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ActivarDispositivoCommand { Id = id });
            return FromResult(commandResult);
        }

        [HttpPut("{id}/Desactivar")]
        public async Task<IActionResult> PutDesactivarDispositivo([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new DesactivarDispositivoCommand { Id = id });
            return FromResult(commandResult);
        }
        #endregion
    }
}
