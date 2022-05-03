using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Classes.Responses
{
    public class QuoteResult
    {
        public double PriceEpsCurrentYear { get; set; }
        public long SharesOutstanding { get; set; }
        public double FiftyDayAverage { get; set; }
        public double FiftyDayAverageChange { get; set; }
        public double TwoHundredDayAverage { get; set; }
        public double TwoHundredDayAverageChange { get; set; }
        public long MarketCap { get; set; }
        public double ForwardPE { get; set; }
        public string AverageAnalystRating { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double RegularMarketDayHigh { get; set; }
        public double RegularMarketDayLow { get; set; }
        public long RegularMarketVolume { get; set; }
        public double RegularMarketPreviousClose { get; set; }
        public long AverageDailyVolume3Month { get; set; }
        public long AverageDailyVolume10Day { get; set; }
        public double FiftyTwoWeekLow { get; set; }
        public double FiftyTwoWeekHigh { get; set; }
        public double TrailingAnnualDividendRate { get; set; }
        public double TrailingPE { get; set; }
        public double TrailingAnnualDividendYield { get; set; }
        public double EpsTrailingTwelveMonths { get; set; }
        public double EpsForward { get; set; }
        public double EpsCurrentYear { get; set; }
        public string DisplayName { get; set; }
        public string Symbol { get; set; }

    }
}
