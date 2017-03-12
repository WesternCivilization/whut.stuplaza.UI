using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mrwwd.BLL;
using mrwwd.MODEL;

namespace mrwwd.UI
{
    public partial class LoginSystem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            AdminBLL bll = new AdminBLL();
            string account = txt_AdminAccount.Text.Trim();
            string password = txt_Password.Text.Trim();
            int comp = string.Compare(password, bll.GetPasswordByAccount(account));
            if (comp == 0)
            {
                Session["account"] = account;
                Response.Redirect("System_Index.aspx");
            }
            else
            {
                Response.Redirect("LoginSystem.aspx");
            }
        }
    }
}