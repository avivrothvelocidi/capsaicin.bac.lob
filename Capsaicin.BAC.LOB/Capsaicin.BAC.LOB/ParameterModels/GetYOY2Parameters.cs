using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetYOY2Parameters : IProcParameters
    {
	    public string Year1 {get;set;}
        public string Year2 { get; set; }
        public string Year3 { get; set; }
        public string Filter { get; set; }
        public string FilterValue { get; set; }

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("Year1", Year1);
            parms.Add("Year2", Year2);
            parms.Add("Year3", Year3);
            parms.Add("Filter", Filter);
            parms.Add("FilterValue", FilterValue);

            return parms;
        }
    }
}