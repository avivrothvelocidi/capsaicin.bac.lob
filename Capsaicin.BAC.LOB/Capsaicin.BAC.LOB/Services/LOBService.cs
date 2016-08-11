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
        protected readonly string GETTOTALSPENDBYMEDIUM = "usp_LOB_GetTotalSpendByMedium";
        protected readonly string GETYOY1 = "usp_LOB_GetYOY1";
        protected readonly string GETYOY2 = "usp_LOB_GetYOY2";
        protected readonly string GETLOBFILTER = "usp_LOB_GetLOBFilter";

        protected HttpContext _context;

        public LOBService(HttpContext context)
        {
            _context = context;
        }

        private string GetDBContext(){
            string dbContext;

            string option = _context.Request.Params["env"] ?? null;

            dbContext = DBCONTEXT + (option == null ? "" : "_" + option);

            return dbContext;
        }

        public string GetDataDate()
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            Dictionary<string, string> parms = new Dictionary<string, string>();

            recs.load(GETDATADATE, parms);
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetCommitments(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetCommitmentsParameters parms = new GetCommitmentsParameters()
            {
                Year = reqParms.Get("year"),
            };

            recs.load(GETCOMMITMENTS, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetTotalSpendByMonth(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
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

        public string GetTotalSpendByMedium(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetTotalSpendByMediumParameters parms = new GetTotalSpendByMediumParameters()
            {
                Year = reqParms.Get("year"),
                LOB = reqParms.Get("lob")
            };

            recs.load(GETTOTALSPENDBYMEDIUM, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetYOY1(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetYOY1Parameters parms = new GetYOY1Parameters()
            {
                Year1 = reqParms.Get("year1"),
                Year2 = reqParms.Get("year2"),
                Year3 = reqParms.Get("year3"),
                Grouping = reqParms.Get("grouping")
            };

            recs.load(GETYOY1, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetYOY2(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetYOY2Parameters parms = new GetYOY2Parameters()
            {
                Year1 = reqParms.Get("year1"),
                Year2 = reqParms.Get("year2"),
                Year3 = reqParms.Get("year3"),
                Filter = reqParms.Get("filter"),
                FilterValue = reqParms.Get("filterValue")
            };

            recs.load(GETYOY2, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetLOBFilter(NameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetLOBParameters parms = new GetLOBParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
            };

            recs.load(GETLOBFILTER, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }
    }
}