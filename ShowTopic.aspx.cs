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
    public partial class ShowTopic : System.Web.UI.Page
    {
        public List<T_stuplazaTopic> list{ get; set;}
        TopicBLL bll = new TopicBLL(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = bll.GetAllTopicInfo();
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {   //删除
            if (e.CommandName.ToString().Trim()=="Delete") {
               bll.DeleteTopic(e.CommandArgument.ToString());
               Repeater1.DataSource = bll.GetAllTopicInfo();
               Repeater1.DataBind();
            }
               //修改
            else if (e.CommandName.ToString().Trim() == "Update") {
                string topicId=e.CommandArgument.ToString().Trim();
                Response.Redirect("EditTopic.aspx?editId=" + topicId);
            }
           
        }
    }
}