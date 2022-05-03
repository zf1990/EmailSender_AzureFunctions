using APIInformationRetriever.Models.Classes.Responses;
using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class SparkSender : BaseSender
    {
        public ISparkRequest Request { get; set; }
        public string SubUrl { get; set; } = "/v8/finance/spark";
        public SparkSender(string APIKey, ISparkRequest Request) : base(APIKey)
        {
            this.Request = Request;
            FormUrl();
        }

        public override void FormUrl()
        {
            RequestUrl = BaseUrl + SubUrl;
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            sb.Append("interval=" + Request.Interval);
            sb.Append("&");
            sb.Append("range=" + Request.Range);
            sb.Append("&");
            sb.Append(String.Join(',', Request.Symbols));
            RequestUrl += sb.ToString();
        }

        public override IResponse GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
