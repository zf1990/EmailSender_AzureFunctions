using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Classes.Responses
{
    public class QuoteResponse : IResponse
    {
        [JsonProperty("result")]
        public List<QuoteResult> QuoteResults { get; set; }

        public string Error { get; set; }
    }
}
