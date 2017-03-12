using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using whut.stuplaza.BLL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ManuScriptDetail 的摘要说明
    /// </summary>
    public class ManuScriptDetail : IHttpHandler
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string manusid = context.Request["id"] ?? "20150802001";
            JavaScriptSerializer java = new JavaScriptSerializer();
            string str = java.Serialize(bll.GetModelById(manusid));
            context.Response.Write(str);
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