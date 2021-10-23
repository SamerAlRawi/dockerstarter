using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AzFunction
{

    public static class HttpTriggerFunctions
    {

        [FunctionName("Enqueue")]
        public static async Task<IActionResult> Enqueue(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Enqueue Triggered.");

            var rabbitHost = Environment.GetEnvironmentVariable("rabbitHost");
            var rabbitUser = Environment.GetEnvironmentVariable("rabbitUser");
            var rabbitPass = Environment.GetEnvironmentVariable("rabbitPass");

            var factory = new ConnectionFactory()
            {
                HostName = rabbitHost,
                UserName = rabbitUser, //set in ../Rabbit/definitions.json
                Password = rabbitPass  //set in ../Rabbit/definitions.json
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.QueueDeclare(queue: "quorum-queue",
                //                     durable: true,
                //                     exclusive: false,
                //                     autoDelete: false,
                //                     arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "quorum-queue",
                                     basicProperties: null,
                                     body: body);
                log.LogInformation(" [x] Sent {0}", message);
            }


            return new OkResult();
        }

        [FunctionName("HttpTriggerCSharp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,

            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            string name = req.Query["name"];

            string requestBody = string.Empty;
            using (var streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
