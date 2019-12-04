// The 'From' and 'To' fields are automatically populated with the values specified by the binding settings.
//
// You can also optionally configure the default From/To addresses globally via host.config, e.g.:
//
// {
//   "sendGrid": {
//      "to": "user@host.com",
//      "from": "Azure Functions <samples@functions.com>"
//   }
// }
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Logging;

namespace csye6225_azure_functionApp
{
    public static class email_send
    {
        [FunctionName("email_send")]
        [return: SendGrid(ApiKey = "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", To = "{CustomerEmail}", From = "SenderEmail@org.com")]
        public static SendGridMessage Run([QueueTrigger("sampleMessages", Connection = "storageaccountmyres8d02")]Order order, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed order: {order.OrderId}");

            SendGridMessage message = new SendGridMessage()
            {
                Subject = $"Thanks for your order (#{order.OrderId})!"
            };

            message.AddContent("text/plain", $"{order.CustomerName}, your order ({order.OrderId}) is being processed!");
            return message;
        }
    }
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
