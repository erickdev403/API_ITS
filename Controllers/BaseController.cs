using CSharpFunctionalExtensions;
using IPTE.ITS.Dominio.ErroresDominio;
using MassTransit.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPTE.ITS.API.Controllers
{
    [ApiController]
    [Route("ITS/[controller]")]
    public class BaseController : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected new IActionResult Ok() 
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T resultado)
        {
            return base.Ok(Envelope.Ok(resultado));
        }

        protected IActionResult FromResult<T>(Result<T,Error> resultado) 
        {
            if(resultado.IsSuccess)
                return Ok(resultado.Value);

            return BadRequest(Envelope.Error(resultado.Error));
        }
    }
}
