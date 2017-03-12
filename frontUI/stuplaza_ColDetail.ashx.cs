using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using whut.stuplaza.BLL;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    /// <summary>
    /// stuplaza_ColDetail 的摘要说明
    /// </summary>
    public class stuplaza_ColDetail : IHttpHandler
    {
        ColumnBLL bll = new ColumnBLL();
        ArticleBLL article = new ArticleBLL();
        ArticlePageHander pageArticle = new ArticlePageHander();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
           
            
            string columnId = "";
            int columnStatus = 0;
            if(context.Request["columnid"]!=null)
            {
                 columnId = context.Request["columnid"];
            }
            if (context.Request["columnstatus"] != null)
            {
                columnStatus = int.Parse(context.Request["columnstatus"]);
            }
            if (columnStatus == 0)
            {
                GenerateStaticStr(columnId, context);
            }
            else
            {
                GenerateDynamicStr(columnId, context);
            }

            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //生成静态内容的时候替换部分字符串
        public void GenerateStaticStr(string columnid, HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaColumn> list = new List<T_stuplazaColumn>();
            string html = File.ReadAllText(context.Request.MapPath("ColDetailStatic.html"));
            list = bll.GetDTSiblingsById(columnid);
            T_stuplazaColumn column = new T_stuplazaColumn();
            column = bll.GetModelById(columnid);
            foreach (T_stuplazaColumn col in list)
            {
                if (bll.GetRecordByParent(col.ColumnName) > 0)
                {
                    sb.AppendFormat("<li><span>></span><a href='stuplaza_SecondColumn.aspx?parentNode={0}' target='_self'>{1}</a></li>", col.ColumnName, col.ColumnName);
                }
                else
                    sb.AppendFormat("<li><span>></span><a href='stuplaza_ColDetail.ashx?columnid={0}&&columnstatus={1}' target='_self'>{2}</a></li>", col.ColumnId, col.ColumnStatus, col.ColumnName);
            }
            string html1 = html.Replace("@content", column.ColumnContent);
            string html2 = html1.Replace("@sidebar", sb.ToString()).Replace("@nav",GenerateTagById(columnid));
            context.Response.Write(html2);
            context.Response.End();
        
        }

        //生成动态内容的时候替换关键字符串
        public void GenerateDynamicStr(string columnid, HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = new List<T_stuplazaArticle>();
            List<T_stuplazaColumn> column = new List<T_stuplazaColumn>();
            StringBuilder sb2 = new StringBuilder();
            string urlNav = "";
            int pageIndex = int.Parse(context.Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(context.Request["pageSize"] ?? "15");
            int total = 0;
            column = bll.GetDTSiblingsById(columnid);
            foreach (T_stuplazaColumn col in column)
            {
                if (bll.GetRecordByParent(col.ColumnName) > 0)
                {
                    sb2.AppendFormat("<li><span>></span><a href='stuplaza_SecondColumn.aspx?parentNode={0}' target='_self'>{1}</a></li>", col.ColumnName, col.ColumnName);
                }
                else
                    sb2.AppendFormat("<li><a href='stuplaza_ColDetail.ashx?columnid={0}&&columnstatus={1}' target='_self'>{2}</a></li>", col.ColumnId, col.ColumnStatus, col.ColumnName);
            }
            list = pageArticle.LoadPageDataByColumn(pageIndex,pageSize,columnid,out total);
            if (list.Count > 0)
            {
                string html = File.ReadAllText(context.Request.MapPath("ColDetailDynamic.html"));
                foreach (T_stuplazaArticle model in list)
                {
                    //sb.AppendFormat("<li class='listli'><a href='#' newsid='{0}'>{1}</a><span>{2}</span></li>", model.ArticleId, model.ArticleTitle, model.ArticleTime);
                    sb.AppendFormat("<li><span>{0}</span><a href='#' newsid='{1}' target='_blank'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);
                }
                urlNav = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
                string str = html.Replace("@content", sb.ToString()).Replace("@sidebar",sb2.ToString()).Replace("@nav",GenerateTagById(columnid)).Replace("@fenye",urlNav);
                context.Response.Write(str);
            }
            else
                context.Response.End();
        }

        //遍历生成a标签
        public string GenerateTagById(string columnid)
        {
            StringBuilder sb = new StringBuilder();
            int flag = (columnid.TrimEnd('0').Length + 1) / 2;
            T_stuplazaColumn model=new T_stuplazaColumn();
            string columnid2 = "";
            model=bll.GetModelById(columnid);
            switch(flag)
            {
                case 2: sb.AppendFormat("<a href='stuplaza_Index.aspx' target='_self'>首页</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={3}' target='_self'>{3}</a><span>></span><a href='stuplaza_ColDetail.ashx?columnid={0}&&columnstatus={1}' target='_self'>{2}</a>", model.ColumnId, model.ColumnStatus, model.ColumnName, model.ColumnParent); break;
                case 3: columnid2 = columnid.Substring(0, 4); 
                        T_stuplazaColumn model2 = new T_stuplazaColumn(); 
                        model2 = bll.GetModelById(columnid2);
                        sb.AppendFormat("<a href='stuplaza_Index.aspx' target='_self'>首页</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}' target='_self'>{0}</a><span>></span><a href='stuplaza_SecondColumn.aspx?secondcolumn={1}' target='_self'>{1}</a><span>></span><a href='stuplaza_ColDetail.ashx?columnid={2}&&columnstatus={3}' target='_self'>", model2.ColumnParent, model2.ColumnName,model.ColumnId,model.ColumnStatus);break;
                        
                    
            }
            return sb.ToString();
        }
    }
}