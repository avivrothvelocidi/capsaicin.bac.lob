using System;
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