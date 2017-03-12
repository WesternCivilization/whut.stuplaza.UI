using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    /// <summary>
    /// ProcessManuSubmit 的摘要说明
    /// </summary>
    public class ProcessManuSubmit : IHttpHandler
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string title = context.Request.Form["title"] ?? "未设置标题";
            string source = context.Request.Form["source"] ?? "未填写学院";
            string author = context.Request.Form["author"];
            string phone = context.Request.Form["phone"];
            string email = context.Request.Form["email"];
            string content = context.Request.Form["txtcontent"];
            string id=bll.GetIdByTime(DateTime.Now.ToString("yyyyMMdd"));
            if ((author == "") || (phone == "") || (email == "") || (content == ""))
            {
                context.Response.Write("<script>alert('相关信息填写错误或未填写！';location.href='OnlineSubmit.html')</script>");

            }
            else
            {
                T_stuplazaManuScript model = new T_stuplazaManuScript() { ManuScriptId = id, ManuScriptTitle = title, ManuScriptAcademy = source, ManuScriptAuthor = author, ManuScriptContent = content, ManuScriptEmail = email, ManuScriptReviewer = "", ManuScriptStatus = 0, ManuScriptTel = phone, ManuScriptTime = DateTime.Now.ToString() };

                if (bll.InsertArticle(model) > 0)
                    context.Response.Redirect("success.html");
                else
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