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
    public class UserBLL
    {
        // 更新用户信息 手机 姓名 地点等
        public bool UpdateUser(T_user model)
        {
            UserDAL dal = new UserDAL();
            return dal.UpdateUser(model);
        }

        // 通过openId获取用户信息 如果返回的DateTable的数据行为0则没有数据 >0则有数据
        public List<T_user> GetUserInfoByOpenId(string openId)
        {
            UserDAL dal = new UserDAL();
            return DateTableToList(dal.GetUserByOpenId(openId));
        }

        public List<T_user> DateTableToList(DataTable dt)
        {
            List<T_user> list = new List<T_user>();
            T_user model = new T_user();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["C_UserOpenId"] != null && dt.Rows[i]["C_UserOpenId"].ToString() != "")
                    {
                        model.C_UserOpenId = dt.Rows[i]["C_UserOpenId"].ToString();
                    }
                    if (dt.Rows[i]["C_UserName"] != null && dt.Rows[i]["C_UserName"].ToString() != "")
                    {
                        model.C_UserName = dt.Rows[i]["C_UserName"].ToString();
                    }
                    if (dt.Rows[i]["C_UserPhone"] != null && dt.Rows[i]["C_UserPhone"].ToString() != "")
                    {
                        model.C_UserPhone = dt.Rows[i]["C_UserPhone"].ToString();
                    }
                    if (dt.Rows[i]["C_UserPlaceId"] != null && dt.Rows[i]["C_UserPlaceId"].ToString() != "")
                    {
                        model.C_UserPlaceId = dt.Rows[i]["C_UserPlaceId"].ToString();
                    }
                    if (dt.Rows[i]["C_UserTotalRightNum"] != null && dt.Rows[i]["C_UserTotalRightNum"].ToString() != "")
                    {
                        model.C_UserTotalRightNum = (int)dt.Rows[i]["C_UserTotalRightNum"];
                    }
                    if (dt.Rows[i]["C_UserTodayRightNum"] != null && dt.Rows[i]["C_UserTodayRightNum"].ToString() != "")
                    {
                        model.C_UserTodayRightNum = (int)dt.Rows[i]["C_UserTodayRightNum"];
                    }
                    if (dt.Rows[i]["C_UserAccuracy"] != null && dt.Rows[i]["C_UserAccuracy"].ToString() != "")
                    {
                        model.C_UserAccuracy = dt.Rows[i]["C_UserAccuracy"].ToString();
                    }
                    if (dt.Rows[i]["C_UserAnswerDays"] != null && dt.Rows[i]["C_UserAnswerDays"].ToString() != "")
                    {
                        model.C_UserAnswerDays = (int)dt.Rows[i]["C_UserAnswerDays"];
                    }
                    if (dt.Rows[i]["C_UserLastLogin"] != null && dt.Rows[i]["C_UserLastLogin"].ToString() != "")
                    {
                        model.C_UserLastLogin = dt.Rows[i]["C_UserLastLogin"].ToString();
                    }
                    if (dt.Rows[i]["C_UserFirstLogin"] != null && dt.Rows[i]["C_UserFirstLogin"].ToString() != "")
                    {
                        model.C_UserFirstLogin = dt.Rows[i]["C_UserFirstLogin"].ToString();
                    }
                    if (dt.Rows[i]["C_UserRanking"] != null && dt.Rows[i]["C_UserRanking"].ToString() != "")
                    {
                        model.C_UserRanking = (int)dt.Rows[i]["C_UserRanking"];
                    }
                    if (dt.Rows[i]["C_UserTotalAnswerNum"] != null && dt.Rows[i]["C_UserTotalAnswerNum"].ToString() != "")
                    {
                        model.C_UserTotalAnswerNum = (int)dt.Rows[i]["C_UserTotalAnswerNum"];
                    }
                    list.Add(model);
                }
            }
            return list;
        }


        // 注册用户
        public bool UserRegister(T_user model)
        {
            UserDAL dal = new UserDAL();
            if (dal.UserRegister(model) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 根据答对题数获取排名
        public int GetRankingByTotalRightNum(int totalRightNum)
        {
            UserDAL dal = new UserDAL();
            return dal.GetRankingByTotalRightNum(totalRightNum);
        }

        // 根据openId获取用户答题天数
        public int GetUserAnswerDays(string openId)
        {
            UserDAL dal = new UserDAL();
            return dal.GetUserAnswerDays(openId);
        }
    }
}
