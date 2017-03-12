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
    public partial class stuplaza_topicList : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        TopicBLL topicBll = new TopicBLL();
        public string GetList { get; set; }
        public string navHtml { get; set; }
        public string sideNav { get; set; }
        public string nav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex=int.Parse(Request["pageIndex"]??"1");
            int pageSize=int.Parse(Request["pageSize"]??"7");
            int topicid=int.Parse(Request["topicid"]??"1");
            int total = 0;
            GetList = GetListPage(pageIndex, pageSize, topicid, out total);
            navHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
            sideNav = GenerateTopicList(10);
            nav = topicBll.GetTopicNameById(topicid);

        }
        //遍历生成分页列表
        public string GetListPage(int pageIndex,int pageSize,int topicid,out int total)
        {
            
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetListByTopic(pageIndex, pageSize, topicid, out total);
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
       
        
        //生成右边的专题列表
        public string GenerateTopicList(int total)
        {
           List<T_stuplazaTopic> list=topicBll.GetListByPriority(total);
           StringBuilder sb = new StringBuilder();
           foreach (var model in list)
           {
               sb.AppendFormat(" <li><span>></span><a href='stuplaza_topicList.aspx?topicid={0}' target='_self'>{1}</a></li>", model.TopicId, model.TopicTitle);
           }
           return sb.ToString();
        }
    }
}