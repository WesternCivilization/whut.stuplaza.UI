using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mrwwd.BLL;
using mrwwd.MODEL;
using mrwwd.COMMON;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace mrwwd.UI
{
    public partial class index : System.Web.UI.Page
    {
        QuestionBLL qestionBLL = new QuestionBLL();

        public string UserName { get; set; }

        public string Ques1 { get; set; }
        public string Ques1Id { get; set; }
        public string Answer11 { get; set; }
        public string Answer12 { get; set; }
        public string Answer13 { get; set; }
        public string Answer14 { get; set; }
        public string Answer01 { get; set; }
        public string Ques2 { get; set; }
        public string Ques2Id { get; set; }
        public string Answer21 { get; set; }
        public string Answer22 { get; set; }
        public string Answer23 { get; set; }
        public string Answer24 { get; set; }
        public string Answer02 { get; set; }
        public string Ques3 { get; set; }
        public string Ques3Id { get; set; }
        public string Answer31 { get; set; }
        public string Answer32 { get; set; }
        public string Answer33 { get; set; }
        public string Answer34 { get; set; }
        public string Answer03 { get; set; }
        public string Ques4 { get; set; }
        public string Ques4Id { get; set; }
        public string Answer41 { get; set; }
        public string Answer42 { get; set; }
        public string Answer43 { get; set; }
        public string Answer44 { get; set; }
        public string Answer04 { get; set; }
        public string Ques5 { get; set; }
        public string Ques5Id { get; set; }
        public string Answer51 { get; set; }
        public string Answer52 { get; set; }
        public string Answer53 { get; set; }
        public string Answer54 { get; set; }
        public string Answer05 { get; set; }
        public string Ques6 { get; set; }
        public string Ques6Id { get; set; }
        public string Answer61 { get; set; }
        public string Answer62 { get; set; }
        public string Answer63 { get; set; }
        public string Answer64 { get; set; }
        public string Answer06 { get; set; }
        public string Ques7 { get; set; }
        public string Ques7Id { get; set; }
        public string Answer07 { get; set; }

        public string appid = "wxf650d27b40aaa327";

        public string appSecret = "be51134f39d7a6264ab560f53aaa9f22";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            T_user userModel = new T_user();
            //// 获取用户openId并进行验证!!!!!!!!!!!!!!!!!!
            //string openId = GetOpenId();

            string openId = "112";

            Session["openId"] = openId;

            // 如果今天已经答过题 则跳转到 TodayHaveDone.html 选择查看今日题库或者历史题库
            // 根据 openId 和 日期 进行判断
            AnswerBLL answerBLL = new AnswerBLL();
            if (answerBLL.GetAnswerByOpenIdAndDate(openId,DateTime.Now.ToString("yyyy-MM-dd")).Rows.Count > 0)
            {
                Response.Redirect("TodayHaveDone.html");
            }

            // 如果是第一次答题，就先自动用openId注册之后再登记信息
            if (bll.GetUserInfoByOpenId(openId).Count <= 0)
            {
                Response.Redirect("register.aspx");
            }
            else
                userModel = bll.GetUserInfoByOpenId(openId)[0];
            UserName = userModel.C_UserName;

            bool c1 = LoadQuestionCategory1();
            bool c2 = LoadQuestionCategory2();
            bool c3 = LoadQuestionCategory3();
            bool c4 = LoadQuestionCategory4();

        }

        // 获取openId
        public string GetOpenId()
        {
            string code;
            if (Context.Request.QueryString["code"] != null)
            {
                WeiXinAccessTokenModel accessTokenModel = new WeiXinAccessTokenModel();

                code = Context.Request.QueryString["code"];
                
                string getAccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appid + "&secret=" + appSecret + "&code=" + code + "&grant_type=authorization_code";
                HttpWebRequest request = WebRequest.CreateHttp(getAccessTokenUrl);
                request.Method = "get";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                Stream s = response.GetResponseStream();
                StreamReader sr = new StreamReader(s,System.Text.Encoding.GetEncoding("utf-8"));
                string json = sr.ReadToEnd();

                accessTokenModel = JsonConvert.DeserializeObject<WeiXinAccessTokenModel>(json);
                return accessTokenModel.openid;
            }
            else
            {

                Response.Redirect("error.html");
                return "ERROR";
            }
            

        }


        // 加载题目类别1
        public bool LoadQuestionCategory1()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            //StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(1, 3);
            //sb.AppendFormat("{0}", list[0].C_QuestionInfo);

            Ques1 = list[0].C_QuestionInfo;
            Answer11 = list[0].C_QuestionOptionA;
            Answer12 = list[0].C_QuestionOptionB;
            Answer13 = list[0].C_QuestionOptionC;
            Answer14 = list[0].C_QuestionOptionD;   // 加载选项
            Answer01 = list[0].C_QuestionAnswer;
            Session["Answer01"] = Answer01;
            Ques1Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
            Session["Ques1Id"] = Ques1Id;



            Ques2 = list[1].C_QuestionInfo;
            Answer21 = list[1].C_QuestionOptionA;
            Answer22 = list[1].C_QuestionOptionB;
            Answer23 = list[1].C_QuestionOptionC;
            Answer24 = list[1].C_QuestionOptionD;
            Answer02 = list[1].C_QuestionAnswer;
            Session["Answer02"] = Answer02;
            Ques2Id = list[1].C_QuestionId;
            Session["Ques2Id"] = Ques2Id;
            // 题目状态  0为题目还未作答  1为题目已放出    3为今日题目   // 题目状态不用改变。后台设置好今日题目状态为3，每次就加载状态为3的题目
            if (questionBLL.UpdateQuestionPublishTime(Ques1Id, DateTime.Now.ToString("yyyy-MM-dd")) && questionBLL.UpdateQuestionPublishTime(Ques2Id, DateTime.Now.ToString("yyyy-MM-dd")))
            {

                return true;
            }
            else
            {
                return false;
            }            
        }


        public bool LoadQuestionCategory2()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            //StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(2, 3);
            //sb.AppendFormat("{0}", list[0].C_QuestionInfo);

            Ques3 = list[0].C_QuestionInfo;
            Answer31 = list[0].C_QuestionOptionA;
            Answer32 = list[0].C_QuestionOptionB;
            Answer33 = list[0].C_QuestionOptionC;
            Answer34 = list[0].C_QuestionOptionD;   // 加载选项
            Answer03 = list[0].C_QuestionAnswer;
            Session["Answer03"] = Answer03;
            Ques3Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
            Session["Ques3Id"] = Ques3Id;

            Ques4 = list[1].C_QuestionInfo;
            Answer41 = list[1].C_QuestionOptionA;
            Answer42 = list[1].C_QuestionOptionB;
            Answer43 = list[1].C_QuestionOptionC;
            Answer44 = list[1].C_QuestionOptionD;
            Answer04 = list[1].C_QuestionAnswer;
            Session["Answer04"] = Answer04;
            Ques4Id = list[1].C_QuestionId;
            Session["Ques4Id"] = Ques4Id;
            // 题目状态  0为题目还未作答  1为题目已放出    3为今日题目   // 题目状态不用改变。后台设置好今日题目状态为3，每次就加载状态为3的题目
            if (questionBLL.UpdateQuestionPublishTime(Ques3Id, DateTime.Now.ToString("yyyy-MM-dd")) && questionBLL.UpdateQuestionPublishTime(Ques4Id, DateTime.Now.ToString("yyyy-MM-dd")))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoadQuestionCategory3()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            //StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(3, 3);
            //sb.AppendFormat("{0}", list[0].C_QuestionInfo);

            Ques5 = list[0].C_QuestionInfo;
            Answer51 = list[0].C_QuestionOptionA;
            Answer52 = list[0].C_QuestionOptionB;
            Answer53 = list[0].C_QuestionOptionC;
            Answer54 = list[0].C_QuestionOptionD;   // 加载选项
            Answer05 = list[0].C_QuestionAnswer;
            Session["Answer05"] = Answer05;
            Ques5Id = list[0].C_QuestionId;         // 获取题目id便于更改状态
            Session["Ques5Id"] = Ques5Id;

            Ques6 = list[1].C_QuestionInfo;
            Answer61 = list[1].C_QuestionOptionA;
            Answer62 = list[1].C_QuestionOptionB;
            Answer63 = list[1].C_QuestionOptionC;
            Answer64 = list[1].C_QuestionOptionD;
            Answer06 = list[1].C_QuestionAnswer;
            Session["Answer06"] = Answer06;
            Ques6Id = list[1].C_QuestionId;
            Session["Ques6Id"] = Ques6Id;
            // 题目状态  0为题目还未作答  1为题目已放出    3为今日题目   // 题目状态不用改变。后台设置好今日题目状态为3，每次就加载状态为3的题目
            if (questionBLL.UpdateQuestionPublishTime(Ques5Id, DateTime.Now.ToString("yyyy-MM-dd")) && questionBLL.UpdateQuestionPublishTime(Ques6Id, DateTime.Now.ToString("yyyy-MM-dd")))
            {

                return true;
            }
            else
            {
                return false;
            }
        }



        

        // 加载题目7
        public bool LoadQuestionCategory4()
        {
            QuestionBLL questionBLL = new QuestionBLL();
            //StringBuilder sb = new StringBuilder();
            List<T_question> list = questionBLL.GetQuestionModelListByCategoryAndStatus(4, 3);
            //sb.AppendFormat("{0}", list[0].C_QuestionInfo);
            Ques7 = list[0].C_QuestionInfo;
            Answer07 = list[0].C_QuestionAnswer;
            Ques7Id = list[0].C_QuestionId;
            // 题目状态  0为题目还未作答  1为题目已放出    3为今日题目   // 题目状态不用改变。后台设置好今日题目状态为3，每次就加载状态为3的题目
            if (questionBLL.UpdateQuestionPublishTime(Ques7Id, DateTime.Now.ToString("yyyy-MM-dd")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

    }
}