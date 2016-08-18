﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capsaicin.BAC.LOB.Services;

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

            string action = context.Request.Params["action"] ?? "";
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
                    response = _service.GetCommitments(context.Request.Params);
                    break;
                case "GETTOTALSPENDBYMONTH":
                    //LOB.ashx?action=GETTOTALSPENDBYMONTH&time1=201601&time2=201602&time3=201603&time4=201604&time5=201605&time6=201606&time7=201607&time8=201608&time9=201609&time10=201610&time11=201611&time12=201612
                    response = _service.GetTotalSpendByMonth(context.Request.Params);
                    break;
                case "GETTOTALSPENDBYMEDIUM":
                    //LOB.ashx?action=GetTotalSpendByMedium&year=<2016>&lob=<GWIM>
                    response = _service.GetTotalSpendByMedium(context.Request.Params);
                    break;
                case "GETYOY1":
                    //LOB.ashx?action=GetYOY1&year1=2015&year2=2016&year3=2017&lob=GWIM
                    response = _service.GetYOY1(context.Request.Params);
                    break;
                case "GETYOY2":
                    //LOB.ashx?action=GetYOY2&year1=2015&year2=2016&year3=2017&filter=LOB&filterValue=GBM
                    response = _service.GetYOY2(context.Request.Params);
                    break;
                case "GETLOBFILTER":
                    //LOB.ashx?action=GetLOBFilter&startMonth=201601&endMonth=201612
                    response = _service.GetLOBFilter(context.Request.Params);
                    break;
                case "GETDIVISIONFILTER":
                    //LOB.ashx?action=GetDivisionFilter&startMonth=201601&endMonth=201612&LOB=GBM
                    response = _service.GetDivisionFilter(context.Request.Params);
                    break;
                case "GETCAMPAIGNFILTER":
                    //LOB.ashx?action=GetCampaignFilter&startMonth=201601&endMonth=201612&LOB=GBM&Division=GBM
                    response = _service.GetCampaignFilter(context.Request.Params);
                    break;
                case "GETTOPCAMPAIGN":
                    //LOB.ashx?action=GetTopCampaign&startMonth=201601&endMonth=201612
                    response = _service.GetTopCampaign(context.Request.Params);
                    break;
                case "GETTITLE":
                    //LOB.ashx?action=GetTitle&startMonth=201601&endMonth=201612&allSpend=1
                    response = _service.GetTitle(context.Request.Params);
                    break;
                case "GETML1":
                    //LOB.ashx?action=GetML1&startMonth=201601&endMonth=201612&spendType=estimated&campaigns=%27Merrill%20EDGE%20Baseline%27
                    response = _service.GetML1(context.Request.Params);
                    break;
                case "GETML2":
                    //LOB.ashx?action=GetML2&startMonth=201601&endMonth=201612&spendType=estimated&campaigns=%27Merrill%20EDGE%20Baseline%27
                    response = _service.GetML2(context.Request.Params);
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