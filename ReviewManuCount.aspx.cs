using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;

namespace whut.stuplaza.UI
{
    public partial class ReviewManuCount : System.Web.UI.Page
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = bll.GetTableByTime("2014-01-01 00:00:00.000", "2050-01-01 00:00:00.000");
                
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string begintime = Request.Form["ctl00$CPH1$act_start_time"];
            string endtime = Request.Form["ctl00$CPH1$act_stop_time"];
            this.Repeater1.DataSource = bll.GetTableByTime(begintime, endtime);
            this.Repeater1.DataBind();

        }
    }
}