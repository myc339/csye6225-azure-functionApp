// Default URL for triggering event grid function in the local environment.
using Microsoft.Azure.EventGrid.Models;
using SendGrid.Helpers.Mail;
using System.Net.Http;

using Microsoft.Extensions.Logging;


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
