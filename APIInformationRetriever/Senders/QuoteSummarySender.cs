﻿using APIInformationRetriever.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInformationRetriever.Senders
{
    public class QuoteSummarySender : BaseSender
    {
        public IQuoteSummaryRequest Request { get; set; }
        public QuoteSummarySender(string APIKey, IQuoteSummaryRequest Request): base(APIKey)
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
            sb.Append($"symbol={Request.Symbol}");
            sb.Append("&");
        }
    }
}