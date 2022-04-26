using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Classes
{
    public class QuoteRequest : IQuoteRequest, IRequest
    {
        public string Region { get; set; } = "us";
        public string Lang { get; set; } = "en";
        
        public HashSet<string> Symbols { get; set; }
        public int MaxSymbols { get; set; } = 10;

        public QuoteRequest(HashSet<string> Symbols)
        {
            this.Symbols = Symbols;
        }

        public bool AddSymbol(string symbol)
        {
            if (Symbols.Count < 10)
            {
                Symbols.Add(symbol);
                return true;
            }
            return false;
        }

        public void RemoveSymbol(string symbol) => Symbols.Remove(symbol);
    }
}
