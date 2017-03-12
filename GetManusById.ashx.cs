using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using whut.stuplaza.BLL;

namespace whut.stuplaza.UI
{
    /// <summary>
    /// GetManusById 的摘要说明
    /// </summary>
    public class GetManusById : IHttpHandler
    {
        MenuScriptBLL bll = new MenuScriptBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string  id =context.Request["id"] ?? "20150802001";
            
            var news = bll.GetModelById(id);

            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            string strJson = javaScriptSerializer.Serialize(news);
            context.Response.Write(strJson);
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