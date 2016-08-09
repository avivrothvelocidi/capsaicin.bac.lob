using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetTotalSpendByMonthParameters : IProcParameters
    {
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public string Time3 { get; set; }
        public string Time4 { get; set; }
        public string Time5 { get; set; }
        public string Time6 { get; set; }
        public string Time7 { get; set; }
        public string Time8 { get; set; }
        public string Time9 { get; set; }
        public string Time10 { get; set; }
        public string Time11 { get; set; }
        public string Time12 { get; set; }

        public Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("Time1", Time1);
            parms.Add("Time2", Time2);
            parms.Add("Time3", Time3);
            parms.Add("Time4", Time4);
            parms.Add("Time5", Time5);
            parms.Add("Time6", Time6);
            parms.Add("Time7", Time7);
            parms.Add("Time8", Time8);
            parms.Add("Time9", Time9);
            parms.Add("Time10", Time10);
            parms.Add("Time11", Time11);
            parms.Add("Time12", Time12);

            return parms;
        }
    }
}