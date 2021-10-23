using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzFunction
{
    public static class QueueTriggerFunctions
    {
        [FunctionName("RabbitMQTest")]
        public static void RabbitMQTest([RabbitMQTrigger(queueName:"quorum-queue",
            ConnectionStringSetting = "RabbitMQConnection")] string message,
            [RabbitMQ(ConnectionStringSetting = "RabbitMQConnection",
                        QueueName = "classic-queue")] out string outputMessage,
            ILogger log)
        {
            log.LogInformation(message);

            outputMessage = message;
        }
    }
}
