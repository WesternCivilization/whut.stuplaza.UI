using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// getdate 的摘要说明
    /// </summary>
    public class getdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
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