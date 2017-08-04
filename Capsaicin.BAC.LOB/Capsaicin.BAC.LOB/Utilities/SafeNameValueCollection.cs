using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Capsaicin.BAC.LOB.Utilities
{
    public class SafeNameValueCollection : NameValueCollection
    {
        public SafeNameValueCollection(NameValueCollection nvc) : base(nvc)
        {
        }

        public override string Get(string name)
        {
            return parseInValue(base.Get(name));
        }

        private string parseInValue(string raw)
        {
            string rawTemp = raw;
            string result = rawTemp;
            if (rawTemp != null && raw.IndexOf("'") >= 0)
            {
                if (rawTemp.StartsWith("'")) rawTemp = rawTemp.Substring(1);
                if (rawTemp.EndsWith("'")) rawTemp = rawTemp.Substring(0, rawTemp.Length - 1);
                string[] rawValsSep = { "','" };
                string[] rawVals = rawTemp.Split(rawValsSep, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < rawVals.Length; i++)
                {
                    rawVals[i] = rawVals[i].Replace("'", "''");
                }
                if (rawVals.Length > 0)
                    result = "'" + String.Join("','", rawVals) + "'";
                else result = "";
            }

            return result;
        }
    }
}