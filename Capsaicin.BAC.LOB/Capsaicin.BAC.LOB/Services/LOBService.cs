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
        protected readonly string DBCONTEXT = "LOBContext";
        protected readonly string GETDATADATE = "usp_LOB_GetDataDate";
        protected readonly string GETCOMMITMENTS = "usp_LOB_GetCommitments";

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

        public string GetCommitments(NameValueCollection reqParms)
        {
            Records recs = RecordsFactory.getRecordsObject(null, DBCONTEXT, _context);
            GetCommitmentsParameters parms = new GetCommitmentsParameters()
            {
                Year = reqParms.Get("year"),
            };

            recs.load(GETCOMMITMENTS, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }
    }
}