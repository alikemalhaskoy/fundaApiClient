using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundaClient.Controllers
{
    public class ErrorController : ApiControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            // TODO
            // _logger.LogError(context.Error);
            return Problem();
        }
    }
}
