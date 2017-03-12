using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI.frontUI
{
    public partial class stuplaza_FirstColStatic : System.Web.UI.Page
    {
        public T_stuplazaColumn col{ get; set; }
        public string  nav { get; set; }
        public string StaticTitle { get; set; }
        ColumnBLL bll = new ColumnBLL();
        ArticleBLL article = new ArticleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["columnid"] != null)
            {
                string columnId = Request["columnid"];
                nav = GenerateNav(columnId);
                col = GenerateContent(columnId);
                StaticTitle = bll.GetModelById(columnId).ColumnName;
            }
            else
            {
                Response.Redirect("error.html");
            }
        }

        ///地图导航
        public string GenerateNav(string columnId) 
        {
            StringBuilder sb = new StringBuilder();
            int flag = (columnId.TrimEnd('0').Length + 1) / 2;
            T_stuplazaColumn model = new T_stuplazaColumn();
            string columnid2 = "";
            model = bll.GetModelById(columnId);
            columnid2 = columnId.Substring(0, 4);
            T_stuplazaColumn model2 = new T_stuplazaColumn();
            model2 = bll.GetModelById(columnid2 + "0000");
            switch (flag)
            {
                case 2: sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}' target='_self'>{2}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={0}' target='_self'>{1}</a>", model.ColumnId, model.ColumnName, model.ColumnParent); break;
                case 3: 
                    sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}' target='_self'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}' target='_self'>{1}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={2}' target='_self'>{3}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnId,model.ColumnName); break;
                case 4: if (model.ColumnStatus == 1)
                    {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColDynmic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                    }
                    else
                    {
                        sb.AppendFormat("<span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={0}'>{0}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={1}'>{1}</a><span>></span><a href='stuplaza_FirstColumn.aspx?firstcolumn={2}'>{2}</a><span>></span><a href='stuplaza_FirstColStatic.aspx?columnid={3}'>{4}</a>", model2.ColumnParent, model2.ColumnName, model.ColumnParent, model.ColumnId, model.ColumnName);
                    } break;

            }
            return sb.ToString();
        }
        public T_stuplazaColumn GenerateContent(string columnId)
        {
            T_stuplazaColumn col = bll.GetModelById(columnId);
            return col;
        }
    }
}