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
    public partial class stuplaza_fileDetail : System.Web.UI.Page
    {
        public T_stuplazaFile model=new T_stuplazaFile();
        FileBLL bll=new FileBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fileid"] != "" || Request["fileid"] != null)
            {
                string id = Context.Request["fileid"];
                model = bll.GetModelById(id);
                if (model.FileName == null)
                {
                    Response.Redirect("error.html");
                }
            }
            else
            {
                Response.Redirect("error.html");
            }
        }
        public string GetFilePath(string filePath) {
            if (filePath != null)
            {
                return filePath;
            }
            else {
                Response.Redirect("error.html");
                return filePath;

            }
             
        }
    }
}