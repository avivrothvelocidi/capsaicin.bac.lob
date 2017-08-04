using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using DataService;
using Capsaicin.BAC.LOB.ParameterModels;
using Capsaicin.BAC.LOB.Utilities;

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
        protected readonly string GETDIVISIONFILTER = "usp_LOB_GetDivisionFilter";
        protected readonly string GETCAMPAIGNFILTER = "usp_LOB_GetCampaignFilter";
        protected readonly string GETTOPCAMPAIGN = "usp_LOB_GetTopCampaign";
        protected readonly string GETTITLE = "usp_LOB_GetTitle";
        protected readonly string GETML = "usp_LOB_GetMerrillLynch";
        protected readonly string GETSPENDBYLOB = "usp_LOB_GetSpendByLOB";
        protected readonly string GETMLBREAKDOWN = "usp_LOB_GetMLBreakdown";
        protected readonly string GETROLLUP = "usp_LOB_GetRollup";
        protected readonly string GETMARKETS = "usp_LOB_GetMarkets";
        protected readonly string GETSPENDBYDIVISION = "usp_LOB_GetSpendByDivision";

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

        public string GetCommitments(SafeNameValueCollection reqParms)
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

        public string GetTotalSpendByMonth(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetTotalSpendByMonthParameters parms = new GetTotalSpendByMonthParameters()
            {
                LOB = reqParms.Get("lob"),
                Division = reqParms.Get("division"),
                Campaign = reqParms.Get("campaign"),
                SpendType = reqParms.Get("spendType"),
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

        public string GetTotalSpendByMedium(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetTotalSpendByMediumParameters parms = new GetTotalSpendByMediumParameters()
            {
                Year = reqParms.Get("year"),
                LOB = String.IsNullOrEmpty(reqParms.Get("lob")) ? "<ALL>": reqParms.Get("lob"),
                Division = String.IsNullOrEmpty(reqParms.Get("division")) ? "<ALL>" : reqParms.Get("division"),
                Campaign = String.IsNullOrEmpty(reqParms.Get("campaign")) ? "<ALL>" : reqParms.Get("campaign"),
                SpendType = String.IsNullOrEmpty(reqParms.Get("spendType")) ? "<BOTH>" : reqParms.Get("spendType")
            };

            recs.load(GETTOTALSPENDBYMEDIUM, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetYOY1(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetYOY1Parameters parms = new GetYOY1Parameters()
            {
                Year1 = reqParms.Get("year1"),
                Year2 = reqParms.Get("year2"),
                Year3 = reqParms.Get("year3"),
                LOB = reqParms.Get("lob")
            };

            recs.load(GETYOY1, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetYOY2(SafeNameValueCollection reqParms)
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

        public string GetLOBFilter(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);
            GetLOBFilterParameters parms = new GetLOBFilterParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
            };

            recs.load(GETLOBFILTER, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetDivisionFilter(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetDivisionFilterParameters parms = new GetDivisionFilterParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob") ?? ""
            };

            recs.load(GETDIVISIONFILTER, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetCampaignFilter(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetCampaignFilterParameters parms = new GetCampaignFilterParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob") ?? "",
                Division = reqParms.Get("division")
            };

            recs.load(GETCAMPAIGNFILTER, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetTopCampaign(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetTopCampaignParameters parms = new GetTopCampaignParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth")
            };

            recs.load(GETTOPCAMPAIGN, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetTitle(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetTitleParameters parms = new GetTitleParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob"),
                Division = reqParms.Get("division"),
                Campaign = reqParms.Get("campaign")
            };

            recs.load(GETTITLE, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetMerrillLynch(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetMLParameters parms = new GetMLParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob"),
                Division = reqParms.Get("division"),
                Campaign = reqParms.Get("campaign"),
                SpendType = reqParms.Get("spendType"),
                ResultType = reqParms.Get("resultType")
            };

            recs.load(GETML, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetSpendByLOB(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetSpendByLOBParameters parms = new GetSpendByLOBParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob"),
                Division = reqParms.Get("division"),
                Campaign = reqParms.Get("campaign"),
                SpendType = reqParms.Get("spendType"),
                IsLOBGrouping = reqParms.Get("isLOBGrouping")
            };

            recs.load(GETSPENDBYLOB, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetMLBreakdown(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            MonthRangeParameters parms = new MonthRangeParameters()
            {
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth")
            };

            recs.load(GETMLBREAKDOWN, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetRollup(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetRollupParameters parms = new GetRollupParameters()
            {
                Year = reqParms.Get("year")
            };

            recs.load(GETROLLUP, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetMarkets(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetMarketsParameters parms = new GetMarketsParameters()
            {
                Year = reqParms.Get("year"),
                Market1 = reqParms.Get("market1"),
                Market2 = reqParms.Get("market2"),
                Market3 = reqParms.Get("market3"),
                Market4 = reqParms.Get("market4"),
                Market5 = reqParms.Get("market5"),
                Market6 = reqParms.Get("market6"),
                Market7 = reqParms.Get("market7"),
                Market8 = reqParms.Get("market8"),
                Market9 = reqParms.Get("market9"),
                Market10 = reqParms.Get("market10"),
                Market11 = reqParms.Get("market11"),
                Market12 = reqParms.Get("market12"),
                Market13 = reqParms.Get("market13"),
                Market14 = reqParms.Get("market14"),
                Market15 = reqParms.Get("market15"),
                Market16 = reqParms.Get("market16")
            };

            recs.load(GETMARKETS, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }

        public string GetSpendByDivision(SafeNameValueCollection reqParms)
        {
            string dbContext = GetDBContext();
            Records recs = RecordsFactory.getRecordsObject(null, dbContext, _context);

            GetSpendByDivisionParameters parms = new GetSpendByDivisionParameters()
            {
                QueryType = reqParms.Get("queryType"),
                StartMonth = reqParms.Get("startMonth"),
                EndMonth = reqParms.Get("endMonth"),
                LOB = reqParms.Get("lob"),
                Division = reqParms.Get("division"),
                Campaign = reqParms.Get("campaign"),
                SpendType = reqParms.Get("spendType"),
                Year = reqParms.Get("year")
            };

            recs.load(GETSPENDBYDIVISION, parms.MapToDictionary());
            return XcelsiusFormat.ToXML(recs);
        }
    }
}