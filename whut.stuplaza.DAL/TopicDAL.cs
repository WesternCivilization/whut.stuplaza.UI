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
   public class TopicDAL
    {
        //需求:查询所有专题信息
        public DataTable GetAllTopicInfo()
        {
            string sql = "select * from T_stuplazaTopic";
            return  SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        
        }
       //转化datarow为model
        public T_stuplazaTopic DataRowToModel(DataRow row)
        {
            T_stuplazaTopic model = new T_stuplazaTopic();
            if (row != null)
            {
                if (row["C_TopicId"] != null)
                    model.TopicId = int.Parse(row["C_TopicId"].ToString());
                if (row["C_TopicTitle"] != null && row["C_TopicTitle"].ToString() != "")
                    model.TopicTitle = row["C_TopicTitle"].ToString();
                if (row["C_TopicTime"] != null)
                {
                    DateTime time = DateTime.Parse(row["C_TopicTime"].ToString());
                    model.TopicTime = time.ToString("yyyy-MM-dd");
                }
                if (row["C_TopicPriority"] != null)
                    model.TopicPriority = int.Parse(row["C_TopicPriority"].ToString());
                if (row["C_TopicSummary"] != null)
                    model.TopicSummary = row["C_TopicSummary"].ToString();
                if (row["C_TopicFileName"] != null)
                    model.TopicFileName = row["C_TopicFileName"].ToString();
            
            }
            return model;
        
        }


       //根据id查询专题名称
        public string GetTopicNameById(int id)
        {
            string sql = "select C_TopicTitle from T_stuplazaTopic where C_TopicId=@id";
            SqlParameter[] pms = { new SqlParameter("@id", id) };
            return SqlHelper.ExecuteScalar(sql, CommandType.Text,pms).ToString();
        }
       //根据专题标题获取标题
        public bool GetTopicNameByName(string name)
        {
            string sql = "select C_TopicTitle from T_stuplazaTopic where C_TopicTitle=@name";
            SqlParameter[] pms = { new SqlParameter("@name", name)};
            int flag = SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text,pms);
            if (flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetListByTotal(int total)
        {
            string sql = "select top " + total + " * from T_stuplazaTopic order by C_TopicPriority";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        public DataTable GetListByPriority(int total)
        {
            string sql = "select top " + total + " * from T_stuplazaTopic order by C_TopicPriority,C_TopicTime desc";
            return SqlHelper.ExecuteDataTable(sql, CommandType.Text);
        }
        public DataTable GetListByCategory(int pageIndex, int pageSize, out int total)
        {
            DataTable tb = new DataTable();
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            SqlParameter[] sp ={new SqlParameter("@pageIndex",pageIndex),
                                  new SqlParameter("@pageSize",pageSize),
                                 totalParameter};

            tb = SqlHelper.ExecuteDataTable("PTopicListByPage", CommandType.StoredProcedure, sp);
            total = (int)totalParameter.Value;
            return tb;

        }


        //插入一条数据
        public int Insert(T_stuplazaTopic model) { 
            // C_TopicId, C_TopicTitle, C_TopicTime, C_TopicPriority, C_TopicSummary, C_TopicFileName
            string sql = "insert into T_stuplazaTopic(C_TopicTitle, C_TopicTime, C_TopicPriority, C_TopicSummary, C_TopicFileName) values(@title,@time,@Priority,@summary,@filename)";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@title",model.TopicTitle),
            new SqlParameter("@time",model.TopicTime),
            new SqlParameter("@priority",model.TopicPriority),
            new SqlParameter("@summary",model.TopicSummary),
            new SqlParameter("@filename",model.TopicFileName),
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);        
        } 

        //修改数据
        public bool Update(T_stuplazaTopic model)
        {  //C_TopicId, C_TopicTitle, C_TopicTime, C_TopicPriority, C_TopicSummary, C_TopicFileName
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_stuplazaTopic set ");
            strSql.Append("C_TopicTitle=@title,");
            strSql.Append("C_TopicTime=@time,");
            strSql.Append("C_TopicPriority=@priority,");
            strSql.Append("C_TopicSummary=@summary,");
            strSql.Append("C_TopicFileName=@filename");
            strSql.Append(" where C_TopicId=@id"); 
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@time", SqlDbType.DateTime),
					new SqlParameter("@priority", SqlDbType.Int),
					new SqlParameter("@summary", SqlDbType.NVarChar,100),
					new SqlParameter("@filename", SqlDbType.NVarChar,200),
                    new SqlParameter("@id", SqlDbType.Int)};
            
            parameters[0].Value = model.TopicTitle;
            parameters[1].Value = model.TopicTime;
            parameters[2].Value = model.TopicPriority;
            parameters[3].Value = model.TopicSummary;
            parameters[4].Value = model.TopicFileName;
            parameters[5].Value = model.TopicId;
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

       //删除数据
        public bool Delete(string id) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_stuplazaTopic");
            strSql.Append(" where C_TopicId=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int)
			};
            parameters[0].Value = id;
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update T_stuplazaArticle set ");
            updateSql.Append("C_ArticleTopic=null ");
            updateSql.Append("where C_ArticleTopic=@topicId");
            SqlParameter[]  pma = { new SqlParameter("@topicId",SqlDbType.Int)};
            pma[0].Value = id;
            int flag=SqlHelper.ExecuteNonQuery(updateSql.ToString(),CommandType.Text,pma);
            int rows = SqlHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //根据Id得到专题
        public T_stuplazaTopic GetTopicById(string id)
        {
            SqlParameter[] sp = { new SqlParameter("@id", id) };
            string sql = "select * from T_stuplazaTopic where C_TopicId=@id";
            T_stuplazaTopic model = new T_stuplazaTopic();
            DataTable tb = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;
        }
    
         
    }
}
