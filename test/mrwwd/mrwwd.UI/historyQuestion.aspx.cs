using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mrwwd.MODEL;
using mrwwd.BLL;
using System.Text;

namespace mrwwd.UI
{
    public partial class historyQuestion : System.Web.UI.Page
    {
        public string listPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["openId"] == null)
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                UserBLL userBLL = new UserBLL();

                int userAnswerDays = userBLL.GetUserAnswerDays(Session["openId"].ToString());

                if (userAnswerDays < 7)
                {
                    Response.Redirect("historyQuestionNoAccess.html");
                }
                //if (Session["userAnswerDays"] != null)
                //{
                //    userAnswerDays = (int)Session["userAnswerDays"];
                //    if (userAnswerDays < 7)
                //    {
                //        Response.Redirect("hisToryQuestionNoAccess.html");
                //    }
                //}
                listPage = GetListPage();
                
            }
        }

        // 获得历史日期列表页
        public string GetListPage()
        {
            QuestionBLL bll = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = bll.GetHistoryQuestionListByAllPublishTime();
            if (list.Count > 0)
            {
                foreach (var model in list)
                {
                    // !!!!!!!!!!!!!!!
                    sb.AppendFormat("<a class='weui_cell' href='historyQuestionDetail.aspx?questionPublishTime={0}'><div class='weui_cell_bd weui_cell_primary'><p>{1}</p></div><div class='weui_cell_ft'></div></a>", model.C_QuestionPublishTime, model.C_QuestionPublishTime);
                }
            }
            return sb.ToString();
        }
    }
}