using IPTE.ITS.Aplicacion.Camara.Commands.DownDiagonalCameraCommand;
using IPTE.ITS.Aplicacion.Camara.Commands.PanCameraCommand;
using IPTE.ITS.Aplicacion.Camara.Commands.TiltCameraCommand;
using IPTE.ITS.Aplicacion.Camara.Commands.UpDiagonalCameraCommand;
using IPTE.ITS.Aplicacion.Camara.Commands.ZoomCameraCommand;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class CamaraController : BaseController
    {
        #region Post

        [HttpPost("{id}/Pan")]
        public async Task<IActionResult> PanCamera([FromRoute] Guid id, [FromBody] PanCameraCommand panCameraCommand)
        {
            panCameraCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(panCameraCommand);
            return FromResult(commandResult);
        }

        [HttpPost("{id}/Tilt")]
        public async Task<IActionResult> TiltCamera([FromRoute] Guid id, [FromBody] TiltCameraCommand tiltCameraCommand)
        {
            tiltCameraCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(tiltCameraCommand);
            return FromResult(commandResult);
        }

        [HttpPost("{id}/DiagonalArriba")]
        public async Task<IActionResult> ZoomCamera([FromRoute] Guid id, [FromBody] UpDiagonalCameraCommand upDiagonalCameraCommand)
        {
            upDiagonalCameraCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(upDiagonalCameraCommand);
            return FromResult(commandResult);
        }

        [HttpPost("{id}/DiagonalAbajo")]
        public async Task<IActionResult> ZoomCamera([FromRoute] Guid id, [FromBody] DownDiagonalCameraCommand downDiagonalCameraCommand)
        {
            downDiagonalCameraCommand.IdDispositivo = id;

            var commandResult = await Mediator.Send(downDiagonalCameraCommand);
            return FromResult(commandResult);
        }

        [HttpPost("{id}/Zoom")]
        public async Task<IActionResult> ZoomCamera([FromRoute] Guid id, [FromBody] ZoomCameraCommand zoomInCamera)
        {
            zoomInCamera.IdDispositivo = id;

            var commandResult = await Mediator.Send(zoomInCamera);
            return FromResult(commandResult);
        }

        #endregion
    }
}
