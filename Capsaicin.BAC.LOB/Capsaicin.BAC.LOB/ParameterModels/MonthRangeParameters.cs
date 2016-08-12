using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class MonthRangeParameters : IProcParameters
    {
	    public string StartMonth {get;set;}
        public string EndMonth { get; set; }

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("StartMonth", StartMonth);
            parms.Add("EndMonth", EndMonth);

            return parms;
        }
    }
}