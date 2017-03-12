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
    public partial class stuplaza_newsDetail : System.Web.UI.Page
    {
        ArticleBLL bll = new ArticleBLL();
        public T_stuplazaArticle model { get; set; }
        public string aAnnex { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["articleid"] != "" || Request["articleid"] != null)
            {
                string id = Context.Request["articleid"];

                model = bll.GetArticleById(id);
                if (model.ArticleCategory == 0)
                {
                    Response.Redirect("error.html");
                }

                if (model.ArticleAnnexAddr != "")
                {

                    string[] pathUrl = bll.GetAnnexAddrByAnnex(model.ArticleAnnexAddr);
                    string[] sp = null;
                    if (model.ArticleAnnexAddr.IndexOf(',') > 0)
                        sp = model.ArticleAnnexAddr.Split(',');
                    else
                        sp = new string[] { model.ArticleAnnexAddr };
                    aAnnex = GenerateATagByAnnex(pathUrl, sp);

                }


            }
            else
            { Response.Redirect("error.html"); }
        }
        //生成a标签
        public string GenerateATagByAnnex(string[] path, string[] sp)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < path.Length; i++)
            {
                sb.AppendFormat("<a href='{0}' target='_blank'>{1}</a>", path[i], sp[i]);
            }
            return sb.ToString();
        }
    }
}