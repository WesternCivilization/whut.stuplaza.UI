using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// LoadDetailById 的摘要说明
    /// </summary>
    public class LoadDetailById : IHttpHandler
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
                context.Response.Write(article.ArticleContent);
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