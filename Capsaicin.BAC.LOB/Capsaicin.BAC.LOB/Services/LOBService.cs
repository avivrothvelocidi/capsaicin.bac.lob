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
        protected readonly string GETTOTALSPENDBYMONTH = "usp_LOB_GetTotalSpendByMonth";

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

        public string GetTotalSpendByMonth(NameValueCollection reqParms)
        {
            Records recs = RecordsFactory.getRecordsObject(null, DBCONTEXT, _context);
            GetTotalSpendByMonthParameters parms = new GetTotalSpendByMonthParameters()
            {
                Time1 = reqParms.Get("time1"),
                Time2 = reqParms.Get("time2"),
                Time3 = reqParms.Get("time3"),
                Time4 = reqParms.Get("time4"),
                Time5 = reqParms.Get("time5"),
                Time6 = reqParms.Get("time6"),
                Time7 = reqParms.Get("time7"),
                Time8 = reqParms.Get("time8"),
                Time9 = reqParms.Get("time9"),
                Time10 = reqParms.Get("time10"),
                Time11 = reqParms.Get("time11"),
                Time12 = reqParms.Get("time12")
            };

            recs.load(GETTOTALSPENDBYMONTH, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }
    }
}