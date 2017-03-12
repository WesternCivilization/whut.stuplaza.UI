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
    public partial class stuplaza_fileListBySector : System.Web.UI.Page
    {
        FileBLL bll = new FileBLL();
        public string GetList { get; set; }
        public string navHtml { get; set; }
        public string nav { get; set; }
        public string prenav { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "9");
            string sector = Request["sector"] ?? "1";
            string sector2 = ReturnSector(int.Parse(sector));
            int total = 0;
            GetList = GetListPage(pageIndex, pageSize, sector2, out total);
            navHtml = CjsPager.ShowPageNavFront(pageSize, pageIndex, total);
            prenav = "<a href='stuplaza_fileList.aspx'>文件列表</a>";
            nav = "<a href='stuplaza_fileListBySector.aspx?sector=" + int.Parse(sector) + "'>" + sector2 + "</a>";
            
        }


        //得到list
        public string GetListPage(int pageIndex, int pageSize, string sector, out int total)
        {

            StringBuilder sb = new StringBuilder();
            List<T_stuplazaFile> list = bll.GetListBySector(pageIndex, pageSize, sector, out total);
            if (list.Count > 0)
            {

                foreach (var model in list)
                {

                    sb.AppendFormat("<li><span>{0}</span><a href='stuplaza_fileDetail.aspx?fileid={2}' target='_blank' title='{1}'>{1}</a></li>", model.FileTime, model.FileName, model.FileId);   
                    
                }
            }
            return sb.ToString();
        }
        //f
        public string ReturnSector(int sectorId)
        {
            string str = "";
            switch (sectorId)
            {
                case 1: str = "学生教育办公室(学生)"; break;
                case 2: str = "学生教育办公室(辅导员)"; break;
                case 3: str = "学生管理办公室(日常)"; break;
                case 4: str = "学生管理办公室(就业)"; break;
                case 5: str = "心理健康教育中心"; break;
                case 6: str = "学生资助与服务中心(资助)"; break;
                case 7: str = "学生资助与服务中心(住宿、勤工助学)"; break;
                case 8: str = "招生办公室"; break;
                case 9: str = "武装部"; break;
                case 10: str = "团委"; break;
                case 11: str = "综合办公室"; break;
                default: break;
            }
            return str;
        }
    }
}