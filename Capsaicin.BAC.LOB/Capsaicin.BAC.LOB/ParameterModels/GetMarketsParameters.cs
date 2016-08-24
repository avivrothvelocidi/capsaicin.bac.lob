using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Interfaces.ParameterModels;

namespace Capsaicin.BAC.LOB.ParameterModels
{
    public class GetMarketsParameters : IProcParameters
    {
        public string Year { get; set; }
	    public string Market1 {get;set;}
        public string Market2 { get; set; }
        public string Market3 { get; set; }
        public string Market4 { get; set; }
        public string Market5 { get; set; }
        public string Market6 { get; set; }
        public string Market7 { get; set; }
        public string Market8 { get; set; }
        public string Market9 { get; set; }
        public string Market10 { get; set; }
        public string Market11 { get; set; }
        public string Market12 { get; set; }
        public string Market13 { get; set; }
        public string Market14 { get; set; }
        public string Market15 { get; set; }
        public string Market16 { get; set; }

        public virtual Dictionary<string, string> MapToDictionary()
        {
            Dictionary<string, string> parms = new Dictionary<string, string>();

            parms.Add("Year", Year);
            parms.Add("Market1", Market1);
            parms.Add("Market2", Market2);
            parms.Add("Market3", Market3);
            parms.Add("Market4", Market4);
            parms.Add("Market5", Market5);
            parms.Add("Market6", Market6);
            parms.Add("Market7", Market7);
            parms.Add("Market8", Market8);
            parms.Add("Market9", Market9);
            parms.Add("Market10", Market10);
            parms.Add("Market11", Market11);
            parms.Add("Market12", Market12);
            parms.Add("Market13", Market13);
            parms.Add("Market14", Market14);
            parms.Add("Market15", Market15);
            parms.Add("Market16", Market16);

            return parms;
        }
    }
}