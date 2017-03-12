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
    public partial class EditInfoAdmin : System.Web.UI.Page
    {
        public T_stuplazaInfoAdmin model { get; set; }
        UserLoginBLL bll = new UserLoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string id = Request["editid"].ToString().Trim();
                model = bll.GetInfoAdmin(id);
                txt_Id.Text = model.InfoAdminAccount.ToString().Trim();
                txt_Pwd.Text = model.InfoAdminPwd.ToString().Trim();
                txt_Name.Text = model.InfoAdminName.ToString().Trim();
                txt_Sector.Text = model.InfoAdminSector.ToString().Trim();
                txt_Category.Text =GetCategory(model.InfoAdminCategory.ToString().Trim());
                txt_Tel.Text = model.InfoAdminTel.ToString().Trim();
                txt_Email.Text = model.InfoAdminEmail.ToString().Trim();
            
            }
        }
        //获取发布员级别
        public string GetCategory(string s) { 
            string category="";
            if (s == "1")
            {
                category = "普通发布员";
            }
            else {
                category = "超级发布员";
            }
            return category;
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
                T_stuplazaInfoAdmin model = new T_stuplazaInfoAdmin();
                model.InfoAdminAccount = id;
                model.InfoAdminPwd = pwd;
                model.InfoAdminName = name;
                model.InfoAdminTel = tel;
                model.InfoAdminEmail = email;
                if (bll.UpdateInfoAdmin(model))
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