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
        public static void Run([EventGridTrigger]EventGridEvent eventGridEvent, ILogger log,[SendGrid(ApiKey = "GridKey",To="chen.yum39@gmail.com",From = "noreply@myc39.me")] out SendGridMessage message
            ,[CosmosDB(
                              databaseName: "ToDoList",
                              collectionName: "Items",
                              ConnectionStringSetting = "CosmosDBConnection")]out dynamic documen])
        {
            log.LogInformation(eventGridEvent.Data.ToString());
             message = new SendGridMessage();
             message.SetSubject("Message Via Azure Event Grid");
                // message.PlainTextContent= eventGridEvent.Data.ToString();
              message.AddContent("text/plain", "hello world");
              String a = "hello";
              String b = "world";
              outputDocument = new{a,b};
        }
    }
}
