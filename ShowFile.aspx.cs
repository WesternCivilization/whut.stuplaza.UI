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
    public partial class ShowFile : System.Web.UI.Page
    {
        public List<T_stuplazaFile> list{ get; set; } 
        FileBLL bll=new FileBLL(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  string sector=(Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                list = new List<T_stuplazaFile>();
                if (sector == "综合办公室")
                {
                    fileList.DataSource = bll.GetListleAll();
                }
                else
                {
                    fileList.DataSource = bll.GetListBySector((Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector);
                }
               fileList.DataBind();
               this.NavStrHtml.Text = this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }  
        }

        protected void fileList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string sector = (Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector.ToString();
            if (e.CommandName.ToString().Trim() == "Delete")
            {
                int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
                int pageSize = int.Parse(Request["pageSize"] ?? "8");
                int total = 0;
                bll.deleteFile(e.CommandArgument.ToString());
                if (sector == "综合办公室")
                {
                    fileList.DataSource = bll.GetListleAll();
                }
                else
                {
                    fileList.DataSource = bll.GetListBySector((Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector);
                }
                 fileList.DataBind();
                 this.NavStrHtml.Text = this.NavStrHtml.Text = CjsPager.ShowPageNavigate(pageSize, pageIndex, total);
            }
        }
    }
}