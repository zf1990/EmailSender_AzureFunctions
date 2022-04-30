using APIInformationRetriever.Models.Enums;
using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Classes
{
    public class QuoteSummaryRequest : IQuoteSummaryRequest, IRequest
    {
        public string Lang { get; set; } = "en";
        public string Region { get; set; } = "us";
        public string Symbol { get; set; }
        HashSet<ModulesEnum> IQuoteSummaryRequest.Modules { get; set; } = new HashSet<ModulesEnum>() { 
            ModulesEnum.summaryDetail,
            ModulesEnum.fundProfile,
            ModulesEnum.financialData,
            ModulesEnum.defaultKeyStatistics,
            ModulesEnum.earningsHistory,
            ModulesEnum.price,
            ModulesEnum.quoteType
        };

        public QuoteSummaryRequest(string Symbol)
        {
            this.Symbol = Symbol;
        }

        public void AddModules(ModulesEnum Module)
        {
        }

        public void ChangeSymbol(string symbol)
        {
            this.Symbol = symbol;
        }

        public void RemoveModules(ModulesEnum Module)
        {
            throw new NotImplementedException();
        }
    }
}
