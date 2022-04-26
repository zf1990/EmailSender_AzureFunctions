using System;
using System.Threading.Tasks;
using AzureServices;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace EmailSender
{
    public class StockAndGoldInformationSender
    {
        [FunctionName("EmailSender")]
        public async Task Run([TimerTrigger("0 30 9 * * 1-5",
        #if DEBUG
            RunOnStartup=true
        #endif
            )]
            TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            KeyVaultService _service = new KeyVaultService();

            string Email = Environment.GetEnvironmentVariable("Email");
            //log.LogInformation(Email);
            //Console.WriteLine(Email);

            var EmailPasswordTask = _service.GetSecretValue(Environment.GetEnvironmentVariable("EmailPassword"));
            var APIKeyTask = _service.GetSecretValue(Environment.GetEnvironmentVariable("YahooFinanceAPIKey"));
            Task.WaitAll(new Task[] {EmailPasswordTask, APIKeyTask});

            Sender sender = new Sender(Email, EmailPasswordTask.Result);
            sender.AddRecipientEmail("zfang1216@gmail.com");
            sender.SetSubject("SMTP Test");
            sender.SetMessage("Test test test");
            sender.Send();

            //Console.WriteLine(APIKey);
            Console.WriteLine("Completed");


        }
    }
}
