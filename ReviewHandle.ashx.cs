using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ReviewHandle 的摘要说明
    /// </summary>
    public class ReviewHandle : IHttpHandler, IReadOnlySessionState
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string manuid=context.Request["manuid"] ?? "20150802001";
            T_stuplazaManuScript model = bll.GetModelById(manuid);
            if ((model.ManuScriptStatus == 0 )|| (model.ManuScriptStatus == 2))
            { 
                model.ManuScriptStatus = 1;
                if (context.Session["Category"].ToString() == "信息发布者")

                    model.ManuScriptReviewer = (context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminName;
                else
                    model.ManuScriptReviewer = (context.Session["model"] as T_stuplazaReviewer).ReviewerName;
                bll.Update(model);
            }
            context.Response.Write("ok");
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