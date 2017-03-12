using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.MODEL;
using mrwwd.COMMON;
using System.Data.SqlClient;
using System.Data;

namespace mrwwd.DAL
{
    public class AnswerDAL
    {

        // 插入一条答案数据
        public int InsertAnswer(T_answer model)
        {
            string strSql = "insert into T_answer values(@C_AnswerOpenId,@C_AnswerQuestionId,@C_AnswerDate,@C_AnswerStatus,@C_AnswerUserAnswer)";
            SqlParameter[] sp =
            {
                new SqlParameter("@C_AnswerOpenId",model.C_AnswerOpenId),
                new SqlParameter("@C_AnswerQuestionId",model.C_AnswerQuestionId),
                new SqlParameter("@C_AnswerDate",model.C_AnswerDate),
                new SqlParameter("@C_AnswerStatus",model.C_AnswerStatus),
                new SqlParameter("@C_AnswerUserAnswer",model.C_AnswerUserAnswer)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }

        // 根据题目id以及用户openId获得用户对于该题目的答案
        public string GetUserAnswerByQuestionIdAndOpenId(string questionId, string openId)
        {
            string strSql = "select C_AnswerUserAnswer from T_answer where C_AnswerQuestionId=@questionId and C_AnswerOpenId=@openId";
            SqlParameter[] sp =
            {
                new SqlParameter("@questionId",questionId),
                new SqlParameter("@openId",openId)
            };
            return (string)SqlHelper.ExecuteScalar(strSql, CommandType.Text, sp);
        }

        // 根据 openId 和 题目日期 查找做题记录
        public DataTable GetAnswerByOpenIdAndDate(string openId,string date)
        {
            string strSql = "select * from T_answer where C_AnswerOpenId=@openId and C_AnswerDate=@date";
            SqlParameter[] sp =
            {
                new SqlParameter("@openId",openId),
                new SqlParameter("@date",date)
            };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }
    }
}
