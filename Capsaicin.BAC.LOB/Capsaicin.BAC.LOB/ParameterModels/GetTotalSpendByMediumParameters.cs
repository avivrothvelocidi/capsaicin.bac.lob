using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetTotalSpendByMediumParameters : AllFilterParameters
    {
	    public string Year { get; set; }
        public string SpendType { get; set; }

        public override Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("Year", Year);
            parms.Add("SpendType", SpendType);

            return parms;
        }
    }
}