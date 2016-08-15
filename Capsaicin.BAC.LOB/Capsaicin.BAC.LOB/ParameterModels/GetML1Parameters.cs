﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetML1Parameters : MonthRangeParameters
    {
	    public string Campaigns {get;set;}
        public string SpendType { get; set; }

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("Campaigns", Campaigns);
            parms.Add("SpendType", SpendType);

            return parms;
        }
    }
}