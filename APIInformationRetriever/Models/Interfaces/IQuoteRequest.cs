using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Interfaces
{
    public interface IQuoteRequest : ISymbols
    {
        public string Region { get; set; }
        public string Lang { get; set; }

    }
}
