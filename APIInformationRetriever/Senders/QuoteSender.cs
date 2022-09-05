using APIInformationRetriever.Models.Classes.Responses;
using APIInformationRetriever.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class QuoteSender : BaseSender
    {
        public IQuoteRequest Request { get; set; }
        public string subUrl { get; set; } = "/v6/finance/quote";
        public QuoteSender(string APIKey, IQuoteRequest Request) : base(APIKey)
        {
            this.Request = Request;
            if (this.Request.Symbols.Count < 10)
                FormUrl();
            else
                FormUrls();
        }

        public override void FormUrl()
        {
            StringBuilder sb = GetBasicStringBuilder();
            sb.Append(String.Join(',', Request.Symbols));
            RequestUrl = sb.ToString();                
        }

        private void FormUrls()
        {
            for(int i = 0; i<=Request.Symbols.Count; i+= 10)
            {
                StringBuilder sb = GetBasicStringBuilder();
                sb.Append(String.Join(',', Request.Symbols.Skip(i).Take(10)));
                RequestUrls.Add(sb.ToString());
            }
        }

        private StringBuilder GetBasicStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BaseUrl);
            sb.Append(subUrl);
            sb.Append("?");
            sb.Append($"lang={Request.Lang}");
            sb.Append("&");
            sb.Append($"region={Request.Region}");
            sb.Append("&");
            sb.Append("symbols=");
            return sb;
        }

        public override IResponse GetResponse()
        {
            List<QuoteResult> responseData = new List<QuoteResult>();
            if(ResponseStrings.Count > 0)
            {
                foreach(string s in ResponseStrings)
                    GetSingleResponse(responseData, s);
            } else
            {
                GetSingleResponse(responseData, ResponseString);
            }

            QuoteResponse response = new QuoteResponse();
            response.QuoteResults = responseData;

            return response;
        }

        private void GetSingleResponse(List<QuoteResult> responseData, string responseString)
        {
            JObject obj = JObject.Parse(responseString);
            IList<JToken> results = obj["quoteResponse"]["result"].Children().ToList();

            foreach (JToken result in results)
            {
                QuoteResult quoteResult = result.ToObject<QuoteResult>();
                responseData.Add(quoteResult);
            }
        }
    }
}
