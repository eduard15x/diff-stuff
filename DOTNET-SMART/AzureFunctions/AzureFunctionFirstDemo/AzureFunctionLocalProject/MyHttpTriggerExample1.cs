using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionLocalProject
{
    public class MyHttpTriggerExample1
    {
        private readonly ILogger<MyHttpTriggerExample1> _logger;

        public MyHttpTriggerExample1(ILogger<MyHttpTriggerExample1> logger)
        {
            _logger = logger;
        }

        [Function("MyHttpTriggerExample1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
