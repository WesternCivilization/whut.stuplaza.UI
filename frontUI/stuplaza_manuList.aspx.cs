using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    public partial class stuplaza_manuList : System.Web.UI.Page
    {
        public string ListPage { get; set; }
        public string NavHtml { get; set; }
       MenuScriptBLL bll = new MenuScriptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;
            ListPage = GetListByPage(pageIndex, pageSize, out total);
            NavHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
           


        }
        public string GetListByPage(int pageIndex, int pageSize, out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaManuScript> list = new List<T_stuplazaManuScript>();
            list = bll.GetListByPageManager(pageIndex, pageSize, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                        sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_manuDetail.aspx?manuid={1}' target='_blank' title=''>【{2}】{3}</a></li>", model.ManuScriptTime, model.ManuScriptId, model.ManuScriptAcademy, model.ManuScriptTitle);       
                }
            }
            return sb.ToString();

        }
    }
}