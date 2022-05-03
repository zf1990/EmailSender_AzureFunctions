using APIInformationRetriever.Models.Classes.Responses;
using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class QuoteSummarySender : BaseSender
    {
        public IQuoteSummaryRequest Request { get; set; }
        public string SubUrl { get; set; } = "/v11/finance/quoteSummary/";
        public QuoteSummarySender(string APIKey, IQuoteSummaryRequest Request): base(APIKey)
        {
            this.Request = Request;
            FormUrl();
        }

        public override void FormUrl()
        {
            RequestUrl = BaseUrl + SubUrl + Request.Symbol;
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            sb.Append($"lang={Request.Lang}");
            sb.Append("&");
            sb.Append($"region={Request.Region}");
        }

        public override IResponse GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
