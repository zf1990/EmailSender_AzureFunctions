using APIInformationRetriever.Models.Classes.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public abstract class BaseSender
    {
        protected string BaseUrl = "https://yfapi.net";
        protected string APIKey { get; init; }

        protected string ResponseString { get; set; } = String.Empty;
        protected List<string> ResponseStrings { get; set; }

        protected string RequestUrl { get; set; } = string.Empty;

        protected List<string> RequestUrls { get; set; }

        public BaseSender(string APIKey)
        {
            this.APIKey = APIKey;
            ResponseString = string.Empty;
            RequestUrls = new List<string>();
            ResponseStrings = new List<string>();
        }

        public async Task Send()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", APIKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");

            if (RequestUrls.Count == 0)
            {
                var response = await httpClient.GetAsync(RequestUrl);
                ResponseString += await response.Content.ReadAsStringAsync();
            } else
            {
                foreach(var url in RequestUrls)
                {
                    var response = await httpClient.GetAsync(url);
                    ResponseStrings.Add(await response.Content.ReadAsStringAsync());
                }
            }
        }

        public abstract void FormUrl();
        public abstract IResponse GetResponse();
    }
}
