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
    public partial class ReviewManuNo : System.Web.UI.Page
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public List<T_stuplazaManuScript> list { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                this.Repeater1.DataSource = bll.GetListByStatus(pageIndex, pageSize, out total);
                this.Repeater1.DataBind();
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
               
            }
        }


        public string CheckManuScriptStatus(object ManuScriptStatus)
        {
            try
            {
                int status = Convert.ToInt32(ManuScriptStatus);
                string str = "";
                switch (status)
                {
                    case 0: str = "未审核"; break;
                    case 2: str = "审核未通过"; break;
                    default: str = "审核通过"; break;
                }
                return str;
            }
            catch
            {
                throw;
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString().Trim() == "Delete")
            {
                string id = e.CommandArgument.ToString().Trim();
                bll.Delete(id);
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                this.Repeater1.DataSource = bll.GetListByStatus(pageIndex, pageSize, out total);
                this.Repeater1.DataBind();
                this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }

          }
        }
    }
 