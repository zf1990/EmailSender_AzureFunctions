using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Classes
{
    public class SparkRequest : ISparkRequest, IRequest
    {
        public string Interval { get; set; } = "1d";
        public string Range { get; set; } = "1mo";
        public HashSet<string> Symbols { get; set; } = new HashSet<string>();
        public int MaxSymbols { get; set; } = 10;

        public bool AddSymbol(string Symbol)
        {
            if (Symbols.Count < MaxSymbols)
            {
                Symbols.Add(Symbol);
                return true;
            }
            return false;
        }

        public void RemoveSymbol(string Symbol)
        {
            Symbols.Remove(Symbol);
        }

        public bool ChangeInterval(string Interval)
        {
            Interval = Interval.ToLower();
            if (Interval == "1m" || Interval == "5m" || Interval == "15m" || Interval == "1d" || Interval == "1wk" || Interval == "1mo")
            {
                this.Interval = Interval;
                return true;
            }
            return false;
        }

        public bool ChangeRange(string Range)
        {
            Range = Range.ToLower();
            if (Range == "1d" || Range == "5d" || Range == "1mo" || Range == "3mo" || Range == "6mo" || Range == "1y" || Range == "5y" || Range == "max")
            {
                this.Range = Range;
                return true;
            }
            return false;
        }
    }
}
