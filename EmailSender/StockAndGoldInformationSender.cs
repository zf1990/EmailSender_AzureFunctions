using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIInformationRetriever.Factory;
using APIInformationRetriever.Models.Classes;
using APIInformationRetriever.Models.Classes.Responses;
using APIInformationRetriever.Models.Interfaces;
using AzureServices;
using FileWritter;
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

            var EmailPasswordTask = _service.GetSecretValue(Environment.GetEnvironmentVariable("EmailPassword"));
            var APIKeyTask = _service.GetSecretValue(Environment.GetEnvironmentVariable("YahooFinanceAPIKey"));
            Task.WaitAll(new Task[] {EmailPasswordTask, APIKeyTask});

            HashSet<string> Symbols = new HashSet<string>() {"VFIAX", "XOM", "OXY", "CVX", "COP", "ENB", "SU", "IMO", "CNQ", "CHK"};
            IRequest Request = new QuoteRequest(Symbols);
            IFactory factory = new SenderFactory();
            var RequestSender = factory.GetSender(Request, APIKeyTask.Result);
            string information = await RequestSender.Send();
            IResponse response = RequestSender.GetResponse();
            //Console.WriteLine(information);

            Writer writer = new Writer(response, "StockInfo");
            string filePath = writer.WriteResponses();

            Sender sender = new Sender(Email, EmailPasswordTask.Result);
            sender.AddRecipientEmail("zfang1216@gmail.com");
            sender.AddRecipientEmail("fzp58@163.com");
            sender.SetSubject("Stock Information");
            sender.SetMessage("Please see the attachment for the stock information for today.  VFIAX represent S&P 500.");
            sender.AddAttachment(filePath);
            sender.Send();

            writer.DeleteFile();

            Console.WriteLine("Completed");


        }
    }
}
