using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetMLParameters : MonthRangeParameters
    {
	    public string LOB {get;set;}
        public string Division { get; set; }
        public string Campaign { get; set; }
        public string SpendType { get; set; }
        public string ResultType { get; set; }

        public override Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("LOB", LOB);
            parms.Add("Division", Division);
            parms.Add("Campaign", Campaign);
            parms.Add("SpendType", SpendType);
            parms.Add("ResultType", ResultType);

            return parms;
        }
    }
}