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
    /// indexNewsHandle 的摘要说明
    /// </summary>
    public class indexNewsHandle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ArticleBLL bllArticle = new ArticleBLL();
            //首页需求要求显示最新通知公告置顶最新的5条通知公告，每条消息的字符上限是25，多出省略；同样，最新文件自动置顶4条最新文件,最新新闻动态自动置顶最新前7条；图说新闻自动置顶3个有图片的新闻


            if (context.Request["newsid"] != null)
            {
                string newsId = context.Request["newsid"];
                JavaScriptSerializer java = new JavaScriptSerializer();
                string str = java.Serialize(bllArticle.GetArticleById(newsId));
                context.Response.Write(str);

            }
            else
            {
                context.Response.ContentType = "text/plain";
                List<T_stuplazaArticle> list = bllArticle.GetNoticeModelListByNum(7, 2);
                JavaScriptSerializer java = new JavaScriptSerializer();
                string str = java.Serialize(list);
                context.Response.Write(str);
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