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

        protected string RequestUrl { get; set; }

        public BaseSender(string APIKey)
        {
            this.APIKey = APIKey;
        }

        protected async Task<string> Send()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", APIKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            var response = await httpClient.GetAsync(RequestUrl);
            return await response.Content.ReadAsStringAsync();
        }

        public abstract void FormUrl();
    }
}
