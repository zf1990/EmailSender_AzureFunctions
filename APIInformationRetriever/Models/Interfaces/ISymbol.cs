﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Models.Interfaces
{
    public interface ISymbol
    {
        public string Symbol { get; set; }
        public void ChangeSymbol(string symbol);
    }
}
