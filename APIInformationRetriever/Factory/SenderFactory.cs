using APIInformationRetriever.Models.Classes;
using APIInformationRetriever.Models.Interfaces;
using APIInformationRetriever.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Factory
{
    public class SenderFactory : IFactory
    {
        public BaseSender GetSender(IRequest Request, string APIKey)
        {
            BaseSender sender = null;
            switch(Request)
            {
                case IQuoteRequest request:
                    sender = new QuoteSender(APIKey, request);
                    break;
                case IQuoteSummaryRequest request:
                    sender = new QuoteSummarySender(APIKey, request);
                    break;
                case ISparkRequest request:
                    sender = new SparkSender(APIKey, request);
                    break;
                default:
                    throw new ArgumentException("Invalid request or the request isn't supported");
            }
            return sender;
        }
    }
}
