using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                if (Session["model"] == null)
                {
                    Response.Redirect("LoginSystem.aspx");
                }

                else
                {
                    //不同用户操作提示
                    if (Session["Category"].ToString() == "信息发布者")
                    {
                        if ((Session["model"] as T_stuplazaInfoAdmin).InfoAdminAccount.ToString().Substring(4, 2).ToString() == "00")
                        {
                            pl_ChaoJiInfoAdmin.Visible = true;
                            pl_PuTongInfoAdmin.Visible = false;
                            pl_Reviewer.Visible = false;
                            pl_SysAdmin.Visible = false;
                        }
                        else
                        {
                            pl_ChaoJiInfoAdmin.Visible = false;
                            pl_PuTongInfoAdmin.Visible = true;
                            pl_Reviewer.Visible = false;
                            pl_SysAdmin.Visible = false;
                        }

                    }
                    else if (Session["Category"].ToString() == "稿件审核员")
                    {
                        pl_ChaoJiInfoAdmin.Visible = false;
                        pl_PuTongInfoAdmin.Visible = false;
                        pl_Reviewer.Visible = true;
                        pl_SysAdmin.Visible = false;

                    }
                    else if (Session["Category"].ToString() == "系统管理员")
                    {
                        pl_ChaoJiInfoAdmin.Visible = false;
                        pl_PuTongInfoAdmin.Visible = false;
                        pl_Reviewer.Visible = false;
                        pl_SysAdmin.Visible = true;

                    }
                }
            }
        }
      }
  }
 