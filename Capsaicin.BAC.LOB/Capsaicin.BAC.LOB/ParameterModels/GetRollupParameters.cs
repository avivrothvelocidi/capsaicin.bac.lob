using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetRollupParameters : IProcParameters
    {
	    public string Year {get;set;}

        public virtual Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("Year", Year);

            return parms;
        }
    }
}