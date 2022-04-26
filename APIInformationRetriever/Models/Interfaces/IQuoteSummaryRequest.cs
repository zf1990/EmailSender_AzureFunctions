using APIInformationRetriever.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Interfaces
{
    public interface IQuoteSummaryRequest : ISymbol
    {
        public HashSet<ModulesEnum> Modules { get; set; }
        public string Lang { get; set; }
        public string Region { get; set; }
        public void AddModules(ModulesEnum Module);
        public void RemoveModules(ModulesEnum Module);
    }
}
