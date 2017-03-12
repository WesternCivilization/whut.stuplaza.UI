using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using whut.stuplaza.BLL;
namespace whut.stuplaza.UI
{
    /// <summary>
    /// loadAllTopic 的摘要说明
    /// </summary>
    public class loadAllTopic : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           
            TopicBLL topic = new TopicBLL();
            context.Response.ContentType = "text/plain";
            JavaScriptSerializer java = new JavaScriptSerializer();
            string str = java.Serialize(topic.GetAllTopicInfo());
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