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
    public partial class EditReviewer : System.Web.UI.Page
    {
        public T_stuplazaReviewer model { get; set; }
        UserLoginBLL bll = new UserLoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["editid"].ToString().Trim();
                model = bll.GetReviewer(id);
                txt_Id.Text = model.ReviewerAccount.ToString().Trim();
                txt_Pwd.Text = model.ReviewerPwd.ToString().Trim();
                txt_Name.Text = model.ReviewerName.ToString().Trim();
                txt_Tel.Text = model.ReviewerTel.ToString().Trim();
                txt_Email.Text = model.ReviewerEmail.ToString().Trim();
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string id = txt_Id.Text.ToString();
            string pwd = txt_Pwd.Text.ToString().Trim();
            string name = txt_Name.Text.ToString().Trim();
            string tel = txt_Tel.Text.ToString().Trim();
            string email = txt_Email.Text.ToString().Trim();
            try
            {
                T_stuplazaReviewer model = new T_stuplazaReviewer();
                model.ReviewerAccount =id;
                model.ReviewerPwd = pwd;
                model.ReviewerName = name;
                model.ReviewerTel = tel;
                model.ReviewerEmail = email;
                if (bll.UpdateReviewer(model))
                {
                    Response.Redirect("ShowUser.aspx");
                }
            }
            catch
            {
                throw;
            }  
        }
    }
}