//#r "Microsoft.Azure.EventGrid"
//#r "SendGrid"
using Microsoft.Azure.EventGrid.Models;
using SendGrid.Helpers.Mail;
using System.Net.Http;
public static void Run(EventGridEvent eventGridEvent, ILogger log,out SendGridMessage message)
{
    log.LogInformation(eventGridEvent.Data.ToString());
    message = new SendGridMessage();
    message.SetSubject("Message Via Azure Event Grid");
    // message.PlainTextContent= eventGridEvent.Data.ToString();
     message.AddContent("text/plain", "hello world");
}
