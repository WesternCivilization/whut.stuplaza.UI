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
    public partial class submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InsertAnswer();
        }

        public bool InsertAnswer()
        {
            AnswerBLL bll = new AnswerBLL();
            // 待解决！！！！！！！！！！！！
            string answer = Request.QueryString["radioValue"];

            // string answer = "B C D B C C";
            string[] Answers = answer.Split(new char[] { ' ' }); // 得到6道选择题答案
            bool[] Q = new bool[6]; // 在都为真时插入成功

            int result1, result2, result3, result4, result5, result6;
            result1 = Math.Abs(string.Compare(Answers[0], Session["Answer01"].ToString()));
            result2 = Math.Abs(string.Compare(Answers[1], Session["Answer02"].ToString()));
            result3 = Math.Abs(string.Compare(Answers[2], Session["Answer03"].ToString()));
            result4 = Math.Abs(string.Compare(Answers[3], Session["Answer04"].ToString()));
            result5 = Math.Abs(string.Compare(Answers[4], Session["Answer05"].ToString()));
            result6 = Math.Abs(string.Compare(Answers[5], Session["Answer06"].ToString()));

            int todayResult = 6 - (result1 + result2 + result3 + result4 + result5 + result6);
            UserBLL userBLL = new UserBLL();
            T_user userModel = new T_user();
            T_user oldModel = new T_user();
            oldModel = userBLL.GetUserInfoByOpenId(Session["openId"].ToString())[0];
            userModel.C_UserName = oldModel.C_UserName;
            userModel.C_UserPhone = oldModel.C_UserPhone;
            userModel.C_UserPlaceId = oldModel.C_UserPlaceId;
            userModel.C_UserFirstLogin = oldModel.C_UserFirstLogin;
            userModel.C_UserOpenId = Session["openId"].ToString();
            userModel.C_UserTodayRightNum = todayResult;
            userModel.C_UserTotalRightNum = oldModel.C_UserTotalRightNum + todayResult; // 先找到历史纪录再加上去
            userModel.C_UserAnswerDays = oldModel.C_UserAnswerDays + 1;
            userModel.C_UserLastLogin = DateTime.Now.ToString("yyyy-MM-dd");
            userModel.C_UserTotalAnswerNum = (oldModel.C_UserAnswerDays + 1) * 6;
            userModel.C_UserAccuracy = ((oldModel.C_UserTotalRightNum + todayResult) / ((oldModel.C_UserAnswerDays + 1) * 6.0)).ToString();
            userModel.C_UserRanking = userBLL.GetRankingByTotalRightNum(oldModel.C_UserTotalRightNum + todayResult);


            if(userBLL.UpdateUser(userModel))
            {

            }
            else
            {
                Response.Redirect("error.html");
            }

            // q1
            if (result1 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques1Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[0];

                Q[0] = bll.InsertAnswer(model);
            }
            else if (result1 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques1Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[0];

                Q[0] = bll.InsertAnswer(model);
            }
            // q2
            if (result2 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques2Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[1];

                Q[1] = bll.InsertAnswer(model);
            }
            else if (result2 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques2Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[1];

                Q[1] = bll.InsertAnswer(model);
            }
            // q3
            if (result3 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques3Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[2];

                Q[2] = bll.InsertAnswer(model);
            }
            else if (result3 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques3Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[2];

                Q[2] = bll.InsertAnswer(model);
            }
            // q4
            if (result4 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques4Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[3];

                Q[3] = bll.InsertAnswer(model);
            }
            else if (result4 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques4Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[3];

                Q[3] = bll.InsertAnswer(model);
            }
            // q5
            if (result5 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques5Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[4];

                Q[4] = bll.InsertAnswer(model);
            }
            else if (result5 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques5Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[4];

                Q[4] = bll.InsertAnswer(model);
            }
            // q6
            if (result6 == 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques6Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 1;
                model.C_AnswerUserAnswer = Answers[5];

                Q[5] = bll.InsertAnswer(model);
            }
            else if (result6 != 0)
            {
                T_answer model = new T_answer();
                model.C_AnswerOpenId = Session["openId"].ToString();
                model.C_AnswerQuestionId = Session["Ques6Id"].ToString();
                model.C_AnswerDate = DateTime.Now.ToString("yyyy-MM-dd");
                model.C_AnswerStatus = 0;
                model.C_AnswerUserAnswer = Answers[5];

                Q[5] = bll.InsertAnswer(model);

            }



            if (Q[0] && Q[1] && Q[2] && Q[3] && Q[4] && Q[5])
            {
                
                return true; // !!!!
            }
            else
            {
                Response.Redirect("insertAnswerFailure.html");
                return false;
            }

        }
    }
}