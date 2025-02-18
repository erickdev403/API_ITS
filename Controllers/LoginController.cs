using IPTE.ITS.Aplicacion.Login.Commands.LoginCommand;
using IPTE.ITS.Aplicacion.Login.Commands.ReactivarCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    public class LoginController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand login)
        {
            var commandResult = await Mediator.Send(login);
            return FromResult(commandResult);
        }

        [HttpPut("{id}/Reactivar")]
        [Authorize(Roles = "Mantenimiento,Administrador")]
        public async Task<IActionResult> Reactivar([FromRoute] Guid id)
        {
            var commandResult = await Mediator.Send(new ReactivarCommand { Id = id});
            return FromResult(commandResult);
        }
    }
}
