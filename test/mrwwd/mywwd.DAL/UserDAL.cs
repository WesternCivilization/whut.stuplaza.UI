using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.MODEL;
using mrwwd.COMMON;

namespace mrwwd.DAL
{
    public class UserDAL
    {
        // 通过微信openid获得model
        public DataTable GetUserByOpenId(string openId)
        {
            string strSql = "select * from T_user where C_UserOpenId=@openId";
            SqlParameter[] sp = { new SqlParameter("@openId", openId) };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }
        public DataTable GetAllUser()
        {
            string strSql = "select * from T_user";
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text);
        }


        





        // 更新用户信息
        public bool UpdateUser(T_user model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update T_user set ");
            sb.Append("C_UserName=@name, ");
            sb.Append("C_UserPhone=@phone, ");
            sb.Append("C_UserPlaceId=@placeId, ");
            sb.Append("C_UserTotalRightNum=@totalRightNum, ");
            sb.Append("C_UserTodayRightNum=@todayRightNum, ");
            sb.Append("C_UserAccuracy=@accuracy, ");
            sb.Append("C_UserAnswerDays=@answerDays, ");
            sb.Append("C_UserLastLogin=@lastLogin, ");
            sb.Append("C_UserFirstLogin=@firstLogin, ");
            sb.Append("C_UserRanking=@ranking, ");
            sb.Append("C_UserTotalAnswerNum=@totalAnswerNum ");
            sb.Append("where C_UserOpenId=@openId");


            SqlParameter[] sp =
            {
                new SqlParameter("@name",model.C_UserName),
                new SqlParameter("@phone",model.C_UserPhone),
                new SqlParameter("@placeId",model.C_UserPlaceId),
                new SqlParameter("@totalRightNum",model.C_UserTotalRightNum),
                new SqlParameter("@todayRightNum",model.C_UserTodayRightNum),
                new SqlParameter("@accuracy",model.C_UserAccuracy),
                new SqlParameter("@answerDays",model.C_UserAnswerDays),
                new SqlParameter("@lastLogin",model.C_UserLastLogin),
                new SqlParameter("@firstLogin",model.C_UserFirstLogin),
                new SqlParameter("@ranking",model.C_UserRanking),
                new SqlParameter("@totalAnswerNum",model.C_UserTotalAnswerNum),
                new SqlParameter("@openId",model.C_UserOpenId)
            };
            int flag = SqlHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, sp);
            if(flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 用户注册
        public int UserRegister(T_user model)
        {
            string strSql = "insert into T_user(C_UserOpenId,C_UserName,C_UserPhone,C_UserPlaceId,C_UserFirstLogin,C_UserTotalRightNum,C_UserTotalAnswerNum,C_UserAnswerDays) values(@openId,@userName,@phoneNumber,@placeId,@firstLogin,@totalRightNum,@totalAnswerNum,@userAnswerDays)";
            SqlParameter[] sp =
            {
                new SqlParameter("@openId",model.C_UserOpenId),
                new SqlParameter("@userName",model.C_UserName),
                new SqlParameter("@phoneNumber",model.C_UserPhone),
                new SqlParameter("@placeId",model.C_UserPlaceId),
                new SqlParameter("@firstLogin",model.C_UserFirstLogin),
                new SqlParameter("@totalRightNum",model.C_UserTotalRightNum),
                new SqlParameter("@totalAnswerNum",model.C_UserTotalAnswerNum),
                new SqlParameter("@userAnswerDays",model.C_UserAnswerDays)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }


        // 根据答对题数获取排名（查询比特定数目大的人数）
        public int GetRankingByTotalRightNum (int totalRightNum)
        {
            string strSql = "select count(*) from T_user where C_UserTotalRightNum > @totalRightNum";
            SqlParameter[] sp =
            {
                new SqlParameter("@totalRightNum",totalRightNum)
            };
            int ranking = ((int)SqlHelper.ExecuteScalar(strSql, CommandType.Text, sp)) + 1;
            return ranking;
        }

        // 根据openId获取用户答题天数
        public int GetUserAnswerDays(string openId)
        {
            string strSql = "select C_UserAnswerDays from T_user where C_UserOpenId=@openId";
            SqlParameter[] sp =
            {
                new SqlParameter("@openId",openId)
            };
            return (int)SqlHelper.ExecuteScalar(strSql, CommandType.Text, sp);
        }
    }
}
