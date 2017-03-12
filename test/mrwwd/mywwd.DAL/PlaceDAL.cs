using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mrwwd.COMMON;
using mrwwd.MODEL;

namespace mrwwd.DAL
{
    public class PlaceDAL
    {
        // 转化DataRow到地点实体
        public T_place DataRowToModel(DataRow row)
        {
            T_place model = new T_place();
            if (row != null)
            {
                if (row["C_PlaceId"] != null && row["C_PlaceId"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlaceId"].ToString();
                }
                if (row["C_PlaceName"] != null && row["C_PlaceName"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlaceName"].ToString();
                }
                if (row["C_PlaceParent"] != null && row["C_PlaceParent"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlaceParent"].ToString();
                }
                if (row["C_PlacePersonNum"] != null && row["C_PlacePersonNum"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlacePersonNum"].ToString();
                }
                if (row["C_PlaceQuestionAnsweredNum"] != null && row["C_PlaceQuestionAnsweredNum"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlaceQuestionAnsweredNum"].ToString();
                }
                if (row["C_PlaceAccuracy"] != null && row["C_PlaceAccuracy"].ToString() != "")
                {
                    model.C_PlaceId = row["C_PlaceAccuracy"].ToString();
                }
                if (row["C_PlaceTotalRightNum"] != null && row["C_PlaceTotalRightNum"].ToString() != "")
                {
                    model.C_PlaceTotalRightNum = (int)row["C_PlaceTotalRightNum"];
                }
                
            }
            return model;
        }


        // 根据地点ID获取地方答题数据
        public T_place GetPlaceById (string id)
        {
            SqlParameter[] sp = { new SqlParameter("@id", id) };
            string strSql = "select * from T_place where C_PlaceId=@id";
            T_place model = new T_place();
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if(tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;

        }

        // 根据地名获取地方数据 县
        public T_place GetCountyByPlaceName(string placeName)
        {
            SqlParameter[] sp = { new SqlParameter("@PlaceName", placeName) };
            string strSql = "select * from T_place where C_PlaceName=@placeName";
            T_place model = new T_place();
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                model = DataRowToModel(tb.Rows[0]);
            }
            return model;

        }

        //// 根据地区名查询地方数据 市
        //public DataTable GetCityByPlaceName(string placeId)
        //{
        //    SqlParameter[] sp = { new SqlParameter("@placeId", placeId) };
        //    string strSql = "select * from T_place inner union T_user on T_place.C_PlaceId = T_user.C_UserPlaceId";
        //    return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        //}

        // 根据父节点获取子节点
        public DataTable GetDataTableByParent(string parent)
        {
            string strSql = "select * from T_place where C_PlaceParent=@parent";
            SqlParameter[] sp = { new SqlParameter("@parent", parent) };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }

        // 根据地区名更新地区答题人数
        public bool UpdateTotalPeople(string placeName, int personNum)
        {
            string strSql = "update T_place set C_PlacePersonNum=@personNum where C_PlaceName=@placeName";
            SqlParameter[] sp =
            {
                 new SqlParameter("@personNum", personNum),
                 new SqlParameter("@placeName",placeName)
            };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 根据地区名以及总题数更新地区正确总题数
        public int UpdateRightNum(string placeName, int TotalRightNum)
        {
            string strSql = "update T_place set C_PlaceTotalRightNum=@TotalRightNum where C_PlaceName=@placeName";
            SqlParameter[] sp =
            {
                 new SqlParameter("@TotalRightNum", TotalRightNum),
                 new SqlParameter("@placeName",placeName)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);            
        }

        // 根据地区名以及总人数更新地区总人数
        public int UpdatePersonNum(string placeName,int personNum)
        {
            string strSql = "update T_place set C_PlacePersonNum=@personNum where C_PlaceName=@placeName";
            SqlParameter[] sp =
            {
                new SqlParameter("@personNum",personNum),
                new SqlParameter("@placeName",placeName)
            };
            return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        }

        //// 更新地区答对题目总数
        //public int UpdateRightNum(string placeName,int rightNum)
        //{
        //    string strSql = "update T_place set C_PlaceRightNum=@rightNum where C_PlaceName=@placeName";
        //    SqlParameter[] sp =
        //    {
        //        new SqlParameter("@rightNum",rightNum),
        //        new SqlParameter("@placeName",placeName)
        //    };
        //    return SqlHelper.ExecuteNonQuery(strSql, CommandType.Text, sp);
        //}

        // 通过PlaceId获取答题总数 县
        public DataTable GetTotalAnswersByPlaceId(string placeId)
        {
            string strSql = "select * from T_user where C_UserPlaceId=@placeId";
            SqlParameter[] sp = { new SqlParameter("@placeId", placeId) };
            return SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
        }





        // 获取地方答题人数
        public int GetCountyUserNumByPlaceId(string placeId)
        {
            string strSql = "select * from T_user where C_UserPlaceId=@placeId";
            SqlParameter[] sp = { new SqlParameter("@placeId", placeId) };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            return tb.Rows.Count;
        }

        // 获取市级答题人数
        public int GetCityUserNumByPlaceId(string placeId)
        {
            // 用户表联合地方表查询某个城市下的总用户数
            string strSql = "select * from T_user inner join T_place on T_user.@placeId=T_place.@placeId";
            SqlParameter[] sp = { new SqlParameter("@placeId", placeId) };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            return tb.Rows.Count;

        }

        // 获取地方总答题正确的数目   ????
        public int GetPlaceNumOfCorrectAns(string placeName)
        {
            string strSql = "select * from T_user inner join T_place on T_user.@placeName=T_place.@placeName";
            SqlParameter[] sp = { new SqlParameter("@placeName", placeName) };
            DataTable tb = SqlHelper.ExecuteDataTable(strSql, CommandType.Text, sp);
            return tb.Rows.Count;
        }

    }
}
