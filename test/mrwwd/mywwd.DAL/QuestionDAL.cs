using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.MODEL;
using mrwwd.COMMON;

namespace mrwwd.DAL
{
    public class QuestionDAL
    {
        // 根据id获取题目
        public T_question GetQuestionById(string id)
        {
            T_question model = new T_question();
            string strSql = "select * from T_question where C_QuestionId=@id";
            SqlParameter[] sp = { new SqlParameter("@id", id) };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;
        }

        // 数据行转换为问题类实体
        public T_question DataRowToModel(DataRow row)
        {
            T_question model = new T_question();
            if (row != null)
            {
                if (row["C_QuestionId"] != null && row["C_QuestionId"].ToString() != "")
                {
                    model.C_QuestionId = row["C_QuestionId"].ToString();
                }
                if (row["C_QuestionInfo"] != null && row["C_QuestionInfo"].ToString() != "")
                {
                    model.C_QuestionInfo = row["C_QuestionInfo"].ToString();
                }
                if (row["C_QuestionCategory"] != null && row["C_QuestionCategory"].ToString() != "")
                {
                    model.C_QuestionCategory = (int)row["C_QuestionCategory"];
                }
                if (row["C_QuestionOptionA"] != null && row["C_QuestionOptionA"].ToString() != "")
                {
                    model.C_QuestionOptionA = row["C_QuestionOptionA"].ToString();
                }
                if (row["C_QuestionOptionB"] != null && row["C_QuestionOptionB"].ToString() != "")
                {
                    model.C_QuestionOptionB = row["C_QuestionOptionB"].ToString();
                }
                if (row["C_QuestionOptionC"] != null && row["C_QuestionOptionC"].ToString() != "")
                {
                    model.C_QuestionOptionC = row["C_QuestionOptionC"].ToString();
                }
                if (row["C_QuestionOptionD"] != null && row["C_QuestionOptionD"].ToString() != "")
                {
                    model.C_QuestionOptionD = row["C_QuestionOptionD"].ToString();
                }
                if (row["C_QuestionAnswer"] != null && row["C_QuestionAnswer"].ToString() != "")
                {
                    model.C_QuestionAnswer = row["C_QuestionAnswer"].ToString();
                }
                if (row["C_QuestionPublishTime"] != null && row["C_QuestionPublishTime"].ToString() != "")
                {
                    model.C_QuestionPublishTime = row["C_QuestionPublishTime"].ToString();
                }
                if (row["C_QuestionStatus"] != null && row["C_QuestionStatus"].ToString() != "")
                {
                    model.C_QuestionStatus = (int)row["C_QuestionStatus"];
                }
            }
            return model;
        }

        // 根据日期获取题目
        public T_question GetQuestionByDate(string date)
        {
            T_question model = new T_question();
            string strSql = "select * from T_question where C_QuestionPublishTime=@date";
            SqlParameter[] sp = { new SqlParameter("@date", date) };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;
        }

        // 根据类别以及id获取题目
        public T_question GetQuestionByCategoryAndId(string category,string id)
        {
            T_question model = new T_question();
            string strSql = "select * from T_question where C_QuestionCategory=@category,C_QuestionId=id";
            SqlParameter[] sp =
            {
                new SqlParameter("@category",category),
                new SqlParameter("@id",id)
            };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;
        }







        // 根据问题类别及问题状态获取问题  可得到类型1/2/3/4的题目中 未答过的问题/已答问题/今日问题
        public DataTable GetQuestionModelListByCategoryAndStatus(int category,int questionStatus)
        {
            string strSql = "select * from T_question where C_QuestionCategory=@category and C_QuestionStatus=@questionStatus order by C_QuestionId";   // !!! 多个条件用 , 隔开？？
            SqlParameter[] sp =
            {
                new SqlParameter("@category",category),
                new SqlParameter("@questionStatus",questionStatus)
            };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }

        // 根据题目id更改题目状态
        public int UpdateQuestionStatus(string questionId,int questionStatus)
        {
            string strSql = "update T_question set C_QuestionStatus=@questionStatus,C_QuestionPublishTime=@publishTime where C_QuestionId=@questionId";
            SqlParameter[] sp =
            {
                new SqlParameter("@questionId",questionId),
                new SqlParameter("@questionStatus",questionStatus),
                new SqlParameter("@publishTime",DateTime.Now.ToString("yyyy-MM-dd"))
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }

        // 根据题目id以及系统时间更改题目的发布时间
        public int UpdateQuestionPublishTime(string questionId,string publishTime)
        {
            string strSql = "update T_question set C_QuestionPublishTime=@publishTime where C_QuestionId=@questionId";
            SqlParameter[] sp =
            {
                new SqlParameter("@publishTime",publishTime),
                new SqlParameter("@questionId",questionId)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }

        // 根据所有发布时间获取历史题库日期列表   !!!
        public DataTable GetHistoryQuestionListByAllPublishTime()
        {
            string strSql = "select distinct C_QuestionPublishTime from T_question order by C_QuestionPublishTime";
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text);
        }

        // 根据历史日期获取该日期的所有题目
        public DataTable GetHistoryQuestionByPublishTime(string publishTime)
        {
            string strSql = "select * from T_question where C_QuestionPublishTime=@publishTime order by C_QuestionCategory";
            SqlParameter[] sp =
            {
                new SqlParameter("@publishTime",publishTime)
            };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }

        // 根据状态变更状态  （3变1）
        public int UpdateStatusByStatus(int iniStatus,int tarStatus)
        {
            string strSql = "update T_question set C_QuestionStatus=@tarStatus where C_QuestionStatus=@iniStatus";
            SqlParameter[] sp =
            {
                new SqlParameter("@tarStatus",tarStatus),
                new SqlParameter("@iniStatus",iniStatus)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }

        
    }
}
