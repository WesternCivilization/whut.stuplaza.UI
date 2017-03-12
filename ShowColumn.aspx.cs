using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.BLL;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class ShowColumns : System.Web.UI.Page
    {
        T_stuplazaColumn model = new T_stuplazaColumn();
        ColumnBLL bll = new ColumnBLL();
        string id = "01";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = bll.GetColumn(id);
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToString().Trim() == "Delete")
            {
                bll.delete(e.CommandArgument.ToString().Trim());

                Repeater1.DataSource = bll.GetColumn(ddl_Column.SelectedValue.ToString().Trim());
                Repeater1.DataBind();

            }
            else if (e.CommandName.ToString().Trim() == "Update") {
                string columnId = e.CommandArgument.ToString().Trim();
                Response.Redirect("EditColumn.aspx?editId=" + columnId);
            
            }
        }

        protected void ddl_Column_SelectedIndexChanged(object sender, EventArgs e)
        {
            Repeater1.DataSource = bll.GetColumn(ddl_Column.SelectedValue.ToString().Trim());
            Repeater1.DataBind();
        }
        protected  string GetGrade(object id){
            string grade="";
            if (id.ToString().Substring(0, 2) == "00") {
                grade = "未分栏";
            }
            else  if ((id.ToString().Substring(0, 2) != "00")&&(id.ToString().Substring(2, 2) == "00"))
            {
                grade = "一级栏目";
            }
            else if ((id.ToString().Substring(0, 2) != "00") && (id.ToString().Substring(2, 2) != "00") && (id.ToString().Substring(4, 2) == "00"))
            {
                grade = "二级栏目";
            }
            else if ((id.ToString().Substring(0, 2) != "00") && (id.ToString().Substring(2, 2) != "00") && (id.ToString().Substring(4, 2) != "00") && (id.ToString().Substring(6, 2) == "00")) {
                grade = "三级栏目";
            }
            else
            {
                grade = "四级栏目";
            }


            return grade;
        }
    }
}