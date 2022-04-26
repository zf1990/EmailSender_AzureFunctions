using APIInformationRetriever.Models.Enums;
using System.Text;

namespace APIInformationRetriever
{
    public class InformationGetter
    {
        public string APIKey { get; set; }


        private string baseUrl = "https://yfapi.net";
        public InformationGetter(string APIKey, ICollection<string> Tickers, ICollection<string> Attributes)
        {
            this.APIKey = APIKey;
        }

        public bool AddTicker(string Ticker)
        {

            return false;
        }

        private string GetBaseUrl(StockOptionsEnum option)
        {
            string returnUrl = string.Empty;
            switch (option) {
                case StockOptionsEnum.quote:
                    returnUrl += "/v6/finance/quote?";
                    
                    break;
                case StockOptionsEnum.quoteSummary:
                    returnUrl += "/v11/finance/quoteSummary?";
                    break;
                case StockOptionsEnum.spark:
                    returnUrl += "/v8/finance/spark?";
                    break;
                default:
                    throw new ArgumentException("The given option does not exist or is not yet supported");
            }
            return returnUrl;
        }


        public async Task<string> GetInformation(StockOptionsEnum option)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Add("X-API-KEY", APIKey);
            httpClient.DefaultRequestHeaders.Add("accept", "application/json");
            string formedString = GetBaseUrl(option);
            var response = await httpClient.GetAsync(formedString);
            return await response.Content.ReadAsStringAsync();
        }

        public Dictionary<string, string> GetRequestParameters(StockOptionsEnum option)
        {
            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            
            switch (option) {
                case StockOptionsEnum.spark:
                    break;
                case StockOptionsEnum.quote:
                    Parameters.Add("lang", "en");
                    Parameters.Add("region", "US");
                    //Parameters.Add("symbols", String.Join(',', Tickers));
                    break;
                case StockOptionsEnum.quoteSummary:
                    break;
            }

            return Parameters;
        }



    }
}