using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class EditArticle : System.Web.UI.Page
    {
        public  T_stuplazaArticle model { get; set; }
        public string topicBind { get; set; }
        ArticleBLL bll = new ArticleBLL();
        TopicBLL topic=new TopicBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request["editid"] ?? "00000000";
                model = bll.GetArticleById(id);
                if (model.topic == null)
                {
                    model.topic = new T_stuplazaTopic();
                    model.topic.TopicId = 0;
                    topicBind += "<option value='" + model.topic.TopicId + "'>" +"未设置专题"+ "</option>";
                }
                
                if (model.topic.TopicId!=0)
                {
                  
                    int topicId=model.topic.TopicId;
                    string topicName=topic.GetTopicNameById(topicId);
                    topicBind += "<option value='" + model.topic.TopicId + "'>" + topicName + "</option>";
                }
                    List<T_stuplazaTopic> list = topic.GetAllTopicInfo();
                    foreach (var model2 in list)
                    {
                        topicBind += "<option value='" + model2.TopicId + "'>" + model2.TopicTitle + "</option>";
                   
                    
                }
            }

            
            //else//点击了修改按钮，把表单中数据拿到然后修改到数据库里面去。
            //{
            //    string id =Request["hidid"] ?? "00000000";
            //    var editingNews = bll.GetArticleById(id);
            //    editingNews.ArticleTitle = Request["title"];
            //    editingNews.ArticleContent = Request["txtcontent"];
            //    editingNews.ArticlePostStaff = Request["poststaff"];
                
            //    bll.Update(editingNews);

            //    Response.Redirect("ShowArticle.aspx");
            //}
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string id = Request["editid"] ?? "00000000";
            var editingNews = bll.GetArticleById(id);
            editingNews.ArticleTitle = Request["title"].ToString().Trim();
            editingNews.ArticleContent = Request["txtcontent"].ToString().Trim();
            if ((Request["select1"] != "")&&(Request["select1"]!="0"))
                editingNews.topic.TopicId = int.Parse(Request["select1"]);
            bll.Update(editingNews);

            Response.Redirect("ShowArticle.aspx");
        }
    }
}