using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;


namespace whut.stuplaza.UI.frontUI
{
    /// <summary>
    /// RetColDetailStatic 的摘要说明
    /// </summary>
    public class RetColDetailStatic : IHttpHandler
    {
        ArticleBLL bll = new ArticleBLL();
        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            if (context.Request["newsid"] != null)
            {
                string newsId = context.Request["newsid"];
                T_stuplazaArticle article = new T_stuplazaArticle();
                article = bll.GetArticleById(newsId);
                JavaScriptSerializer java = new JavaScriptSerializer();
                string str = java.Serialize(article);
                context.Response.Write(str);
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