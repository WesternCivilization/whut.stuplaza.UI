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
    public partial class stuplaza_topicpicList : System.Web.UI.Page
    {
        TopicBLL bll = new TopicBLL();
        public string ListPage { get; set; }
        public string NavHtml { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "6");
            int total = 0;
            ListPage = GetListPage(pageIndex, pageSize, out total);
            NavHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
        }
        public string GetListPage(int pageIndex, int pageSize, out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaTopic> list = bll.GetListByCategory(pageIndex, pageSize, out total);
            if (list.Count > 0)
            {
                sb.Append("<div class='theme left'>");
                if (list.Count <= 3)
                {
                    foreach (var model in list)
                    {
                        sb.AppendFormat("<dl><dt><a href='stuplaza_topicList.aspx?topicid={0}' target='_blank'><img src='{1}' width='400' height='150' /></a></dt><dd>{2}</dd></dl>", model.TopicId, model.TopicFileName, model.TopicTitle);
                    }
                    sb.Append("</div>");
                }
                else
                {
                    for (int i = 0; i <3;i++ )
                    {
                        sb.AppendFormat("<dl><dt><a href='stuplaza_topicList.aspx?topicid={0}' target='_blank'><img src='{1}' width='400' height='150' /></a></dt><dd>{2}</dd></dl>", list[i].TopicId, list[i].TopicFileName,list[i].TopicTitle);
                    }
                    sb.Append("</div><div class='line'><img src='images/list_page/stu_park/fenlanxian.png' width='2' height='530' /></div><div class='theme right'>");
                    for (int i = 3; i < list.Count; i++)
                    {
                        sb.AppendFormat("<dl><dt><a href='stuplaza_topicList.aspx?topicid={0}' target='_blank'><img src='{1}' width='400' height='150' /></a></dt><dd>{2}</dd></dl>", list[i].TopicId, list[i].TopicFileName, list[i].TopicTitle);
                    }
                    sb.Append("</div>");
                }
            }
            return sb.ToString();
        }
    }
}