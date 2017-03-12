using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class EditManuScript : System.Web.UI.Page
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request["manuid"] != "" && Request["manuid"] != null)
                {
                    string manuId = Request["manuid"];
                    T_stuplazaManuScript model = bll.GetModelById(manuId);
                    txt_Tiltle.Text = model.ManuScriptTitle;
                    txt_Author.Text = model.ManuScriptAuthor;
                    txtcontent.Text = model.ManuScriptContent;
                    txt_Lab.Text = model.ManuScriptId;

                }
            }
        }

        protected void txtSub_Click(object sender, EventArgs e)
        {
            string id = txt_Lab.Text;
            string title = txt_Tiltle.Text.Trim();
            string content = txtcontent.Text;
             var news =bll.GetModelById(id);
            news.ManuScriptTitle=title;
            news.ManuScriptContent = content;
            if (bll.Update(news))
                if (news.ManuScriptStatus == 0)
                {
                    Response.Redirect("ReviewManu.aspx");
                }
                else
                {
                    Response.Redirect("ReviewManuManager.aspx");
                }
           }
      }
}