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
    public partial class System_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["account"] == null)
                {
                    Response.Redirect("LoginSystem.aspx");
                }
            }
        }

        protected void btn_UpdateQuestions_Click(object sender, EventArgs e)
        {
            // 将状态为3的题目（新的一天开始时 3 表示昨日题目 ）变为状态1（已发布）
            // 同时将后面状态为0的问题变为状态3
            QuestionBLL bll = new QuestionBLL();
            bll.UpDateStatusByStatus(3, 1);

            // 发布新题
            T_question ques1 = new T_question();
            T_question ques2 = new T_question();
            T_question ques3 = new T_question();
            T_question ques4 = new T_question();
            T_question ques5 = new T_question();
            T_question ques6 = new T_question();
            T_question ques7 = new T_question();

            List<T_question> quesCat1 = new List<T_question>();
            List<T_question> quesCat2 = new List<T_question>();
            List<T_question> quesCat3 = new List<T_question>();
            List<T_question> quesCat4 = new List<T_question>();
            quesCat1 = bll.GetQuestionModelListByCategoryAndStatus(1, 0);
            quesCat2 = bll.GetQuestionModelListByCategoryAndStatus(2, 0);
            quesCat3 = bll.GetQuestionModelListByCategoryAndStatus(3, 0);
            quesCat4 = bll.GetQuestionModelListByCategoryAndStatus(4, 0);

            ques1 = quesCat1[0];
            ques2 = quesCat1[1];
            ques3 = quesCat2[0];
            ques4 = quesCat2[1];
            ques5 = quesCat3[0];
            ques6 = quesCat3[1];
            ques7 = quesCat4[0];

            bool b1 = bll.UpdateQuestionStatus(ques1.C_QuestionId, 3);
            bool b2 = bll.UpdateQuestionStatus(ques2.C_QuestionId, 3);
            bool b3 = bll.UpdateQuestionStatus(ques3.C_QuestionId, 3);
            bool b4 = bll.UpdateQuestionStatus(ques4.C_QuestionId, 3);
            bool b5 = bll.UpdateQuestionStatus(ques5.C_QuestionId, 3);
            bool b6 = bll.UpdateQuestionStatus(ques6.C_QuestionId, 3);
            bool b7 = bll.UpdateQuestionStatus(ques7.C_QuestionId, 3);

            if ( b1 && b2 && b3 && b4 && b5 && b6 && b7)
            {
                Response.Write("题库更新成功");
            }
            else
            {
                Response.Redirect("error.html");
            }
        }
    }
}