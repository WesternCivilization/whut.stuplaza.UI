using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    public partial class stuplaza_Index : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        FileBLL fileBll = new FileBLL();
        TopicBLL topicBll = new TopicBLL();
        MenuScriptBLL manuBll = new MenuScriptBLL();
        ImgChangeBLL imgBll = new ImgChangeBLL();
        
        public string PreNotice { get; set; }
        public string PreNews { get; set; }
        public string PreFile { get; set; }
        public string PreTopic { get; set; }
        public string PrePic { get; set; }
        public string PreImg { get; set; }
        public string tzgg_Recent { get; set; }
        public string tzgg_Early { get; set; }
        public string xwdt_toutiao { get; set; }
        public string xwdt_recent { get; set; }
        public string xwdt_pic { get; set; }
        public string ztzx_early { get; set; }
        public string zdwj_recent { get; set; }
        public string zdwj_common { get; set; }
        public string zdwj_early { get; set; }
        public string fwzn_guide { get; set; }
        public string fwzn_download { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PreNotice = LoadFiveNotice();
            PreNews = LoadSevenNews();
            PreFile = LoadFourFile();
            PreTopic = LoadThreeTopic();
            PreImg = LoadIndexImage();
            PrePic = LoadThreeImage();
            tzgg_Recent = LoadRecentNotice();
            tzgg_Early = LoadEarlyNotice();
            xwdt_toutiao = LoadToutiaoNews();
            xwdt_recent = LoadRecentManu();
            ztzx_early = LoadEarlyTopic();
            zdwj_common = LoadCommonFile();
            zdwj_recent = LoadRecentFile();
            zdwj_early = LoadEarlyFile();
            fwzn_guide = LoadSevenService();
            fwzn_download = LoadDownLoadService();
            xwdt_pic = LoadPicNews();
            
        }
        //首页大图加载
        public string LoadIndexImage()
        {
            StringBuilder sb = new StringBuilder();
            List<T_ImgChange> list=imgBll.GetList();
            sb.AppendFormat("<li style='display:block;'><a href='"+@"http://"+"{0}' target='_blank'><img src='images/banner/back1.jpg' width='990' height='340' alt='{1}'/></a><p><a href='#'>{1}</a></p></li>",list[0].C_ImgUrl,list[0].C_ImgDes);
            sb.AppendFormat("<li style='display:none;'><a href='"+@"http://"+"{0}' target='_blank'><img src='images/banner/back2.jpg' width='990' height='340' alt='{1}'/></a><p><a href='#'>{1}</a></p></li>", list[1].C_ImgUrl, list[1].C_ImgDes);
            sb.AppendFormat("<li style='display:none;'><a href='"+@"http://"+"{0}' target='_blank'><img src='images/banner/back3.jpg' width='990' height='340' alt='{1}'/></a><p><a href='#'>{1}</a></p></li>", list[2].C_ImgUrl, list[2].C_ImgDes);
            sb.AppendFormat("<li style='display:none;'><a href='"+ @"http://"+"{0}' target='_blank'><img src='images/banner/back4.jpg' width='990' height='340' alt='{1}'/></a><p><a href='#'>{1}</a></p></li>", list[3].C_ImgUrl, list[3].C_ImgDes);
            return sb.ToString();
        }
        //预加载通知公告
        public string LoadFiveNotice()
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetNoticeModelListByNum(5, 1);
            foreach (T_stuplazaArticle model in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_noticeDetail.aspx?articleid={1}' newid='{1}' target='_blank' title='{2}'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle); 
            }
            return sb.ToString();
        }
        //预加载新闻列表
        public string LoadSevenNews()
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetNoticeModelListByNum(7, 2);
            foreach (T_stuplazaArticle model in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_newsDetail.aspx?articleid={1}' newid='{1}' target='_blank' title='{2}'>{2}</a></li>", model.ArticleTime, model.ArticleId, model.ArticleTitle);
            }
            return sb.ToString();
        }
        //预加载文件列表
        public string LoadFourFile()
        {
            List<T_stuplazaFile> list=fileBll.GetPreNumList(4);
            StringBuilder sb = new StringBuilder();
            foreach (var model in list)
            {
                
                sb.AppendFormat("<li><a href='stuplaza_filecomDetail.aspx?fileid={0}' target='_blank' title='{2}'>{1} | {2}</a></li>",model.FileId,model.FileSector,model.FileSummary );
            }
            return sb.ToString();

        }
        //预加载专题
        public string LoadThreeTopic() 
        {
            List<T_stuplazaTopic> list = topicBll.GetListByTotal(3);
            StringBuilder sb = new StringBuilder();
            
            foreach (var model in list)
            {
                
                sb.AppendFormat("<li><a href='stuplaza_topicList.aspx?topicid={1}' target='_blank'>{0}</a></li>",model.TopicTitle,model.TopicId);
            }
            return sb.ToString();
        }
        //预加载图片
        public string LoadThreeImage()
        {
            List<T_stuplazaArticle> list=bll.GetListByContent();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var model in list)
            {
                i++;
                if(i<=3)
                {
                sb.AppendFormat("<a href='stuplaza_newsDetail.aspx?articleid={0}' target='_blank'>{1}</a>", model.ArticleId, model.ArticleContent);
                }
            }
            return sb.ToString();
        }
        //通知公告栏最近公告
        public string LoadRecentNotice()
        {
            List<T_stuplazaArticle> list = bll.GetNoticeModelListByNum(5, 1);
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var model in list)
            {
                i++;
                sb.AppendFormat("<div class='list'><div class='date'><span class='day'>{0}</span><span class='month'>{1}</span></div><div class='info'><div class='caption' style='font:'微软雅黑''>{2}</div><p><a href='stuplaza_noticeDetail.aspx?articleid={5}' target='_blank' id='anno{4}'>{3}</a></p></div></div>", model.ArticleTime.Substring(model.ArticleTime.LastIndexOf('-') + 1, 2), model.ArticleTime.Substring(0, 7).Replace('-', ','), model.ArticleTitle, Regex.Replace(model.ArticleContent,@"<.*?>",""), i,model.ArticleId);
            }
            return sb.ToString();
        }
        //通知公告栏早期公告
        public string LoadEarlyNotice()
        {
            List<T_stuplazaArticle> list = bll.GetListByIndexCategory(5, 12, 1);
            StringBuilder sb = new StringBuilder();

            foreach (var model in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_noticeDetail.aspx?articleid={2}' newsid='{2}' target='_blank' title=''>{1}</a></li>", model.ArticleTime, model.ArticleTitle, model.ArticleId);
            }
            return sb.ToString();
        }
        //新闻动态头条
        public string LoadToutiaoNews() 
        {
            List<T_stuplazaArticle> list =bll.GetNoticeModelListByNum(3,2);
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var model in list)
            {
                i++;
                sb.AppendFormat("<div class='toutiao'><div class='date'><span class='day'>{0}</span><span class='month'>{1}</span></div><div class='info'><div class='caption'>{2}</div><p><a href='stuplaza_newsDetail.aspx?articleid={5}' target='_blank' id='topline{3}'>{4}</a></p></div></div>", model.ArticleTime.Substring(model.ArticleTime.LastIndexOf('-') + 1, 2), model.ArticleTime.Substring(0, 7).Replace('-', ','), model.ArticleTitle, i, Regex.Replace(model.ArticleContent, "<.*?>", ""),model.ArticleId);
            }
            return sb.ToString();
        }
        //图说新闻
        public string LoadPicNews()
        {
            List<T_stuplazaArticle> list = bll.GetListByContent();
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var model in list)
            {
                i++;
                if (i <= 4)
                {
                    sb.AppendFormat("<a href='stuplaza_newsDetail.aspx?articleid={0}' target='_blank'>{1}</a>", model.ArticleId, model.ArticleContent);
                }
            }
            return sb.ToString();
        }
        //新闻动态最近
        public string LoadRecentManu()
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaManuScript> list =manuBll.GetListByNum(6);
            foreach (T_stuplazaManuScript model in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_manuDetail.aspx?manuid={1}' target='_blank' title='{2}'>【{3}】{2}</a></li>",model.ManuScriptTime,model.ManuScriptId,model.ManuScriptTitle,model.ManuScriptAcademy);
            }
            return sb.ToString();
        }
        //专题加载
        public string LoadEarlyTopic() 
        {
            List<T_stuplazaTopic> list = topicBll.GetListByTotal(3);
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var model in list)
            {
                i++;
                sb.AppendFormat("<div class='special'><a href='stuplaza_topicList.aspx?topicid={0}' target='_blank' class='img'><img src='{1}' width='310' height='120'  alt='{2}'/></a><div class='text'><div class='title'><span>{2}</span> <img src='images/cont_main/ztzx/underline.png'/></div><p><a href='stuplaza_topicList.aspx?topicid={0}' target='_blank' id='topic{4}'>{3}</a></p></div></div>", model.TopicId, model.TopicFileName, model.TopicTitle, model.TopicSummary, i);
            }
            return sb.ToString();
        }
        //制度文件最近
        public string LoadRecentFile() 
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = fileBll.GetListByTime(8);
            foreach (T_stuplazaFile model in list)
            {
                sb.AppendFormat(" <li><a href='stuplaza_filecomDetail.aspx?fileid={0}' target='_blank' fileid='{0}'>{1}</a></li>", model.FileId, model.FileName);
            }
            return sb.ToString();
        }
        //制度文件最热
        public string LoadCommonFile()
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = fileBll.GetListByNumOrderByDow(2);
            foreach (T_stuplazaFile model in list)
            {
                sb.AppendFormat(" <li><a href='stuplaza_filecomDetail.aspx?fileid={0}' target='_blank' fileid='{2}'>{1}</a></li>", model.FileId, model.FileName, model.FileId);
            }
            return sb.ToString();
        }
        //制度文件早期
        public string LoadEarlyFile() 
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = fileBll.GetListByIndexCategory(7, 12);
            foreach (T_stuplazaFile model in list)
            {
                sb.AppendFormat(" <li><a href='stuplaza_filecomDetail.aspx?fileid={0}' target='_blank'>{1}</a></li>", model.FileId, model.FileName);
            }
            return sb.ToString();
        }
        //服务指南
        public string LoadSevenService() 
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaArticle> list = bll.GetNoticeModelListByNum(7, 3);
            foreach (T_stuplazaArticle model in list)
            {
                sb.AppendFormat("<li><a href='stuplaza_serviceDetail.aspx?articleid={0}' target='_blank' title='{1}'>{1}</a></li>", model.ArticleId, model.ArticleTitle);
            }
            return sb.ToString();
        }
        //服务指南常用下载
        public string LoadDownLoadService() 
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = fileBll.GetListByNumOrderByDow(9);
            foreach (T_stuplazaFile model in list)
            {
                sb.AppendFormat(" <li><a href='stuplaza_fileDetail.aspx?fileid={0}' target='_blank' fileid='{0}'>{1}</a></li>", model.FileId, model.FileName );
            }
            return sb.ToString();
        }
        

    }
}