using System;
using System.Collections.Generic;
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
    public partial class stuplaza_FirstColumn : System.Web.UI.Page
    {
        ColumnBLL bll = new ColumnBLL();
        ColumnBLL column = new ColumnBLL();
        public string sideList { get; set; }
        public string leftList { get; set; }
        public string urlReq { get; set; }
        public string FirstTitle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["firstcolumn"] != "" && Request["firstcolumn"] != null)
            {
                string firstcolumn = Context.Request["firstcolumn"] ?? "思想教育";
                urlReq = GenerateNav(firstcolumn);
                leftList = GenerateContent(firstcolumn);
                sideList = GenerateLiList(firstcolumn);
                FirstTitle = firstcolumn;
            }
            else
            {
                Response.Redirect("error.html");
            }
          
        }
        //如果是静态文件就得到第一个栏目的文章
        public string GenerateContent(string firstColumn)
        {
            StringBuilder result = new StringBuilder();
            List<T_stuplazaColumn> list = bll.GetColListByParent(firstColumn);
            List<T_stuplazaColumn> list_change = new List<T_stuplazaColumn>() ;
            foreach (T_stuplazaColumn column in list) {
                if (column.ColumnStatus == 1)
                {
                    list_change.Add(column);
                }
            }
            if (list_change.Count <= 0)
            {
                T_stuplazaColumn col = list[0];
                result.AppendFormat("<div id='contents' style='overflow:auto;'><div class='title'>{0}</div><div class='text' style='height:100%'>{1}</div></div>", col.ColumnName, col.ColumnContent);
            }
            else 
            {
                result.Append(GenerateLeftList(list_change[0].ColumnName));
            }
            return result.ToString();
             
        }
        public string GenerateLeftList(string firstColumn)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = new List<T_stuplazaArticle>();
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;
            string columnId = bll.GetIdByName(firstColumn);

            string columnId2 = columnId.TrimEnd('0');
            if (columnId2.Length % 2 == 1)
            {
                columnId2 = columnId2 + "0";
            }
            list = bll.GetListByColumn(pageIndex, pageSize, columnId2, out total);
            if (list.Count > 0)
            {
                foreach (T_stuplazaArticle model in list)
                {
                    if(model.ArticleCategory==1)
                    sb.AppendFormat("<li><span>【{0}】</span><a href='stuplaza_noticeDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", bll.GetModelById(model.ArticleColumn).ColumnName, model.ArticleId, model.ArticleTitle);
                    else if (model.ArticleCategory == 2)
                    {
                        sb.AppendFormat("<li><span>【{0}】</span><a href='stuplaza_newsDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", bll.GetModelById(model.ArticleColumn).ColumnName, model.ArticleId, model.ArticleTitle);
                        
                    }
                    else
                        sb.AppendFormat("<li><span>【{0}】</span><a href='stuplaza_serviceDetail.aspx?articleid={1}'  target='_blank'>{2}</a></li>", bll.GetModelById(model.ArticleColumn).ColumnName, model.ArticleId, model.ArticleTitle);

                }
                this.NavStrHtml.Text = CjsPager.ShowPageNavigateFirstColumn(pageSize, pageIndex, total, Request.QueryString["firstcolumn"].ToString().Trim());
                return sb.ToString();

            }
            else { return ""; }
        
        }
        public string GenerateNav(string parent)
        {
            StringBuilder sb = new StringBuilder();
            string columnId = bll.GetIdByName(parent);
            int flag = (columnId.TrimEnd('0').Length + 1) / 2;
            T_stuplazaColumn model = new T_stuplazaColumn();
            string columnid2 = columnId.Substring(0, 4)+"0000";
            T_stuplazaColumn model2 = new T_stuplazaColumn();
            model2 = bll.GetModelById(columnid2);
            model = bll.GetModelById(columnId);
            switch (flag)
            {
                case 1: sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a>", model.ColumnName); break;
                case 2: sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a>", model.ColumnParent, model.ColumnName);break;
                case 3:
                    sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a>",model2.ColumnParent,model2.ColumnName,model.ColumnName);break;
                case 4: if (model.ColumnStatus == 1)
                    {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                    }
                    else {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                } break;
                default: break;
            }
            return sb.ToString();
            
           
        }
        public int GetShowType(string parent)
        {
            if (column.GetRecordByParent(parent) > 0)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 拼接li字符串
        /// </summary>
        /// <returns></returns>
        public string GenerateLiList(string parent)
        { 
            List<T_stuplazaColumn> list = column.GetColListByParent(parent);
            StringBuilder sb=new StringBuilder();
            if (list.Count != 0)
            {
                foreach (var col in list)
                {
                    if (GetShowType(col.ColumnName) == 1)
                        sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}' target='_self'>{0}</a></li>", col.ColumnName);
                    else
                    {
                        if (col.ColumnStatus == 1)
                            sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={0}' target='_self'>{1}</a></li>", col.ColumnId, col.ColumnName);
                        else
                            sb.AppendFormat("<li><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={0}' target='_self'>{1}</a></li>", col.ColumnId, col.ColumnName);
                    }
                }
            }
            
            return sb.ToString();
                   
        }
       
       
        
    }
}