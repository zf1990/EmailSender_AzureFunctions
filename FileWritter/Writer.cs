using APIInformationRetriever.Models.Classes.Responses;

namespace FileWritter
{
    public class Writer
    {
        public Writer(IResponse Response)
        {
            switch(Response)
            {
                case QuoteResponse res:
                    break;
                case SparkResponse res:
                    break;
                case QuoteSummaryResponse res:
                    break;
                default:
                    throw new ArgumentException("This response is not supported at the moment");
            }
        }
    }
}