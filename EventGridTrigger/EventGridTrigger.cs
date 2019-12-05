//#r "Microsoft.Azure.EventGrid"
//#r "Microsoft.Azure.SendGrid"
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;

using SendGrid.Helpers.Mail;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Host;



namespace azure_functions
{

    public static class EventGridTrigger
    {
        [FunctionName("EventGridTrigger")]
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log,SendGrid(ApiKey = "GridKey") out SendGridMessage message)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
             message = new SendGridMessage();
             message.AddTo("chen.yum39@gmail.com");
             message.SetFrom(new EmailAddress("noreply@myc39.me"));
             message.SetSubject("Message Via Azure Event Grid");
                // message.PlainTextContent= eventGridEvent.Data.ToString();
              message.AddContent("text/plain", "hello world");
        }
    }
}