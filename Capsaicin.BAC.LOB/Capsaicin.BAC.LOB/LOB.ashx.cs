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