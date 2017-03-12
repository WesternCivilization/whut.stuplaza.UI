using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// loadAllColumn 的摘要说明
    /// </summary>
    public class loadAllColumn : IHttpHandler
    {
        ColumnBLL bll = new ColumnBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string selectValue = context.Request["selectValue"].ToString();
            List<T_stuplazaColumn> list= new List<T_stuplazaColumn>();
            list = bll.GetColListByParent(selectValue);
            JavaScriptSerializer java = new JavaScriptSerializer();
            string str = java.Serialize(list);
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}