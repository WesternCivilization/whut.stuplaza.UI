using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.UI
{
    public partial class stuplaza_BgIndex : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["model"] == null)
                {
                    Response.Redirect("LoginSystem.aspx");
                }
                else
                {
                    //判断用户类型
                    //信息发布人员，区分超发与普发
                    if (Session["Category"].ToString() == "信息发布者")
                    {

                        //超级发布者:专题调整、首页大图更换、稿件发布、信息发布,文件管理
                        if ((Session["model"] as T_stuplazaInfoAdmin).InfoAdminAccount.ToString().Substring(4, 2).ToString() == "00")
                        {
                            ArticleList.Visible = true;
                            ArticleAdd.Visible = true;
                            FileManager.Visible = true;
                            FileAdd.Visible = true;
                            ArticleInfo.Visible = true;
                            ArticleManager.Visible = true;
                            ArticleNo.Visible = true;
                            ArticleCount.Visible = true;
                            AdminManager.Visible = false;
                            AdminAdd.Visible = false;
                            TopicManger.Visible = true;
                            TopicAdd.Visible = true;
                            ColumnsManager.Visible = false;
                            ColumnsAdd.Visible = false;
                            PicChange.Visible = true;

                        }
                        //普通发布者
                        else
                        {
                            ArticleList.Visible = true;
                            ArticleAdd.Visible = true;
                            FileManager.Visible = true;
                            FileAdd.Visible = true;
                            ArticleInfo.Visible = false;
                            ArticleManager.Visible = false;
                            ArticleNo.Visible = false;
                            ArticleCount.Visible = false;
                            AdminManager.Visible = false;
                            AdminAdd.Visible = false;
                            TopicManger.Visible = false;
                            TopicAdd.Visible = false;
                            ColumnsManager.Visible = false;
                            ColumnsAdd.Visible = false;
                            PicChange.Visible = false;
                        }

                    }
                    //稿件审核人员:稿件发布
                    else if (Session["Category"].ToString() == "稿件审核员")
                    {

                        ArticleList.Visible = false;
                        ArticleAdd.Visible = false;
                        FileManager.Visible = false;
                        FileAdd.Visible = false;
                        ArticleInfo.Visible = true;
                        ArticleManager.Visible = true;
                        ArticleNo.Visible = true;
                        ArticleCount.Visible = true;
                        AdminManager.Visible = false;
                        AdminAdd.Visible = false;
                        TopicManger.Visible = false;
                        TopicAdd.Visible = false;
                        ColumnsManager.Visible = false;
                        ColumnsAdd.Visible = false;
                        PicChange.Visible = false;
                    }
                    //系统管理员:专题调整、栏目增减、首页大图更换、用户增减
                    else if (Session["Category"].ToString() == "系统管理员")
                    {

                        ArticleList.Visible = false;
                        ArticleAdd.Visible = false;
                        FileManager.Visible = false;
                        FileAdd.Visible = false;
                        ArticleInfo.Visible = false;
                        ArticleManager.Visible = false;
                        ArticleNo.Visible = false;
                        ArticleCount.Visible = false;
                        AdminManager.Visible = true;
                        AdminAdd.Visible = true;
                        TopicManger.Visible = true;
                        TopicAdd.Visible = true;
                        ColumnsManager.Visible = true;
                        ColumnsAdd.Visible = true;
                        PicChange.Visible = true;

                    }
                }
            }
        }
    }
}