﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Interfaces
{
    public interface ISparkRequest : ISymbols
    {
        public string Interval { get; set; }
        public string Range { get; set; }
    }
}
