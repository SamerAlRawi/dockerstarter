using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzFunction
{
    public static class TimerFunctions
    {
        [FunctionName("Timer300SecFunc")]
        public static void Timer30SecFunc([TimerTrigger("*/300 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

    }
}
