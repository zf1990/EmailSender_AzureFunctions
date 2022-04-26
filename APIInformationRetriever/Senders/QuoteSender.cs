﻿using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class QuoteSender : BaseSender
    {
        public IQuoteRequest Request { get; set; }
        public QuoteSender(string APIKey, IQuoteRequest Request) : base(APIKey)
        {
            this.Request = Request;
        }

        public override void FormUrl()
        {
            RequestUrl = BaseUrl;
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            sb.Append($"lang={Request.Lang}");
            sb.Append("&");
            sb.Append($"region={Request.Region}");
            sb.Append("&");
            sb.Append("symbols=");
            sb.Append(String.Join(',', Request.Symbols));
            RequestUrl += sb.ToString();                
        }
    }
}
