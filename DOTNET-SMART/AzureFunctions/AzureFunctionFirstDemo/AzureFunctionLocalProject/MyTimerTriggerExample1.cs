using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionLocalProject
{
    public class MyTimerTriggerExample1
    {
        private readonly ILogger _logger;

        public MyTimerTriggerExample1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MyTimerTriggerExample1>();
        }

        [Function("MyTimerTriggerExample1")]
        public void Run([TimerTrigger("0 */1 * * * *", RunOnStartup = true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
