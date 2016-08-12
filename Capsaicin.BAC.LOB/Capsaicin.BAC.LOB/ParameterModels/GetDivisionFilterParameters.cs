using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetDivisionFilterParameters : GetLOBFilterParameters
    {
	    public string LOB {get;set;}

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("LOB", LOB);

            return parms;
        }
    }
}