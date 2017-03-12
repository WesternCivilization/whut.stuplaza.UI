using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class ShowUser : System.Web.UI.Page
    {
        UserLoginBLL bbl = new UserLoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                rpt_SysAdmin.DataSource = bbl.GetAllSysAdmin();
                rpt_SysAdmin.DataBind();
                rpt_InfoAdmin.DataSource = bbl.GetAllInfoAdmin();
                rpt_InfoAdmin.DataBind();
                rpt_Reviewer.DataSource = bbl.GetAllReviewer();
                rpt_Reviewer.DataBind();
            }
        }

        protected void rpt_SysAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString().Trim() == "Update")
            {
                string sysAdminId = e.CommandArgument.ToString().Trim();
                Response.Redirect("EditSysAdmin.aspx?editId=" + sysAdminId);
            }
            else if(e.CommandName.ToString().Trim()=="Delete"){
                string sysAdminId = e.CommandArgument.ToString().Trim();
                bbl.DeleteSysAdmin(sysAdminId);
                rpt_SysAdmin.DataSource = bbl.GetAllSysAdmin();
                rpt_SysAdmin.DataBind();
            }
        }

        protected void rpt_InfoAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString().Trim() == "Update")
            {
                string inforAdminId = e.CommandArgument.ToString().Trim();
                Response.Redirect("EditInfoAdmin.aspx?editId=" + inforAdminId);
            }
            else if (e.CommandName.ToString().Trim() == "Delete")
            {
                string inforAdminId = e.CommandArgument.ToString().Trim();
                bbl.DeleteInfoAdmin(inforAdminId);
                rpt_InfoAdmin.DataSource = bbl.GetAllInfoAdmin();
                rpt_InfoAdmin.DataBind();
            }
        }

        protected void rpt_Reviewer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString().Trim() == "Update")
            {
                string reviewerId = e.CommandArgument.ToString().Trim();
                Response.Redirect("EditReviewer.aspx?editId=" + reviewerId);
            }
            else if (e.CommandName.ToString().Trim() == "Delete") {
                string sysReviewer  = e.CommandArgument.ToString().Trim();
                bbl.DeleteReviewer(sysReviewer);
                rpt_Reviewer.DataSource = bbl.GetAllReviewer();
                rpt_Reviewer.DataBind();
            }
        }
        protected string GetPwd(object pwd) {
            StringBuilder password = new StringBuilder();
            string p = (string)pwd;
            for(int i=0;i<p.Length;i++){
                password.Append("*");
            }
            string returnPwd = password.ToString();
            return  returnPwd;

        }
    }
}