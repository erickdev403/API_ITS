using IPTE.ITS.Aplicacion.ModelosDispositivo.Command.CrearModeloCommand;
using IPTE.ITS.Aplicacion.ModelosDispositivo.Command.ModificarModeloCommand;
using IPTE.ITS.Aplicacion.ModelosDispositivo.Queries.ObtenerModeloQuery;
using IPTE.ITS.Aplicacion.ModelosDispositivo.Queries.ObtenerModelosQuery;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class ModelosDispositivosController : BaseController
    {
        #region GET

        [HttpGet("Catalogo")]
        public async Task<IActionResult> GetCatalogoModelosDispositivos()
        {
            var queryResult = await Mediator.Send(new ObtenerModelosQuery { });
            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloDispositivos([FromRoute] decimal id)
        {
            var queryResult = await Mediator.Send(new ObtenerModeloQuery
            {
                Id = id
            });
            return Ok(queryResult);
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> PostModeloDispositivos([FromBody] CrearModeloCommand crearModelo)
        {
            var queryResult = await Mediator.Send(crearModelo);
            return FromResult(queryResult);
        }

        #endregion

        #region PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloDispositivos([FromRoute] decimal id, [FromBody] ModficarModeloCommand modficarModelo)
        {
            modficarModelo.Id = id;
            var queryResult = await Mediator.Send(modficarModelo);
            return Ok(queryResult);
        }

        #endregion
    }
}
