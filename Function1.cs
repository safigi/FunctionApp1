using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function(nameof(Function1))]
        [OpenApiOperation(operationId: nameof(Function1), tags: new[] { "convert" }, Summary = "Convert file from Url", Description = "Convert file from Url", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.OK)]
        [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Cannot convert", Description = "Cannot convert")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

           

            return new OkResult();
        }
    }
}
