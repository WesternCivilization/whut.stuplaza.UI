using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.stuplaza.MODEL;
 


namespace whut.stuplaza.COMMON
{
   public class ArticlePageHander
    {
       private static string conStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="pageIndex">传入的当前页面的值</param>
        /// <param name="pageSize">传入页面的记录</param>
        /// <param name="total">查处一共多少条数据</param>
        /// <returns></returns>
        /// 
        public  System.Collections.Generic.List<T_stuplazaArticle> LoadPageData(int pageIndex, int pageSize, out int total)
        {
           
            DataSet ds = new DataSet();

            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            //DbHelperSQL.RunProcedure()


            //如果用了输出参数，那么就用SqlDataAdapter就可以了，用sqlDataReader时候拿不到输出参数的值。
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("LoadArticleData", conn))
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pageIndex", pageIndex));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", pageSize));

                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //输出参数的用法
                    adapter.SelectCommand.Parameters.Add(totalParameter);

                    adapter.Fill(ds);
                }
            }
            total = (int)totalParameter.Value;//拿到输出参数的值

            return this.DataTableToList(ds.Tables[0]);

        }

       //根据栏目id获取分页文章list集合
        public List<T_stuplazaArticle> LoadPageDataByColumn(int pageIndex, int pageSize, string columnId,out int total)
        {
            DataSet ds = new DataSet();

            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            //DbHelperSQL.RunProcedure()


            //如果用了输出参数，那么就用SqlDataAdapter就可以了，用sqlDataReader时候拿不到输出参数的值。
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("LoadArticleDataByCol", conn))
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pageIndex", pageIndex));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", pageSize));
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@columnId",columnId));
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //输出参数的用法
                    adapter.SelectCommand.Parameters.Add(totalParameter);

                    adapter.Fill(ds);
                }
            }
            total = (int)totalParameter.Value;//拿到输出参数的值

            return this.DataTableToList(ds.Tables[0]);
        }



        /// <summary>
        /// 把datatable转换成装model对象的泛型集合
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<T_stuplazaArticle> DataTableToList(DataTable dt)
        {
            List<T_stuplazaArticle> modelList = new List<T_stuplazaArticle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                T_stuplazaArticle model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new T_stuplazaArticle();
                    if (dt.Rows[n]["C_ArticleId"].ToString() != "")
                    {
                        model.ArticleId =dt.Rows[n]["C_ArticleId"].ToString();
                    }
                    model.ArticleTitle = dt.Rows[n]["C_ArticleTitle"].ToString();
                    model.ArticleCategory = int.Parse(dt.Rows[n]["C_ArticleCategory"].ToString());
                    model.ArticleSector = dt.Rows[n]["C_ArticleSector"].ToString();
                    T_stuplazaTopic top = new T_stuplazaTopic();
                    if (dt.Rows[n]["C_ArticleTopic"].ToString() != ""&&dt.Rows[n]["C_ArticleTopic"]!=null)
                    {
                        top.TopicId = int.Parse(dt.Rows[n]["C_ArticleTopic"].ToString());
                    }
                    model.topic = top;
                    model.ArticleContent = dt.Rows[n]["C_ArticleContent"].ToString();
                    model.ArticlePostStaff = dt.Rows[n]["C_ArticlePostStaff"].ToString();
                    model.ArticleAnnexAddr = dt.Rows[n]["C_ArticleAnnexAddr"].ToString();
                    if (dt.Rows[n]["C_ArticleTime"] != null&&dt.Rows[n]["C_ArticleTime"].ToString()!="")
                    {
                        DateTime time = DateTime.Parse(dt.Rows[n]["C_ArticleTime"].ToString());
                        model.ArticleTime = time.ToString("yyyy-MM-dd");
                        //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
                    }
                    if (dt.Rows[n]["C_ArticleColumn"] != null && dt.Rows[n]["C_ArticleColumn"].ToString() != "")
                    {
                        model.ArticleColumn = dt.Rows[n]["C_ArticleColumn"].ToString();
                    }

                    modelList.Add(model);
                }

            }
            return modelList;
        }
    }
}
