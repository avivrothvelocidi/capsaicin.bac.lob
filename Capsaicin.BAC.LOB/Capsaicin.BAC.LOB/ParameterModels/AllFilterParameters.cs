using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class AllFilterParameters : IProcParameters
    {
        public string LOB { get; set; }
        public string Division { get; set; }
        public string Campaign { get; set; }

        public virtual Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("LOB", LOB);
            parms.Add("Division", Division);
            parms.Add("Campaign", Campaign);

            return parms;
        }
    }
}