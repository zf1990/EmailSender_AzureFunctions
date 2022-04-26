using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender
{
    public class URLBuilder
    {
        private HashSet<string> Tickers { get; set; }
        public string BaseUrl { get; set; } = "https://yfapi.net/v6/finance/quote/";

        public URLBuilder()
        {
            Tickers = new HashSet<string>();
        }
        public URLBuilder(List<string> Tickers)
        {
            this.Tickers = new HashSet<string>(Tickers);
        }

        public string BuildURL()
        {
            string tickerString = String.Join(',', Tickers);
            return BaseUrl + tickerString;
        }

        public void AddTicker(string ticker) => 
            Tickers.Add(ticker);
        public void RemoveTicker(string ticker) => 
            Tickers.Remove(ticker);
    }
}
