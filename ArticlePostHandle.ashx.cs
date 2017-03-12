using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using whut.stuplaza.MODEL;
using whut.stuplaza.BLL;
using System.Web.SessionState;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// ArticlePostHandle 的摘要说明
    /// </summary>
    public class ArticlePostHandle : IHttpHandler, IReadOnlySessionState
    {
        ArticleBLL bll = new ArticleBLL();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
            context.Response.ContentType = "text/plain";
            string articleId = bll.GetIdByTime(DateTime.Now.ToString("yyyyMMdd")); 
            string articleTitle = context.Request.Form["txtTitle"]??"未设置标题".ToString();
            int articleCategory = int.Parse(context.Request.Form["txtCategory"].ToString());
            string articleSector = (context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector;
            int articleTopic = int.Parse(context.Request.Form["txtTopic"].ToString());
            string articleContent = context.Request.Form["txtcontent"].ToString();
            string articlePostStaff = (context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminName;
            string articleAnnexAddr = context.Request.Form["txtAnnex"].ToString();
            string articleTime = context.Request.Form["act_start_time"].ToString();
              if (String.IsNullOrEmpty(articleTime.Trim()))
            {
                articleTime = DateTime.Now.ToString();  
            }
                string articleColumn="00000000";
                if(context.Request.Form["txtcolumn"]!=null)
                {
                    articleColumn= context.Request.Form["txtcolumn"].ToString();
                }
            T_stuplazaArticle article = new T_stuplazaArticle();
            article = GetModel(articleId, articleTitle, articleCategory, articleSector, articleTopic, articleContent, articlePostStaff, articleAnnexAddr, articleTime, articleColumn);
            bll.InsertArticle(article);
            context.Response.Redirect("ShowArticle.aspx");
            }
            catch
            {
                throw;
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public T_stuplazaArticle GetModel(string id, string title, int category, string sector, int topic, string content, string poststaff, string annexaddr, string time, string column)
        {
            T_stuplazaArticle model = new T_stuplazaArticle();
            model.ArticleId = id;
            model.ArticleTitle = title;
            model.ArticleCategory = category;
            model.ArticleSector = sector;
            T_stuplazaTopic st = new T_stuplazaTopic();
            if (topic > 0)
            {
                st.TopicId = topic;
                model.topic = st;
            }
            
            model.ArticleContent = content;
            model.ArticlePostStaff = poststaff;
            model.ArticleAnnexAddr = annexaddr;
            model.ArticleTime = time;
            model.ArticleColumn = column;
            return model;
        
        }
       
       
    }
}