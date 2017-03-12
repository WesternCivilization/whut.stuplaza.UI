using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.MODEL;
using whut.stuplaza.BLL;


namespace whut.stuplaza.UI
{
    public partial class LoginSystem : System.Web.UI.Page
    {
        BLL.UserLoginBLL bll = new UserLoginBLL();  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){ }
        }

        //登录函数
        whut.stuplaza.BLL.UserLoginBLL  userBLL =new UserLoginBLL();
        BLL.LoginError result;
        
        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (rb_admin.SelectedIndex==0)
            {
              result=userBLL.CheckLoginError(admin.Text.Trim(), password.Text.Trim(),1);
              
            }

            else if (rb_admin.SelectedIndex == 1)
           {
            result = userBLL.CheckLoginError(admin.Text.Trim(), password.Text.Trim(), 2);
           }
            else 
           {
            result = userBLL.CheckLoginError(admin.Text.Trim(), password.Text.Trim(), 3);
            }
           switch (result)
              {
               case BLL.LoginError.Success:
                   show.Visible=false;
                   Session["Category"] = rb_admin.SelectedValue.ToString();
                   if (rb_admin.SelectedValue.ToString().Equals("信息发布者"))
                   {
                       Session["model"] = bll.GetInfoAdmin(admin.Text);
                       Session["username"] = (Session["model"] as T_stuplazaInfoAdmin).InfoAdminName;
                   }
                   else if (rb_admin.SelectedValue.ToString().Equals("稿件审核员"))
                   {
                       Session["model"] = bll.GetReviewer(admin.Text);
                       Session["username"] = (Session["model"] as T_stuplazaReviewer).ReviewerName;
                   }
                   else
                   {
                       Session["model"] = bll.GetSysAdmin(admin.Text);
                       Session["username"] = (Session["model"] as T_stuplazaSysAdmin).SysAdminName;
                   }
                   
                   Response.Redirect("default.aspx");
                   break;
               case BLL.LoginError.UserNotExists:
                   show.Visible=true;
                   show.Text = "您的用户名不存在";
                   break;
               case BLL.LoginError.ErrorPassword:
                   show.Visible=true;
                   show.Text = "您填写的密码错误";
                   break;
              } 
         }

        
    }
}
 