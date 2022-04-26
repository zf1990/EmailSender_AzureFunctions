using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class QuoteSender : BaseSender
    {
        public IQuoteRequest Request { get; set; }
        public QuoteSender(string APIKey, IQuoteRequest Request) : base(APIKey)
        {
            this.Request = Request;
        }
    }
}
