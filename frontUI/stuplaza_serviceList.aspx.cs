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
    public partial class stuplaza_serviceList : System.Web.UI.Page
    {
        public string ListPage { get; set; }
        public string NavHtml { get; set; }
        
        ArticleBLL bll = new ArticleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "14");
            int total = 0;
            ListPage = GetListPage(pageIndex, pageSize, 3, out total);
            NavHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
        }

        public string GetListPage(int pageIndex, int pageSize, int category, out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetListByCategory(pageIndex, pageSize, category, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                        sb.AppendFormat("<li><a href='stuplaza_serviceDetail.aspx?articleid={1}' target='_blank' title='{2}'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);
                    
                }
            }
            return sb.ToString();
        }
    }
}