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
    public partial class stuplaza_articleList : System.Web.UI.Page
    {
        public string ListPage { get; set; }
        public string NavHtml { get; set; }
        public string ArticleCategory { get; set; }
        public string Acategory { get; set; }
        ArticleBLL bll = new ArticleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int category=int.Parse(Request["category"]??"1");
            
            Acategory = category.ToString();
            int total = 0;
            ListPage = GetListPage(pageIndex, pageSize,category, out total);
            NavHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total,category,-1);
            if (category == 1)
                ArticleCategory = "通知公告";
            else
                ArticleCategory = "新闻动态";

        }


        public string GetListPage(int pageIndex, int pageSize, int category,out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetListByCategory(pageIndex, pageSize,category, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                    if(category==1)

                    sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_noticeDetail.aspx?articleid={1}' target='_blank' title=''>【{3}】{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle, model.ArticleSector);
                    else if(category==2)
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_newsDetail.aspx?articleid={1}' target='_blank' title=''>【{3}】{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle, model.ArticleSector);
                }
            }
            return sb.ToString();
        }

    }
}