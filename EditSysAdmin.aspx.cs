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
    public partial class EditSysAdmin : System.Web.UI.Page
    {
        public T_stuplazaSysAdmin model { get; set; }
        UserLoginBLL bll = new UserLoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["editid"].ToString().Trim();
                model = bll.GetSysAdmin(id);
                txt_Id.Text = model.SysAdminAccount.ToString().Trim();
                txt_Pwd.Text = model.SysAdminPwd.ToString().Trim();
                txt_Name.Text = model.SysAdminName.ToString().Trim();
                txt_Tel.Text = model.SysAdminTel.ToString().Trim();
                txt_Email.Text = model.SysAdminEmail.ToString().Trim();
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string id=txt_Id.Text.ToString();
            string pwd= txt_Pwd.Text.ToString().Trim();
            string name = txt_Name.Text.ToString().Trim();
            string tel = txt_Tel.Text.ToString().Trim();
            string email = txt_Email.Text.ToString().Trim();
            try
            {
                T_stuplazaSysAdmin model = new T_stuplazaSysAdmin();
                model.SysAdminAccount =id;
                model.SysAdminPwd = pwd;
                model.SysAdminName = name;
                model.SysAdminTel = tel;
                model.SysAdminEmail = email;
                
                if (bll.UpdateSysAdmin(model))
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