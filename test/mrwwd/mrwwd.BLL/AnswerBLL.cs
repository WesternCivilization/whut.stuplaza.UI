using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.MODEL;
using mrwwd.COMMON;
using mrwwd.DAL;
using System.Data.SqlClient;
using System.Data;

namespace mrwwd.BLL
{
    public class AnswerBLL
    {
        public AnswerDAL answerDAL = new AnswerDAL();
        // 提交回答的数据
        public bool InsertAnswer(T_answer model)
        {
            int result = answerDAL.InsertAnswer(model);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 根据题目id以及用户openId获得用户对于该题目的答案
        public string GetUserAnswerByQuestionIdAndOpenId(string questionId, string openId)
        {
            AnswerDAL answerDAL = new AnswerDAL();
            return answerDAL.GetUserAnswerByQuestionIdAndOpenId(questionId, openId);
        }

        // 根据 openId 和 题目日期 查找做题记录
        public DataTable GetAnswerByOpenIdAndDate(string openId, string date)
        {
            AnswerDAL dal = new AnswerDAL();
            return dal.GetAnswerByOpenIdAndDate(openId, date);
        }
    }
}
