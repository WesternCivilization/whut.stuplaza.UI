using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whut.stuplaza.COMMON;
using whut.stuplaza.MODEL;

namespace whut.stuplaza.DAL
{
  public class MenuScriptDAL
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model">传入model类</param>
        /// <returns></returns>
        public int Insert(T_stuplazaManuScript model)
        {
            //C_ManuScriptId, C_ManuScriptTitle, C_ManuScriptContent, C_ManuScriptAcademy, C_ManuScriptAuthor, C_ManuScriptTel, C_ManuScriptEmail, C_ManuScriptReviewer, C_ManuScriptStatus
            string sql = "insert into T_stuplazaManuScript values(@id,@title,@content,@academy,@author,@tel,@email,@reviewer,@status,@time)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@id",model.ManuScriptId),
            new SqlParameter("@title",model.ManuScriptTitle),
            new SqlParameter("@content",model.ManuScriptContent),
            new SqlParameter("@academy",model.ManuScriptAcademy),
            new SqlParameter("@author",model.ManuScriptAuthor),
            new SqlParameter("@tel",model.ManuScriptTel),
            new SqlParameter("@email",model.ManuScriptEmail),
            new SqlParameter("@reviewer",model.ManuScriptReviewer),
            new SqlParameter("@status",model.ManuScriptStatus),
            
            new SqlParameter("@time",model.ManuScriptTime)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);

        }
      /// <summary>
      /// 更新一条数据
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
        public bool Update(T_stuplazaManuScript model)
        {
            //C_ManuScriptId, C_ManuScriptTitle, C_ManuScriptContent, C_ManuScriptAcademy, C_ManuScriptAuthor, C_ManuScriptTel, C_ManuScriptEmail, C_ManuScriptReviewer, C_ManuScriptStatus
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_stuplazaManuScript set ");
            strSql.Append("C_ManuScriptId=@id,");
            strSql.Append("C_ManuScriptTitle=@title,");
            strSql.Append("C_ManuScriptContent=@content,");
            strSql.Append("C_ManuScriptAcademy=@academy,");
            strSql.Append("C_ManuScriptAuthor=@author,");
            strSql.Append("C_ManuScriptTel=@tel,");
            strSql.Append("C_ManuScriptEmail=@email,");
            strSql.Append("C_ManuScriptReviewer=@reviewer,");
            strSql.Append("C_ManuScriptStatus=@status,");
            strSql.Append("C_ManuScriptTime=@time");
            strSql.Append(" where C_ManuScriptId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id",model.ManuScriptId),
					new SqlParameter("@title",model.ManuScriptTitle),
					new SqlParameter("@content",model.ManuScriptContent),
					new SqlParameter("@academy",model.ManuScriptAcademy),
					new SqlParameter("@author",model.ManuScriptAuthor),
					new SqlParameter("@tel",model.ManuScriptTel),
					new SqlParameter("@email",model.ManuScriptEmail),
					new SqlParameter("@reviewer",model.ManuScriptReviewer),
                    new SqlParameter("@status",model.ManuScriptStatus),
                    new SqlParameter("@time",model.ManuScriptTime )};
           
            int flag = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      //删除一条数据
        public bool Delete(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaManuScript ");
            strSql.Append("where C_ManuScriptId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Char,11)
			};
            parameters[0].Value = id;
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text,parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaManuScript ");
            strSql.Append(" where C_ManuScriptId in (" + idlist + ")  ");
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


      ///获取数据
        public List<T_stuplazaManuScript> GetList()
        {
            string sql="select * from T_stuplazaManuScript order by C_ManuScriptTime desc";
            return DataTableToList(SqlHelper.ExecuteDataTable(sql, CommandType.Text));
        }


       ///datatabletolist
       public List<T_stuplazaManuScript> DataTableToList(DataTable tb)
       {
           List<T_stuplazaManuScript> list=new List<T_stuplazaManuScript>();
           if(tb.Rows.Count>0)
           {
               for(int i=0;i<tb.Rows.Count;i++)
               {
                    T_stuplazaManuScript model = new T_stuplazaManuScript();
                     if (tb.Rows[i]["C_ManuScriptId"] != null &&tb.Rows[i]["C_ManuScriptId"].ToString() != "")
                {
                    model.ManuScriptId =tb.Rows[i]["C_ManuScriptId"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptTitle"] != null)
                {
                    model.ManuScriptTitle = tb.Rows[i]["C_ManuScriptTitle"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptContent"] != null)
                {
                    model.ManuScriptContent=tb.Rows[i]["C_ManuScriptContent"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptAcademy"] != null)
                {
                    model.ManuScriptAcademy = tb.Rows[i]["C_ManuScriptAcademy"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptAuthor"] != null)
                {
                    model.ManuScriptAuthor =tb.Rows[i]["C_ManuScriptAuthor"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptTel"] != null && tb.Rows[i]["C_ManuScriptTel"].ToString() != "")
                {
                    model.ManuScriptTel=tb.Rows[i]["C_ManuScriptTel"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptEmail"] != null && tb.Rows[i]["C_ManuScriptEmail"].ToString() != "")
                {
                    model.ManuScriptEmail=tb.Rows[i]["C_ManuScriptEmail"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptReviewer"]!= null)
                {
                    model.ManuScriptReviewer =tb.Rows[i]["C_ManuScriptReviewer"].ToString();
                }
                if (tb.Rows[i]["C_ManuScriptStatus"] != null)
                {
                    model.ManuScriptStatus=int.Parse(tb.Rows[i]["C_ManuScriptStatus"].ToString());
                }
                if(tb.Rows[i]["C_ManuScriptTime"]!=null)
                {
                    DateTime time = DateTime.Parse(tb.Rows[i]["C_ManuScriptTime"].ToString());
                    model.ManuScriptTime = time.ToString("yyyy-MM-dd");
                    //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
                }
               
               list.Add(model);
               }
            
           }
            return list;
       }

      //根据id获取model
       public T_stuplazaManuScript GetModelById(string id)
       {
           string sql = "select * from T_stuplazaManuScript where C_ManuScriptId=@id";
           SqlParameter[] ps = { new SqlParameter("@id", id) };
           DataTable tb= SqlHelper.ExecuteDataTable(sql, CommandType.Text, ps);
           T_stuplazaManuScript model = new T_stuplazaManuScript();
           if (tb.Rows[0]["C_ManuScriptId"] != null && tb.Rows[0]["C_ManuScriptId"].ToString() != "")
           {
               model.ManuScriptId = tb.Rows[0]["C_ManuScriptId"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptTitle"] != null)
           {
               model.ManuScriptTitle = tb.Rows[0]["C_ManuScriptTitle"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptContent"] != null)
           {
               model.ManuScriptContent = tb.Rows[0]["C_ManuScriptContent"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptAcademy"] != null)
           {
               model.ManuScriptAcademy = tb.Rows[0]["C_ManuScriptAcademy"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptAuthor"] != null)
           {
               model.ManuScriptAuthor = tb.Rows[0]["C_ManuScriptAuthor"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptTel"] != null && tb.Rows[0]["C_ManuScriptTel"].ToString() != "")
           {
               model.ManuScriptTel = tb.Rows[0]["C_ManuScriptTel"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptEmail"] != null && tb.Rows[0]["C_ManuScriptEmail"].ToString() != "")
           {
               model.ManuScriptEmail = tb.Rows[0]["C_ManuScriptEmail"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptReviewer"] != null)
           {
               model.ManuScriptReviewer = tb.Rows[0]["C_ManuScriptReviewer"].ToString();
           }
           if (tb.Rows[0]["C_ManuScriptStatus"] != null)
           {
               model.ManuScriptStatus = int.Parse(tb.Rows[0]["C_ManuScriptStatus"].ToString());
           }
           if (tb.Rows[0]["C_ManuScriptTime"] != null)
           {
               DateTime time = DateTime.Parse(tb.Rows[0]["C_ManuScriptTime"].ToString());
               model.ManuScriptTime = time.ToString("yyyy-MM-dd hh:mm");
               //model.ArticleTime = Convert.ToDateTime((DateTime.Parse(row["C_ArticleTime"].ToString()).ToShortDateString().ToString()));
           }
           return model;

       }
       //根据日期模糊查询获取编号
       public DataTable GetIdByTime(string dateTime)
       {
           string sql = string.Format("select top(1) *from  T_stuplazaManuScript where (C_ManuScriptId like '{0}%') order by  C_ManuScriptId desc", dateTime);
           return SqlHelper.ExecuteDataTable(sql, CommandType.Text);

       }
      //
       public List<T_stuplazaManuScript> GetListByNum(int num)
       {
           string sql="select top "+num+" * from T_stuplazaManuScript where C_ManuScriptStatus=1 order by C_ManuScriptTime desc";
           return DataTableToList(SqlHelper.ExecuteDataTable(sql, CommandType.Text));
       }


      //分页获取数据为审核数据
       public List<T_stuplazaManuScript> GetListByPage(int pageIndex, int pageSize, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                 totalParameter};

           tb=SqlHelper.ExecuteDataTable("PManuListByPage", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return DataTableToList(tb);
       }
       //获取未审核和审核未通过的数据
       public List<T_stuplazaManuScript> GetListByStatus(int pageIndex, int pageSize, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PManuListByStatus", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return DataTableToList(tb);
       }

      //通过姓名分页获取数据
       public List<T_stuplazaManuScript> GetListByName(int pageIndex, int pageSize,string name, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@name",name),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PManuListByName", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return DataTableToList(tb);
       }
      //通过标题获取分页数据
       public List<T_stuplazaManuScript> GetListByTitle(int pageIndex, int pageSize, string title, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                  new SqlParameter("@title",title),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PManuListByTitle", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return DataTableToList(tb);
       }

      //分页获取已审核数据
       public List<T_stuplazaManuScript> GetListByPageManager(int pageIndex, int pageSize, out int total)
       {
           DataTable tb = new DataTable();
           SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
           totalParameter.Direction = ParameterDirection.Output;
           SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                 totalParameter};

           tb = SqlHelper.ExecuteDataTable("PManuListManager", CommandType.StoredProcedure, sp);
           total = (int)totalParameter.Value;
           return DataTableToList(tb);
       }
      //
       public DataTable GetTableByTime(string begintime, string endtime)
       {
           DataTable tb = new DataTable();
           
           SqlParameter[] sp ={new SqlParameter("@begintime",begintime),
                                  new SqlParameter("@endtime",endtime),
                                };

           tb = SqlHelper.ExecuteDataTable("PCatalogNum", CommandType.StoredProcedure, sp);
           
           return tb;
       }
    }
}
