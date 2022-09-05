using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Interfaces
{
    public interface ISymbols
    {
        public HashSet<string> Symbols { get; set; }
        public int MaxSymbols { get; set; }
        public void AddSymbol(string Symbol);
        public void RemoveSymbol(string Symbol);
    }
}
