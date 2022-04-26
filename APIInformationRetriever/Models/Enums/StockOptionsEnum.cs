using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Enums
{
    public enum StockOptionsEnum
    {
        /// <summary>
        /// Real Time Quote
        /// </summary>
        quote,

        /// <summary>
        /// Detailed information about a particular stock such as asset profile, insider transactions etc.
        /// </summary>
        quoteSummary,

        /// <summary>
        /// Get the history of the stock/stocks.  Max 10.
        /// </summary>
        spark
    }
}
