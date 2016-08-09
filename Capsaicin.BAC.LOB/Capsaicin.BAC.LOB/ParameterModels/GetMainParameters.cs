using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetMainParameters : IProcParameters
    {
	    public string TimeInterval1 {get;set;}


        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("TimeInterval1", TimeInterval1);

            return parms;
        }
    }
}