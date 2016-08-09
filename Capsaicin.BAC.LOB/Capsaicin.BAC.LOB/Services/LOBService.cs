using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using DataService;
using Capsaicin.BAC.LOB.ParameterModels;

namespace Capsaicin.BAC.LOB.Services
{
    public class LOBService
    {
        protected readonly string DBCONTEXT = "ParentCompanyContext";
        protected readonly string GETDATADATE = "usp_LOB_GetDataDate";

        protected HttpContext _context;

        public LOBService(HttpContext context)
        {
            _context = context;
        }

        public string GetDataDate()
        {
            Records recs = RecordsFactory.getRecordsObject(null, DBCONTEXT, _context);
            Dictionary<string, string> parms = new Dictionary<string, string>();

            recs.load(GETDATADATE, parms);
            return XcelsiusFormat.ToXML(recs);
        }
    }
}