using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetSpendByDivisionParameters : AllFilterParameters
    {
        public string QueryType { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string Year { get; set; }
        public string SpendType { get; set; }

        public override Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("QueryType", QueryType);
            parms.Add("StartMonth", StartMonth);
            parms.Add("EndMonth", EndMonth);
            parms.Add("Year", Year);
            parms.Add("SpendType", SpendType);

            return parms;
        }
    }
}