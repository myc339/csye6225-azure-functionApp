// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using Microsoft.Azure.EventGrid.Models;
using SendGrid.Helpers.Mail;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]
namespace azure_functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.addEventGrid();
            builder.addSendGrid();
            builder.Services.AddSingleton((s) => {
                return new MyService();
            });

            builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }
    }
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
