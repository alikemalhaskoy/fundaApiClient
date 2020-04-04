using Microsoft.AspNetCore.Mvc;

namespace FundaClient
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <inheritdoc />
        protected ApiControllerBase()
        {
        }
    }
}
