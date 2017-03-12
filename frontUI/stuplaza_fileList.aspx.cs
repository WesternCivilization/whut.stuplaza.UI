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
    public partial class stuplaza_fileList : System.Web.UI.Page
    {
        FileBLL bll = new FileBLL();
        public string ListPage { get; set; }
        public string NavHtml { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "15");
            int total = 0;
            ListPage = GetListPage(pageIndex, pageSize, out total);
            NavHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
        }
        public string GetListPage(int pageIndex, int pageSize, out int total)
        {
            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = bll.GetListByPage(pageIndex, pageSize, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {
                    sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_fileDetail.aspx?fileid={1}' target='_blank' title=''>【{3}】{2}</a></li>", model.FileTime, model.FileId, model.FileName, model.FileSector);
                }
            }
            return sb.ToString();
        }
    }
}