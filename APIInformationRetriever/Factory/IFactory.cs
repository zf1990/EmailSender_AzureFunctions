using APIInformationRetriever.Models.Interfaces;
using APIInformationRetriever.Senders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Factory
{
    public interface IFactory
    {
        public BaseSender GetSender(IRequest Request, string APIKey);
    }
}
