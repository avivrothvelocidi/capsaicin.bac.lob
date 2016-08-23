using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetSpendByLOBParameters : AllFilterParameters
    {
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string SpendType { get; set; }
        public string IsLOBGrouping { get; set; }

        public override Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = base.MapToDictionary();

            parms.Add("StartMonth", StartMonth);
            parms.Add("EndMonth", EndMonth);
            parms.Add("SpendType", SpendType);
            parms.Add("IsLOBGrouping", IsLOBGrouping);

            return parms;
        }
    }
}