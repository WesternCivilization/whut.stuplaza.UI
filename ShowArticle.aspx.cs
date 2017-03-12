using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class ShowArticle : System.Web.UI.Page
    {
        TopicBLL top = new TopicBLL();
        ArticlePageHander pageHander = new ArticlePageHander();
        ArticleBLL bll = new ArticleBLL();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {    
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                string sector = (Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
                int total = 0;
                //综合办公司开始时绑定所有文章
                if (sector == "综合办公室")
                {
                    this.newsList.DataSource = pageHander.LoadPageData(pageIndex, pageSize, out total);
                }
                    //其余按各自办公室绑定
                else
                {
                    this.newsList.DataSource = bll.GetListBySector(pageIndex, pageSize, sector, out total);
                }
                this.newsList.DataBind();
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
        }
        /// <summary>
        /// 返回文章类型
        /// </summary>
        /// <returns></returns>
        public string CheckArticleCategory(object category)
        {
            try
            {
                int cateGory = Convert.ToInt32(category);
                string str = "";
                switch (cateGory)
                {
                    case 1: str = "通知公告"; break;
                    case 2: str = "新闻动态"; break;
                    default: str = "服务指南"; break;
                }
                return str;
            }
            catch
            {
                throw;
            }
        }
        //获取附件
        public string GetArticleAnnexAddr(Object AnnexAddr) {
            try
            {
                string str = (string)AnnexAddr.ToString();
                if (str == "")
                {  
                    str = "无附件";
                }
              return str;
            }
            catch {
                throw;
            }
           
        }


        /// <summary>
        /// 返回专题名称
        /// </summary>
        /// <param name="source"></param>
        public string ReturnTopicName(object id)
        {
            try
            {
                string str = "";
                int topicId = Convert.ToInt32(id);
                if (topicId > 0)
                {
                    str = top.GetTopicNameById(topicId);
                }
                else
                    str = "未设置专题";
                return str;
            }
            catch
            {
                throw;
            }
        }
        //返回栏目名称
        public string ReturnColumnName(Object id) {
            try
            {
                string columnId = (string)id;
                string str = "";
                ColumnBLL bll = new ColumnBLL();
                str = bll.GetModelById(columnId).ColumnName.ToString().Trim();
                return str;
            }
            catch
            {
                throw;
            }
                 
   }
        
      

        protected void newsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string sector = (Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
            if (e.CommandName == "Delete")//点击了删除按钮
            {
                string deleteId = e.CommandArgument.ToString().Trim();
                bll.Delete(deleteId);


                //重新绑定。
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "6");
                int total = 0;
                if (RB_notice.Checked)
                {   //如果是超发 
                    if (sector == "综合办公室")
                        this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 1, out  total);
                     //普发
                    else {
                        this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector,1, out  total);
                    }
                    this.newsList.DataBind();

                    this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
                }
                else if (RB_news.Checked)
                {
                    //如果是超发 
                    if (sector == "综合办公室")
                        this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 2, out  total);
                     //普发
                    else
                    {
                        this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector, 2, out  total);
                    }
                }
                else if (RB_service.Checked)
                {
                    //如果是超发 
                    if (sector == "综合办公室")
                        this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 3, out  total);
                     //普发
                    else
                    {
                        this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector, 3, out  total);
                    }
                }
                else
                {
                    if (sector == "综合办公室")
                    {
                        this.newsList.DataSource = pageHander.LoadPageData(pageIndex, pageSize, out total);
                    }
                    else
                    {
                        this.newsList.DataSource = bll.GetListBySector(pageIndex, pageSize, sector, out total);
                    }
                    this.newsList.DataBind();
                    this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
                }
            }
            else if (e.CommandName == "Update")
            {
                string editId = e.CommandArgument.ToString();
                Response.Redirect("EditArticle.aspx?editId=" + editId);
            }
            
        }

        protected void btn_Select_Click(object sender, EventArgs e)
        {
            string sector = (Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
            if (RB_notice.Checked)
            {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                if (sector == "综合办公室")
                {
                    this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 1, out  total);
                }
                else
                {
                    this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector, 1, out  total);
                }
                this.newsList.DataBind();

                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
            else if (RB_news.Checked)
            {   
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                if (sector == "综合办公室")
                {
                    this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 2, out  total);
                }
                else
                {
                    this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector, 2, out  total);
                }
                this.newsList.DataBind();

                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
            else
            {  
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                if (sector == "综合办公室")
                {
                    this.newsList.DataSource = bll.GetListByCategory(pageIndex, pageSize, 3, out  total);
                }
                else
                {
                    this.newsList.DataSource = bll.GetListBySectorAndCategory(pageIndex, pageSize, sector, 3, out  total);
                }
                this.newsList.DataBind();

                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
         }

        protected void btn_title_Click(object sender, EventArgs e)
        {   string sector=(Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
            string title =txt_title.Text.ToString().Trim();
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "8");
            int total = 0;
        if (title == "") {
            lbl_title.Text = "(搜索标题不能为空！)";
          }
        else if (title != "") {
            if (sector == "综合办公室")
            {
                this.newsList.DataSource = bll.GetListByTitle(pageIndex, pageSize,title, out total);   
            }
            else {
                this.newsList.DataSource = bll.GetListByTitleAndSector(pageIndex, pageSize, sector, title, out  total);
            }
            this.newsList.DataBind();
            this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
          }
        }
     }
 }
