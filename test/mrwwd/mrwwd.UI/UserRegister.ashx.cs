using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mrwwd.MODEL;
using mrwwd.BLL;

namespace mrwwd.UI
{
    /// <summary>
    /// UserRegister 的摘要说明
    /// </summary>
    public class UserRegister : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            UserBLL bll = new UserBLL();
            T_user model = new T_user();
            model.C_UserOpenId = context.Request.QueryString["openId"];
            model.C_UserName = context.Request.QueryString["userName"];
            model.C_UserPhone = context.Request.QueryString["phoneNumber"];
            model.C_UserPlaceId = context.Request.QueryString["placeId"];

            if (bll.UserRegister(model))
            {
                context.Response.Write("注册成功<a href=index.aspx>点击返回答题</a>");
            }
            else
            {
                context.Response.Write("注册失败<a href=index.aspx>点击返回首页</a>");
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