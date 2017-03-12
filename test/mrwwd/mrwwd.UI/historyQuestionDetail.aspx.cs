using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mrwwd.MODEL;
using mrwwd.BLL;

namespace mrwwd.UI
{
    public partial class historyQuestionDetail : System.Web.UI.Page
    {
        public T_question QuesModel1 { get; set; }
        public T_question QuesModel2 { get; set; }
        public T_question QuesModel3 { get; set; }
        public T_question QuesModel4 { get; set; }
        public T_question QuesModel5 { get; set; }
        public T_question QuesModel6 { get; set; }
        public T_question QuesModel7 { get; set; }
        public string questionPublishTime { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                Response.Redirect("index.aspx");
            }
            else if(Session["openId"] == null)
            {
                Response.Redirect("index.aspx");
            }

            QuestionBLL bll = new QuestionBLL();

            if (Request["questionPublishTime"] != "" || Request["questionPublishTime"] != null)
            {
                questionPublishTime = Context.Request["questionPublishTime"];
                List<T_question> questionList = new List<T_question>();
                questionList = bll.GetHistoryQuestionByPublishTime(questionPublishTime);
                QuesModel1 = questionList[0];
                QuesModel2 = questionList[1];
                QuesModel3 = questionList[2];
                QuesModel4 = questionList[3];
                QuesModel5 = questionList[4];
                QuesModel6 = questionList[5];
                
                if (questionList[6] != null)
                {
                    QuesModel7 = questionList[6];
                }
                else
                {
                    QuesModel7.C_QuestionInfo = "本次没有问答题";
                    QuesModel7.C_QuestionAnswer = "本次没有问答题"; 
                }


            }
            else
            {
                Response.Redirect("error.html");
            }
        }
    }
}