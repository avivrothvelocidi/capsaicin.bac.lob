using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetTitleParameters : AllFilterParameters
    {
        private MonthRangeParameters monthParms;
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }

        public GetTitleParameters()
        {
            monthParms = new MonthRangeParameters();
        }

        public GetTitleParameters(MonthRangeParameters monthParms)
        {
            this.monthParms = monthParms;
            this.StartMonth = this.monthParms.StartMonth;
            this.EndMonth = this.monthParms.EndMonth;
        }
    }
}