using mrwwd.BLL;
using mrwwd.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mrwwd.UI
{
    public partial class todayQuestion : System.Web.UI.Page
    {
        public string Ques1 { get; set; }
        public string Ques1Id { get; set; }
        public string Answer11 { get; set; }
        public string Answer12 { get; set; }
        public string Answer13 { get; set; }
        public string Answer14 { get; set; }
        public string Answer01 { get; set; }
        public string UserAnswer01 { get; set; }
        public string Ques2 { get; set; }
        public string Ques2Id { get; set; }
        public string Answer21 { get; set; }
        public string Answer22 { get; set; }
        public string Answer23 { get; set; }
        public string Answer24 { get; set; }
        public string Answer02 { get; set; }
        public string UserAnswer02 { get; set; }
        public string Ques3 { get; set; }
        public string Ques3Id { get; set; }
        public string Answer31 { get; set; }
        public string Answer32 { get; set; }
        public string Answer33 { get; set; }
        public string Answer34 { get; set; }
        public string Answer03 { get; set; }
        public string UserAnswer03 { get; set; }
        public string Ques4 { get; set; }
        public string Ques4Id { get; set; }
        public string Answer41 { get; set; }
        public string Answer42 { get; set; }
        public string Answer43 { get; set; }
        public string Answer44 { get; set; }
        public string Answer04 { get; set; }
        public string UserAnswer04 { get; set; }
        public string Ques5 { get; set; }
        public string Ques5Id { get; set; }
        public string Answer51 { get; set; }
        public string Answer52 { get; set; }
        public string Answer53 { get; set; }
        public string Answer54 { get; set; }
        public string Answer05 { get; set; }
        public string UserAnswer05 { get; set; }
        public string Ques6 { get; set; }
        public string Ques6Id { get; set; }
        public string Answer61 { get; set; }
        public string Answer62 { get; set; }
        public string Answer63 { get; set; }
        public string Answer64 { get; set; }
        public string Answer06 { get; set; }
        public string UserAnswer06 { get; set; }
        public string Ques7 { get; set; }
        public string Ques7Id { get; set; }
        public string Answer07 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["openId"] == null)
                {
                    Response.Redirect("index.aspx");
                }
            }

            LoadTodayQuestion();

            //Ques1 = LoadQuestion1();
            //Ques2 = LoadQuestion2();
            //Ques3 = LoadQuestion3();
            //Ques4 = LoadQuestion4();
            //Ques5 = LoadQuestion5();
            //Ques6 = LoadQuestion6();
            //Ques7 = LoadQuestion7();
        }


        public void LoadTodayQuestion ()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            AnswerBLL answerBLL = new AnswerBLL();

            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetHistoryQuestionByPublishTime(DateTime.Now.ToString("yyyy-MM-dd"));


            Ques1 = list[0].C_QuestionInfo;
            Answer11 = list[0].C_QuestionOptionA;
            Answer12 = list[0].C_QuestionOptionB;
            Answer13 = list[0].C_QuestionOptionC;
            Answer14 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer01 = list[0].C_QuestionAnswer;
            Ques1Id = list[0].C_QuestionId;
            UserAnswer01 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques1Id, Session["openId"].ToString());

            Ques2 = list[1].C_QuestionInfo;
            Answer21 = list[1].C_QuestionOptionA;
            Answer22 = list[1].C_QuestionOptionB;
            Answer23 = list[1].C_QuestionOptionC;
            Answer24 = list[1].C_QuestionOptionD;   // 加载选项 !!!???
            Answer02 = list[1].C_QuestionAnswer;
            Ques2Id = list[1].C_QuestionId;
            UserAnswer02 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques2Id, Session["openId"].ToString());

            Ques3 = list[2].C_QuestionInfo;
            Answer31 = list[2].C_QuestionOptionA;
            Answer32 = list[2].C_QuestionOptionB;
            Answer33 = list[2].C_QuestionOptionC;
            Answer34 = list[2].C_QuestionOptionD;   // 加载选项 !!!???
            Answer03 = list[2].C_QuestionAnswer;
            Ques3Id = list[2].C_QuestionId;
            UserAnswer03 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques3Id, Session["openId"].ToString());

            Ques4 = list[3].C_QuestionInfo;
            Answer41 = list[3].C_QuestionOptionA;
            Answer42 = list[3].C_QuestionOptionB;
            Answer43 = list[3].C_QuestionOptionC;
            Answer44 = list[3].C_QuestionOptionD;   // 加载选项 !!!???
            Answer04 = list[3].C_QuestionAnswer;
            Ques4Id = list[3].C_QuestionId;
            UserAnswer04 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques4Id, Session["openId"].ToString());

            Ques5 = list[4].C_QuestionInfo;
            Answer51 = list[4].C_QuestionOptionA;
            Answer52 = list[4].C_QuestionOptionB;
            Answer53 = list[4].C_QuestionOptionC;
            Answer54 = list[4].C_QuestionOptionD;   // 加载选项 !!!???
            Answer05 = list[4].C_QuestionAnswer;
            Ques5Id = list[4].C_QuestionId;
            UserAnswer05 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques5Id, Session["openId"].ToString());

            Ques6 = list[5].C_QuestionInfo;
            Answer61 = list[0].C_QuestionOptionA;
            Answer62 = list[0].C_QuestionOptionB;
            Answer63 = list[0].C_QuestionOptionC;
            Answer64 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer06 = list[0].C_QuestionAnswer;    // 题目答案
            Ques6Id = list[0].C_QuestionId;
            UserAnswer06 = answerBLL.GetUserAnswerByQuestionIdAndOpenId(Ques6Id, Session["openId"].ToString());

        }

        public string LoadQuestion1()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer11 = list[0].C_QuestionOptionA;
            Answer12 = list[0].C_QuestionOptionB;
            Answer13 = list[0].C_QuestionOptionC;
            Answer14 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer01 = list[0].C_QuestionAnswer;
            Ques1Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques1Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques1Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        public string LoadQuestion2()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer21 = list[0].C_QuestionOptionA;
            Answer22 = list[0].C_QuestionOptionB;
            Answer23 = list[0].C_QuestionOptionC;
            Answer24 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer02 = list[0].C_QuestionAnswer;
            Ques2Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques2Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques2Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        public string LoadQuestion3()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer31 = list[0].C_QuestionOptionA;
            Answer32 = list[0].C_QuestionOptionB;
            Answer33 = list[0].C_QuestionOptionC;
            Answer34 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer03 = list[0].C_QuestionAnswer;
            Ques3Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques3Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques3Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        public string LoadQuestion4()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer41 = list[0].C_QuestionOptionA;
            Answer42 = list[0].C_QuestionOptionB;
            Answer43 = list[0].C_QuestionOptionC;
            Answer44 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer04 = list[0].C_QuestionAnswer;
            Ques4Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques4Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques4Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        public string LoadQuestion5()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer51 = list[0].C_QuestionOptionA;
            Answer52 = list[0].C_QuestionOptionB;
            Answer53 = list[0].C_QuestionOptionC;
            Answer54 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer05 = list[0].C_QuestionAnswer;
            Ques5Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques5Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques5Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        public string LoadQuestion6()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer61 = list[0].C_QuestionOptionA;
            Answer62 = list[0].C_QuestionOptionB;
            Answer63 = list[0].C_QuestionOptionC;
            Answer64 = list[0].C_QuestionOptionD;   // 加载选项 !!!???
            Answer06 = list[0].C_QuestionAnswer;    // 题目答案
            Ques6Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
                                                    //// 题目状态改变  0为题目还未作答  1为题目今日已做 2为历史作答 3为已被加载（还未作答）  此处应为3
                                                    //if (questionBLL.UpdateQuestionStatus(Ques6Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques6Id, DateTime.Now.ToString("yyyy-MM-dd")))
                                                    //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

        // 加载题目7
        public string LoadQuestion7()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(4, 0);
            sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Answer07 = list[0].C_QuestionAnswer;
            Ques7Id = list[0].C_QuestionId;

            //if (questionBLL.UpdateQuestionStatus(Ques7Id, 1) && questionBLL.UpdateQuestionPublishTime(Ques7Id, DateTime.Now.ToString("yyyy-MM-dd")))
            //{
            return sb.ToString();
            //}
            //else
            //{
            //    return "ERROR";
            //}
        }

    }
}