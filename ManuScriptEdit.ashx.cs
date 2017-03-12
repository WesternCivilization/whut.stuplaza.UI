using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ManuScriptEdit 的摘要说明
    /// </summary>
    public class ManuScriptEdit : IHttpHandler
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string title = context.Request["txtTitle"];
            string content = context.Request["txtcontent"];
            string id = context.Request["hidId"] ?? "20150802001";
            T_stuplazaManuScript model = new T_stuplazaManuScript();
            var news =bll.GetModelById(id);
            news.ManuScriptTitle=title;
            news.ManuScriptContent = content;
            if (bll.Update(news))
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("修改败了");
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