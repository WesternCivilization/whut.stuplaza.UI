using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace mrwwd.UI
{
    /// <summary>
    /// GetQuestionAnswer 的摘要说明
    /// </summary>
    public class GetQuestionAnswer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            string answer = context.Request.QueryString["selectValue"];
            string[] Answers = answer.Split(new char[] { ' ' }); // 得到6道选择题答案
            for (int i = 0; i < 6; i++)
            {

            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}