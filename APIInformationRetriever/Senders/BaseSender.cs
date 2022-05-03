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

        public string ResponseString { get; set; }

        protected string RequestUrl { get; set; } = string.Empty;

        public BaseSender(string APIKey)
        {
            this.APIKey = APIKey;
            ResponseString = string.Empty;
        }

        public async Task<string> Send()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", APIKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await httpClient.GetAsync(RequestUrl);
            ResponseString =  await response.Content.ReadAsStringAsync();
            return ResponseString;
        }

        public abstract void FormUrl();
        public abstract IResponse GetResponse();
    }
}
