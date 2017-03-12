using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace uploadfile
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
            // Context.Response.ContentType = "text/plain";
            //Context.Response.Charset = "utf-8";

            HttpPostedFile file = Context.Request.Files["Filedata"];
            string uploadPath =
                HttpContext.Current.Server.MapPath(@Context.Request["folder"]) + "\\";

            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + file.FileName);
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                Context.Response.Write("1");
            }
            else
            {
                Context.Response.Write("0");
            }  
            }
        }

    
        
    }
}