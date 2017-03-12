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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            }
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            string pwd = txt_Pwd.Text.ToString().Trim();
            if (pwd.Length >= 8)
            {
                string name = txt_UserName.Text.ToString().Trim();
                string tel = txt_Tel.Text.ToString().Trim();
                string email = txt_Email.Text.ToString().Trim();
                //稿件审核员
                if (ddl_Category.SelectedValue.ToString().Trim() == "02")
                {

                    ddl_Sector.Visible = false;
                    UserLoginBLL bll = new UserLoginBLL();
                    string getId = bll.GetReviewerId().Substring(8,2);
                    int intId = Convert.ToInt32(getId) + 1;
                    string id;
                    if (intId >= 10)
                        id = "Reviewer" + Convert.ToString(intId);
                    else
                    {   id = "Reviewer0" + Convert.ToString(intId);
                       
                    }
                    try
                    {
                        T_stuplazaReviewer model = new T_stuplazaReviewer();
                        model.ReviewerAccount = id;
                        model.ReviewerPwd = pwd;
                        model.ReviewerName = name;
                        model.ReviewerTel = tel;
                        model.ReviewerEmail = email;
                        if (bll.InsertReviewer(model) >= 0)
                        {
                            Response.Redirect("ShowUser.aspx");
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                //系统管理员
                else if (ddl_Category.SelectedValue.ToString().Trim() == "03")
                {
                    ddl_Sector.Visible = false;
                    UserLoginBLL bll = new UserLoginBLL();
                    int category = 0;
                    string id;
                    string getId = bll.GetSysAdminId().Substring(7, 2);
                    int intId = Convert.ToInt32(getId) + 1;
                    if (intId >= 10)
                    {
                        id = "Admin00" + Convert.ToString(intId);
                    }
                    else
                    {
                        id = "Admin000" + Convert.ToString(intId);
                    }
                    try
                    {
                        T_stuplazaSysAdmin model = new T_stuplazaSysAdmin();
                        model.SysAdminAccount = id;
                        model.SysAdminPwd = pwd;
                        model.SysAdminName = name;
                        model.SysAdminCategory = category;
                        model.SysAdminTel = tel;
                        model.SysAdminEmail = email;
                        if (bll.InsertSysAdmin(model) >= 0)
                        {
                            Response.Redirect("ShowUser.aspx");
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                //信息发布员
                else if (ddl_Category.SelectedValue.ToString().Trim() == "00")
                {
                    ddl_Sector.Visible = false;
                    UserLoginBLL bll = new UserLoginBLL();
                    int category = 0;
                    string id;
                    string getId = bll.GetInfoAdminId("00", "").Substring(6, 2);
                    int intId = Convert.ToInt32(getId) + 1;
                    if (intId >= 10)
                    {
                        id = "whut00" + Convert.ToString(intId);
                    }
                    else
                    {
                        id = "whut000" + Convert.ToString(intId);
                    }
                    try
                    {
                        T_stuplazaInfoAdmin model = new T_stuplazaInfoAdmin();
                        model.InfoAdminAccount = id;
                        model.InfoAdminPwd = pwd;
                        model.InfoAdminName = name;
                        model.InfoAdminCategory = category;
                        model.InfoAdminSector = "综合办公室";
                        model.InfoAdminTel = tel;
                        model.InfoAdminEmail = email;
                        if (bll.InsertInfoAdmin(model) >= 0)
                        {
                            Response.Redirect("ShowUser.aspx");
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
                else if (ddl_Category.SelectedValue.ToString().Trim() == "01")
                {
                    ddl_Sector.Visible = true;
                    UserLoginBLL bll = new UserLoginBLL();
                    int category = 1;
                    string id;
                    string sector = getSector(ddl_Sector.SelectedValue);
                    string getId = bll.GetInfoAdminId("01", sector).Substring(6,2);
                    int intId = Convert.ToInt32(getId) + 1;
                    if (intId >= 10)
                    {
                        id = "whut" + sector + Convert.ToString(intId);
                    }
                    else
                    {
                        id = "whut" + sector + "0" + Convert.ToString(intId);
                    }
                    try
                    {
                        T_stuplazaInfoAdmin model = new T_stuplazaInfoAdmin();
                        model.InfoAdminAccount = id;
                        model.InfoAdminPwd = pwd;
                        model.InfoAdminName = name;
                        model.InfoAdminCategory = category;
                        model.InfoAdminSector = ddl_Sector.SelectedValue.ToString().Trim();
                        model.InfoAdminTel = tel;
                        model.InfoAdminEmail = email;
                        if (bll.InsertInfoAdmin(model) >= 0)
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
            else 
            {
                error.Text = "（*密码的长度要求至少8位）";
            }
            }
        public string getSector(string sector)
        {
            string str = "";
            switch (sector)
            {
                case "学生教育办公室(学生)": str ="01"; break;
                case "学生管理办公室(日常)": str ="02"; break;
                case "学生资助与服务中心(资助)": str ="03"; break;
                case "学生资助与服务中心(住宿、勤工助学)": str = "04"; break;
                case "学生教育办公室(辅导员)": str ="05"; break;
                case "心理健康教育中心": str ="06"; break;
                case "招生办公室": str ="07"; break;
                case "学生管理办公室(就业)": str ="08"; break;
                case "武装部": str = "09"; break;
                case "团委": str = "10"; break;
                default: break;
            }
            return str;
        }
        }
    }
 