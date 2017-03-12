using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.stuplaza.BLL;

namespace whut.stuplaza.UI.frontUI
{
    /// <summary>
    /// ProcessUpdateFileNum 的摘要说明
    /// </summary>
    public class ProcessUpdateFileNum : IHttpHandler
    {
        FileBLL bll = new FileBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["fileId"] != "")
            {
                string fileId = context.Request["fileId"];
                if (bll.UpdateDowNumById(fileId))
                {
                    context.Response.Write("ok");
                    context.Response.End();
                }
            }
            else 
            {
                context.Response.Redirect("error.html");
            }
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