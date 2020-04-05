using Microsoft.AspNetCore.Mvc;

namespace FundaClient
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <inheritdoc />
        protected ApiControllerBase()
        {
        }
    }
}
