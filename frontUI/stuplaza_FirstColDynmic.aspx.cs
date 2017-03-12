using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    public partial class stuplaza_FirstColDynmic : System.Web.UI.Page
    {
        public string content { get; set; }
        public string nav { get; set; }
        public string sidebar { get; set; }
        public string DynamicTitle { get; set; }
        ColumnBLL bll = new ColumnBLL();
        ArticleBLL article = new ArticleBLL();
        ArticlePageHander pageArticle = new ArticlePageHander();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["columnid"] != null&&Request["columnid"]!="")
            {
                string columnId = Request["columnid"];

                content = GenerateList(columnId);
                nav = GenerateNav(columnId);
                DynamicTitle = bll.GetModelById(columnId).ColumnName;
                sidebar = GenerateSideNav(columnId);
            }
            else 
            {
                Response.Redirect("error.html");
            }
        }
        public string GenerateNav(string columnId) 
        {
            StringBuilder sb = new StringBuilder();
            int flag = (columnId.TrimEnd('0').Length + 1) / 2;
            T_stuplazaColumn model = new T_stuplazaColumn();
            string columnid2 = "";
            model = bll.GetModelById(columnId);
            columnid2 = columnId.Substring(0, 4);
            T_stuplazaColumn model2 = new T_stuplazaColumn();
            model2 = bll.GetModelById(columnid2 + "0000");
            switch (flag)
            {
                case 2: if(model.ColumnStatus==1)
                    sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}' target='_self'>{2}</a><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={0}' target='_self'>{1}</a>", model.ColumnId, model.ColumnName,model.ColumnParent); 
                    else
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}' target='_self'>{2}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={0}' target='_self'>{1}</a>", model.ColumnId, model.ColumnName,model.ColumnParent); 
                    break;
                case 3: 
                    sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}' target='_self'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}' target='_self'>{1}</a><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={2}' target='_self'>{3}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnId,model.ColumnName); break;
                case 4: if (model.ColumnStatus == 1)
                    {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                    }
                    else
                    {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                    } break;


            }
            return sb.ToString();
        }
        public string GenerateList(string columnId) {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = new List<T_stuplazaArticle>();
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;
            list = pageArticle.LoadPageDataByColumn(pageIndex, pageSize, columnId, out total);
            if (list.Count > 0)
            {
                foreach (T_stuplazaArticle model in list)
                {
                    if(model.ArticleCategory==1)
                    sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_noticeDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);
                    else if (model.ArticleCategory == 2)
                    {
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_newsDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);
                        
                    }
                    else
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_serviceDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);

                }
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
                return sb.ToString();

            }
            else { return ""; }
        }
        public string GenerateSideNav(string columnId) {
            List<T_stuplazaColumn> column = new List<T_stuplazaColumn>();
            StringBuilder sb = new StringBuilder();
            column = bll.GetDTSiblingsById(columnId);
            foreach (T_stuplazaColumn col in column)
            {
                if (bll.GetRecordByParent(col.ColumnName) > 0)
                {
                    sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}' target='_self'>{1}</a></li>", col.ColumnName, col.ColumnName);
                }
                else
                {
                    if(col.ColumnStatus==1)
                    sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={0}' target='_self'>{1}</a></li>", col.ColumnId,col.ColumnName);
                    else
                        sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={0}' target='_self'>{1}</a></li>", col.ColumnId, col.ColumnName);
                }
            }
            return sb.ToString();
        }
        
    }
}