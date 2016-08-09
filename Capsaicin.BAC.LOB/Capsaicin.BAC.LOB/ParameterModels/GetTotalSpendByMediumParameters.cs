using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetTotalSpendByMediumParameters : IProcParameters
    {
	    public string Year {get;set;}
        public string LOB { get; set; }

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("Year", Year);
            parms.Add("LOB", LOB);

            return parms;
        }
    }
}