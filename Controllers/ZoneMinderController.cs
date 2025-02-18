using IPTE.ITS.Aplicacion.Mib.Queries.CatalogoMibsQuery;
using IPTE.ITS.Aplicacion.ZoneMinder.Command;
using IPTE.ITS.Aplicacion.ZoneMinder.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class ZoneMinderController : BaseController
    {
        #region Get
        [HttpPost]
        public async Task<IActionResult> PostToken([FromBody] ObtenerTokenQuery obtenerTokenQuery)
        {
            var queryResult = await Mediator.Send(obtenerTokenQuery);
            
            return FromResult(queryResult);
        }

        [HttpPost("Eliminar")]
        public async Task<IActionResult> DeleteCam()
        {
            var queryResult = await Mediator.Send(new EliminarCamaraZoneMinderCommand { });

            return FromResult(queryResult);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> AddCam()
        {
            var queryResult = await Mediator.Send(new CrearCamaraZoneMinderCommand { });

            return FromResult(queryResult);
        }
        #endregion
    }
}
