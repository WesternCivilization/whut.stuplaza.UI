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
    public partial class EditColumn : System.Web.UI.Page
    {
        public T_stuplazaColumn model { get; set; }
        ColumnBLL bll = new ColumnBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["editid"].ToString().Trim();
            model = bll.GetModelById(id);
            if (!IsPostBack)
            {
                txt_Id.Text = model.ColumnId.ToString().Trim();
                txt_Name.Text = model.ColumnName.ToString().Trim();
                txt_ColumnContent.Text = model.ColumnContent.ToString().Trim();
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            model.ColumnName = txt_Name.Text.ToString().Trim();
            model.ColumnContent = txt_ColumnContent.Text.ToString().Trim();
            try
            {
                if (bll.Update(model))
                {
                    Response.Redirect("ShowColumn.aspx");
                }
            }
            catch
            {
                throw;
            }  
        }
    }
}