using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopAPI.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        private readonly Dictionary<string, string> ErrorMessages = new Dictionary<string, string>
        {

        };

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/Error")]
        public ActionResult HandleErrors()
        {
            var request = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            _logger.LogError(exception, "An exception occurred during request: " + request);

            var exceptionType = exception.GetType().Name;
            ErrorMessages.TryGetValue(exceptionType, out string errorMessage);
            return Problem(errorMessage ?? "An error occurred on the server. Please contact support.");
        }
    }
}
