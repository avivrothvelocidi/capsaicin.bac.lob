using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Services;
using Capsaicin.BAC.LOB.Utilities;

namespace Capsaicin.BAC.LOB
{
    /// <summary>
    /// Summary description for LOB
    /// </summary>
    public class LOB : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string action = new SafeNameValueCollection(context.Request.Params)["action"] ?? "";
            context.Trace.Write("Request action: " + action);

            LOBService _service = new LOBService(context);

            string response;

            switch (action.Trim().ToUpper())
            {
                case "GETDATADATE":
                    //LOB.ashx?action=GetDataDate
                    response = _service.GetDataDate();
                    break;
                case "GETCOMMITMENTS":
                    //LOB.ashx?action=GetCommitments&year=2011
                    response = _service.GetCommitments(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETTOTALSPENDBYMONTH":
                    //LOB.ashx?action=GETTOTALSPENDBYMONTH&lob='GBM','GWIM'&division='GBM'&campaign='Global Rgn GBAM BBG-SEM'&spendType='Actual'&time1=201601&time2=201602&time3=201603&time4=201604&time5=201605&time6=201606&time7=201607&time8=201608&time9=201609&time10=201610&time11=201611&time12=201612
                    response = _service.GetTotalSpendByMonth(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETTOTALSPENDBYMEDIUM":
                    //LOB.ashx?action=GetTotalSpendByMedium&year=<2016>&lob='GWIM','GBM'&division='GBM'&campaign='Global Rgn GBAM BBG-SEM'&spendType='Estimated'
                    response = _service.GetTotalSpendByMedium(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETYOY1":
                    //LOB.ashx?action=GetYOY1&year1=2015&year2=2016&year3=2017&lob=GWIM
                    response = _service.GetYOY1(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETYOY2":
                    //LOB.ashx?action=GetYOY2&year1=2015&year2=2016&year3=2017&filter=LOB&filterValue=GBM
                    response = _service.GetYOY2(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETLOBFILTER":
                    //LOB.ashx?action=GetLOBFilter&startMonth=201601&endMonth=201612
                    response = _service.GetLOBFilter(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETDIVISIONFILTER":
                    //LOB.ashx?action=GetDivisionFilter&startMonth=201601&endMonth=201612&LOB=GBM
                    response = _service.GetDivisionFilter(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETCAMPAIGNFILTER":
                    //LOB.ashx?action=GetCampaignFilter&startMonth=201601&endMonth=201612&LOB=GBM&Division=GBM
                    response = _service.GetCampaignFilter(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETTOPCAMPAIGN":
                    //LOB.ashx?action=GetTopCampaign&startMonth=201601&endMonth=201612
                    response = _service.GetTopCampaign(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETTITLE":
                    //lob.ashx?action=GetTitle&startMonth=201601&endMonth=201612&lob='GWIM','GBM'&division='GBM','GCB'&campaign='Global Rgn GBAM BBG-SEM'
                    response = _service.GetTitle(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETML":
                    //LOB.ashx?action=GetML&startMonth=201601&endMonth=201612&spendType='Actual'&lob='GCSBB','GBM'&division='Digital Marketing Programs', 'Merrill Lynch'&resultType=1
                    response = _service.GetMerrillLynch(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETSPENDBYLOB":
                    //LOB.ashx?action=GetSpendByLOB&startMonth=201601&endMonth=201612&lob='GWIM','GBM'&division='GBM','GCB'&campaign='Global Rgn GBAM BBG-SEM'&spendType='Actual'&isLOBGrouping=1
                    response = _service.GetSpendByLOB(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETMLBREAKDOWN":
                    //LOB.ashx?action=GetMLBreakdown&startMonth=201601&endMonth=201612
                    response = _service.GetMLBreakdown(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETROLLUP":
                    //LOB.ashx?action=GetRollup&year=2016
                    response = _service.GetRollup(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETMARKETS":
                    //LOB.ashx?action=GetMarkets&year=2016&market1=BALTIMORE,%20MD
                    response = _service.GetMarkets(new SafeNameValueCollection(context.Request.Params));
                    break;
                case "GETSPENDBYDIVISION":
                    //LOB.ashx?action=GetSpendByDivision&queryType=1&startMonth=201601&endMonth=201612&lob=%27GWIM%27,%27GCSBB%27&division=1&campaign=%27Goals%20Based%20Wealth%20Management%27,%27Institutional%20Retirement%27&spendType=&year=2016
                    response = _service.GetSpendByDivision(new SafeNameValueCollection(context.Request.Params));
                    break;
                default:
                    response = "Error: Unknown action";
                    break;
            }

            context.Response.Output.Write(response);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}