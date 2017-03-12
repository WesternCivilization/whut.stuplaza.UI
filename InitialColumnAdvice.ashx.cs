using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// InitialColumnAdvice 的摘要说明
    /// </summary>
    public class InitialColumnAdvice : IHttpHandler, IReadOnlySessionState
    {
        ColumnBLL bll = new ColumnBLL();
        List<T_stuplazaColumn> list = new List<T_stuplazaColumn>();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            string sector="综合管理办公室";
            if (OutPutSession(context) != null)
            {
                string session = context.Session["Category"].ToString();
            }
            if (context.Session["Category"].ToString() == "信息发布者")
            {
                sector = (context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminSector;
                if ((context.Session["model"] as T_stuplazaInfoAdmin).InfoAdminAccount.Substring(4, 2) != "00")
                {
                    string firstCol = bll.GetColumnNameBySector(sector);
                    string colId = bll.GetIdByName(firstCol);
                    list = bll.GetColumnListByFirstCol(colId);
                    JavaScriptSerializer java = new JavaScriptSerializer();
                    string str = java.Serialize(list);
                    context.Response.Write(str);
                    context.Response.End();
                }
                else
                context.Response.Write("");
                context.Response.End();
            }  
          
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public string OutPutSession(HttpContext context)
        {
            if (context.Session["Category"] != null)
                return context.Session["Category"].ToString();
            else
                return "";
        }
        
    }
}