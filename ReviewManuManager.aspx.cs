using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;
using whut.stuplaza.COMMON;

namespace whut.stuplaza.UI
{
    public partial class RevieweManuManager : System.Web.UI.Page
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public List<T_stuplazaManuScript> list { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
               this.Repeater1.DataSource = bll.GetListByPageManager(pageIndex, pageSize, out total);
                this.Repeater1.DataBind();
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);

            }
        }
        //返回审核状态类型

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        { 
            if(e.CommandName.ToString().Trim()=="Delete"){
            string id = e.CommandArgument.ToString().Trim();
            bll.Delete(id);
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "8");
            int total = 0;
            this.Repeater1.DataSource = bll.GetListByPageManager(pageIndex, pageSize, out total);
            this.Repeater1.DataBind();
           this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
          }
        }

        protected void btn_name_Click(object sender, EventArgs e)
        {    
            string name = txt_name.Text.ToString().Trim();
            if (name == "") { 
                 lbl_show.Text="(请输入投稿人姓名！)";
            }
            else if(name!="")
            {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "8");
            int total = 0;
            this.Repeater1.DataSource = bll.GetListByName(pageIndex, pageSize,name, out total);
            this.Repeater1.DataBind();
            this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
           }
        }

        protected void btn_title_Click(object sender, EventArgs e)
        {
            string title = txt_title.Text.ToString().Trim();
            if (title == "") { 
               lbl_show.Text = "(请输入稿件标题)";
            }
            else if (title != "") {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                this.Repeater1.DataSource = bll.GetListByTitle(pageIndex, pageSize, title, out total);
                this.Repeater1.DataBind();
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
            
        }
    }
}