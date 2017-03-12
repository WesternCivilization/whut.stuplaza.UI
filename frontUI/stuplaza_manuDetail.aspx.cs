using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    public partial class stuplaza_manuDetail : System.Web.UI.Page
    {
        MenuScriptBLL bll=new MenuScriptBLL();
        public T_stuplazaManuScript model=new T_stuplazaManuScript();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["manuid"] != "" || Request["manuid"] != null)
            {
                string id = Context.Request["manuid"];

                model = bll.GetModelById(id);
                if (model.ManuScriptId == null)
                {
                    Response.Redirect("error.html");
                }
            }
            else
            {
                Response.Redirect("error.html");
            }

        }
    }
}