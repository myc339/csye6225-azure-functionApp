// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
#r "Microsoft.Azure.EventGrid"
#r "SendGrid"
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using System.Net.Http;

namespace azure_functions
{
    public static class EventGridTrigger
    {
        [FunctionName("EventGridTrigger")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log,out SendGridMessage message)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
             message = new SendGridMessage();
             message.SetSubject("Message Via Azure Event Grid");
                // message.PlainTextContent= eventGridEvent.Data.ToString();
              message.AddContent("text/plain", "hello world");
        }
    }
}
