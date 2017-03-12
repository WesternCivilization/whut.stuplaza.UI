using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.MODEL;
using mrwwd.DAL;
using System.Data;

namespace mrwwd.BLL
{
    public class QuestionBLL
    {
        // 根据题目类别以及题目状态按照题目id顺序提取 题目model 
        public List<T_question> GetQuestionModelListByCategoryAndStatus(int category,int questionStatus)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            return DataTableToList(questionDAL.GetQuestionModelListByCategoryAndStatus(category, questionStatus));
        }

        public List<T_question> DataTableToList(DataTable tb)
        {
            List<T_question> list = new List<T_question>();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    T_question model = new T_question();
                    if (tb.Rows[i]["C_QuestionId"] != null && tb.Rows[i]["C_QuestionId"].ToString() != "")
                    {
                        model.C_QuestionId = tb.Rows[i]["C_QuestionId"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionInfo"] != null && tb.Rows[i]["C_QuestionInfo"].ToString() != "")
                    {
                        model.C_QuestionInfo = tb.Rows[i]["C_QuestionInfo"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionCategory"] != null && tb.Rows[i]["C_QuestionCategory"].ToString() != "")
                    {
                        model.C_QuestionCategory = (int)tb.Rows[i]["C_QuestionCategory"];
                    }
                    if (tb.Rows[i]["C_QuestionOptionA"] != null && tb.Rows[i]["C_QuestionOptionA"].ToString() != "")
                    {
                        model.C_QuestionOptionA = tb.Rows[i]["C_QuestionOptionA"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionOptionB"] != null && tb.Rows[i]["C_QuestionOptionB"].ToString() != "")
                    {
                        model.C_QuestionOptionB = tb.Rows[i]["C_QuestionOptionB"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionOptionC"] != null && tb.Rows[i]["C_QuestionOptionC"].ToString() != "")
                    {
                        model.C_QuestionOptionC = tb.Rows[i]["C_QuestionOptionC"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionOptionD"] != null && tb.Rows[i]["C_QuestionOptionD"].ToString() != "")
                    {
                        model.C_QuestionOptionD = tb.Rows[i]["C_QuestionOptionD"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionAnswer"] != null && tb.Rows[i]["C_QuestionAnswer"].ToString() != "")
                    {
                        model.C_QuestionAnswer = tb.Rows[i]["C_QuestionAnswer"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionPublishTime"] != null && tb.Rows[i]["C_QuestionPublishTime"].ToString() != "")
                    {
                        model.C_QuestionPublishTime = tb.Rows[i]["C_QuestionPublishTime"].ToString();
                    }
                    if (tb.Rows[i]["C_QuestionStatus"] != null && tb.Rows[i]["C_QuestionStatus"].ToString() != "")
                    {
                        model.C_QuestionStatus = (int)tb.Rows[i]["C_QuestionStatus"];
                    }
                    
                    list.Add(model);
                }
            }
            return list;
        }

        // 根据题目id修改题目状态
        public bool UpdateQuestionStatus(string questionId,int questionStatus)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            if (questionDAL.UpdateQuestionStatus(questionId,questionStatus) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 根据题目id以及系统时间更改题目发布时间
        public bool UpdateQuestionPublishTime(string questionId,string publishTime)
        {
            QuestionDAL questionDAL = new QuestionDAL();
            if(questionDAL.UpdateQuestionPublishTime(questionId,publishTime) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 根据所有发布时间获取历史题库日期列表  .
        public List<T_question> GetHistoryQuestionListByAllPublishTime()
        {
            QuestionDAL dal = new QuestionDAL();
            return HistoryQuestionTableToList(dal.GetHistoryQuestionListByAllPublishTime());
        }

        public List<T_question> HistoryQuestionTableToList(DataTable dt)
        {
            QuestionDAL dal = new QuestionDAL();
            List<T_question> list = new List<T_question>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T_question model = new T_question();
                    if (dt.Rows[i]["C_QuestionPublishTime"]  != null && dt.Rows[i]["C_QuestionPublishTime"].ToString() !=  "")
                    {
                        model.C_QuestionPublishTime = dt.Rows[i]["C_QuestionPublishTime"].ToString();
                    }
                    list.Add(model);
                }
            }
            return list;
        }

        // 根据单个发布日期获取该日期所有题目    .
        public List<T_question> GetHistoryQuestionByPublishTime(string publishTime)
        {
            QuestionDAL dal = new QuestionDAL();
            return DataTableToList(dal.GetHistoryQuestionByPublishTime(publishTime));
        }

        // 根据状态变更状态
        public bool UpDateStatusByStatus(int iniStatus,int tarStatus)
        {
            QuestionDAL dal = new QuestionDAL();
            if (dal.UpdateStatusByStatus(iniStatus,tarStatus) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
