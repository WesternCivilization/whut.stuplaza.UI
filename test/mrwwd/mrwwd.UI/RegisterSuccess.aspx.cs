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
    public partial class RegisterSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Request.QueryString["radioValue"];

            string[] userInfo = str.Split(new char[] { ' ' });
            string name = userInfo[0];
            string phoneNumber = userInfo[1];
            //string city = SqlDataSource1.ToString();
            string placeParent = userInfo[2];
            string placeId = userInfo[3];

            UserBLL bll = new UserBLL();
            T_user userModel = new T_user();
            userModel.C_UserOpenId = Session["openId"].ToString();
            userModel.C_UserName = name;
            userModel.C_UserPhone = phoneNumber;
            userModel.C_UserPlaceId = placeId;
            userModel.C_UserFirstLogin = DateTime.Now.ToString("yyyy-MM-dd");
            userModel.C_UserTotalRightNum = 0;
            userModel.C_UserTotalAnswerNum = 0;
            userModel.C_UserAnswerDays = 0;




            if (bll.UserRegister(userModel))
            {
                Response.Redirect("RegisterSuccess.html");
            }
            else
            {
                Response.Redirect("error.html");
            }
        }
    }
}