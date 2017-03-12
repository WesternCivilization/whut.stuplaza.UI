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
    public partial class stuplaza_articleListBySector : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        public string GetList { get; set; }
        public string navHtml { get; set; }
        public string Acategory { get; set; }
        public string nav { get; set; }
        public string prenav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex=int.Parse(Request["pageIndex"]??"1");
            int pageSize=int.Parse(Request["pageSize"]??"7");
            string sector=Request["sector"]??"1";
            int category = int.Parse(Request["category"] ?? "1");
            Acategory = category.ToString();
            string sector2=ReturnSector(int.Parse(sector));
            int total = 0;
            GetList = GetListPage(pageIndex, pageSize, sector2,category, out total);
            navHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total,category,sector);
            string strCategory = "";
            switch (category)
            {
                case 1: strCategory = "通知公告"; break;
                case 2: strCategory = "新闻动态"; break;
                default: break;
            }
            prenav = "<a href='stuplaza_articleList.aspx?category=" + category + "'>"+strCategory+"</a>";
            nav = "<a href='stuplaza_articleListBySector.aspx?sector=" + int.Parse(sector) + "'>" + sector2 + "</a>";
            
        }
        //得到list
        public string GetListPage(int pageIndex, int pageSize, string sector, int category,out int total)
        {

            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetListBySector(pageIndex, pageSize,sector, category,out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                    if (model.ArticleCategory == 1)
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_noticeDetail.aspx?articleid={2}' target='_blank' title=''>{1}</a></li>", model.ArticleTime, model.ArticleTitle, model.ArticleId);
                    else if (model.ArticleCategory == 2)
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_newsDetail.aspx?articleid={2}' target='_blank' title=''>{1}</a></li>", model.ArticleTime, model.ArticleTitle, model.ArticleId);
                    else
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_serviceDetail.aspx?articleid={2}' target='_blank' title=''>{1}</a></li>", model.ArticleTime, model.ArticleTitle, model.ArticleId);
                }
            }
            return sb.ToString();
        }

        //对应部门的编号
        public string ReturnSector(int sectorId)
        {
            string str = "";
            switch (sectorId)
            {
                case 1: str = "学生教育办公室(学生)"; break;
                case 2: str = "学生教育办公室(辅导员)"; break;
                case 3: str = "学生管理办公室(日常)"; break;
                case 4: str = "学生管理办公室(就业)"; break;
                case 5: str = "心理健康教育中心"; break;
                case 6: str = "学生资助与服务中心(资助)"; break;
                case 7: str = "学生资助与服务中心(住宿、勤工助学)"; break;
                case 8: str = "招生办公室"; break;
                case 9: str = "武装部"; break;
                case 10: str = "团委"; break;
                case 11: str = "综合办公室"; break;
                default:break;
            }
            return str;
        }
    }
}